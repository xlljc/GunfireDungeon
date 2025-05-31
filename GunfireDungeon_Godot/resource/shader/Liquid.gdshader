shader_type canvas_item;

// —— 参数 ——
// 动画帧控制
uniform int   hframes : hint_range(1, 16) = 1;
uniform int   frame   : hint_range(0, 15) = 0;

// 液体贴图的总像素尺寸（整张图，不是单帧）
uniform vec2  origin_size = vec2(256.0, 256.0);

// 遮罩纹理
uniform sampler2D mask : filter_nearest, repeat_enable;

// 透明度
uniform float  alpha : hint_range(0.0, 1.0, 0.01) = 1.0;

// —— 传递像素坐标
varying vec2 pixel_pos;


bool checkLB(vec2 len, sampler2D tex, vec2 uv) {
	int c = 0;
	int c2 = 0;
	if (texture(tex, uv + vec2(-len.x, 0.0)).a > 0.0) {
		c++;
		c2 += 1;
	} else if (texture(tex, uv + vec2(-len.x * 2.0, 0.0)).a > 0.0) {
		c++;
		c2 += 2;
	}
	if (c > 0) {
		if (texture(tex, uv + vec2(0.0, -len.y)).a > 0.0) {
			c++;
			c2 += 1;
		} else if (texture(tex, uv + vec2(0.0, -len.y * 2.0)).a > 0.0) {
			c++;
			c2 += 2;
		}
	}
	return c >= 2 && c2 <= 3;
}

bool checkLT(vec2 len, sampler2D tex, vec2 uv) {
	int c = 0;
	int c2 = 0;
	if (texture(tex, uv + vec2(-len.x, 0.0)).a > 0.0) {
		c++;
		c2 += 1;
	} else if (texture(tex, uv + vec2(-len.x * 2.0, 0.0)).a > 0.0) {
		c++;
		c2 += 2;
	}
	if (c > 0) {
		if (texture(tex, uv + vec2(0.0, len.y)).a > 0.0) {
			c++;
			c2 += 1;
		} else if (texture(tex, uv + vec2(0.0, len.y * 2.0)).a > 0.0) {
			c++;
			c2 += 2;
		}
	}
	return c >= 2 && c2 <= 3;
}

bool checkRB(vec2 len, sampler2D tex, vec2 uv) {
	int c = 0;
	int c2 = 0;
	if (texture(tex, uv + vec2(len.x, 0.0)).a > 0.0) {
		c++;
		c2 += 1;
	} else if (texture(tex, uv + vec2(len.x * 2.0, 0.0)).a > 0.0) {
		c++;
		c2 += 2;
	}
	if (c > 0) {
		if (texture(tex, uv + vec2(0.0, -len.y)).a > 0.0) {
			c++;
			c2 += 1;
		} else if (texture(tex, uv + vec2(0.0, -len.y * 2.0)).a > 0.0) {
			c++;
			c2 += 2;
		}
	}
	return c >= 2 && c2 <= 3;
}

bool checkRT(vec2 len, sampler2D tex, vec2 uv) {
	int c = 0;
	int c2 = 0;
	if (texture(tex, uv + vec2(len.x, 0.0)).a > 0.0) {
		c++;
		c2 += 1;
	} else if (texture(tex, uv + vec2(len.x * 2.0, 0.0)).a > 0.0) {
		c++;
		c2 += 2;
	}
	if (c > 0) {
		if (texture(tex, uv + vec2(0.0, len.y)).a > 0.0) {
			c++;
			c2 += 1;
		} else if (texture(tex, uv + vec2(0.0, len.y * 2.0)).a > 0.0) {
			c++;
			c2 += 2;
		}
	}
	return c >= 2 && c2 <= 3;
}


// 获取液体纹理数据
vec4 get_tex_color(sampler2D tex) {
	// 单帧像素尺寸
	vec2 frame_px = vec2(origin_size.x / float(hframes), origin_size.y);
	// 当前片元在当前帧子图内的归一化坐标 [0,1)
	vec2 fuv = fract(pixel_pos / frame_px);
	// 映射到整张图的子图区域
	vec2 uv;
	uv.x = (fuv.x + float(frame)) / float(hframes);
	uv.y = fuv.y;
	// 采样主贴图
	return texture(tex, uv);
}

// 获取遮罩纹理数据
vec4 get_mask_color(vec2 uv, ivec2 uvSize, vec2 pixelSize) {
	ivec2 pos = ivec2(pixel_pos) / 4;
	vec4 color = texelFetch(mask, pos, 0);
	ivec2 maskSize = textureSize(mask, 0);
	vec2 a = vec2(float(uvSize.x) / float(maskSize.x), float(uvSize.y) / float(maskSize.y));
	vec2 newUv = a / 4.0 * uv;
	pixelSize *= a;
	vec2 delta = pixelSize / 4.0;

	if (color.a <= 0.0) {
		int c = 0;
		vec4 cf = vec4(0.0, 0.0, 0.0, 0.0);
		vec4 cL = texture(mask, newUv + vec2(-pixelSize.x, 0.0));
		vec4 cr = texture(mask, newUv + vec2(pixelSize.x, 0.0));
		vec4 ct = texture(mask, newUv + vec2(0.0, pixelSize.y));
		vec4 cb = texture(mask, newUv + vec2(0.0, -pixelSize.y));
		if (cL.a > 0.0) {
			c++;
			cf += cL;
		}
		if (cr.a > 0.0) {
			c++;
			cf += cr;
		}
		if (ct.a > 0.0) {
			c++;
			cf += ct;
		}
		if (cb.a > 0.0) {
			c++;
			cf += cb;
		}
		if (c >= 2) {
			if (cb.a > 0.0 && cL.a > 0.0) {
				if (checkLB(delta, mask, newUv)) {
					cf /= float(c);
					color = cf;
				}
			}
			if (ct.a > 0.0 && cL.a > 0.0) {
				if (checkLT(delta, mask, newUv)) {
					cf /= float(c);
					color = cf;
				}
			}

			if (cb.a > 0.0 && cr.a > 0.0) {
				if (checkRB(delta, mask, newUv)) {
					cf /= float(c);
					color = cf;
				}
			}
			if (ct.a > 0.0 && cr.a > 0.0) {
				if (checkRT(delta, mask, newUv)) {
					cf /= float(c);
					color = cf;
				}
			}
		}
	} else {
		int c = 0;
		vec4 cf = vec4(0.0, 0.0, 0.0, 0.0);
		vec4 clt = texture(mask, newUv + vec2(-delta.x, delta.y));
		vec4 crt = texture(mask, newUv + vec2(delta.x, delta.y));
		vec4 clb = texture(mask, newUv + vec2(-delta.x, -delta.y));
		vec4 crb = texture(mask, newUv + vec2(delta.x, -delta.y));

		if (clt.a > 0.0) {
			c++;
			cf += clt;
		}
		if (crt.a > 0.0) {
			c++;
			cf += crt;
		}
		if (clb.a > 0.0) {
			c++;
			cf += clb;
		}
		if (crb.a > 0.0) {
			c++;
			cf += crb;
		}
		if (c > 0 && c < 2) {
			color = vec4(0.0, 0.0, 0.0, 0.0);
		} else {
			color = cf / float(c);
		}
	}

	return color;
}

void vertex() {
	pixel_pos = VERTEX.xy; // 本地像素位置，已包含 Scale
}

void fragment() {
	vec4 c = get_tex_color(TEXTURE);
	if (c.a > 0.0) {
		c.a = get_mask_color(UV, textureSize(TEXTURE, 0), TEXTURE_PIXEL_SIZE).a;
	}
	c.a *= alpha;
	COLOR = c;
}
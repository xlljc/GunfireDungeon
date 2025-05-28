shader_type canvas_item;

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


//void vertex() {
	//VERTEX = VERTEX * vec2(4.0);
//}

void fragment() {
	
	if (COLOR.a <= 0.0) {
		int c = 0;
		vec4 cf = vec4(0.0, 0.0, 0.0, 0.0);
		vec4 cL = texture(TEXTURE, UV + vec2(-TEXTURE_PIXEL_SIZE.x, 0.0));
		vec4 cr = texture(TEXTURE, UV + vec2(TEXTURE_PIXEL_SIZE.x, 0.0));
		vec4 ct = texture(TEXTURE, UV + vec2(0.0, TEXTURE_PIXEL_SIZE.y));
		vec4 cb = texture(TEXTURE, UV + vec2(0.0, -TEXTURE_PIXEL_SIZE.y));
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
				if (checkLB(TEXTURE_PIXEL_SIZE / 4.0, TEXTURE, UV)) {
					cf /= float(c);
					COLOR = cf;
				}
			}
			if (ct.a > 0.0 && cL.a > 0.0) {
				if (checkLT(TEXTURE_PIXEL_SIZE / 4.0, TEXTURE, UV)) {
					cf /= float(c);
					COLOR = cf;
				}
			}

			if (cb.a > 0.0 && cr.a > 0.0) {
				if (checkRB(TEXTURE_PIXEL_SIZE / 4.0, TEXTURE, UV)) {
					cf /= float(c);
					COLOR = cf;
				}
			}
			if (ct.a > 0.0 && cr.a > 0.0) {
				if (checkRT(TEXTURE_PIXEL_SIZE / 4.0, TEXTURE, UV)) {
					cf /= float(c);
					COLOR = cf;
				}
			}
		}
	} else {
		int c = 0;
		vec2 tempV = TEXTURE_PIXEL_SIZE / 4.0;
		vec4 cf = vec4(0.0, 0.0, 0.0, 0.0);
		vec4 clt = texture(TEXTURE, UV + vec2(-tempV.x, tempV.y));
		vec4 crt = texture(TEXTURE, UV + vec2(tempV.x, tempV.y));
		vec4 clb = texture(TEXTURE, UV + vec2(-tempV.x, -tempV.y));
		vec4 crb = texture(TEXTURE, UV + vec2(tempV.x, -tempV.y));
		
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
			COLOR = vec4(0.0, 0.0, 0.0, 0.0);
		} else {
			COLOR = cf / float(c);
		}
	}
}

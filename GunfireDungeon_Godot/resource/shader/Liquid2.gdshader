shader_type canvas_item;

// —— 参数 ——
// 动画帧控制
uniform int   hframes : hint_range(1, 16) = 1;
uniform int   frame   : hint_range(0, 15) = 0;

// 液体贴图的总像素尺寸（整张图，不是单帧）
uniform vec2  origin_size = vec2(256.0, 256.0);

// 遮罩纹理
uniform sampler2D mask : filter_nearest, repeat_enable;

// —— 传递像素坐标
varying vec2 pixel_pos;

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
vec4 get_mask_color() {
	ivec2 pos = ivec2(pixel_pos) / 4;
	vec4 color = texelFetch(mask, pos, 0);

	return color;
}

void vertex() {
	pixel_pos = VERTEX.xy; // 本地像素位置，已包含 Scale
}

void fragment() {
	vec4 c = get_tex_color(TEXTURE);
	if (c.a > 0.0) {
		c.a = get_mask_color().a;
	}
	COLOR = c;
}
shader_type canvas_item;

// —— 参数 ——
// hframes:   纹理横向拆分的总帧数
uniform int   hframes    : hint_range(1, 16) = 1;
// frame:     当前要显示的帧索引（0 到 hframes-1）
uniform int   frame      : hint_range(0, 15) = 0;
// size:      整张贴图的像素尺寸（宽, 高）
uniform vec2  size       = vec2(256.0, 256.0);

// —— 从顶点传到片元的：当前片元的“像素坐标”——已经包含节点的 Scale —— 单位：像素
varying vec2 pixel_pos;

void vertex() {
    // VERTEX.xy 就是当前片元在 Sprite 本地坐标下的像素位置，已应用 Scale
    pixel_pos = VERTEX.xy;
}

void fragment() {
    // 每帧子图在像素空间的尺寸
    vec2 frame_px = vec2(size.x / float(hframes), size.y);

    // 计算在当前片元处，按子图尺寸应铺多少个 tile，取小数部分实现重复
    // fract(pixel_pos / frame_px) → [0,1) 区间内的“帧内归一化坐标”
    vec2 fuv = fract(pixel_pos / frame_px);

    // 将 fuv.x 映射到对应子图：加上 frame 偏移，然后除以 hframes 得到 UV.x
    vec2 uv;
    uv.x = (fuv.x + float(frame)) / float(hframes);
    uv.y = fuv.y;

    // 采样
    COLOR = texture(TEXTURE, uv);
}

shader_type canvas_item;
render_mode unshaded;

// —— 屏幕贴图 ——（不动）
uniform sampler2D screen_texture : hint_screen_texture, repeat_disable, filter_nearest;

// —— 动画帧参数 ——  
// hframes: 图集在横向拆分的总帧数  
uniform int   hframes    : hint_range(1, 16) = 1;
// frame:   当前要显示的帧索引（0 ~ hframes-1）
uniform int   frame      : hint_range(0, 15) = 0;

// —— 要平铺的 Sprite 图集 ——  
// 最近邻、不做 clamp，这样才能平铺／取边界外像素
uniform sampler2D tex : filter_nearest, repeat_enable;
// tex 纹理像素缩放倍率 
uniform float scale = 4.0;

// 偏移，单位像素
uniform vec2 offset;

void fragment() {
    // 1) 将归一化屏幕 UV 转为像素坐标，并加上偏移，再除以 scale 来控制像素放大
    vec2 pixel_pos = (SCREEN_UV / SCREEN_PIXEL_SIZE) / float(scale) + offset;

    // 2) 拿到贴图尺寸（像素）
    ivec2 tex_size_i = textureSize(tex, 0);
    vec2  tex_size   = vec2(tex_size_i);

    // 3) 计算单帧宽度（像素）
    float frame_w = tex_size.x / float(hframes);

    // 4) 对像素坐标做“分帧 + 平铺”处理
    //    首先把全局 x 坐标（已经包含 offset）减去当前帧在贴图中的起始像素，然后对单帧宽度取模。
    float local_x = mod(pixel_pos.x - float(frame) * frame_w, frame_w);
    // y 方向直接按贴图高度平铺（包含 offset.y）
    float local_y = mod(pixel_pos.y, tex_size.y);

    // 5) 把“像素级局部坐标”归一化到 [0,1] 区间，并加上帧的偏移
    vec2 uv_sample = vec2(
        (float(frame) * frame_w + local_x) / tex_size.x,
        local_y / tex_size.y
    );

    // 6) 采样并输出，保持屏幕透明度
    vec4 screen_col = textureLod(screen_texture, SCREEN_UV, 0.0);
    vec4 sprite_col = texture(tex, uv_sample);
    sprite_col.a = screen_col.a;
    COLOR = sprite_col;
}
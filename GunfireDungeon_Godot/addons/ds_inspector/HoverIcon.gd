@tool
extends TextureButton

var is_dragging: bool = false
var drag_offset: Vector2 = Vector2.ZERO
var drag_move_flag: bool = false

@export
var debug_tool_path: NodePath

@onready
var debug_tool = get_node(debug_tool_path)

func _ready():
	_load_pos()
	pressed.connect(_on_HoverIcon_pressed)
	mouse_entered.connect(_on_mouse_entered)
	mouse_exited.connect(_on_mouse_exited)
	pass

func _on_mouse_entered():
	if debug_tool:
		debug_tool._mouse_in_hover_btn = true
	pass

func _on_mouse_exited():
	if debug_tool:
		debug_tool._mouse_in_hover_btn = false
	pass

func _input(event):
	# 检测鼠标按下事件
	if event is InputEventMouseButton and event.button_index == MOUSE_BUTTON_LEFT:
		if event.pressed:
			drag_move_flag = false
			if get_global_rect().has_point(event.position):
				is_dragging = true
				drag_offset = event.position - global_position
		else:
			is_dragging = false
			_save_pos()

	# 检测鼠标移动事件
	if event is InputEventMouseMotion and is_dragging:
		drag_move_flag = true
		global_position = _clamp_to_screen(event.position - drag_offset)


func _on_HoverIcon_pressed():
	if !drag_move_flag:
		if debug_tool:
			if !debug_tool.window.visible:
				debug_tool.window.do_show()
			else:
				debug_tool.window.do_hide()
	pass


func _save_pos():
	if debug_tool.save_config:
		debug_tool.save_config.save_hover_icon_position(global_position)
	pass

func _clamp_to_screen(pos: Vector2) -> Vector2:
	var vp := get_viewport().get_visible_rect().size
	var w := size.x
	var h := size.y
	# 确保在可视区域内
	pos.x = clamp(pos.x, 0, max(0, vp.x - w))
	pos.y = clamp(pos.y, 0, max(0, vp.y - h))
	return pos

func _load_pos():
	if debug_tool.save_config:
		var raw_pos = debug_tool.save_config.get_hover_icon_position()
		var clamped = _clamp_to_screen(raw_pos)
		global_position = clamped
		# 如果位置被修正，保存回配置文件以持久化
		if clamped != raw_pos:
			_save_pos()
	pass

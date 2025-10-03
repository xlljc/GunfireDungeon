@tool
extends BaseAttr
class_name Vector2IAttr

@export
var label: Label
@export
var x_line_edit: LineEdit
@export
var y_line_edit: LineEdit

var _attr: String
var _node: Node

var _focus_flag: bool = false
var _temp_value: Vector2i  # 修改为 Vector2i

func _ready():
	x_line_edit.text_changed.connect(_on_x_text_changed)
	y_line_edit.text_changed.connect(_on_y_text_changed)

	x_line_edit.focus_entered.connect(_on_focus_entered)
	y_line_edit.focus_entered.connect(_on_focus_entered)

	x_line_edit.focus_exited.connect(_on_focus_exited)
	y_line_edit.focus_exited.connect(_on_focus_exited)
	pass

func set_node(node: Node):
	_node = node

func set_title(name: String):
	_attr = name
	label.text = name

func set_value(value):
	if not value is Vector2i:  # 修改类型判断
		return
	if _focus_flag:
		_temp_value = value
		return
	x_line_edit.text = str(value.x)
	y_line_edit.text = str(value.y)

func _on_x_text_changed(new_str: String):
	_temp_value.x = int(new_str)  # 修改为 int
	if is_instance_valid(_node):
		_node.set(_attr, _temp_value)

func _on_y_text_changed(new_str: String):
	_temp_value.y = int(new_str)  # 修改为 int
	if is_instance_valid(_node):
		_node.set(_attr, _temp_value)

func _on_focus_entered():
	_focus_flag = true
	pass

func _on_focus_exited():
	_focus_flag = false
	if is_instance_valid(_node):
		_node.set(_attr, _temp_value)
	pass

@tool
extends BaseAttr
class_name ColorAttr


@export
var label: Label
@export
var r_line_edit: LineEdit
@export
var g_line_edit: LineEdit
@export
var b_line_edit: LineEdit
@export
var a_line_edit: LineEdit

var _attr: String
var _node: Node

var _focus_flag: bool = false
var _temp_value: Color

func _ready():
	r_line_edit.text_changed.connect(_on_r_text_changed)
	g_line_edit.text_changed.connect(_on_g_text_changed)
	b_line_edit.text_changed.connect(_on_b_text_changed)
	a_line_edit.text_changed.connect(_on_a_text_changed)

	r_line_edit.focus_entered.connect(_on_focus_entered)
	g_line_edit.focus_entered.connect(_on_focus_entered)
	b_line_edit.focus_entered.connect(_on_focus_entered)
	a_line_edit.focus_entered.connect(_on_focus_entered)

	r_line_edit.focus_exited.connect(_on_focus_exited)
	g_line_edit.focus_exited.connect(_on_focus_exited)
	b_line_edit.focus_exited.connect(_on_focus_exited)
	a_line_edit.focus_exited.connect(_on_focus_exited)
	pass

func set_node(node: Node):
	_node = node

func set_title(name: String):
	_attr = name
	label.text = name

func set_value(value):
	if not value is Color:
		return
	if _focus_flag:
		_temp_value = value
		return
	r_line_edit.text = str(value.r)
	g_line_edit.text = str(value.g)
	b_line_edit.text = str(value.b)
	a_line_edit.text = str(value.a)

func _on_r_text_changed(new_str: String):
	_temp_value.r = float(new_str)
	if is_instance_valid(_node):
		_node.set(_attr, _temp_value)

func _on_g_text_changed(new_str: String):
	_temp_value.g= float(new_str)
	if is_instance_valid(_node):
		_node.set(_attr, _temp_value)

func _on_b_text_changed(new_str: String):
	_temp_value.b = float(new_str)
	if is_instance_valid(_node):
		_node.set(_attr, _temp_value)

func _on_a_text_changed(new_str: String):
	_temp_value.a = float(new_str)
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

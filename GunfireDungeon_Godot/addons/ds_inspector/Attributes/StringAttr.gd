extends BaseAttr
class_name StringAttr

@export
var label: Label
@export
var line_edit: LineEdit

var _attr: String
var _node: Node

var _focus_flag: bool = false
var _temp_value: String

func _ready():
	line_edit.text_changed.connect(_on_text_changed)
	line_edit.focus_entered.connect(_on_focus_entered)
	line_edit.focus_exited.connect(_on_focus_exited)
	pass

func set_node(node: Node):
	_node = node

func set_title(name: String):
	_attr = name
	label.text = name

func set_value(value):
	if not value is String:
		return
	if _focus_flag:
		_temp_value = value
		return
	line_edit.text = str(value)

func _on_text_changed(new_str: String):
	_temp_value = new_str
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

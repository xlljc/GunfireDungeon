@tool
extends BaseAttr
class_name BoolAttr

@export
var label: Label
@export
var check_box: CheckBox

var _attr: String
var _node: Node

func _ready():
	check_box.pressed.connect(_on_pressed)
	pass

func set_node(node: Node):
	_node = node

func set_title(name: String):
	_attr = name
	label.text = name

func set_value(value):
	if not value is bool:
		return
	check_box.button_pressed = value

func _on_pressed():
	_node.set(_attr, check_box.button_pressed)

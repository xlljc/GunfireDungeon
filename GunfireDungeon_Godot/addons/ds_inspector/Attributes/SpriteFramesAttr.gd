@tool
extends BaseAttr
class_name SpriteFramesAttr

@export
var label: Label
@export
var texture_node: TextureRect

var _attr: String
var _node: Node

func set_node(node: Node):
	_node = node

func set_title(name: String):
	_attr = name
	label.text = name

func set_value(value):
	if value == null:
		texture_node.texture = null
	elif not value is SpriteFrames:
		return
	else:
		texture_node.texture = value.get_frame_texture(_node.animation, _node.frame)

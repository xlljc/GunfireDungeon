extends BaseAttr
class_name EnumAttr

@export
var label: Label
@export
var option_button: OptionButton

var _attr: String
var _node: Node

func _ready():
	option_button.item_selected.connect(_on_item_selected)
	pass

func set_node(node: Node):
	_node = node

func set_enum_options(options: String):
	option_button.clear()
	var opts = options.split(",")
	for i in opts.size():
		option_button.add_item(opts[i])
	pass

func set_title(name: String):
	_attr = name
	label.text = name

func set_value(value):
	if not value is int:
		return
	if not option_button.has_focus():
		option_button.select(value)
	pass

func _on_item_selected(index: int):
	_node.set(_attr, index)
	pass

extends VBoxContainer

@export
var search_btn_path: NodePath
@export
var clear_search_btn_path: NodePath
@export
var search_input_path: NodePath
@export
var node_tree_path: NodePath
@export
var search_tree_path: NodePath

@onready
var search_btn: Button = get_node(search_btn_path)
@onready
var clear_search_btn: Button = get_node(clear_search_btn_path)
@onready
var search_input: LineEdit = get_node(search_input_path)
@onready
var node_tree: Tree = get_node(node_tree_path)
@onready
var search_tree: Tree = get_node(search_tree_path)
@onready
var debug_tool = get_node("/root/DsInspector")

func _ready():
	search_btn.pressed.connect(_do_serach)
	clear_search_btn.pressed.connect(_do_clear_serach)
	pass

func _do_serach():
	# print("camera" in "camera2d")
	var text: String = search_input.text
	if text.length() == 0:
		node_tree.visible = true
		search_tree.visible = false
	else:
		node_tree.visible = false
		search_tree.visible = true
		text = text.to_lower()
		var arr = _get_search_node_list(text)
		search_tree.set_search_node(arr)
	pass

func _do_clear_serach():
	search_input.text = ""
	_do_serach()
	pass

func _get_search_node_list(text: String) -> Array:
	var arr: Array = []
	for ch in get_tree().root.get_children(true):
		if debug_tool and ch == debug_tool:
			continue
		_each_node(ch, text, arr)
	return arr

func _each_node(node: Node, text: String, arr: Array):
	var n: String = node.name.to_lower()
	if text in n:
		arr.append(node)
	for ch in node.get_children(true):
		_each_node(ch, text, arr)
	pass

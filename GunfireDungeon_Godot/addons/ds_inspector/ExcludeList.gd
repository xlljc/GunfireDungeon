@tool
extends Tree
class_name ExcludeList

@export
var add_btn_path: NodePath

@export
var debug_tool_path: NodePath

@onready
var add_btn: Button = get_node(add_btn_path)
@onready
var debug_tool = get_node(debug_tool_path)
var _list: Array = []
var _root_item: TreeItem
@onready
var _delete_icon: Texture = preload("res://addons/ds_inspector/icon/delete.svg")

func _ready():
	add_btn.pressed.connect(_on_add_click);
	button_clicked.connect(_on_button_pressed);
	_root_item = create_item()

	# 载入文件
	_load_exclude_list()
	pass

func has_excludeL_path(s: String) -> bool:
	if debug_tool.save_config:
		return debug_tool.save_config.has_exclude_path(s)
	return _list.has(s)

# 添加排除路径
func add_excludeL_path(s: String) -> void:
	if has_excludeL_path(s):
		return

	_list.append(s)
	var item: TreeItem = create_item(_root_item)
	item.set_text(0, s)
	item.add_button(0, _delete_icon)

	if debug_tool.save_config:
		debug_tool.save_config.add_exclude_path(s)
	pass

func _on_add_click():
	if debug_tool:
		var node: Node = debug_tool.brush.get_draw_node()
		if node != null and is_instance_valid(node):
			var s: String = debug_tool.get_node_path(node)
			add_excludeL_path(s)
	pass

func _on_button_pressed(item: TreeItem, column: int, id: int, mouse_button_index: int):
	var s: String = item.get_text(0)
	item.free()
	var index: int = _list.find(s)
	if index >= 0:
		_list.remove_at(index)
		if debug_tool.save_config:
			debug_tool.save_config.remove_exclude_path(s)
	pass

# 加载排除列表
func _load_exclude_list():
	if debug_tool.save_config:
		_list = debug_tool.save_config.get_exclude_list()
		for s in _list:
			var item: TreeItem = create_item(_root_item)
			item.set_text(0, s)
			item.add_button(0, _delete_icon)

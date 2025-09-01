extends Tree

@export
var node_tree_path: NodePath

@onready
var _script_icon: Texture = preload("res://addons/ds_inspector/icon/icon_script.svg")
@onready
var _scene_icon: Texture = preload("res://addons/ds_inspector/icon/icon_play_scene.svg")
@onready
var _visible_icon: Texture = preload("res://addons/ds_inspector/Icon/Visible.png")
@onready
var _hide_icon: Texture = preload("res://addons/ds_inspector/Icon/Hide.png")

@onready
var node_tree: NodeTree = get_node(node_tree_path)
var _root_item: TreeItem

func _ready():
	# 选中item信号
	item_selected.connect(_on_item_selected)
	# item按钮按下信号
	button_clicked.connect(node_tree._on_button_pressed)
	_root_item = create_item()

## 选中节点
func _on_item_selected():
	var item: TreeItem = get_selected()
	var node_data := item.get_metadata(0)
	if node_tree != null and is_instance_valid(node_data.node):
		node_tree.show_tree(node_data.node)
	else:
		node_tree.show_tree()
	pass

## 设置搜索结果列表
func set_search_node(arr: Array):
	clear()
	_root_item = create_item()
	for node in arr:
		_create_node_item(node)
	pass

func _create_node_item(node: Node):
	var item: TreeItem      = create_item(_root_item)
	var node_data := node_tree.create_node_data(node)
	item.set_metadata(0, node_data)  # 存储节点引用
	item.set_text(0, node.name)
	item.set_icon(0, load(node_tree.icon_mapping.get_icon(node.get_class())))
	
	var btn_index: int = 0
	if node.scene_file_path != "":
		node_data.scene_icon_index = btn_index
		item.add_button(0, _scene_icon)  # 添场景按钮
		btn_index += 1
	if node.get_script() != null:
		node_data.script_icon_index = btn_index
		item.add_button(0, _script_icon)  # 添加脚本按钮
		btn_index += 1
	if node is CanvasItem or node is Control or node is CanvasLayer:
		node_data.visible_icon_index = btn_index
		node_data.visible = node.visible
		item.add_button(0, node_tree.get_visible_icon(node_data.visible))  # 添加显示/隐藏按钮
		btn_index += 1
	pass

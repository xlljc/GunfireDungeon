@tool
extends EditorPlugin

# 添加节点预设的界面
const ADD_NODE_PRESETTING = preload("res://addons/node_presetting/ui/add_node_presetting.tscn")
# 移除节点预设的界面
const REMOVE_NODE_PRESETTING = preload("res://addons/node_presetting/ui/remove_node_presetting.tscn")

# 检查器
var inspector : Node
# 菜单按钮
var _menu_button: MenuButton

# 添加节点预设
var add_node_presetting : AddNodePresetting
# 移除节点预设
var remove_node_presetting : RemovePresetting

# 对象
var object : Object
# 节点数据
var node_data : Dictionary
# 节点类名
var node_class_name : String:
	set(v):
		node_class_name = v
		_menu_button.disabled = node_class_name == ""
# 文件路径字典
var files_path : Dictionary

func _init():
	_menu_button = MenuButton.new()
	_menu_button.about_to_popup.connect(_on_menu_about_to_popup)
	_menu_button.icon = preload("res://addons/node_presetting/icon/node_icon.png")
	_menu_button.expand_icon = true
	_menu_button.flat = false
	_menu_button.custom_minimum_size = Vector2(24, 32)
	_menu_button.disabled = true

# 菜单按钮的弹窗出现信号触发方法
func _on_menu_about_to_popup() -> void:
	var popup : PopupMenu = _menu_button.get_popup()
	if not popup.id_pressed.is_connected(_on_menu_button_popup_index_pressed):
		popup.id_pressed.connect(_on_menu_button_popup_index_pressed)

	popup.clear()
	popup.add_item("新建预设", 1000)
	popup.add_item("删除预设", 1001)
	popup.add_separator("节点预设")

	if not DirAccess.dir_exists_absolute("res://addons/node_presetting/config/"): return
	var dir = DirAccess.open("res://addons/node_presetting/config/")
	var dirs : Array = dir.get_directories()
	var _files_path : Dictionary
	var _id : int = 0

	for i in dirs:
		if i != node_class_name: continue
		var files : Array = dir.open("res://addons/node_presetting/config/%s" % i).get_files()

		for f : String in files:
			popup.add_item(f.get_basename(), _id)

			_files_path[_id] = "res://addons/node_presetting/config/" + i + "/" + f
			_id += 1
	files_path = _files_path

# 菜单按钮选择信号触发方法
func _on_menu_button_popup_index_pressed(id : int) -> void:
	match id:
		1000:
			add_node_presetting = ADD_NODE_PRESETTING.instantiate()
			add_node_presetting.submit_name.connect(_on_add_node_presetting_submit_name)
			get_editor_interface().get_base_control().add_child(add_node_presetting)
			return
		1001:
			remove_node_presetting = REMOVE_NODE_PRESETTING.instantiate()
			remove_node_presetting.remove_file.connect(_on_remove_node_presetting_remove_file)
			get_editor_interface().get_base_control().add_child(remove_node_presetting)
			return

	node_data.clear()

	var node_config : NodeConfig = load(files_path[id])
	node_data = node_config.node_data

	for i in node_data:
		object.set(i, node_data[i])

# 添加节点预设提交信号触发方法
func _on_add_node_presetting_submit_name(_name : String) -> void:
	if not DirAccess.dir_exists_absolute("res://addons/node_presetting/config/"):
		DirAccess.make_dir_absolute("res://addons/node_presetting/config/")
	if not DirAccess.dir_exists_absolute("res://addons/node_presetting/config/%s" % node_class_name):
		DirAccess.make_dir_absolute("res://addons/node_presetting/config/%s" % node_class_name)

	node_data.clear()

	for i in object.get_property_list():
		if i["name"] == "": continue
		if i["usage"] == 128: continue
		if i["usage"] == 4096: continue
		if i["usage"] == 64: continue
		if i["usage"] == 256: continue
		if i["name"] == "owner": continue
		if i["name"] == "scene_file_path": continue
		if i["name"] == "name": continue
		if i["name"] == "multiplayer": continue
		node_data[i["name"]] = object.get(i["name"])

	var node_config : NodeConfig = NodeConfig.new()
	node_config.node_data = node_data
	ResourceSaver.save(node_config, "res://addons/node_presetting/config/%s/%s.tres" % [node_class_name, _name])

	get_editor_interface().get_resource_filesystem().scan()

# 移除节点预设移除文件信号触发方法
func _on_remove_node_presetting_remove_file() -> void:
	get_editor_interface().get_resource_filesystem().scan()

# 检查器内容改变信号触发方法
func _on_edited_object_changed() -> void:
	node_class_name = ""
	if not get_editor_interface().get_inspector().get_edited_object(): return

	object = get_editor_interface().get_inspector().get_edited_object()

	var property_list : Array = object.get_property_list()
	property_list.reverse()

	for i in property_list:
		if i["usage"] != 128: continue
		if i["name"].ends_with(".gd"): continue
		node_class_name = i["name"]
		return

func _enter_tree() -> void:
	get_editor_interface().get_inspector().edited_object_changed.connect(_on_edited_object_changed)
	inspector = get_editor_interface().get_inspector().get_parent()
	inspector.get_child(2).add_child(_menu_button)

func _exit_tree() -> void:
	_menu_button.queue_free()
	if add_node_presetting: add_node_presetting.queue_free()
	if remove_node_presetting: remove_node_presetting.queue_free()

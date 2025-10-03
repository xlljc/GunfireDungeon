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

const SAVE_PATH := "user://exclude_select.json"

func _ready():
	add_btn.pressed.connect(_on_add_click);
	button_clicked.connect(_on_button_pressed);
	_root_item = create_item()

	# 载入文件
	_load_exclude_list()
	pass

func has_excludeL_path(s: String) -> bool:
	return _list.has(s)

# 添加排除路径
func add_excludeL_path(s: String) -> void:
	if has_excludeL_path(s):
		return

	_list.append(s)
	var item: TreeItem = create_item(_root_item)
	item.set_text(0, s)
	item.add_button(0, _delete_icon)
	_save_exclude_list()
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
		_save_exclude_list()
	pass

# 保存为 JSON 文件
func _save_exclude_list():
	var file := FileAccess.open(SAVE_PATH, FileAccess.WRITE)
	if file:
		file.store_string(JSON.stringify(_list))
		file.close()
	else:
		print("无法保存文件到 ", SAVE_PATH)

# 加载 JSON 文件
func _load_exclude_list():
	if FileAccess.file_exists(SAVE_PATH):
		var file := FileAccess.open(SAVE_PATH, FileAccess.READ)
		if file:
			var content: String = file.get_as_text()
			file.close()
			var json := JSON.new()
			var parse_result = json.parse(content)
			if parse_result == OK:
				var result = json.data
				if typeof(result) == TYPE_ARRAY:
					for s in result:
						if typeof(s) == TYPE_STRING:
							_list.append(s)
							var item: TreeItem = create_item(_root_item)
							item.set_text(0, s)
							item.add_button(0, _delete_icon)
				else:
					print("JSON 文件内容格式错误")
			else:
				print("JSON 解析错误")
		else:
			print("无法打开文件 ", SAVE_PATH)

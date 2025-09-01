extends Window

const SAVE_PATH := "user://ds_inspector_window.txt"

@export
var tree: NodeTree
@export
var exclude_list: ExcludeList
@export
var select_btn: Button
@export
var save_btn: Button
@export
var delete_btn: Button
@export
var hide_border_btn: Button
@export
var play_btn: Button
@export
var file_window: FileDialog
@export
var put_away: Button
@export
var confirmation: ConfirmationDialog

# 缓存的窗口状态
var _cached_window_state: Dictionary = {}

@onready
var debug_tool = get_node("/root/DsInspector")

func _ready():
	_load_window_state()
	select_btn.pressed.connect(select_btn_click)
	# 修改为弹出确认框
	delete_btn.pressed.connect(_on_delete_btn_pressed)
	hide_border_btn.pressed.connect(hide_border_btn_click)
	play_btn.pressed.connect(play_btn_click)
	save_btn.pressed.connect(save_btn_click)
	close_requested.connect(do_hide)
	size_changed.connect(_on_window_resized)
	file_window.file_selected.connect(on_file_selected)
	put_away.pressed.connect(do_put_away)
	# focus_exited.connect(_on_focus_exited)
	confirmation.confirmed.connect(_on_delete_confirmed) # 连接确认事件

# 当窗口失去焦点时关闭窗口
func _on_focus_exited():
	do_hide()

# 显示弹窗
func do_show():
	if debug_tool:
		debug_tool.mask.visible = false
		debug_tool._is_open_check_ui = false
		debug_tool.find_current_camera()
		popup()
		tree.show_tree(debug_tool.brush._draw_node)
		debug_tool.brush.set_show_text(false)
	pass

# 隐藏弹窗
func do_hide():
	hide()
	_save_window_state()
	tree.hide_tree()
	pass

func select_btn_click():
	hide()
	if debug_tool:
		debug_tool.mask.visible = true
		debug_tool._is_open_check_ui = true

# 删除按钮点击，弹出确认框
func _on_delete_btn_pressed():
	confirmation.dialog_text = "确定要删除选中的节点吗？"
	confirmation.popup_centered()

# 确认框确认后执行删除
func _on_delete_confirmed():
	tree.delete_selected()

func hide_border_btn_click():
	if debug_tool:
		debug_tool.brush.set_draw_node(null)
	pass

func play_btn_click():
	var p: bool = !get_tree().paused
	get_tree().paused = p
	play_btn.text = "继续游戏" if p else "暂停游戏"
	pass

func save_btn_click():
	if debug_tool and debug_tool.brush._draw_node != null:
		do_hide()
		file_window.call_deferred("popup", Rect2i(position, size))
	pass

func on_file_selected(path: String):
	# print("选择文件" + path)
	if debug_tool:
		var node: Node = debug_tool.brush._draw_node
		if node != null and is_instance_valid(node):
			save_node_as_scene(node, path)
	pass

func do_put_away():
	_each_and_put_away(tree.get_root())
	pass

func _each_and_put_away(tree_item: TreeItem):
	var ch := tree_item.get_children()
	for item in ch:
		item.collapsed = true
		_each_and_put_away(item)
	pass

func save_node_as_scene(node: Node, path: String) -> void:
	var o: Node = node.owner
	node.owner = null
	_recursion_set_owner(node, node)
	var scene: PackedScene = PackedScene.new()
	var result: int = scene.pack(node)
	if result != OK:
		print("打包失败，错误码：", result)
		node.owner = o
		return
	
	var _err: int = ResourceSaver.save(scene, path)
	if _err == OK:
		print("保存成功: ", path)
	else:
		print("保存失败，错误码：", _err)
	node.owner = o

func _recursion_set_owner(node: Node, owner: Node):
	for ch in node.get_children(true):
		ch.owner = owner
		_recursion_set_owner(ch, owner)

# 当窗口大小改变时保存状态
func _on_window_resized():
	_save_window_state()

# 保存窗口状态（位置和大小）
func _save_window_state():
	var data := {
		"size": size
	}
	_cached_window_state = data
	
	var file := FileAccess.open(SAVE_PATH, FileAccess.WRITE)
	if file != null:
		file.store_string(var_to_str(data))
		file.close()
	else:
		print("无法保存窗口状态到 ", SAVE_PATH)

# 加载窗口状态（位置和大小）
func _load_window_state():
	if FileAccess.file_exists(SAVE_PATH):
		var file := FileAccess.open(SAVE_PATH, FileAccess.READ)
		if file != null:
			var content := file.get_as_text()
			file.close()
			var data := str_to_var(content)
			if data is Dictionary and data.has("size"):
				_cached_window_state = data
				var dataSize: Vector2 = _cached_window_state.size
				size = dataSize

@tool
class_name RemovePresetting extends PanelContainer

@onready var remove_menu_button: MenuButton = %RemoveMenuButton
@onready var cancel_button: Button = %CancelButton

# 移除文件信号
signal remove_file()

# 节点预设名称
var node_presetting_name : String = ""
# 是否拖拽
var drag : bool = false
# 拖拽时的坐标
var chick_pos : Vector2
# 文件路径字典
var files_path : Dictionary

func _ready() -> void:
	remove_menu_button.about_to_popup.connect(_on_remove_menu_button_about_to_popup)
	cancel_button.pressed.connect(_on_cancel_button_pressed)

func _gui_input(event: InputEvent) -> void:
	if event is InputEventMouseButton:
		if event.button_index == MOUSE_BUTTON_LEFT and event.is_pressed():
			drag = true
			chick_pos = get_global_mouse_position() - global_position
		elif event.button_index == MOUSE_BUTTON_LEFT and event.is_released():
			drag = false

	if drag: global_position = get_global_mouse_position() - chick_pos

# 取消按钮按下信号触发方法
func _on_cancel_button_pressed() -> void:
	queue_free()

# 菜单按钮的弹窗出现信号触发方法
func _on_remove_menu_button_about_to_popup() -> void:
	var popup : PopupMenu = remove_menu_button.get_popup()
	popup.id_pressed.connect(_on_remove_node_button_id_pressed)

	var dir = DirAccess.open("res://node_presettings/")
	var dirs : Array = dir.get_directories()
	var _files_path : Dictionary
	var _id : int = 0

	popup.clear()

	for i in dirs:
		var files : Array = dir.open("res://node_presettings/%s" % i).get_files()

		if not files.is_empty():
			popup.add_separator(i)
			_id += 1

		for f : String in files:
			popup.add_item(f.get_basename(), _id)
			_files_path[_id] =  "res://node_presettings/" + i + "/" + f
			_id += 1

	files_path = _files_path

# 菜单按钮选择信号触发方法
func _on_remove_node_button_id_pressed(id : int) -> void:
	var dialog : AcceptDialog = AcceptDialog.new()

	dialog.confirmed.connect(_on_dialog_confirmed.bind(id))
	dialog.add_cancel_button("取消")
	dialog.dialog_text = "是否要删除该节点预设"
	dialog.position = get_viewport_rect().size / 2

	EditorInterface.popup_dialog(dialog)

# 对话框确定信号触发方法
func _on_dialog_confirmed(id : int) -> void:
	DirAccess.remove_absolute(files_path[id])
	remove_file.emit()

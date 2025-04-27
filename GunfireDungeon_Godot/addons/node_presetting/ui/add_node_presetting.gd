@tool
class_name AddNodePresetting extends PanelContainer

@onready var name_line_edit: LineEdit = %NameLineEdit
@onready var confirm_button: Button = %ConfirmButton
@onready var cancel_button: Button = %CancelButton

# 提交名称的信号
signal submit_name(node_presetting_name : String)

# 节点预设名称
var node_presetting_name : String = ""
# 是否拖拽
var drag : bool = false
# 拖拽时的坐标
var chick_pos : Vector2

func _ready() -> void:
	name_line_edit.text_changed.connect(_on_name_line_edit_text_changed)
	name_line_edit.text_submitted.connect(_on_name_line_edit_text_submitted)
	confirm_button.pressed.connect(_on_confirm_button_pressed)
	cancel_button.pressed.connect(_on_cancel_button_pressed)

func _gui_input(event: InputEvent) -> void:
	if event is InputEventMouseButton:
		if event.button_index == MOUSE_BUTTON_LEFT and event.is_pressed():
			drag = true
			chick_pos = get_global_mouse_position() - global_position
		elif event.button_index == MOUSE_BUTTON_LEFT and event.is_released():
			drag = false

	if drag: global_position = get_global_mouse_position() - chick_pos

# 确定按钮按下信号触发方法
func _on_confirm_button_pressed() -> void:
	submit_name.emit(node_presetting_name)
	queue_free()

# 取消按钮按下信号触发方法
func _on_cancel_button_pressed() -> void:
	queue_free()

# 文字编辑器文字改变触发方法
func _on_name_line_edit_text_changed(new_text: String) -> void:
	node_presetting_name = new_text
	confirm_button.disabled = new_text == ""

# 文字编辑器文字提交触发方法
func _on_name_line_edit_text_submitted(new_text: String) -> void:
	_on_confirm_button_pressed()

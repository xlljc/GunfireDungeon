@tool
extends VBoxContainer

@export
var debug_tool: CanvasLayer
@export
var tree_container: VBoxContainer

@export
var use_system_window_checkbox: CheckBox
@export
var auto_open_checkbox: CheckBox
@export
var auto_search_checkbox: CheckBox
@export
var scale_options: OptionButton

func _ready():
	# 读取并设置 checkbox 状态
	if !Engine.is_editor_hint():
		use_system_window_checkbox.button_pressed = debug_tool.save_config.get_use_system_window()
		use_system_window_checkbox.toggled.connect(_on_use_system_window_toggled)
		use_system_window_checkbox.get_parent().visible = true
	else:
		use_system_window_checkbox.get_parent().visible = false

	auto_open_checkbox.button_pressed = debug_tool.save_config.get_auto_open()
	auto_open_checkbox.toggled.connect(_on_auto_open_toggled)
	
	auto_search_checkbox.button_pressed = debug_tool.save_config.get_auto_search()
	auto_search_checkbox.toggled.connect(_on_auto_search_toggled)		

	scale_options.selected = debug_tool.save_config.get_scale_index()
	scale_options.item_selected.connect(_on_scale_options_selected)

	call_deferred("init_config")


func init_config():
	# 自动打开窗口
	if debug_tool.save_config and debug_tool.save_config.get_auto_open():
		debug_tool.window.call_deferred("do_show")
	# 自动搜索
	_refresh_auto_search()
	# 缩放
	_apply_scale()

func _refresh_auto_search():
	tree_container.set_auto_search_enabled(debug_tool.save_config.get_auto_search())

func _on_use_system_window_toggled(enabled: bool):
	debug_tool.save_config.set_use_system_window(enabled)

func _on_auto_open_toggled(enabled: bool):
	debug_tool.save_config.set_auto_open(enabled)

func _on_auto_search_toggled(enabled: bool):
	debug_tool.save_config.set_auto_search(enabled)
	_refresh_auto_search()

func _on_scale_options_selected(index: int):
	debug_tool.save_config.set_scale_index(index)
	_apply_scale()

func _apply_scale():
	var factor = debug_tool.save_config.get_scale_factor()
	debug_tool.window.content_scale_factor = factor

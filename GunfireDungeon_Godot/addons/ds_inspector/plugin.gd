@tool
extends EditorPlugin

var debug_tool: Node
var tool_menu: PopupMenu
var save_config: SaveConfig

func _enter_tree():
	# 创建工具菜单
	tool_menu = PopupMenu.new()
	tool_menu.add_check_item("在编辑器运行", 0)
	tool_menu.add_check_item("在游戏中运行", 1)
	
	SaveConfig.save_path = "user://ds_inspector_editor_config.json"
	# 设置初始状态
	save_config = SaveConfig.new()
	add_child(save_config)

	tool_menu.set_item_checked(0, save_config.get_enable_in_editor())
	tool_menu.set_item_checked(1, save_config.get_enable_in_game())

	# 连接信号
	tool_menu.connect("id_pressed", Callable(self, "_on_tool_menu_pressed"))

	# 添加到工具菜单
	add_tool_submenu_item("DsInspector", tool_menu)

	_refresh_debug_tool(save_config.get_enable_in_editor())
	_refresh_debug_tool_in_game(save_config.get_enable_in_game())

func _exit_tree():
	remove_tool_menu_item("DsInspector")
	if save_config.get_enable_in_game():
		remove_autoload_singleton("DsInspector")
	if debug_tool != null:
		debug_tool.free()
		debug_tool = null

func _on_tool_menu_pressed(id: int):
	if id == 0: # 启用编辑器运行
		var enabled = not save_config.get_enable_in_editor()
		save_config.set_enable_in_editor(enabled)
		tool_menu.set_item_checked(0, enabled)
		_refresh_debug_tool(enabled)
	elif id == 1: # 启用游戏中运行
		var enabled = not save_config.get_enable_in_game()
		save_config.set_enable_in_game(enabled)
		tool_menu.set_item_checked(1, enabled)
		_refresh_debug_tool_in_game(enabled)

func _refresh_debug_tool(enabled: bool):
	if enabled:
		if debug_tool != null:
			debug_tool.free()
		debug_tool = load("res://addons/ds_inspector/DsInspectorTool.tscn").instantiate()
		debug_tool.save_config = save_config
		add_child(debug_tool)
	else:
		if debug_tool != null:
			debug_tool.free()
			debug_tool = null

func _refresh_debug_tool_in_game(enabled: bool):
	if enabled:
		# 添加自动加载场景
		add_autoload_singleton("DsInspector", "res://addons/ds_inspector/DsInspector.gd")
	else:
		# 移除自动加载场景
		remove_autoload_singleton("DsInspector")
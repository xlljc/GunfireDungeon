@tool
extends EditorPlugin

var debug_tool: Node

func _enter_tree():
	# 添加自动加载场景
	add_autoload_singleton("DsInspector", "res://addons/ds_inspector/DsInspector.gd")
	debug_tool = load("res://addons/ds_inspector/DsInspectorTool.tscn").instantiate()
	add_child(debug_tool)

func _exit_tree():
	# 移除自动加载场景
	remove_autoload_singleton("DsInspector")
	debug_tool.free()

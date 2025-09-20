@tool
extends EditorPlugin


func _enter_tree():
	# 添加自动加载场景
	add_autoload_singleton("DsInspector", "res://addons/ds_inspector/DsInspector.tscn")


func _exit_tree():
	# 移除自动加载场景
	remove_autoload_singleton("DsInspector")

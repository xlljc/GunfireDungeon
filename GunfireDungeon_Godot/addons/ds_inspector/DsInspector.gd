extends Node

var debug_tool: Node;

@onready
var template: PackedScene = preload("res://addons/ds_inspector/DsInspectorTool.tscn")

func _ready():
	if !OS.has_feature("editor"): # 判断是否是导出模式
		return
	debug_tool = template.instantiate()
	call_deferred("_deff_init")
	pass

func _deff_init():
	get_parent().add_child(debug_tool)
	reparent(debug_tool)
	pass

### 添加作弊按钮
func add_cheat_button(title: String, target: Node, method: String):
	if debug_tool == null:
		return
	debug_tool.cheat.add_cheat_button(title, target, method)
	pass

### 添加作弊按钮
func add_cheat_button_callable(title: String, callable: Callable):
	if debug_tool == null:
		return
	debug_tool.cheat.add_cheat_button_callable(title, callable)
	pass

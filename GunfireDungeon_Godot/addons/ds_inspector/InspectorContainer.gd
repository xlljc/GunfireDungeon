@tool
extends VBoxContainer
class_name InspectorContainer

@export
var update_time: float = 0.2 # 更新时间
@export
var filtr_input: LineEdit # 过滤属性输入框

var _curr_node: Node
var _has_node: bool = false
var _timer: float = 0

const flag: int = PROPERTY_USAGE_SCRIPT_VARIABLE | PROPERTY_USAGE_EDITOR
var _attr_list: Array = [] # value: AttrItem

@onready
var line: PackedScene = preload("res://addons/ds_inspector/Attributes/Line.tscn")
@onready
var label_attr: PackedScene = preload("res://addons/ds_inspector/Attributes/LabelAttr.tscn")
@onready
var rich_text_attr: PackedScene = preload("res://addons/ds_inspector/Attributes/RichTextAttr.tscn")
@onready
var bool_attr: PackedScene = preload("res://addons/ds_inspector/Attributes/BoolAttr.tscn")
@onready
var float_attr: PackedScene = preload("res://addons/ds_inspector/Attributes/FloatAttr.tscn")
@onready
var int_attr: PackedScene = preload("res://addons/ds_inspector/Attributes/IntAttr.tscn")
@onready
var vector2_attr: PackedScene = preload("res://addons/ds_inspector/Attributes/Vector2Attr.tscn")
@onready
var vector2I_attr: PackedScene = preload("res://addons/ds_inspector/Attributes/Vector2IAttr.tscn")
@onready
var vector3_attr: PackedScene = preload("res://addons/ds_inspector/Attributes/Vector3Attr.tscn") # 新增
@onready
var vector3I_attr: PackedScene = preload("res://addons/ds_inspector/Attributes/Vector3IAttr.tscn") # 新增
@onready
var color_attr: PackedScene = preload("res://addons/ds_inspector/Attributes/ColorAttr.tscn")
@onready
var rect_attr: PackedScene = preload("res://addons/ds_inspector/Attributes/RectAttr.tscn")
@onready
var recti_attr: PackedScene = preload("res://addons/ds_inspector/Attributes/RectIAttr.tscn")
@onready
var string_attr: PackedScene = preload("res://addons/ds_inspector/Attributes/StringAttr.tscn")
@onready
var texture_attr: PackedScene = preload("res://addons/ds_inspector/Attributes/TextureAttr.tscn")
@onready
var sprite_frames_attr: PackedScene = preload("res://addons/ds_inspector/Attributes/SpriteFramesAttr.tscn")
@onready
var enum_attr: PackedScene = preload("res://addons/ds_inspector/Attributes/EnumAttr.tscn")

class AttrItem:
	var attr: BaseAttr
	var name: String
	var usage: int
	var type: int
	func _init(_attr: BaseAttr, _name: String, _usage: int, _type: int):
		attr = _attr
		name = _name
		usage = _usage
		type = _type
		pass
	pass

func _ready():
	if filtr_input:
		filtr_input.text_changed.connect(_on_filter_text_changed)
	pass

func _process(delta):
	if _has_node:
		if _curr_node == null or !is_instance_valid(_curr_node) or !_curr_node.is_inside_tree():
			_clear_node_attr()
			pass
		_timer += delta
		if _timer > update_time:
			_timer = 0
			_update_node_attr()
		pass

func set_view_node(node: Node):
	_clear_node_attr()
	if node == null or !is_instance_valid(node):
		return
	_curr_node = node
	_has_node = true
	_init_node_attr()
	_update_node_attr()
	
	# 应用当前的过滤条件
	if filtr_input and filtr_input.text != "":
		_filter_attributes(filtr_input.text)
	pass

func _init_node_attr():
	var title = line.instantiate();
	add_child(title)
	title.set_title("基础属性")

	# 节点名称
	_create_label_attr(_curr_node, "名称：", _curr_node.name)
	
	# 节点类型
	_create_label_attr(_curr_node, "类型：", _curr_node.get_class())
	
	# _curr_node.name
	var path: String = ""
	var curr: Node = _curr_node
	while curr != null:
		if path.length() == 0:
			path = curr.name
		else:
			path = curr.name + "/" + path
		curr = curr.get_parent()
	
	_create_label_attr(_curr_node, "路径：", path)
	
	if _curr_node.scene_file_path != "":
		_create_label_attr(_curr_node, "场景：", _curr_node.scene_file_path)
	
	var props: Array[Dictionary] = _curr_node.get_property_list()

	var script: Script = _curr_node.get_script()
	if script != null:
		_create_label_attr(_curr_node, "脚本：", script.get_path())

		var title2 = line.instantiate();
		add_child(title2)
		title2.set_title("脚本导出属性")
		
		for prop in props:
			if prop.usage & PROPERTY_USAGE_SCRIPT_VARIABLE and prop.usage & PROPERTY_USAGE_EDITOR: # PROPERTY_USAGE_STORAGE   PROPERTY_USAGE_SCRIPT_VARIABLE
				_attr_list.append(_create_node_attr(prop))
		
		var title4 = line.instantiate();
		add_child(title4)
		title4.set_title("脚本属性")
		
		for prop in props:
			if prop.usage & PROPERTY_USAGE_SCRIPT_VARIABLE and not prop.usage & PROPERTY_USAGE_EDITOR: # PROPERTY_USAGE_STORAGE   PROPERTY_USAGE_SCRIPT_VARIABLE
				_attr_list.append(_create_node_attr(prop))
	
	var title3 = line.instantiate();
	add_child(title3)
	title3.set_title("内置属性")

	for prop in props:
		if prop.usage & PROPERTY_USAGE_EDITOR and not prop.usage & PROPERTY_USAGE_SCRIPT_VARIABLE:
			_attr_list.append(_create_node_attr(prop))
			
	var c: Control = Control.new()
	c.custom_minimum_size = Vector2(0, 100)
	add_child(c)
	pass

func _create_node_attr(prop: Dictionary) -> AttrItem:
	var v := _curr_node.get(prop.name)
	var attr: BaseAttr

	# ------------- 特殊处理 -----------------
	if _curr_node is AnimatedSprite2D:
		if prop.name == "sprite_frames":
			attr = sprite_frames_attr.instantiate()
	# ---------------------------------------

	if attr == null:
		if v == null:
			attr = rich_text_attr.instantiate()
		else:
			match typeof(v):
				TYPE_BOOL:
					attr = bool_attr.instantiate()
				TYPE_INT:
					if prop.hint == PROPERTY_HINT_ENUM:
						attr = enum_attr.instantiate()
					else:
						attr = int_attr.instantiate()
				TYPE_FLOAT:
					attr = float_attr.instantiate()
				TYPE_VECTOR2:
					attr = vector2_attr.instantiate()
				TYPE_VECTOR2I:
					attr = vector2I_attr.instantiate()
				TYPE_VECTOR3:
					attr = vector3_attr.instantiate() # 新增
				TYPE_VECTOR3I:
					attr = vector3I_attr.instantiate() # 新增
				TYPE_COLOR:
					attr = color_attr.instantiate()
				TYPE_RECT2:
					attr = rect_attr.instantiate()
				TYPE_RECT2I:
					attr = recti_attr.instantiate()
				TYPE_STRING:
					attr = string_attr.instantiate()
				TYPE_OBJECT:
					if v is Texture2D:
						attr = texture_attr.instantiate()
					else:
						attr = rich_text_attr.instantiate()
				_:
					attr = rich_text_attr.instantiate()
	add_child(attr)

	attr.set_node(_curr_node)
	attr.set_title(prop.name)
	
	if attr is EnumAttr:
		attr.set_enum_options(prop.hint_string)
	
	attr.set_value(v)
	# print(prop.name, "   ", typeof(v))
	return AttrItem.new(attr, prop.name, prop.usage, prop.type)

func _create_label_attr(node: Node, title: String, value: String) -> void:
	var attr: RichTextAttr = rich_text_attr.instantiate()
	add_child(attr)
	attr.set_node(node)
	attr.set_title(title)
	attr.set_value(value)

func _update_node_attr():
	for item in _attr_list:
		item.attr.set_value(_curr_node.get(item.name))
	pass

func _clear_node_attr():
	_curr_node = null
	_has_node = false
	_attr_list.clear()
	for child in get_children():
			child.queue_free()
	pass

func _on_filter_text_changed(new_text: String):
	_filter_attributes(new_text)
	pass

func _filter_attributes(filter_text: String):
	if filter_text == "":
		# 显示所有属性
		for item in _attr_list:
			item.attr.visible = true
	else:
		# 过滤属性（不区分大小写，忽略下划线）
		var filter_lower = filter_text.to_lower().replace("_", "")
		for item in _attr_list:
			var title_lower = item.name.to_lower().replace("_", "")
			var name_lower = item.name.to_lower().replace("_", "")
			var matches = title_lower.contains(filter_lower) or name_lower.contains(filter_lower)
			item.attr.visible = matches
	pass

extends Node2D
class_name Brush


var node_tree
# 当前绘制的节点
var _draw_node: Node = null
var _in_canvaslayer: bool = false

@export
var node_path_tips: Control# = $"../Control"
@export
var icon_tex_rect: TextureRect# = $"../Control/ColorRect/Icon"
@export
var path_label: Label# = $"../Control/Path"
@onready
var debug_tool = get_node("/root/DsInspector")

var _icon: Texture
var _show_text: bool = false

func _ready():
	node_path_tips.visible = false
	pass

func _process(_delta):
	queue_redraw()
	pass

func set_draw_node(node: Node) -> void:
	if node == null:
		_draw_node = null
		set_show_text(false)
		return
	_draw_node = node
	_in_canvaslayer = debug_tool.is_in_canvaslayer(node)
	var icon_path = node_tree.icon_mapping.get_icon(_draw_node.get_class())
	_icon = load(icon_path)
	icon_tex_rect.texture = _icon
	
	path_label.size.x = 0
	node_path_tips.size.x = 0
	path_label.text = debug_tool.get_node_path(node)
	pass

func set_show_text(flag: bool):
	_show_text = flag
	node_path_tips.visible = flag
	pass

func _draw():
	if _draw_node != null:
		if !is_instance_valid(_draw_node):
			_draw_node = null
			return
		
		var camera_trans: CameraTransInfo = debug_tool.get_camera_trans()
		var node_trans: NodeTransInfo = debug_tool.calc_node_rect(_draw_node)
		var pos: Vector2
		var rot: float
		var scale: Vector2
		if _in_canvaslayer:
			pos = node_trans.position
			scale = Vector2.ONE
			rot = node_trans.rotation
		else:
			pos = debug_tool.scene_to_ui(node_trans.position)
			scale = camera_trans.zoom
			rot = node_trans.rotation - camera_trans.rotation
		
		if _draw_node is CollisionShape2D:
			_draw_node_shape(_draw_node.shape, pos, scale, rot)
		elif _draw_node is CollisionPolygon2D or _draw_node is Polygon2D:
			_draw_node_polygon(_draw_node.polygon, pos, scale, rot)
		elif _draw_node is LightOccluder2D:
			if _draw_node.occluder != null:
				_draw_node_polygon(_draw_node.occluder.polygon, pos, scale, rot)
			else:
				_draw_node_rect(pos, scale, node_trans.size, rot, false)
		elif _draw_node is VisibleOnScreenEnabler2D or _draw_node is VisibleOnScreenNotifier2D:
			_draw_node_rect(pos, scale, node_trans.size, rot, true)
		else:
			_draw_node_rect(pos, scale, node_trans.size, rot, false)

		if _show_text:
			node_path_tips.visible = true
			var view_size: Vector2 = get_viewport().size
			var label_size: Vector2 = path_label.size
			var tips_size: Vector2 = node_path_tips.size
			var text_size: Vector2 = Vector2(
				max(label_size.x, tips_size.x),
				max(label_size.y, tips_size.y)
		 	)
			var text_pos: Vector2 = pos + Vector2(0, 5)
			# 限制在屏幕内，结合 path_label 的大小
			if text_pos.x + text_size.x > view_size.x:
				text_pos.x = view_size.x - text_size.x
			elif text_pos.x < 0:
				text_pos.x = 0
			if text_pos.y + text_size.y > view_size.y:
				text_pos.y = view_size.y - text_size.y
			elif text_pos.y < 0:
				text_pos.y = 0
			node_path_tips.position = text_pos
	pass

func _draw_node_shape(shape: Shape2D, pos: Vector2, scale: Vector2, rot: float):
	draw_circle(pos, 3, Color(1, 0, 0))
	if shape != null:
		draw_set_transform(pos, rot, scale)
		shape.draw(get_canvas_item(), Color(0, 1, 1, 0.5))
		draw_set_transform(Vector2.ZERO, 0, Vector2.ZERO)

func _draw_node_polygon(polygon: PackedVector2Array, pos: Vector2, scale: Vector2, rot: float):
	draw_circle(pos, 3, Color(1, 0, 0))
	if polygon != null and polygon.size() > 0:
		# 画轮廓线
		var arr: Array[Vector2] = []
		arr.append_array(polygon)
		arr.append(polygon[0])
		draw_set_transform(pos, rot, scale)
		# 画填充多边形
		draw_polygon(polygon, [Color(1, 0, 0, 0.3)])  # 半透明红色
		draw_polyline(arr, Color(1, 0, 0), 2.0)  # 闭合线
		draw_set_transform(Vector2.ZERO, 0, Vector2.ZERO)

func _draw_node_rect(pos: Vector2, scale: Vector2, size: Vector2, rot: float, filled: bool):
	draw_circle(pos, 3, Color(1, 0, 0))
	if size == Vector2.ZERO:
		return
	# 设置绘制变换
	draw_set_transform(pos, rot, scale)
	# 绘制矩形
	var rect = Rect2(Vector2.ZERO, size)
	if filled:
		draw_rect(rect, Color(1,0,0,0.3), true)
	draw_rect(rect, Color(1,0,0), false, 2)
	# 重置变换
	draw_set_transform(Vector2.ZERO, 0, Vector2.ONE)

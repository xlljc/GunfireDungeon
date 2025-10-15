@tool
extends CanvasLayer


@export
var window: Window
@export
var brush: Brush
@export
var mask: Control
@export
var inspector: InspectorContainer
@export
var tips: Label
@export
var tips_anim: AnimationPlayer
@export
var cheat: VBoxContainer

var save_config: SaveConfig = null

var main_camera: Camera2D = null
var prev_click: bool = false
var _check_camer_timer: float = 0.0

# 排除列表
var _exclude_list: Array = []
var _selected_list: Array = []
var _has_exclude_coll: bool = false
var _coll_list: Array = []
var _tips_finish_count: int = 0
var _prev_mouse_position: Vector2 = Vector2.ZERO
# 是否开启拣选Ui
var _is_open_check_ui: bool = false
var _mouse_in_hover_btn: bool = false

func _enter_tree():
	if save_config == null:
		save_config = SaveConfig.new()
		call_deferred("add_child", save_config)

func _ready():
	brush.node_tree = window.tree
	tips_anim.animation_finished.connect(on_tip_anim_finished)
	pass

## func _on_idle_frame() -> void:
func _process(delta: float) -> void:
	if window.visible:
		if main_camera == null or !is_instance_valid(main_camera) or !main_camera.is_current():
			main_camera = null
		_check_camer_timer -= delta
		if _check_camer_timer <= 0:
			## print("重新开始检测Camer相机")
			_check_camer_timer = 1.0
			find_current_camera()
	######################### 拣选Ui相关 
	if _is_open_check_ui:
		if !_mouse_in_hover_btn and Input.is_mouse_button_pressed(MOUSE_BUTTON_LEFT):
			if !prev_click:
				prev_click = true
				# 在macOS上使用Command键，其他平台使用Ctrl键
				var modifier_key_pressed: bool = false
				var p = OS.get_name()
				if p == "OSX":
					modifier_key_pressed = Input.is_key_pressed(KEY_META)  # Command键
				else:
					modifier_key_pressed = Input.is_key_pressed(KEY_CTRL)  # Ctrl键
				
				if modifier_key_pressed: # 按下修饰键, 执行向前选择
					if _selected_list.size() > 0:
						var node: Node = _selected_list.pop_back()
						if node != null and is_instance_valid(node):
							brush.set_draw_node(node)
							brush.set_show_text(true)
							return
				else:
					var node := get_check_node();
					if node != null:
						# print("选中节点: ", node.get_path())
						var draw_node = brush.get_draw_node()
						if draw_node != null:
							_selected_list.append(draw_node)
						brush.set_draw_node(node)
						brush.set_show_text(true)
						return
					elif _selected_list.size() > 1: # and _tips_finish_count < 5: # 最多提示 5 次
						if p == "OSX":
							tips.text = "错过了选中的节点？\n按住Command在点击鼠标左键可以回溯选择的节点！"
						else:
							tips.text = "错过了选中的节点？\n按住Ctrl在点击鼠标左键可以回溯选择的节点！"
						tips_anim.play("show")
						
		else:
			prev_click = false
	##################################################

## 获取鼠标点击选中的节点
func get_check_node() -> Node:
	var mousePos: Vector2 = brush.get_global_mouse_position()
	if _prev_mouse_position != mousePos:
		_prev_mouse_position = mousePos
		_has_exclude_coll = false
		_exclude_list.clear()  # 清空排除列表
		_selected_list.clear()
		_coll_list.clear()

	# 优先检测碰撞体
	if !_has_exclude_coll:
		var space_state: PhysicsDirectSpaceState2D = brush.get_viewport().get_world_2d().direct_space_state
		var pos: Vector2
		if main_camera:
			pos = main_camera.get_global_mouse_position()
		else:
			pos = mousePos
		var query = PhysicsPointQueryParameters2D.new()
		query.position = pos
		query.collision_mask = 2147483647
		query.collide_with_areas = true
		_coll_list = space_state.intersect_point(query)
		_has_exclude_coll = _coll_list.size() > 0
	
	if _has_exclude_coll:
		while _coll_list.size() > 0:
			var item = _coll_list[0]
			_coll_list.remove_at(0)
			var collider = item["collider"]
			if collider and is_instance_valid(collider) and !(collider is TileMap):
				var collision_shape = _find_collision_shape(collider)
				var node_path: String = get_node_path(collision_shape)
				if !_is_path_excluded(node_path):
					return collision_shape
	
	var camera_trans: CameraTransInfo = get_camera_trans()
	var node: Node = _each_and_check(get_tree().root, "", mousePos, camera_trans.zoom, false, _exclude_list);
	if node != null:
		_exclude_list.append(node)
	return node
	return null;

func _find_collision_shape(node: Node):
	if node == null:
		return null
	for child in node.get_children():
		if child is CollisionShape2D or child is CollisionPolygon2D:
			return child
	return null

# 检查节点路径是否被排除（包括子路径检查）
func _is_path_excluded(node_path: String) -> bool:
	# 首先检查完全匹配
	if window.exclude_list.has_excludeL_path(node_path):
		return true
	
	# 然后检查是否是任何排除路径的子路径
	for exclude_path in window.exclude_list._list:
		if node_path.begins_with(exclude_path + "/"):
			return true
	
	return false

func _each_and_check(node: Node, path: String, mouse_position: Vector2, camera_zoom: Vector2, in_canvaslayer: bool, exclude_list: Array) -> Node:
	if node == self or window.exclude_list.has_excludeL_path(path):
		return null

	if !in_canvaslayer and node is CanvasLayer:
		in_canvaslayer = true;

	if exclude_list.has(node) or (node is Control and !node.visible) or (node is CanvasItem and !node.visible) or (node is CanvasLayer and !node.visible):
		return null

	# 部分类型节点不参与子节点拣选
	for i in range(node.get_child_count(true) - 1, -1, -1):  # 从最后一个子节点到第一个子节点
		var child := node.get_child(i, true)
		if child is Viewport:
			continue
		var new_path: String
		if path.length() > 0:
			new_path = path + "/" + child.name
		else:
			new_path = child.name
		var result: Node = _each_and_check(child, new_path, mouse_position, camera_zoom, in_canvaslayer, exclude_list)
		if result != null:
			return result

	# 检测包含 polygon 的节点
	if node is LightOccluder2D:
		var occluder: OccluderPolygon2D = node.occluder
		if occluder:
			if is_polygon_node_coll(node, in_canvaslayer, mouse_position, occluder.polygon):
				return node
	elif node is Polygon2D:
		if is_polygon_node_coll(node, in_canvaslayer, mouse_position, node.polygon):
			return node
	else:
		var rect: NodeTransInfo = calc_node_rect(node)
		if rect.size == Vector2.ZERO:
			return null
		var mpos: Vector2
		if in_canvaslayer:
			mpos = mouse_position
		else:
			mpos = ui_to_scene(mouse_position)
		if is_in_rotated_rect(mpos, Rect2(rect.position.x, rect.position.y, rect.size.x, rect.size.y), rect.rotation, Vector2.ZERO):
			return node
	return null

func is_polygon_node_coll(node: Node2D, in_canvaslayer: bool, mouse_position: Vector2, polygon: PackedVector2Array) -> bool:
	if polygon != null and polygon.size() > 0:
		# 将鼠标位置转换到节点的局部坐标系
		var local_mouse_pos: Vector2 = mouse_position
		# 如果不在CanvasLayer中，需要将UI坐标转换回场景坐标
		if !in_canvaslayer:
			local_mouse_pos = ui_to_scene(mouse_position)
		# 转换到节点的局部坐标系
		local_mouse_pos = node.to_local(local_mouse_pos)
		# 使用Godot内置的几何检测函数
		if Geometry2D.is_point_in_polygon(local_mouse_pos, polygon):
			return true
	return false

## 旋转矩形检测
func is_in_rotated_rect(mouse_pos: Vector2, rect: Rect2, rotation: float, offset: Vector2) -> bool:
	# 计算旋转中心点（世界坐标）
	var pivot = rect.position + offset
	
	# 将 mouse_pos 转换到矩形局部坐标系（反向旋转）
	var local_pos = (mouse_pos - pivot).rotated(-rotation)
	
	# 处理负尺寸：计算实际位置和尺寸
	var actual_position = rect.position
	var actual_size = rect.size.abs()  # 取尺寸的绝对值
	
	# 根据原始尺寸符号调整位置偏移
	if rect.size.x < 0:
		actual_position.x += rect.size.x  # 负X时向右调整原点
	if rect.size.y < 0:
		actual_position.y += rect.size.y  # 负Y时向下调整原点
	
	# 将矩形位置转换到相对于 pivot 的局部坐标
	var local_rect_pos = actual_position - pivot
	
	# 构造正向尺寸的局部矩形
	var local_rect = Rect2(local_rect_pos, actual_size)
	
	# 在未旋转空间中进行包含检测
	return local_rect.has_point(local_pos)


## 判断点 (targetX, targetY) 是否在矩形区域 (x, y, w, h) 内
func is_in_rect(targetX: float, targetY: float, x: float, y: float, w: float, h: float) -> bool:
	return targetX >= x and targetX <= x + w and targetY >= y and targetY <= y + h

func is_in_canvaslayer(node: Node) -> bool:
	var parent: Node = node.get_parent()
	while parent != null:
		if parent is CanvasLayer:
			return true
		parent = parent.get_parent()
	return false

# 工具函数：递归向上查找 Viewport，但排除 root
func is_under_inner_viewport(n: Node) -> bool:
	var current = n
	var root_viewport = get_tree().root
	while current != null:
		if current is Viewport and current != root_viewport:
			return true
		current = current.get_parent()
	return false

func calc_node_rect(node: Node) -> NodeTransInfo:
	## 获取节点的矩形范围
	if node is Control:
		var trans: Transform2D = node.get_global_transform()
		var rect: Rect2 = node.get_global_rect()
		return NodeTransInfo.new(rect.position, rect.size, trans.get_rotation())
	elif node is Node2D:
		var pos: Vector2 = node.global_position
		var rot: float = node.global_rotation
		if node is Sprite2D:
			var texture: Texture2D = node.texture
			if texture:
				var scale: Vector2 = node.global_scale
				var offset: Vector2 = node.offset * scale
				var size: Vector2 = Vector2.ZERO
				var h := max(1, node.hframes)
				var v := max(1, node.vframes)
				if node.region_enabled:
					size = node.region_rect.size
				else:
					size = texture.get_size()
				size = size / Vector2(h, v) * scale
				# 根据 hframes，vframes，region_rect 计算 size
				if node.centered:
					pos -= (size * 0.5).rotated(rot)
				pos += offset.rotated(rot)
				return NodeTransInfo.new(pos, size, rot)
		elif node is AnimatedSprite2D:
			var sf: SpriteFrames = node.sprite_frames
			if sf:
				var curr_texture: Texture2D = sf.get_frame_texture(node.animation, node.frame)
				if curr_texture:
					var scale: Vector2 = node.global_scale
					var size: Vector2 = curr_texture.get_size() * scale
					var offset: Vector2 = node.offset * scale
					if node.centered:
						pos -= (size * 0.5).rotated(rot)
					pos += offset.rotated(rot)
					return NodeTransInfo.new(pos, size, rot)
		elif node is PointLight2D:
			var texture: Texture2D = node.texture;
			if texture:
				var scale: Vector2 = node.global_scale
				var size: Vector2 = texture.get_size() * scale;
				var offset: Vector2 = node.offset * scale
				pos += (offset - size * 0.5).rotated(rot)
				return NodeTransInfo.new(pos, size, rot)
		elif node is TileMap or node.get_class() == "TileMapLayer":
			var ts: TileSet = node.tile_set;
			if ts != null:
				var scale: Vector2 = node.global_scale;
				var rect: Rect2 = node.get_used_rect()
				var tile_size: Vector2 = Vector2(ts.tile_size)
				var size: Vector2 = rect.size * scale * tile_size
				pos += (rect.position * scale * tile_size).rotated(rot)
				return NodeTransInfo.new(pos, size, rot)
		elif node is BackBufferCopy or node is VisibleOnScreenEnabler2D or node is VisibleOnScreenNotifier2D:
			var scale: Vector2 = node.global_scale;
			var rect: Rect2 = node.rect;
			pos -= (rect.size * 0.5 * scale).rotated(rot)
			return NodeTransInfo.new(pos, rect.size * scale, rot)
		return NodeTransInfo.new(pos, Vector2.ZERO, rot)
	return NodeTransInfo.new(Vector2.ZERO, Vector2.ZERO, 0)

## 检测点是否在多边形内部（支持变换的版本）
func is_point_in_polygon_transformed(point: Vector2, polygon: PackedVector2Array, node_transform: Transform2D) -> bool:
	if polygon.size() < 3:
		return false
	
	# 将点转换到多边形的局部坐标系
	var local_point = node_transform.affine_inverse() * point
	
	# 使用Godot内置的几何检测函数
	return Geometry2D.is_point_in_polygon(local_point, polygon)

## 检测点是否在多边形内部（原有函数保持兼容）
func is_point_in_polygon(point: Vector2, polygon: PackedVector2Array) -> bool:
	if polygon.size() < 3:
		return false
	
	# 直接使用Godot内置的几何检测函数
	return Geometry2D.is_point_in_polygon(point, polygon)

## 计算多边形的边界矩形
func get_polygon_bounding_rect(polygon: PackedVector2Array) -> Rect2:
	if polygon.size() == 0:
		return Rect2()
	
	var min_x = polygon[0].x
	var max_x = polygon[0].x
	var min_y = polygon[0].y
	var max_y = polygon[0].y
	
	for point in polygon:
		min_x = min(min_x, point.x)
		max_x = max(max_x, point.x)
		min_y = min(min_y, point.y)
		max_y = max(max_y, point.y)
	
	return Rect2(Vector2(min_x, min_y), Vector2(max_x - min_x, max_y - min_y))

func scene_to_ui(scene_position: Vector2) -> Vector2:
	if main_camera == null or !is_instance_valid(main_camera):
		return scene_position
	
	var viewport = main_camera.get_viewport()
	if viewport == null:
		return scene_position
	
	# 使用 Godot 4 内置的坐标转换
	# 先将世界坐标转换为画布坐标，再转换为屏幕坐标
	var canvas_transform = main_camera.get_canvas_transform()
	var screen_position = canvas_transform * scene_position
	
	return screen_position

# 将UI坐标转换回场景坐标（scene_to_ui的逆操作）
func ui_to_scene(ui_position: Vector2) -> Vector2:
	if main_camera == null or !is_instance_valid(main_camera):
		return ui_position
	
	var viewport = main_camera.get_viewport()
	if viewport == null:
		return ui_position
	
	# 使用 Godot 4 内置的坐标转换
	# 获取画布变换的逆变换，将屏幕坐标转换回场景坐标
	var canvas_transform = main_camera.get_canvas_transform()
	var scene_position = canvas_transform.affine_inverse() * ui_position
	
	return scene_position

# 获取相机位置信息
func get_camera_trans() -> CameraTransInfo:
	if main_camera != null and is_instance_valid(main_camera):
		if main_camera.ignore_rotation:
			return CameraTransInfo.new(main_camera.global_position, main_camera.zoom, 0.0, main_camera.offset, main_camera.anchor_mode == Camera2D.ANCHOR_MODE_FIXED_TOP_LEFT)
		else:
			return CameraTransInfo.new(main_camera.global_position, main_camera.zoom, main_camera.global_rotation, main_camera.offset, main_camera.anchor_mode == Camera2D.ANCHOR_MODE_FIXED_TOP_LEFT)
	return CameraTransInfo.new(Vector2.ZERO, Vector2.ONE, 0.0, Vector2.ZERO, true)

## 遍历场景树, 在控制台打印出来
func _each_tree(node: Node) -> void:
	var count := node.get_child_count(true)
	for i in range(count):
		var child := node.get_child(i, true)
		print(child.name, " ", child.get_class(), " ", child.get_path())
		_each_tree(child)
	pass
	
func find_current_camera() -> Camera2D:
	var viewport = get_viewport()
	if not viewport:
		main_camera = null
		return null
	var camera := get_viewport().get_camera_2d()
	if main_camera != null and is_instance_valid(main_camera):
		if camera == main_camera:
			return main_camera

	main_camera = camera
	return camera

# 获取一个节点的路径
func get_node_path(node: Node) -> String:
	var s: String
	var current: Node = node
	while current != null:
		var p = current.get_parent()
		if p == null:
			break
		if s.length() > 0:
			s = current.name + "/" + s
		else:
			s = current.name
		current = p
	return s

func on_tip_anim_finished(_name: String):
	_tips_finish_count += 1

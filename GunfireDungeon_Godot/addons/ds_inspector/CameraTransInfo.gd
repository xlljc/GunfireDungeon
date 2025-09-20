class_name CameraTransInfo

# 节点的位置
var position: Vector2
# 视野的大小
var zoom: Vector2
# 节点的旋转角度，弧度制
var rotation: float
# 节点的偏移量
var offset: Vector2
# 相机锚点是否是中心点
var is_center: bool

func _init(_position: Vector2, _zoom: Vector2, _rotation: float, _offset: Vector2, _is_center: bool):
	position = _position
	zoom = _zoom
	rotation = _rotation
	offset = _offset
	is_center = _is_center
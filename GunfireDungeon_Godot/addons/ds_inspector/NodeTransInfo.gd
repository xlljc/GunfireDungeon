

# NodeTransInfo
# 表示节点的变换信息的类，包括其位置、大小、旋转和偏移。
class_name NodeTransInfo

# 节点的位置
var position: Vector2
# 节点的大小
var size: Vector2
# 节点的旋转角度，弧度制
var rotation: float

func _init(_position: Vector2, _size: Vector2, _rotation: float):
	position = _position
	size = _size
	rotation = _rotation
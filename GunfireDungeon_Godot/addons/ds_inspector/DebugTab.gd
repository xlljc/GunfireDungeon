extends TabContainer

@export
var tab_names: Array = []

func _ready():
	for i in range(tab_names.size()):
		set_tab_title(i, tab_names[i])

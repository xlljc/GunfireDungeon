extends VBoxContainer

@export
var cheat_package_scene: PackedScene;
@export
var cheat_list: VBoxContainer

func add_cheat_button(title: String, target: Node, method: String):
	add_cheat_button_callable(title, Callable(target, method))

func add_cheat_button_callable(title: String, callable: Callable):
	var item: Control = cheat_package_scene.instantiate();
	var t: Label = item.get_node("Title");
	var b: Button = item.get_node("Button");
	t.text = title;
	b.pressed.connect(callable)
	cheat_list.add_child(item);
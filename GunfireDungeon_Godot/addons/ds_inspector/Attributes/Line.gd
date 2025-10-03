@tool
extends MarginContainer

@export
var _title: Label

func set_title(title: String):
	_title.text = title

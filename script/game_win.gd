extends Control

func _unhandled_input(event):
	if event is InputEventKey and event.pressed and event.keycode == KEY_ENTER:
		get_tree().change_scene_to_file("res://scenes/RestArea/scenes/rest_area.tscn")

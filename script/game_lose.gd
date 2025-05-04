extends Control

func _unhandled_input(event):
	if event is InputEventKey and event.pressed and event.keycode == KEY_ENTER:
		get_tree().quit()

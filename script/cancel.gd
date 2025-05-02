extends Button


func _on_pressed() -> void:
	if Global.BackPackIsOpen:
		Global.BackPackIsOpen = false
	else:
		Global.BackPackIsOpen = true

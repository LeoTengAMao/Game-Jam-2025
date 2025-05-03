extends Panel

@onready var item_visual: Sprite2D = $CenterContainer/Panel/ItemDisplay

var item_name : String = ""


	

func update(item: InvItem):
	if !item :
		item_visual.visible = false 
	else :
		item_visual.visible = true 
		item_visual.texture = item.texture
		item_name = item.name




func _on_button_pressed() -> void:
	if item_visual.visible == false :
		print("No")
	else :
		print("Yes")


func _on_button_mouse_entered() -> void:
	
	
	pass # Replace with function body.

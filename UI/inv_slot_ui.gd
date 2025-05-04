extends Panel

@onready var item_visual: Sprite2D = $CenterContainer/Panel/ItemDisplay

var item_name : String = ""


	

func update(item: InvItem):
	if !item:
		item_visual.visible = false 
	else:
		item_visual.visible = true 
		item_visual.texture = item.texture
		item_name = item.name

		if item.texture:
			var tex_size = item.texture.get_size()
			var max_size = 64.0

			var scale_ratio = min(max_size / tex_size.x, max_size / tex_size.y)
			item_visual.scale = Vector2.ONE * scale_ratio






func _on_button_pressed() -> void:
	if item_visual.visible == false :
		print("No")
	else :
		print("Yes")


func _on_button_mouse_entered() -> void:
	
	
	pass # Replace with function body.

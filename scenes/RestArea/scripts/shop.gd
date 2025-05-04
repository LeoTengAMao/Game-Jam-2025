extends Area2D

@export var shop_intro : Label

	
func _on_body_entered(body: Node2D) -> void:
	if body.name == "player":
		print("enter next level")
		GlobalRest.in_shop = true
		shop_intro.visible = true


func _on_body_exited(body: Node2D) -> void:
	if body.name == "player":
		print("exit shop")
		GlobalRest.in_shop = false
		shop_intro.visible = false
	

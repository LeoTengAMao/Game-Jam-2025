extends Area2D

@export var shop_intro : Label
	
func _on_body_entered(body: Node2D) -> void:
	Global.Floor +=1
	shop_intro.visible = true


func _on_body_exited(body: Node2D) -> void:
	
	GlobalRest.in_shop = false
	shop_intro.visible = false
	

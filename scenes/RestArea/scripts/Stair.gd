extends Area2D

@export var Stair_intro : Label
	
func _on_body_entered(body: Node2D) -> void:
	
	GlobalRest.in_stair = true
	Stair_intro.visible = true


func _on_body_exited(body: Node2D) -> void:

	GlobalRest.in_stair = false
	Stair_intro.visible = false
	

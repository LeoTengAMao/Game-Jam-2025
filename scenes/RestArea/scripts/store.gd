extends Area2D

@export var store_label : Label


func _on_body_entered(body: Node2D) -> void:
	print("enter store")
	get_tree().current_scene.in_store = true
	store_label.visible = true


func _on_body_exited(body: Node2D) -> void:
	print("exit store")
	get_tree().current_scene.in_store = false	
	store_label.visible = false


		

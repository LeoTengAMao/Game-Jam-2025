extends CharacterBody2D


@export var move_speed : float = 300.0


func _process(delta: float) -> void:
	if Input.is_action_just_pressed("interaction"):
		if GlobalRest.in_shop:
			get_tree().change_scene_to_file("res://scenes/RestArea/scenes/store.tscn")
		

func _physics_process(delta: float) -> void:
	velocity = Input.get_vector("ui_left", "ui_right", "ui_up", "ui_down") * move_speed
	move_and_slide()
	

extends CharacterBody2D


@export var move_speed : float = 1000

func _process(delta: float) -> void:
	if get_tree().current_scene.in_store and Input.is_action_just_pressed("interaction"):
		print("buy sword")

func _physics_process(delta: float) -> void:
		# print(Input.get_vector("left", "right", "up", "down"))
	velocity = Input.get_vector("left", "right", "up", "down") * move_speed
	
	move_and_slide()

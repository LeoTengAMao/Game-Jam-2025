extends CharacterBody2D


@export var move_speed : float = 300.0


func _process(delta: float) -> void:
	
	if Input.is_action_just_pressed("interaction"):
		if GlobalRest.in_shop:
			get_tree().change_scene_to_file("res://scenes/RestArea/scenes/store.tscn")
		if GlobalRest.in_stair:
			get_tree().change_scene_to_file("res://scenes/RestArea/scenes/game.tscn")
		

func _physics_process(delta: float) -> void:
	velocity = Input.get_vector("ui_left", "ui_right", "ui_up", "ui_down") * move_speed
	if velocity.length() > 0:
		# 設定移動動畫
		$AnimatedSprite2D.play("run")  
		# 根據方向翻轉角色或改變動畫方向
		if abs(velocity.x) > abs(velocity.y):
			$AnimatedSprite2D.flip_h = velocity.x < 0
		# 可加入判斷上下方向的動畫切換
	else:
		# 停下時播放靜止動畫
		$AnimatedSprite2D.play("idle") 
	move_and_slide()
	

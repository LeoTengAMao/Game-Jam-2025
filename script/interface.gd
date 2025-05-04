extends Control

@export var inv: Inv

var combatHanlder
var forbiddenPanel

func _ready() -> void:
	combatHanlder = get_parent().get_node("CombatHandler")
	
	# 訂閱事件
	if combatHanlder != null:
		if combatHanlder.has_signal("EnemyTurnStart"):
			combatHanlder.EnemyTurnStart.connect(ForbiddenButton)
		if combatHanlder.has_signal("PlayerTurnStart"):
			combatHanlder.PlayerTurnStart.connect(OpenButton)
		if combatHanlder.has_signal("Won"):
			combatHanlder.Won.connect(SwitchRestScene)
		if combatHanlder.has_signal("Lost"):
			combatHanlder.Lost.connect(ResetGame)

func SwitchRestScene() -> void:
	print("you win")
	Global.Floor += 1;
	if Global.Floor <= 5:
		get_tree().change_scene_to_file("res://scenes/game_win.tscn")
	'''if stage > 5:
		# switch to scene hightechCG
	'''
	
func ResetGame() -> void:
	print("you lost")
	get_tree().change_scene_to_file("res://scenes/game_lose.tscn")
	

func ForbiddenButton() -> void:
	visible = false

func OpenButton() -> void:
	visible = true

func _on_skill_1_pressed() -> void:
	combatHanlder.Click_Skill(0, 0)
	$FX.stream = load("res://asset/sound/剣で斬る1.mp3")
	$FX.play()

func _on_skill_2_pressed() -> void:
	combatHanlder.Click_Skill(1, 0)
	$FX.stream = load("res://asset/sound/剣で斬る2.mp3")
	$FX.play()

func _on_skill_3_pressed() -> void:
	combatHanlder.Click_Skill(2, 0)
	$FX.stream = load("res://asset/sound/大剣で斬る.mp3")
	$FX.play()

func _on_skill_4_pressed() -> void:
	combatHanlder.Click_Skill(3, 0)
	$FX.stream = load("res://asset/sound/剣で斬る4.mp3")
	$FX.play()

func _on_skill_5_pressed() -> void:
	$FX.stream = load("res://asset/sound/heal_cut.mp3")
	$FX.play()
	combatHanlder.Click_Skill(4, 0)

func _on_back_pack_pressed() -> void:
	$FX.stream = load("res://asset/sound/backpackopen.mp3")
	$FX.play()
	print("Backpack")

func _on_normal_attack_pressed() -> void:
	$FX.stream = load("res://asset/sound/attack.mp3")
	$FX.play()
	if combatHanlder != null:
		combatHanlder.Click_Attack(0)


func _on_normal_defend_pressed() -> void:
	$FX.stream = load("res://asset/sound/盾で防御.mp3")
	$FX.play()
	if combatHanlder != null:
		combatHanlder.Click_Defense();


func _on_take_break_pressed() -> void:
	$FX.stream = load("res://asset/sound/take_a_breath.mp3")
	$FX.play()
	print("takebreak")

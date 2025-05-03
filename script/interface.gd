extends Control

@export var inv: Inv
@onready var health_bar = $PanelContainer/VBoxContainer/HealthBar  # 指向你的 TextureProgress 節點

var combatHanlder
var forbiddenPanel

func _ready() -> void:
	$PanelContainer/VBoxContainer/PlayerName.text = Global.player_name
	combatHanlder = get_parent().get_node("CombatHandler")
	
	# 訂閱事件
	if combatHanlder != null:
		if combatHanlder.has_signal("EnemyTurnStart"):
			combatHanlder.EnemyTurnStart.connect(ForbiddenButton)
		if combatHanlder.has_signal("PlayerTurnStart"):
			combatHanlder.PlayerTurnStart.connect(OpenButton)

func ForbiddenButton() -> void:
	visible = false

func OpenButton() -> void:
	visible = true

func HealthBarUpdate(current_hp: int, max_hp: int) -> void:
	var ratio = float(current_hp) / float(max_hp)
	ratio = clamp(ratio, 0.0, 1.0)
	health_bar.value = ratio * health_bar.max_value	
 
func _on_skill_1_pressed() -> void:
	print("skill1")


func _on_skill_2_pressed() -> void:
	print("skill2")


func _on_skill_3_pressed() -> void:
	print("skill3")


func _on_skill_4_pressed() -> void:
	print("skill4")


func _on_skill_5_pressed() -> void:
	print("skill5")


func _on_back_pack_pressed() -> void:
	print("Backpack")


func _on_normal_attack_pressed() -> void:
	if combatHanlder != null:
		combatHanlder.Click_Attack(0)


func _on_normal_defend_pressed() -> void:
	if combatHanlder != null:
		combatHanlder.Click_Defense();


func _on_take_break_pressed() -> void:
	print("takebreak")

extends Control



@export var inv: Inv
@onready var health_bar = $PanelContainer/VBoxContainer/HealthBar  # 指向你的 TextureProgress 節點


var player

func _ready() -> void:
	player = get_node("PlayerHanlder")
	$PanelContainer/VBoxContainer/PlayerName.text = Global.player_name

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
	player.Click_Attack(0)


func _on_normal_defend_pressed() -> void:
	print("normal_def")


func _on_take_break_pressed() -> void:
	print("takebreak")

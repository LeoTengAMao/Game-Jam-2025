extends Control
@onready var health_bar = $PanelContainer/VBoxContainer/HealthBar

func _ready() -> void:
	$PanelContainer/VBoxContainer/EnemyName.text = "Enemy"
	
func HealthBarUpdate(current_hp: int, max_hp: int) -> void:
	var ratio = float(current_hp) / float(max_hp)
	ratio = clamp(ratio, 0.0, 1.0)
	health_bar.value = ratio * health_bar.max_value	

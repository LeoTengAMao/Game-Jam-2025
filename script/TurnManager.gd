extends Node

enum Turn {
	PLAYER,
	ENEMY
}

var current_turn = Turn.PLAYER

@onready var player_gui = $"Interface"

func _ready():
	update_gui_state()

func next_turn():
	if current_turn == Turn.PLAYER:
		current_turn = Turn.ENEMY
		# 模擬敵人操作
		await enemy_action()
	else:
		current_turn = Turn.PLAYER
	update_gui_state()

func update_gui_state():
	if current_turn == Turn.PLAYER:
		player_gui.visible = true  # 接受點擊
		player_gui.modulate.a = 1.0  # 完全可見（選擇性）
	else:
		player_gui.visible  = false # 不接受點擊
		player_gui.modulate.a = 0.5  # 半透明提示不能操作（選擇性）

func enemy_action():
	await get_tree().create_timer(1.0).timeout
	# 模擬敵人行動
	print("Enemy acted.")
	next_turn()

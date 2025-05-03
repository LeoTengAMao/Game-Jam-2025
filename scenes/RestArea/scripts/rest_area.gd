extends Node2D




# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	$player.position = GlobalRest.player_pos


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	GlobalRest.player_pos = $player.position

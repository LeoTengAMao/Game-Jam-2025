extends Node2D


func _on_line_edit_text_submitted(new_text: String) -> void:
	Global.player_name = new_text
	get_tree().change_scene_to_file("res://scenes/Game.tscn")

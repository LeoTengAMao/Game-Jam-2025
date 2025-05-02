extends Node2D


func _on_line_edit_text_submitted(new_text: String) -> void:
	if new_text != "":
		Global.player_name = new_text
	else :
		Global.player_name = "我是小懶豬，不想取名字"
	get_tree().change_scene_to_file("res://scenes/Game.tscn")

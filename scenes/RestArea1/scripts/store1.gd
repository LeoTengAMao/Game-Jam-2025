extends Control

'''var player_point: int = Global.dot
var player_line: int = Global.line
var player_plane: int = Global.face'''

var player_point: int = 10
var player_line: int = 10
var player_plane: int = 10

func _ready():
	var bg = $Background
	bg.texture = load("res://store/bg.png")
	bg.expand = true
	bg.stretch_mode = TextureRect.STRETCH_SCALE

	update_currency_display()

	$Label.position = Vector2(10, 10)
	$Label.add_theme_font_size_override("font_size", 36)

	add_item($item01, "res://store/other_pic/bomb.png", "像素劍", [0, 4, 1], [170, 30])
	add_item($item02, "res://store/items/potion.png", "戰槌", [0, 6, 1], [375, 30])
	add_item($item03, "res://store/other_pic/fire_stick.png", "看不劍", [16, 0, 0], [580, 30])
	add_item($item04, "res://store/items/potion.png", "遠劍", [0, 6, 4], [790, 30])
	add_item($item05, "res://store/items/potion.png", "正方形", [0, 0, 1], [100, 430])
	add_item($item06, "res://store/items/potion.png", "斗笠", [0, 10, 0], [305, 430])
	add_item($item07, "res://store/items/potion.png", "看不見", [16, 0, 0], [510, 430])
	add_item($item08, "res://store/items/potion.png", "魔法斗篷", [0, 0, 6], [715, 430])
	
	var exit_button = $exit
	exit_button.position = Vector2(830,340)
	exit_button.custom_minimum_size = Vector2(128, 64)
	exit_button.text = "EXIT"
	exit_button.add_theme_font_size_override("font_size", 36)
	exit_button.pressed.connect(_on_exit_button_pressed)

func add_item(item_node, texture_path, item_name, item_price, item_position):
	item_node.position = Vector2(item_position[0], item_position[1])

	var potion_image = item_node.get_node("t")
	potion_image.texture = load(texture_path)
	potion_image.custom_minimum_size = Vector2(180, 180)
	potion_image.size = Vector2(180, 180)
	potion_image.stretch_mode = TextureRect.STRETCH_KEEP_ASPECT_CENTERED
	
	item_node.add_child(potion_image)

	var buy_button = Button.new()
	buy_button.custom_minimum_size = Vector2(128, 64)
	buy_button.text = "%s\n(%d, %d, %d)" % [item_name, item_price[0], item_price[1], item_price[2]]
	buy_button.add_theme_font_size_override("font_size", 36)

	buy_button.pressed.connect(
		func():
			_on_buy_pressed(item_name, texture_path, item_price[0], item_price[1], item_price[2])
	)
	item_node.add_child(buy_button)



func update_currency_display():
	$Label.text = "Point: %d\nLine: %d\nPlane: %d" % [player_point, player_line, player_plane]

func _on_buy_pressed(item_name: String, texture_path: String, cost_point: int, cost_line: int, cost_plane: int):
	if player_point >= cost_point and player_line >= cost_line and player_plane >= cost_plane:
		player_point -= cost_point
		player_line -= cost_line
		player_plane -= cost_plane
		
		update_currency_display()
		$FX.stream = load("res://asset/sound/レジスターで精算.mp3")
		$FX.play()
		
		var purchased_item := InvItem.new()
		purchased_item.name = item_name
		purchased_item.texture = load(texture_path)
		Global.inv.AddItems(purchased_item)
		
		print("%s purchased!" % item_name)
	else:
		$FX.stream = load("res://asset/sound/ビープ音4.mp3")
		$FX.play()
		print("Not enough currency for %s!" % item_name)

func _on_exit_button_pressed():
	Global.dot = player_point
	Global.line = player_line
	Global.face = player_plane
	get_tree().change_scene_to_file("res://scenes/RestArea1/scenes/rest_area.tscn")

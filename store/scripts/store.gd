extends Control

var player_gold := 399
var potion_price := 50

func _ready():
	update_gold_display()
	$BGM.stream = load("res://music/loops/chill_loop.wav")
	$BGM.play()
	$FX.stream = load("res://music/FX/woosh.mp3")
	
	$Label.position = Vector2(10, 10)
	$Label.add_theme_font_size_override("font_size", 36)
	
	$VBoxContainer.position = Vector2(10, 100)
	var potion_image = TextureRect.new()
	potion_image.texture = load("res://store/items/potion.png")
	potion_image.stretch_mode = TextureRect.STRETCH_KEEP_ASPECT_CENTERED
	potion_image.custom_minimum_size = Vector2(128, 128)  # 你可以依照需求調整
	$VBoxContainer.add_child(potion_image)

	var buy_button = Button.new()
	buy_button.custom_minimum_size = Vector2(128, 32)
	buy_button.text = "Potion\n%d G" % potion_price
	buy_button.pressed.connect(_on_buy_potion_pressed)
	buy_button.add_theme_font_size_override("font_size", 24)
	$VBoxContainer.add_child(buy_button)

func update_gold_display():
	$Label.text = "Gold: %d" % player_gold

func _on_buy_potion_pressed():
	if player_gold >= potion_price:
		$FX.play()
		player_gold -= potion_price
		update_gold_display()
		print("Potion purchased!")
	else:
		print("Not enough gold!")

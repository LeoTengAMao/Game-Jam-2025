extends Control


@onready var slots: Array = $NinePatchRect/GridContainer.get_children()


func _ready():
	update_slots()
	Global.BackPackIsOpen = false
	visible = false  
	
	var sword := InvItem.new()
	sword.name = "Iron Sword"
	sword.texture = preload("res://sprite/Stick.png")

	var another_sword := InvItem.new()
	another_sword.name = "Iron Sword"
	another_sword.texture = preload("res://sprite/Stick.png")

	Global.inv.AddItems(sword)
	Global.inv.AddItems(another_sword)

	print("Before remove:", Global.inv.items.size())  # 2

	Global.inv.RemoveItems(sword)  # 只移除你傳入的那個物件，另一個同名不受影響

	print("After remove:", Global.inv.items.size())  # 1
	update_slots()

func update_slots():
	for i in range(min(Global.inv.items.size(),slots.size())):
		slots[i].update(Global.inv.items[i])

func open():
	self.visible = true
	#Global.BackPackIsOpen = true
	
func close():
	visible = false  
	#Global.BackPackIsOpen = false
	
func _process(delta) -> void:
	if Global.BackPackIsOpen:
		open()
	else:
		close()

func _on_back_pack_pressed() -> void:
	if Global.BackPackIsOpen:
		Global.BackPackIsOpen = false
	else:
		Global.BackPackIsOpen = true
		

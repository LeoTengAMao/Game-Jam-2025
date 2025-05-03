extends Control


@onready var slots: Array = $NinePatchRect/GridContainer.get_children()


func _ready():
	update_slots()
	Global.BackPackIsOpen = false
	visible = false  
	
	

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
		

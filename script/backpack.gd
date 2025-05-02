extends Control



func _ready():
	Global.BackPackIsOpen = false
	visible = false  

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
		

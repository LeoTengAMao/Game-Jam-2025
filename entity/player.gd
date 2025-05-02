extends CharacterBody2D

func open():
	self.visible = true
	#Global.BackPackIsOpen = true
	
func close():
	visible = false  
	#Global.BackPackIsOpen = false

func _process(delta) -> void:
	if Global.BackPackIsOpen:
		close()
	else:
		open()

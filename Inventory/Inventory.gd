extends Resource
class_name Inv

@export var items: Array[InvItem] = []

func AddItems(new_stack: InvItem) -> bool:
	for i in items.size():
		if items[i] == null:
			items[i] = new_stack
			return true
	return false  # 沒空格
	
func AddEquiment(new_stack: InvItem) -> bool:
	for i in range(24,items.size()):
		if items[i] == null:
			items[i] = new_stack
			return true
	return false  # 沒空格

func RemoveItems(target_stack: InvItem) -> void:
	if items.has(target_stack):
		items.erase(target_stack)

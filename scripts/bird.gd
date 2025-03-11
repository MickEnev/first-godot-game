extends Node2D

const SPEED = 60

var direction = -1

@onready var sprite = $AnimatedSprite2D
# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	if position.x <= 155:
		direction = 1
		sprite.flip_h = true
	if position.x >= 335:
		direction = -1
		sprite.flip_h = false
	position.x += direction * SPEED * delta

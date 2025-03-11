extends Node

var score = 0

@onready var score_label = $"../Player/Camera2D/Label"

func add_point():
	score += 1
	score_label.text = "How many ungus?? You have: " + str(score)

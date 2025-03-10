using Godot;
using System;
using System.Threading.Tasks.Dataflow;

public partial class Ungus : Area2D
{

	public override void _Ready()
	{
		BodyEntered += OnBodyEnter;
	}
	public void OnBodyEnter(Node2D body) {
		GD.Print("+1");
		QueueFree();
	}
}

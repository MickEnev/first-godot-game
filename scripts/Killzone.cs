using Godot;
using System;

public partial class Killzone : Area2D
{

	private Timer timer;
	public override void _Ready()
	{
		BodyEntered += OnBodyEnter;
		
		timer = new Timer();
		timer.WaitTime = 0.6f;
		timer.OneShot = true;
		AddChild(timer);
		timer.Timeout += OnTimerTimeout;
	}
	public void OnBodyEnter(Node2D body) {
		GD.Print("You died!");
		timer.Start();
	}

	public void OnTimerTimeout() {
		GetTree().ReloadCurrentScene();
	}
}

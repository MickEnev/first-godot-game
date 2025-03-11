using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 200.0f;
	public const float JumpVelocity = -300.0f;
	private AnimatedSprite2D sprite;
	private AudioStreamPlayer2D moveSound;

	public override void _Ready()
	{
		sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		moveSound = GetNode<AudioStreamPlayer2D>("MoveSound");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("move_left", "move_right", "ui_up", "ui_down");
		
		// Flip sprite
		if (direction > Vector2.Zero) {
			sprite.FlipH = false;

		} else if (direction < Vector2.Zero) {
			sprite.FlipH = true;
		}

		// Change animation based on movement 
		if (IsOnFloor()) {
			if (direction == Vector2.Zero) {
				sprite.Play("default");
				if (moveSound.Playing) 
				{
					moveSound.Stop();  // Stop the sound when idle
				}
			} else {
				sprite.Play("move");
				if (!moveSound.Playing)
				{
					moveSound.Play();  // Play the sound when moving
				}
			}
		} else {
			sprite.Play("jump");
			if (moveSound.Playing) 
				{
					moveSound.Stop();  // Stop the sound when idle
				}
		}
		

		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}

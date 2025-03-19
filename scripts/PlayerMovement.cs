using Godot;
using System;

public partial class PlayerMovement : CharacterBody2D
{
	public const float JumpVelocity = -500.0f;

	private AnimatedSprite2D animatedSprite;

	public override void _Ready()
	{
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

		// Apply gravity
		velocity += GetGravity() * (float)delta;

		// Play jump animation once when jumping
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
			animatedSprite.Play("jump");
		}
		else if (IsOnFloor())
		{
			animatedSprite.Play("run");
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}

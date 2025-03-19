using Godot;
using System;

public partial class PlayerMovement : CharacterBody2D
{
	public const float JumpVelocity = -500.0f;

	private AnimatedSprite2D animatedSprite;
	private bool isAttacking = false;

	public override void _Ready()
	{
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		animatedSprite.AnimationFinished += OnAnimationFinished;
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Apply gravity
		velocity += GetGravity() * (float)delta;

		// Play attack animation if not already attacking
		if (Input.IsActionJustPressed("attack") && !isAttacking)
		{
			animatedSprite.Play("attack");
			isAttacking = true;
		}
		else if (!isAttacking)
		{
			if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			{
				velocity.Y = JumpVelocity;
				animatedSprite.Play("jump");
			}
			else if (IsOnFloor())
			{
				animatedSprite.Play("run");
			}
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	private void OnAnimationFinished()
	{
		// Check if it was the attack animation that just finished
		if (animatedSprite.Animation == "attack")
		{
			isAttacking = false;

			// Auto-switch back to run if still on floor
			if (IsOnFloor())
			{
				animatedSprite.Play("run");
			}
		}
	}
}

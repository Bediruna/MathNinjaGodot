using Godot;
using System;

public partial class EnemyMovement : CharacterBody2D
{
	public const float Gravity = 980.0f;

	public Label _enemyLabel;
	private AnimatedSprite2D _animatedSprite;
	private bool _isDead = false;

	private Vector2 EnemyDirection = Vector2.Left;
	private Vector2 _velocity = Vector2.Zero;

	public override void _Ready()
	{
		_enemyLabel = GetNode<Label>("Label");
		
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_animatedSprite.AnimationFinished += OnAnimationFinished;
	}

	public override void _PhysicsProcess(double delta)
	{
		if (_isDead)
			return;

		float dt = (float)delta;

		// Gravity
		if (!IsOnFloor())
			_velocity.Y += Gravity * dt;
		else
			_velocity.Y = 0f;

		// Horizontal movement
		_velocity.X = EnemyDirection.X * GameSettings.GameSpeed;

		// Apply movement
		Velocity = _velocity;
		MoveAndSlide();
	}

	public void PlayDeath()
	{
		if (_isDead)
			return;

		_isDead = true;

		_animatedSprite.Play("death");
	}

	private void OnAnimationFinished()
	{
		if (_animatedSprite.Animation == "death")
		{
			QueueFree();
		}
	}
	public void SetLabelValue(string value)
	{
		if (_enemyLabel != null)
			_enemyLabel.Text = value;
	}

}

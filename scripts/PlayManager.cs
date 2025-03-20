using Godot;
using System;

public partial class PlayManager : Node2D
{
	private Label problemLabel;
	private PackedScene enemyScene;
	private Timer spawnTimer;

	public override void _Ready()
	{
		problemLabel = GetNode<Label>("ProblemLabel");
		enemyScene = GD.Load<PackedScene>("res://scenes/gray_slime.tscn");

		// Create and configure a Timer
		spawnTimer = new Timer();
		spawnTimer.WaitTime = 2.0; // spawn every 2 seconds
		spawnTimer.OneShot = false;
		spawnTimer.Autostart = true;

		AddChild(spawnTimer);

		// Connect the timeout signal
		spawnTimer.Timeout += OnSpawnTimerTimeout;
	}

	public override void _Process(double delta)
	{
		problemLabel.Text = "32 + 32";
	}

	private void OnSpawnTimerTimeout()
	{
		// Example: spawn at a random position
		Vector2 spawnPos = new Vector2(
			GD.RandRange(100, 500),
			GD.RandRange(100, 400)
		);

		SpawnEnemy(spawnPos);
	}

	private void SpawnEnemy(Vector2 spawnPosition)
	{
		Node2D enemyInstance = enemyScene.Instantiate<Node2D>();
		enemyInstance.Position = spawnPosition;
		AddChild(enemyInstance);
	}
}

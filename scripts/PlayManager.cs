using Godot;
using System;

public partial class PlayManager : Node2D
{
	private Label problemLabel;
	private PackedScene enemyScene;
	private Timer spawnTimer;
	
	private int correctAnswer;

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
		spawnTimer.Timeout += SpawnEnemy;
	}

	private void GenerateNewProblem()
	{
		// Generate two numbers for a simple addition
		int a = GD.RandRange(10, 50);
		int b = GD.RandRange(10, 50);

		correctAnswer = a + b;
		problemLabel.Text = $"{a} + {b}";
	}

	private void SpawnEnemy()
	{
		var enemyInstance = enemyScene.Instantiate<EnemyMovement>();
		enemyInstance.Position = new Vector2(1000, 150);

		enemyInstance._Ready();
		// Generate a random value
		int randomValue = GD.RandRange(10, 99);
		enemyInstance.SetLabelValue(randomValue.ToString());

		AddChild(enemyInstance);
	}

}

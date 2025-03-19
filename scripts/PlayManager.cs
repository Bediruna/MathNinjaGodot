using Godot;
using System;

public partial class PlayManager : Node2D
{	
	private Label problemLabel;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		problemLabel = GetNode<Label>("ProblemLabel");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		problemLabel.Text = "Updated text at time: " + Time.GetTicksMsec();
	}
}

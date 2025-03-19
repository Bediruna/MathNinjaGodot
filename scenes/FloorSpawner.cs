using Godot;

public partial class FloorSpawner : Sprite2D
{
	[Export] public float ScrollSpeed = 200f;

	private float _textureWidth;

	public override void _Ready()
	{
		_textureWidth = Texture.GetWidth() * Scale.X;
	}

	public override void _Process(double delta)
	{
		Position = new Vector2(Position.X - ScrollSpeed * (float)delta, Position.Y);

		if (Position.X <= -_textureWidth)
		{
			Position = new Vector2(0, Position.Y);
		}
	}
}

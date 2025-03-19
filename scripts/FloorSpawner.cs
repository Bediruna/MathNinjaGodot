using Godot;

public partial class FloorSpawner : Sprite2D
{
	[Export] public float ScrollSpeed = 200f;

	private float _textureWidth;
	private Sprite2D _secondFloor;

	public override void _Ready()
	{
		_textureWidth = Texture.GetWidth() * Scale.X;

		// Create a second floor sprite instance
		_secondFloor = new Sprite2D();
		_secondFloor.Texture = Texture;
		_secondFloor.Position = new Vector2(Position.X + _textureWidth, Position.Y);
		_secondFloor.Scale = Scale;
		AddChild(_secondFloor);
	}

	public override void _Process(double delta)
	{
		float movement = ScrollSpeed * (float)delta;
		Position = new Vector2(Position.X - movement, Position.Y);
		_secondFloor.Position = new Vector2(_secondFloor.Position.X - movement, _secondFloor.Position.Y);

		if (Position.X <= -_textureWidth)
			Position = new Vector2(_secondFloor.Position.X + _textureWidth, Position.Y);

		if (_secondFloor.Position.X <= -_textureWidth)
			_secondFloor.Position = new Vector2(Position.X + _textureWidth, _secondFloor.Position.Y);
	}
}

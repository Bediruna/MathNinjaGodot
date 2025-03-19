using Godot;

public partial class FloorManager : Node2D
{
	[Export] public float ScrollSpeed = 500f;
	private Sprite2D _floorTexture1;
	private Sprite2D _floorTexture2;
	private float _textureWidth;

	public override void _Ready()
	{
		_floorTexture1 = GetNode<Sprite2D>("FloorTexture1");
		_floorTexture2 = GetNode<Sprite2D>("FloorTexture2");

		_textureWidth = _floorTexture1.Texture.GetWidth() * _floorTexture1.Scale.X;

		_floorTexture1.Position = new Vector2(0, 0);
		_floorTexture2.Position = new Vector2(_textureWidth, 0);
	}

	public override void _Process(double delta)
	{
		float movement = ScrollSpeed * (float)delta;

		_floorTexture1.Position -= new Vector2(movement, 0);
		_floorTexture2.Position -= new Vector2(movement, 0);

		if (_floorTexture1.Position.X <= -_textureWidth)
			_floorTexture1.Position += new Vector2(_textureWidth * 2, 0);

		if (_floorTexture2.Position.X <= -_textureWidth)
			_floorTexture2.Position += new Vector2(_textureWidth * 2, 0);
	}
}

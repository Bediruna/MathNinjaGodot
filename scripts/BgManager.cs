using Godot;

public partial class BgManager : Node2D
{
	[Export] public float BaseScrollSpeed = 100f;
	private Sprite2D[] _layers;
	private Sprite2D[] _layersDuplicates;
	private float[] _layerWidths;

	public override void _Ready()
	{
		int layerCount = 8;
		_layers = new Sprite2D[layerCount];
		_layersDuplicates = new Sprite2D[layerCount];
		_layerWidths = new float[layerCount];

		for (int i = 0; i < layerCount; i++)
		{
			_layers[i] = GetNode<Sprite2D>($"layer{i + 1}");
			_layersDuplicates[i] = (Sprite2D)_layers[i].Duplicate();
			AddChild(_layersDuplicates[i]);

			_layerWidths[i] = _layers[i].Texture.GetWidth() * _layers[i].Scale.X;
			_layersDuplicates[i].Position = _layers[i].Position + new Vector2(_layerWidths[i], 0);
		}
	}

	public override void _Process(double delta)
	{
		for (int i = 0; i < _layers.Length; i++)
		{
			float movement = BaseScrollSpeed * (float)delta * (1f / (i + 1)); // Further layers move slower

			_layers[i].Position -= new Vector2(movement, 0);
			_layersDuplicates[i].Position -= new Vector2(movement, 0);

			if (_layers[i].Position.X <= -_layerWidths[i])
				_layers[i].Position += new Vector2(_layerWidths[i] * 2, 0);

			if (_layersDuplicates[i].Position.X <= -_layerWidths[i])
				_layersDuplicates[i].Position += new Vector2(_layerWidths[i] * 2, 0);
		}
	}
}

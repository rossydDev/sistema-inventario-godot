using Godot;

public class Item {
	public string Nome { get; private set; }
	public float Peso { get; private set; }

	public Texture2D Texture {get; private set;}

	public Item(string Nome, float Peso, Texture2D Texture)
	{
		this.Nome = Nome;
		this.Peso = Peso;
		this.Texture = Texture;
	}
}

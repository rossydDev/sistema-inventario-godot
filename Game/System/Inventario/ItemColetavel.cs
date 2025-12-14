using Godot;
using System;

public partial class ItemColetavel : Area2D
{
	[Export] float peso = 5f;

	Texture2D itemTexture;
	String nome;


  public override void _Ready()
  {
    itemTexture = GetNode<Sprite2D>("%Texture").Texture;
		GenerateName();
	}


  public override void _InputEvent(Viewport viewport, InputEvent @event, int shapeIdx)
  {
    if(@event.IsActionPressed("Select"))
		{
			Item novoItem = GetItem();
			GameEvents.OnItemColetado?.Invoke(novoItem);
		}
  }

	public Item GetItem()
	{
		QueueFree();

		return new Item(nome, peso, itemTexture);
	}

	void GenerateName()
	{
		foreach(char c in Name.ToString())
		{
			if (Char.IsDigit(c))
			{
				break;
			}
			else
			{
				nome += c;
			}
		}
	}

}



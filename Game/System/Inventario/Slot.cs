using Godot;
using System;
using System.ComponentModel;

public partial class Slot : Panel
{
	 [Export] TextureRect texture;
	 [Export]Label name;

	 Item item;

	public void SetItem(Item item)
	{
		this.item = item;

		name.Text = this.item.Nome;
		texture.Texture = this.item.Texture;
	}

	public bool HasItem()
	{
		return item != null;
	}

}

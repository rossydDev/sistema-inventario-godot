using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

public partial class InventarioController : Node
{
	[Export] public PackedScene slot;
	[Export] public GridContainer grid;
	Inventario inventario;
	List<Slot> slots;

	Texture2D prevTexture = GD.Load<Texture2D>("res://icon.svg");

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		slots = new List<Slot>();

		inventario = new Inventario(50);
		inventario.OnItemAdicionado += OnInventarioItemAdicionado;

		Item espada = new Item("Espada", 25f, prevTexture);

		for(int i = 0; i < 5; i++)
		{
			Slot newSlot = slot.Instantiate<Slot>();
			slots.Add(newSlot);
			grid.AddChild(newSlot);
		}

		if (inventario.AdicionarItem(espada))
		{
			GD.Print("O item foi adicionado com sucesso!");
		}

	}


	public void OnInventarioItemAdicionado(Item itemAdicionado)
	{
		foreach(Slot slot in slots)
		{
			if (!slot.HasItem())
			{
				slot.SetItem(itemAdicionado);
				break;
			}
		}
	}
}

using Godot;
using System.Collections.Generic;

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
		GameEvents.OnItemColetado += OnItemColetado;

		for(int i = 0; i < 5; i++)
		{
			Slot newSlot = slot.Instantiate<Slot>();
			slots.Add(newSlot);
			grid.AddChild(newSlot);
		}
	}

  public override void _ExitTree()
  {
    inventario.OnItemAdicionado -= OnInventarioItemAdicionado;
		GameEvents.OnItemColetado -= OnItemColetado;
  }


	public void OnItemColetado(Item novoItem)
	{
		inventario.AdicionarItem(novoItem);
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

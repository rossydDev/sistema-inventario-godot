using System;
using System.Collections.Generic;

public class Inventario
{
	public event Action<Item> OnItemAdicionado;
	public float CapacidadeMaxima { get; private set;}
	float capacidadeAtual;
	List<Item> items;

	public Inventario(float CapacidadeMaxima)
	{
		this.CapacidadeMaxima = CapacidadeMaxima;
		capacidadeAtual = 0;
		this.items = new List<Item>();
	}

	public bool AdicionarItem(Item novoItem)
	{
		float prevCapacidadeAtual = capacidadeAtual;

		prevCapacidadeAtual += novoItem.Peso;

		if (prevCapacidadeAtual > CapacidadeMaxima)
		{
			return false;
		}
		else
		{
			capacidadeAtual = prevCapacidadeAtual;
			items.Add(novoItem);
			OnItemAdicionado?.Invoke(novoItem);

			return true;
		}
	}
}
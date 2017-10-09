/*
 *  Base Itemtype class
 *  Held in ItemStacks
 *  
 */

using UnityEngine;

public class Item {

	public Inventory Inventory;

	// max stack size
	public virtual int StackSize { get { return 99; } }

	// current size of stack
	public int Quantity { get; set; }

	// returns if empty stack
	public bool Empty {	get { return Quantity == 0;	} }

	// name of item
	public virtual string Name { get { return "Base Item"; } }

	public virtual string Description { get { return "Description"; } }

	// if item should be considered nonexistent when quantity is 0
	public virtual bool NullifyOnEmpty { get { return true; } }

	/*
	 * TODO add properties
	 */

	public Item(int quantity) {
		// set properties
		Quantity = quantity;
	}

	public override string ToString() {
		if(Empty && NullifyOnEmpty) {
			return "None";
		}
		return string.Format("{0}: {1}/{2}",Name,Quantity,StackSize);
	}
}

/*
 *  Base item stack class
 *  Exists solely within inventories
 *      - physical form not an Item
 *  
 */

using UnityEngine;

public class Item {

	public Inventory Inventory;

	// max stack size
	public readonly int StackSize;

	// current size of stack
	public int Quantity;

	// returns if empty stack
	public bool Empty {
		get {
			return Quantity == 0;
		}
	}

	/*
	 * TODO add properties
	 */

	public Item(int quantity, int stackSize = 99) {
		// set properties
		Quantity = quantity;
		StackSize = stackSize;
	}

	// transfer the amount specified from this stack into another
	// positive amount values add onto other
	// negative amount values remove from other
	public void Transfer(Item other, int amount) {
		if(amount == 0)
			return;
		if (amount < 0) {
			other.Transfer(this,-amount);
			return;
		}
		int transferAmount = amount;

		transferAmount = Mathf.Min(other.StackSize - other.Quantity,Quantity,transferAmount);

		Quantity -= transferAmount;
		other.Quantity += transferAmount;
	}
}

/*
 *  Base item stack class
 *  Exists solely within inventories
 *      - physical form not an Item
 *  
 */

using UnityEngine;

public class Item {

	// max stack size
	public readonly int StackSize; 

	// current size of stack
	public int Quantity {
		get {
			return Quantity;
		}
		set {
			Quantity = (int)Mathf.Clamp(value,0,StackSize);
		}
	}
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
		int transferAmount = amount;
		if(amount > 0) { // positive - add to other, remove from this
			if(amount > Quantity) { // if amount is greater than can be removed from this
				transferAmount = Mathf.Min(transferAmount,StackSize - Quantity); // choose whichever is smaller: original amount difference or current quantity
			}
			if (amount > other.StackSize - other.Quantity) {
				// will overfill other, clamp to other's stack size
				transferAmount = Mathf.Min(transferAmount, other.StackSize - other.Quantity);
			}
		} else if(amount < 0) { // negative, remove from other, add to this
			// TODO
		} else {
			// nothing
		}

		Quantity -= transferAmount;
		other.Quantity += transferAmount;
	}

	// split this stack into another of type T with quantity Remove
	public Item Split<T>(int remove) {
		
		if (Quantity > remove) {
			Quantity -= remove;
			return new Item(remove,StackSize);
		}
		return null;
	}
}

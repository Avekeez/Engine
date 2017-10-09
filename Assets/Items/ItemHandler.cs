using UnityEngine;

public static class ItemHandler {

	public static void Add(this Item thisItem, int amount) {
		thisItem.Quantity += amount;
		if(thisItem.Quantity > thisItem.StackSize) {
			thisItem.Quantity = thisItem.StackSize;
		}
	}
	public static void Remove(this Item thisItem,int amount) {
		thisItem.Quantity -= amount;
		if(thisItem.Quantity < 0) {
			thisItem.Quantity = 0;
		}
	}

	// transfer the amount specified from thisItem into otherItem
	// positive amount values add onto other
	// negative amount values remove from other
	public static void Transfer(Item thisItem,Item otherItem,int amount) {
		if(amount == 0 || thisItem.Quantity == 0 || otherItem.Quantity == 0)
			return;
		if(amount < 0) {
			Transfer(otherItem,thisItem,-amount);
			return;
		}
		int transferAmount = amount;

		transferAmount = Mathf.Min(otherItem.StackSize - otherItem.Quantity,thisItem.Quantity,transferAmount);

		thisItem.Remove(transferAmount);
		otherItem.Add(transferAmount);
	}

	public static void Merge(Item thisItem,Item otherItem) {
		if(thisItem.GetType() == otherItem.GetType()) {
			// good, keep merging

			Transfer(thisItem,otherItem,thisItem.Quantity);
		}
	}
}

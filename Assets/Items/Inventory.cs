using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : IEnumerable {
	public Item[] Items;

	public Inventory (int size) {
		Items = new Item[size];
		for (int i = 0; i < size; i++) {
			Items[i] = null;
		}
	}

	public IEnumerator GetEnumerator() {
		return Items.GetEnumerator();
	}

	public int Count {
		get {
			return Items.Length;
		}
	}

	public Item this[int slot] { // NO set, only get
		get {
			return Items[slot];
		}
	}

	// places the item into the first empty slot
	public void Place (Item item) {
		for(int i = 0; i < Count; i++) {
			if(Items[i] == null) {
				Place(item,i);
				return;
			}
		}
	}

	// places the item into the specified slot (if empty)
	public void Place (Item item, int spot) {
		if(spot >= Count || spot < 0)
			return;
		if(Items[spot] == null) {
			Items[spot] = item;
			item.Inventory = this;
			return;
		}
	}

	// returns the item currently in the spot and removes it from the inventory
	public Item Remove(int spot) {
		if(spot >= Count || spot < 0)
			return null; // can't remove what doesn't exist, dummy
		Item toReturn = Items[spot];
		toReturn.Inventory = null;
		Items[spot] = null;
		return toReturn;
	}

	public Item RemoveFirst() {
		for (int i = 0; i < Count; i++) {
			if(Items[i] != null) {
				return Remove(i);
			}
		}
		return null;
	}

	public Item RemoveLast() {
		for(int i = Count-1; i >= 0; i--) {
			if(Items[i] != null) {
				return Remove(i);
			}
		}
		return null;
	}

	public override string ToString() {
		string toReturn = "";
		for (int i = 0; i < Count; i++) {
			bool exists = this[i] != null;
			toReturn += String.Format("slot: {0} \titem: {1} \tquant: {2}\n",i,exists ? this[i].Name : "none",exists ? this[i].Quantity.ToString() : "none");
		}
		return toReturn;
	}
}

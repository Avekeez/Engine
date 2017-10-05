using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {
	public Item[] Items;

	public Inventory (int size) {
		Items = new Item[size];
		for (int i = 0; i < size; i++) {
			Items[i] = null;
		}
	}

	public void Place (Item item, int spot = -1) { // if negative place in first empty slot
		if(spot > Items.Length || spot < -1)
			return;
		if (spot == -1) {
			for (int i = 0; i < Items.Length; i++) {
				if (Items[i] == null) {
					Items[i] = item;
					return;
				}
			}
		} else {
			if (Items[spot] == null) {
				Items[spot] = item;
				item.Inventory = this;
			}
		}
	}
}

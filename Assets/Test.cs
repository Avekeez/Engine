using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	Item item1;
	Item item2;

	// Use this for initialization
	void Start () {
		item1 = new Item(0,99);
		item2 = new Item(10,99);
		print(string.Format("item1: {0} - item2: {1}",item1.Quantity,item2.Quantity));
		item1.Transfer(item2,-20);
		print(string.Format("item1: {0} - item2: {1}",item1.Quantity,item2.Quantity));
	}
}

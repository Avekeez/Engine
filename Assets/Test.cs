using UnityEngine;

public class Test : MonoBehaviour {

	Item item1;
	Item item2;
	Inventory inv1;
	Inventory inv2;

	// Use this for initialization
	void Start () {

		item1 = new ItemGasdad(10);
		item2 = new ItemGasdad(40);
		print(string.Format("{0} - {1}",item1.ToString(),item2.ToString()));
		ItemHandler.Transfer(item1, item2,-20);
		print(string.Format("{0} - {1}",item1.ToString(),item2.ToString()));

		ItemNotGasdad bad = new ItemNotGasdad();
		ItemHandler.Merge(item1,item2);
		print(string.Format("{0} - {1}",item1,item2));


		/*
		inv1 = new Inventory(5);
		inv2 = new Inventory(2);
		print(inv1.ToString());
		inv1.Place(new Item(50,"gasdad"), 4);
		print(inv1.ToString());
		Item gasdad = inv1.Remove(4);
		print(inv1.ToString());
		print(gasdad.Name + " " + gasdad.Quantity);
		*/
	}
}

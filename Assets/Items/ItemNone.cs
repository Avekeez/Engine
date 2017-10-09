using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemNone : Item {
	public override string Name {
		get {
			return "NONE";
		}
	}

	public override int StackSize {
		get {
			return 0;
		}
	}

	public ItemNone() : base(0) { }

	public override string ToString() {
		return Name;
	}
}

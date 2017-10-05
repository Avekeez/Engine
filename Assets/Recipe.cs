public class Recipe {
	public struct Ingredient<T> {
		T value;
		public Ingredient (T value) {
			this.value = value;
		}
	}
}

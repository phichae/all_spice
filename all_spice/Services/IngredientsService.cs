namespace all_spice.Services;

public class IngredientsService
{
    private readonly IngredientsRepository _repo;
    public IngredientsService(IngredientsRepository repo)
    {
        _repo = repo;
    }
    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
        Ingredient ingredient = _repo.CreateIngredient(ingredientData);
        return ingredient;
    }

    internal string DeleteIngredient(int ingredientId)
    {
        int rows = _repo.DeleteIngredient(ingredientId);
        if(rows > 1) throw new Exception($"Something went wrong.");
        return $"This ingredient has been deleted.";
    }

    internal List<Ingredient> GetRecipeIngredients(int recipeId)
    {
        List<Ingredient> ingredients = _repo.GetRecipeIngredients(recipeId);
        return ingredients;
    }
}
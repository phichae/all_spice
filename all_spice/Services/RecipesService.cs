namespace all_spice.Services;

public class RecipesService
{
    private readonly RecipesRepository _repo;

    public RecipesService(RecipesRepository repo)
    {
        _repo = repo;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
        Recipe recipe = _repo.CreateRecipe(recipeData);
        return recipe;
    }


    internal List<Recipe> GetAllRecipes()
    {
        List<Recipe> recipes = _repo.GetAllRecipes();
        return recipes;
    }

    internal Recipe GetById(int recipeId)
    {
        Recipe recipe = _repo.GetById(recipeId);
        if(recipe == null) throw new Exception($"no recipe at id:{recipeId}, I swear to all that is holy, I didn't copy and paste this.");
        return recipe;
    }
    internal string DeleteRecipe(int recipeId, string userId)
    {
        Recipe recipe = GetById(recipeId);
        if(recipe.creatorId != userId) throw new Exception("Not your recipe.");
        int rows = _repo.DeleteRecipe(recipeId);
        if(rows > 1) throw new Exception("This messed up bad");
        return $"This reciped has been deleted.";
    }

    internal Recipe EditRecipe(Recipe recipeData, string userId)
    {
        Recipe original = GetById(recipeData.id);

        original.title = recipeData.title != null ? recipeData.title : original.title;
        original.instructions = recipeData.instructions != null ? recipeData.instructions : original.instructions;
        original.img = recipeData.img != null ? recipeData.img : original.img;
        original.category = recipeData.category != null ? recipeData.category : original.category;

        _repo.EditRecipe(original);
        return original;
    }
}

namespace all_spice.Services;

public class FavoritesService
{
    private readonly FavoritesRepository _repo;

    public FavoritesService(FavoritesRepository repo)
    {
        _repo = repo;
    }

    internal Favorite FavoriteRecipe(Favorite favData)
    {
        Favorite favorite = _repo.FavoriteRecipe(favData);
        return favorite;
    }

    internal List<FavoriteRecipe> getFavRecipes(string userId)
    {
        List<FavoriteRecipe> favRecipes = _repo.getFavRecipes(userId);
        return favRecipes;
    }

}
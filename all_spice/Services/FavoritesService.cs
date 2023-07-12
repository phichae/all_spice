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

    internal Favorite GetById(int favId)
    {
        Favorite fav = _repo.getById(favId);
        if (fav == null) new Exception("Invalid id");
        return fav;
    }

    internal List<FavoriteRecipe> getFavRecipes(string userId)
    {
        List<FavoriteRecipe> favRecipes = _repo.getFavRecipes(userId);
        return favRecipes;
    }
    internal void Delete(int favId, Account userInfo)
    {
        Favorite fav = GetById(favId);
        if(fav.accountId != userInfo.Id) new Exception("This is not your favorite to delete.");
        int rows = _repo.Delete(favId);
        if (rows > 1) new Exception("Something went very wrong.");
    }

}
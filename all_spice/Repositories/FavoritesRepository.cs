namespace all_spice.Repositories;

public class FavoritesRepository
{
    private readonly IDbConnection _db;
    public FavoritesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Favorite FavoriteRecipe(Favorite favData)
    {
        string sql = @"
        INSERT INTO favorites
        (accountId, recipeId)
        VALUES
        (@accountId, @recipeId);
        SELECT LAST_INSERT_ID()
        ;";
        int lastInsertId = _db.ExecuteScalar<int>(sql, favData);
        favData.id = lastInsertId;
        return favData;
    }

    internal List<FavoriteRecipe> getFavRecipes(string userId)
    {
        string sql = @"
        SELECT
        fav.*,
        rec.*,
        acc.*,
        FROM favorites fav
        JOIN recipes rec ON rec.id = fav.recipeId
        JOIN accounts acc ON acc.Id = fav.accountId
        WHERE fav.accountId = @userId
        ;";
        List<FavoriteRecipe> favRecipes = _db.Query<Favorite, FavoriteRecipe, Account, FavoriteRecipe>(sql, (favorite, recipe, account) => 
        {
            recipe.favId = favorite.id;
            recipe.Creator = account;
            return recipe;
        }, new { userId }).ToList();
        return favRecipes;
    }
}

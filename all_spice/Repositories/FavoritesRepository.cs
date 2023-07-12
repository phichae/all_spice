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

    internal Favorite getById(int favId)
    {
        string sql = @"
        SELECT * FROM favorites WHERE favorites.id = @favId
        ;";
        var fav = _db.Query<Favorite>(sql, new { favId }).FirstOrDefault();
        return fav;
    }

    internal List<FavoriteRecipe> getFavRecipes(string userId)
    {
        string sql = @"
        SELECT
        fav.*,
        rec.*,
        acc.*
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
    internal int Delete(int favId)
    {
        string sql = @"
        DELETE FROM favorites
        WHERE id = @favId
        LIMIT 1
        ;";
        int rows = _db.Execute(sql, new { favId });
        return rows;
    }
}

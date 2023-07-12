namespace all_spice.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly FavoritesService _favoritesService;
        private readonly Auth0Provider _auth0;
        public FavoritesController(FavoritesService favoritesService, Auth0Provider auth0)
        {
            _favoritesService = favoritesService;
            _auth0 = auth0;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Favorite>> FavoriteRecipe([FromBody] Favorite favData)
        {
            try
            {
                Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
                favData.accountId = userInfo.Id;
                Favorite newFav = _favoritesService.FavoriteRecipe(favData);
                return Ok(newFav);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{favId}")]
        [Authorize]
        public async Task<ActionResult<string>> Delete(int favId)
        {
            try
            {
                Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
                _favoritesService.Delete(favId, userInfo);
                return Ok("Favorite was deleted.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }

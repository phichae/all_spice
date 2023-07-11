namespace all_spice.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly FavoritesService _favoritesService;
  private readonly Auth0Provider _auth0Provider;

  public AccountController(AccountService accountService, FavoritesService favoritesService, Auth0Provider auth0Provider)
  {
    _accountService = accountService;
    _auth0Provider = auth0Provider;
    _favoritesService = favoritesService;
  }

  [HttpGet]
  [Authorize]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateProfile(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("favorites")]
  [Authorize]
  public async Task<ActionResult<List<FavoriteRecipe>>> getFavRecipes()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<FavoriteRecipe> myFavRecipes = _favoritesService.getFavRecipes(userInfo.Id);
      return Ok(myFavRecipes);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}


namespace all_spice.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientsService _ingredientsService;
        public IngredientsController(IngredientsService ingredientsService)
        {
            _ingredientsService = ingredientsService;
        }

        [HttpPost]
        public ActionResult<Ingredient> CreateIngredient([FromBody] Ingredient ingredientData)
        {
            try
            {
                Ingredient newIngredient = _ingredientsService.CreateIngredient(ingredientData);
                return Ok(newIngredient);
            }
            catch (Exception e)
            {
                return new ActionResult<Ingredient>(BadRequest(e.Message));
            }
        }
    }

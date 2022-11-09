using BasketApi.Models;
using BasketApi.Respository;
using Microsoft.AspNetCore.Mvc;

namespace BasketApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketController : ControllerBase
    {
       
        private readonly ILogger<BasketController> _logger;
        private readonly IBasketRepository _cartRepository;

        public BasketController(ILogger<BasketController> logger, IBasketRepository cartRepository)
        {
            _cartRepository = cartRepository;
            _logger = logger;
        }

        /// <summary>
        /// Get cart information 
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCartInformation")]
        public IEnumerable<string> GetCartItems([FromQuery] string cartId)
        {
            //return _cartRepository.GetCartÌtems(cartId);
            return _cartRepository.GetItemsCartInCart(cartId);
        }

        ///// <summary>
        ///// Get cart information
        ///// </summary>
        ///// <param name="cartId"></param>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("GetCartInformation")]
        //public CartVM GetCartInformation([FromQuery] string cartId)
        //{
        //    return _cartRepository.GetCartModel(cartId);
        //}

        /// <summary>
        /// Add item to cart
        /// </summary>
        /// <param name="cartDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddCartItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody] CartDto cartDto)
        {
            try
            {
                _cartRepository.AddCartItem(cartDto.CartId, cartDto.cartItem);
                return Ok();
            }
            catch (BadHttpRequestException)
            {
                return BadRequest();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete item from cart
        /// </summary>
        /// <param name="cartDto"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteCartItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Delete([FromBody] CartDto cartDto)
        {
            try
            {
                _cartRepository.DeleteCartItem(cartDto.CartId, cartDto.ItemId);
                return Ok();
            }
            catch (BadHttpRequestException)
            {
                return BadRequest();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
        }
    }
}
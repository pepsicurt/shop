using Microsoft.AspNetCore.Mvc;

namespace exam.Controllers
{
    [ApiController]
    [Route("api/shops")]
    public class ShopController : ControllerBase
    {
        private List<Shop> shops = new List<Shop>();
        private int nextId;

        public object GetShopById { get; private set; }

        public ShopController()
        {
            shops = new List<Shop>();
            nextId = 1;
        }

        [HttpGet]
        public IActionResult GetAllShops()
        {
            return Ok(shops);
        }
        [HttpGet("{id}")]
        public IActionResult AddShop([FromBody]Shop shop)
        {
            shop.Id = nextId++;
            shops.Add(shop);
            return
            CreatedAtAction(nameof(GetShopById), new { id = shop.Id }, shop);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateShop (int id, [FromBody]Shop updatedShop)
        {
            var shop = shops.FirstOrDefault(s => s.Id == id);
            if(shop == null)
            {
                return NotFound();
            }

            shop.Name = updatedShop.Name;
            shop.Owner = updatedShop.Owner;
            shop.PhoneNumber = updatedShop.PhoneNumber;

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteShop (int id)
        {
            var shop = shops.FirstOrDefault(s => s.Id == id);
            if (shop == null)
            {
                return NotFound();

            }

            shops.Remove(shop);
            return NoContent() ;
        }
    }
       
    };

       
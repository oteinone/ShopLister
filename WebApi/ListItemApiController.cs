using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopLister.Model;

namespace ShopLister.Api
{
    [Route("api/listitem")]
    public class ListItemApiController : Controller
    {
        protected ShopListerOperations Ops { get; set; }

        public ListItemApiController(ShopListerOperations ops) 
        {
            Ops = ops;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ListItem> Get(string id)
        {
            return await Ops.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ListItem item)
        {
            if (ModelState.IsValid)
                return Ok(await Ops.CreateAsync(item));
            else
                return BadRequest(ModelState);
            
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]ListItem item)
        {
            if (ModelState.IsValid)
                return StatusCode(201, await Ops.UpdateAsync(item));
            else
                return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromBody]string id)
        {
            await Ops.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet]
        [Route("GetCollection")]
        public async Task<IEnumerable<ListItem>> GetCollection(string orderBy = "Title")
        {
            return await Ops.GetCollectionAsync<string>(orderBy);
        }
    }
}
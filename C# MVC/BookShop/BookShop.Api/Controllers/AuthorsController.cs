using BookShop.Api.Infrastructure.Extensions;
using BookShop.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BookShop.Api.Models;
using static BookShop.Api.WebConstants;
using BookShop.Api.Infrastructure.Filters;

namespace BookShop.Api.Controllers
{
    public class AuthorsController : BaseController
    {
        private readonly IAuthorService authors;

        public AuthorsController(IAuthorService authors)
        {
            this.authors = authors;
        }

        [HttpGet(WithId)]
        public async Task<IActionResult> Get(int id)
        {
            return this.OkOrNotFound(await this.authors.Details(id));
        }

        //[HttpGet(WithId + "/books")]



        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromBody]AuthorRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = await this.authors.Create(model.FirstName, model.LastName);

            return Ok(id);
        }

    }
}

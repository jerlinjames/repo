using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CatalogueGalleryApp.Interfaces;
using CatalogueGalleryApp.Models;
using CatalogueGalleryApp.Repositories;

namespace CatalogueGalleryApp.Controllers
{
    public class ItemsController : ApiController
    {
        private readonly IItemsRepository _itemsRepository;

        public ItemsController()
        {
            _itemsRepository = new ItemsRepository();
        }

        //[HttpGet]
        //public IHttpActionResult GetCategoriesForUser(UserModel userId)
        //{
        //    return userId;
        //}


        [HttpPost]
        public IHttpActionResult AddNew(ItemModel newItem)
        {
            var addNew = _itemsRepository.AddNew(newItem);
            return Ok(addNew);
        }

        [HttpGet]
        public IHttpActionResult GetAllItemsForUser()
        {
            var items = _itemsRepository.GetAllItems();
            return Ok(items);
        }


























        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}
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
    public class UserController : ApiController
    {

        private readonly IUserRepository _UserRepository;

        public UserController()
        {
            _UserRepository = new UserRepository();
        }

        //[HttpGet]
        //public IHttpActionResult GetCategoriesForUser(UserModel userId)
        //{
        //    return userId;
        //}

        [HttpGet]
        public IHttpActionResult CheckIfUserExists(int? fbId)
        {
            var items = _UserRepository.CheckIfUserExists(fbId);
            return Ok(items);
        }


        [HttpPost]
        public IHttpActionResult AddNewUser(UserModel user)
        {
            var addNew = _UserRepository.AddNewUser(user);
            return Ok(addNew);
        }



    }
}

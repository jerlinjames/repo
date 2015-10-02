using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogueGalleryApp.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        
    }
}
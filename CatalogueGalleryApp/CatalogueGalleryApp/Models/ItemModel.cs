using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogueGalleryApp.Models
{
    public class ItemModel
    {

        //probably not like this..only need ID here not whole category model
        public ItemModel()
        {
            Category = new List<CategoryModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<CategoryModel> Category { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogueGalleryApp.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FbId { get; set; }
        public string FbEmail { get; set; }
        public string FbFirstName { get; set; }
        public string FbLastName { get; set; }
        public string FbName { get; set; }
        public string FbDateOfBirth { get; set; }
        public string FbGender { get; set; }
        
    }
}
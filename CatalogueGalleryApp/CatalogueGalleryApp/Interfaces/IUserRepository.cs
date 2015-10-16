using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogueGalleryApp.Models;

namespace CatalogueGalleryApp.Interfaces
{
    public interface IUserRepository
    {
        bool CheckIfUserExists(string fbId);
        bool AddNewUser(UserModel user); 
        
    }
}

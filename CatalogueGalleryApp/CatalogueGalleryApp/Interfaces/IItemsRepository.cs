using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CatalogueGalleryApp.Models;

namespace CatalogueGalleryApp.Interfaces
{
    public interface IItemsRepository
    {
        bool AddNew(ItemModel newItem);
        IEnumerable<ItemModel> GetAllItems();


    }

   
}

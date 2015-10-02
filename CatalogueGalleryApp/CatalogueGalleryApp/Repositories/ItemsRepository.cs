using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CatalogueGalleryApp.Helpers;
using CatalogueGalleryApp.Interfaces;
using CatalogueGalleryApp.Models;
using Dapper;


namespace CatalogueGalleryApp.Repositories
{
    public class ItemsRepository: IItemsRepository
    {
        public bool AddNew(ItemModel newItem)
        {
            
            using (var conn = ConnectionSettings.GetSqlConnection())
            {
                const string sql = @"";
                //TODO create a storeedProc that adds the new Item to the db
                var newItemCreated = conn.Query<int>(sql, new { newItem }).SingleOrDefault();
                return newItemCreated > 0;
            }
        }

        public IEnumerable<ItemModel> GetAllItems()
        {
            using (var conn = ConnectionSettings.GetSqlConnection())
            {
                const string sql = @"select i.*, c.* from Items I
join Categories c on i.CategoryId = c.Id";
                

                var listOfItemsForUser = conn.QueryParentChild<ItemModel, CategoryModel, int>(sql,
                    itemModel => itemModel.Id, itemModel => itemModel.Category, null);

                return listOfItemsForUser;
            }
        }


    }
}
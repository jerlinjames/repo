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
    public class UserRepository: IUserRepository
    {
        public bool CheckIfUserExists(int? fbId)
        {
            using (var conn = ConnectionSettings.GetSqlConnection())
            {
                const string sql = @"select * from [Users] where FbId = @FbId";
                var userExists = conn.Query(sql, new {fbId}).Any();
                return userExists;
            }
        }

        public bool AddNewUser(UserModel user)
        {
            using (var conn = ConnectionSettings.GetSqlConnection())
            {
                const string sql = @"
INSERT INTO [dbo].[Users]
           ([FbId]
           ,[FbFirstName]
           ,[FbLastName]
           ,[FbName]
           ,[FbEmail]
           ,[FbDateOfBirth]
           ,[FbGender]
           ,[UserFirstLoggedInDate]
           ,[UserLastLoginDate]
           ,[UserDisplayName])
     VALUES
            (@FbId,
            @FbFirstName,
            @FbLastName,
            @FbName,
            @FbEmail,
            @FbDateOfBirth,
            @FbGender,
            @UserFirstLoggedInDate,
            @UserLastLoginDate,
            @UserDisplayName)
";
                var userExists = conn.Query(sql, new { user }).Single();
                return userExists > 0;
            }
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CatalogueGalleryApp.Helpers
{
    public class ConnectionSettings
    {
        private const string CX_NAME = "CatalogueGallery";

        protected internal static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(GetSqlConnectionString(CX_NAME));
        }

        private static string GetSqlConnectionString(string connectionName)
        {
            var cx = System.Configuration.ConfigurationManager.ConnectionStrings[connectionName];
            if (cx == null || string.IsNullOrEmpty(cx.ConnectionString))
            {
                return null;
            }
            return cx.ConnectionString;
        }


    }
}
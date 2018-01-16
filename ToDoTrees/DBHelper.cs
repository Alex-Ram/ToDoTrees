using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoTrees
{
    static class DBHelper
    {
        /// <summary>
        /// Returns the connection string required to connect to the database.
        /// </summary>
        /// <returns>The connection string.</returns>
        public static SqlConnection GetConnection()
        {
            //            return new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=ToDoTreesDB;Integrated Security=True");
            return new SqlConnection("Data Source=localhost; Initial Catalog=ToDoTreesDB; Trusted_Connection=True;");
        }
    }
}

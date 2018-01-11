using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoTrees
{
    static class CategoryDB
    {
        #region Create

        /// <summary>
        /// Creates a new row in the Categories table in the database from a category object.
        /// </summary>
        /// <param name="c">A category object. The CategoryID should be null, and the ParentID should not.</param>
        /// <returns>Return true if one and only one row was successfully added to the Categories table.</returns>
        public static bool Create(Category c)
        {
            return Create(c.ParentID, c.Name);
        }

        /// <summary>
        /// Creates a new row in the Categories table in the database. [Base Version]
        /// </summary>
        /// <param name="parentID">The CategoryID of the parent category. Although a nullable int, it will throw an exception if null.</param>
        /// <param name="name">The name of the category.</param>
        /// <returns>Return true if one and only one row was successfully added to the Categories table.</returns>
        public static bool Create(int? parentID, string name)
        {
            SqlCommand insertCmd = new SqlCommand
            {
                CommandText = "INSERT INTO Categories(ParentID, Name) VALUES(@pid, @name)"
            };

            insertCmd.Parameters.AddWithValue("@pid", parentID ?? throw new ArgumentException());
            insertCmd.Parameters.AddWithValue("@name", name);

            using (insertCmd.Connection = DBHelper.GetConnection())
            {
                insertCmd.Connection.Open();

                if (insertCmd.ExecuteNonQuery() == 1)
                    return true;
                return false;
            }
        }

        #endregion

        #region Read

        /// <summary>
        /// Returns all rows in the Categories table from the database.
        /// </summary>
        /// <returns>A list of catergory objects</returns>
        public static List<Category> GetAllCategories()
        {
            SqlCommand selectCmd = new SqlCommand
            {
                CommandText = "SELECT CategoryID, ParentID, Name FROM Categories"
            };

            using (selectCmd.Connection = DBHelper.GetConnection())
            {
                selectCmd.Connection.Open();

                SqlDataReader reader = selectCmd.ExecuteReader();
                List<Category> resultList = new List<Category>();

                while (reader.Read())
                {
                    Category c = new Category(
                        (int)reader["CategoryID"],
                        (int?)reader["ParentID"],
                        (string)reader["Name"]
                    );
                    resultList.Add(c);
                }

                return resultList;
            }
        }

        /// <summary>
        /// Returns a single category from the database selected by CategoryID.
        /// </summary>
        /// <param name="ID">The CategoryID of the desired category.</param>
        /// <returns>A category object with the matching CategoryID.</returns>
        public static Category GetCategoryByID(int ID)
        {
            SqlCommand selectCmd = new SqlCommand
            {
                CommandText = "SELECT CategoryID, ParentID, Name FROM Categories WHERE CategoryID = @id"
            };

            selectCmd.Parameters.AddWithValue("@id", ID);

            using (selectCmd.Connection = DBHelper.GetConnection())
            {
                selectCmd.Connection.Open();

                SqlDataReader reader = selectCmd.ExecuteReader();
                reader.Read();
                Category c = new Category(
                    (int)reader["CategoryID"],
                    (int?)reader["ParentID"],
                    (string)reader["Name"]
                    );

                return c;
            }
        }

        /// <summary>
        /// Returns all categories whose ParentID matches the given category object's CategoryID.
        /// </summary>
        /// <param name="c">The parent category object</param>
        /// <returns>A list of category objects that are the child of the given parent category.</returns>
        public static List<Category> GetChildCategories(Category c)
        {
            return GetChildCategories(c.CategoryID);
        }

        /// <summary>
        /// Returns all categories whose ParentID matches the given CategoryID. [Base Version]
        /// </summary>
        /// <param name="ID">The CategoryID of the parent category.</param>
        /// <returns>A list of category objects that are the child of the given CategoryID.</returns>
        public static List<Category> GetChildCategories(int? ID)
        {
            SqlCommand selectCmd = new SqlCommand
            {
                CommandText = "SELECT CategoryID, ParentID, Name FROM Categories WHERE ParentID = @id"
            };

            selectCmd.Parameters.AddWithValue("@id", ID ?? throw new ArgumentException());

            using (selectCmd.Connection = DBHelper.GetConnection())
            {
                selectCmd.Connection.Open();

                SqlDataReader reader = selectCmd.ExecuteReader();
                List<Category> resultList = new List<Category>();

                while (reader.Read())
                {
                    Category c = new Category(
                        (int)reader["CategoryID"],
                        (int?)reader["ParentID"],
                        (string)reader["Name"]
                    );
                    resultList.Add(c);
                }

                return resultList;
            }
        }

        #endregion

        #region Update

        /// <summary>
        /// Updates a category with the CategoryID and Name from the given category object.
        /// </summary>
        /// <param name="c">The updated category object</param>
        /// <returns>Return true if one and only one row was successfully updated in the Categories table.</returns>
        public static bool UpdateName(Category c)
        {
            return UpdateName(c.CategoryID, c.Name);
        }

        /// <summary>
        /// Updates a category with the given CategoryID and Name. [Base Version]
        /// </summary>
        /// <param name="ID">The CategoryID of the category to update.</param>
        /// <param name="name">The new name of the category.</param>
        /// <returns>Return true if one and only one row was successfully updated in the Categories table.</returns>
        public static bool UpdateName(int? ID, string name)
        {
            SqlCommand updateCmd = new SqlCommand
            {
                CommandText = "UPDATE Categories SET Name = @name WHERE CategoryID = @id"
            };

            updateCmd.Parameters.AddWithValue("@id", ID ?? throw new ArgumentException());
            updateCmd.Parameters.AddWithValue("@name", name);

            using (updateCmd.Connection = DBHelper.GetConnection())
            {
                updateCmd.Connection.Open();

                if (updateCmd.ExecuteNonQuery() == 1)
                    return true;
                return false;
            }
        }

        #endregion

        #region Delete

        /// <summary>
        /// Deletes a category with the CategoryID of the given category object.
        /// </summary>
        /// <param name="c">The category object with the CategoryID of the category to delete.</param>
        /// <returns>Return true if one and only one row was successfully deleted in the Categories table.</returns>
        public static bool Delete(Category c)
        {
            return Delete(c.CategoryID);
        }

        /// <summary>
        /// Deletes a category with the given CategoryID.
        /// </summary>
        /// <param name="ID">The CategoryID of the category to delete.</param>
        /// <returns>Return true if one and only one row was successfully deleted in the Categories table.</returns>
        public static bool Delete(int? ID)
        {
            SqlCommand deleteCmd = new SqlCommand
            {
                CommandText = "DELETE FROM Categories WHERE CategoryID = @id"
            };

            deleteCmd.Parameters.AddWithValue("@id", ID ?? throw new ArgumentException());

            using (deleteCmd.Connection = DBHelper.GetConnection())
            {
                deleteCmd.Connection.Open();

                if (deleteCmd.ExecuteNonQuery() == 1)
                    return true;
                return false;
            }
        }

        #endregion
    }
}

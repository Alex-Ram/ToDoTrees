using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoTrees
{
    static class ToDoItemDB
    {
        #region Create

        /// <summary>
        /// Creates a new row in the ToDoItems table in the database from a ToDoItem object.
        /// </summary>
        /// <param name="i">A ToDoItem object. The ToDoItemID should be null.</param>
        /// <returns>Returns true if one and oly one row was successfully added to the ToDoItems table.</returns>
        public static bool Create(ToDoItem i)
        {
            return Create(i.CategoryID, i.Description, i.IsCompleted);
        }

        /// <summary>
        /// Creates a new row in the ToDoItems table in the database. [Base Version]
        /// </summary>
        /// <param name="categoryID">The CategoryID of the category the ToDoItem belongs to.</param>
        /// <param name="description">The description of the ToDoItem.</param>
        /// <param name="isCompleted"></param>
        /// <returns></returns>
        public static bool Create(int categoryID, string description, bool isCompleted)
        {
            SqlCommand insertCmd = new SqlCommand
            {
                CommandText = "INSERT INTO ToDoItems(CategoryID, Description, IsCompleted) VALUES(@categoryid, @desc, @isCompleted)"
            };

            insertCmd.Parameters.AddWithValue("@categoryid", categoryID);
            insertCmd.Parameters.AddWithValue("@desc", description);
            insertCmd.Parameters.AddWithValue("@isCompleted", isCompleted);

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
        /// Returns all rows in the ToDoItems table from the database.
        /// </summary>
        /// <returns>A list of ToDoItem objects.</returns>
        public static List<ToDoItem> GetAllToDoItems()
        {
            SqlCommand selectCmd = new SqlCommand
            {
                CommandText = "SELECT ToDoItemID, CategoryID, Description, IsCompleted FROM ToDoItems"
            };

            using (selectCmd.Connection = DBHelper.GetConnection())
            {
                selectCmd.Connection.Open();

                SqlDataReader reader = selectCmd.ExecuteReader();
                List<ToDoItem> resultList = new List<ToDoItem>();

                while (reader.Read())
                {
                    ToDoItem i = new ToDoItem(
                        (int)reader["ToDoItemID"],
                        (int)reader["CategoryID"],
                        (string)reader["Description"],
                        Convert.ToBoolean(reader["IsCompleted"])
                    );
                    resultList.Add(i);
                }

                return resultList;
            }
        }

        /// <summary>
        /// Returns a single ToDoItem from the database selected by ToDoItemID.
        /// </summary>
        /// <param name="ID">The ToDoItemID of the desired category.</param>
        /// <returns>A ToDoItem object with the matching ToDoItemID.</returns>
        public static ToDoItem GetToDoItemByID(int ID)
        {
            SqlCommand selectCmd = new SqlCommand
            {
                CommandText = "SELECT ToDoItemID, CategoryID, Description, IsCompleted FROM ToDoItems WHERE ToDoItemID = @id"
            };

            selectCmd.Parameters.AddWithValue("@id", ID);

            using (selectCmd.Connection = DBHelper.GetConnection())
            {
                selectCmd.Connection.Open();

                SqlDataReader reader = selectCmd.ExecuteReader();
                reader.Read();
                ToDoItem i = new ToDoItem(
                    (int)reader["ToDoItemID"],
                    (int)reader["CategoryID"],
                    (string)reader["Description"],
                    Convert.ToBoolean(reader["IsCompleted"])
                );

                return i;
            }
        }

        /// <summary>
        /// Returns all ToDoItems that belong to the given category object's CategoryID.
        /// </summary>
        /// <param name="c">The category object</param>
        /// <returns>A list of ToDoItem objects that belong to the matching CatergoryID.</returns>
        public static List<ToDoItem> GetToDoItemsByCategoryID(Category c)
        {
            return GetToDoItemsByCategoryID(c.CategoryID);
        }

        /// <summary>
        /// Returns all ToDoItems that belong to the given CategoryID. [Base Version]
        /// </summary>
        /// <param name="ID">The CategoryID.</param>
        /// <returns>A list of ToDoItem objects that belong to the matching CatergoryID.</returns>
        public static List<ToDoItem> GetToDoItemsByCategoryID(int? ID)
        {
            SqlCommand selectCmd = new SqlCommand
            {
                CommandText = "SELECT ToDoItemID, CategoryID, Description, IsCompleted FROM ToDoItems WHERE CategoryID = @id"
            };

            selectCmd.Parameters.AddWithValue("@id", ID ?? throw new ArgumentException());

            using (selectCmd.Connection = DBHelper.GetConnection())
            {
                selectCmd.Connection.Open();

                SqlDataReader reader = selectCmd.ExecuteReader();
                List<ToDoItem> resultList = new List<ToDoItem>();

                while (reader.Read())
                {
                    ToDoItem i = new ToDoItem(
                        (int)reader["ToDoItemID"],
                        (int)reader["CategoryID"],
                        (string)reader["Description"],
                        Convert.ToBoolean(reader["IsCompleted"])
                    );
                    resultList.Add(i);
                }

                return resultList;
            }
        }

        #endregion

        #region Update

        /// <summary>
        /// Updates a ToDoItem with the ToDoItemID and Description from the given ToDoItem object.
        /// </summary>
        /// <param name="i">The updated ToDoItem object.</param>
        /// <returns>Return true if one and only one row was successfully updated in the ToDoItems table.</returns>
        public static bool UpdateDescription(ToDoItem i)
        {
            return UpdateDescription(i.ToDoItemID, i.Description);
        }

        /// <summary>
        /// Updates a ToDoItem with the given ToDoItemID and Description. [Base Version]
        /// </summary>
        /// <param name="ID">The ToDoItemID of the ToDoItem to update.</param>
        /// <param name="desc">The new description of the ToDoItem</param>
        /// <returns>Return true if one and only one row was successfully updated in the ToDoItems table.</returns>
        public static bool UpdateDescription(int? ID, string desc)
        {
            SqlCommand updateCmd = new SqlCommand
            {
                CommandText = "UPDATE ToDoItems SET Description = @desc WHERE ToDoItemID = @id"
            };

            updateCmd.Parameters.AddWithValue("@id", ID ?? throw new ArgumentException());
            updateCmd.Parameters.AddWithValue("@desc", desc);

            using (updateCmd.Connection = DBHelper.GetConnection())
            {
                updateCmd.Connection.Open();

                if (updateCmd.ExecuteNonQuery() == 1)
                    return true;
                return false;
            }
        }

        /// <summary>
        /// Updates a ToDoItem with the given ToDoItemID and IsCompleted status from the given ToDoItem object.
        /// </summary>
        /// <param name="i">The updated ToDoItem object.</param>
        /// <returns>Return true if one and only one row was successfully updated in the ToDoItems table.</returns>
        public static bool UpdateIsCompleted(ToDoItem i)
        {
            return UpdateIsCompleted(i.ToDoItemID, i.IsCompleted);
        }

        /// <summary>
        /// Updates a ToDoItem with the given ToDoItemID and IsCompleted status.
        /// </summary>
        /// <param name="ID">The ToDoItemID of the ToDoItem to update.</param>
        /// <param name="isCompleted">The new IsCompleted status of the ToDoItem.</param>
        /// <returns>Return true if one and only one row was successfully updated in the ToDoItems table.</returns>
        public static bool UpdateIsCompleted(int? ID, bool isCompleted)
        {
            SqlCommand updateCmd = new SqlCommand
            {
                CommandText = "UPDATE ToDoItems SET IsCompleted = @isCompleted WHERE ToDoItemID = @id"
            };

            updateCmd.Parameters.AddWithValue("@id", ID ?? throw new ArgumentException());
            updateCmd.Parameters.AddWithValue("@isCompleted", isCompleted);

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
        /// Deletes a ToDoItem with the ToDoItemID of the given ToDoItem object.
        /// </summary>
        /// <param name="i">The ToDoItem with the ToDoItemID of the ToDoItem to delete.</param>
        /// <returns>Return true if one and only one row was successfully deleted in the Categories table.</returns>
        public static bool Delete(ToDoItem i)
        {
            return Delete(i.ToDoItemID);
        }

        /// <summary>
        /// Deletes a ToDoItem with the given ToDoItemID.
        /// </summary>
        /// <param name="ID">The ToDoItemID of the ToDoItem to delete.</param>
        /// <returns>Return true if one and only one row was successfully deleted in the Categories table.</returns>
        public static bool Delete(int? ID)
        {
            SqlCommand deleteCmd = new SqlCommand
            {
                CommandText = "DELETE FROM ToDoItems WHERE ToDoItemID = @id"
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

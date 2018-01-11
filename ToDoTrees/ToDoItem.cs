using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoTrees
{
    /// <summary>
    /// Represents an item on the todo list.
    /// </summary>
    class ToDoItem
    {
        #region Properties

        // The ToDoItemID property is nullable because the ID for a ToDoItem doesn't exist before it is added to the database.
        public int? ToDoItemID { get; set; }

        public int CategoryID { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a ToDoItem object from an already existing ToDoItem
        /// </summary>
        /// <param name="i">A ToDoItem object.</param>
        public ToDoItem(ToDoItem i)
            : this(i.ToDoItemID, i.CategoryID, i.Description, i.IsCompleted) {}

        /// <summary>
        /// Constructs a ToDoItem object with an IsCompleted property of false.
        /// </summary>
        /// <param name="ID">The ID of the ToDoItem. Is nullable.</param>
        /// <param name="categoryID">The ID of the category the ToDoItem belongs to.</param>
        /// <param name="desc">The description of the ToDoItem.</param>
        public ToDoItem(int? ID, int categoryID, string desc)
            : this(ID, categoryID, desc, false) {}

        /// <summary>
        /// Constructs a ToDoItem object. [Base Version]
        /// </summary>
        /// <param name="ID">The ID of the ToDoItem. Is nullable.</param>
        /// <param name="categoryID">The ID of the category the ToDoItem belongs to.</param>
        /// <param name="desc">The description of the ToDoItem.</param>
        /// <param name="isCompleted">A boolean property that keeps track of whether the ToDoItem has been completed or not.</param>
        public ToDoItem(int? ID, int categoryID, string desc, bool isCompleted)
        {
            ToDoItemID = ID;
            CategoryID = categoryID;
            Description = desc;
            IsCompleted = isCompleted;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a string representation of the ToDoItem object.
        /// </summary>
        /// <returns>The desciption of the ToDoItem</returns>
        public override string ToString()
        {
            return Description;
        }

        #endregion
    }
}

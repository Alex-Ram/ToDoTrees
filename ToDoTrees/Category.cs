using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoTrees
{
    /// <summary>
    /// Represents a category for ToDoItems.
    /// </summary>
    class Category
    {
        #region Properties

        // The CategoryID property is nullable because the ID for a category doesn't exist before it is added to the database.
        public int? CategoryID { get; set; }

        // The ParentID property is nullable because the root category does not have a ParentID.
        public int? ParentID { get; set; }

        public string Name { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a new category object from an already existing category object.
        /// </summary>
        /// <param name="c">A category object.</param>
        public Category(Category c)
            : this(c.CategoryID, c.ParentID, c.Name) {}

        /// <summary>
        /// Constructs a new category object.  [Base Version]
        /// </summary>
        /// <param name="ID">The ID of the category. Is nullable.</param>
        /// <param name="parentID">The ID of the parent category. Throws an exception if null because only the top level category should have a null parent and the top level category is added at database creation.</param>
        /// <param name="name">The name of the category</param>
        public Category(int? ID, int? parentID, string name)
        {
            CategoryID = ID;
            ParentID = parentID ?? throw new ArgumentException();
            Name = name;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a string representation of a category object.
        /// </summary>
        /// <returns>The name of the category.</returns>
        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}

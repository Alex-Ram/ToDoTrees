using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoTrees
{
    class Category
    {
        public int? CategoryID { get; set; }
        public int? ParentID { get; set; }
        public string Name { get; set; }

        public Category(Category c)
            : this(c.CategoryID, c.ParentID, c.Name) {}

        public Category(int? ID, int? parentID, string name)
        {
            CategoryID = ID;
            ParentID = parentID;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

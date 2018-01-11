using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoTrees
{
    class ToDoItem
    {
        public int? ToDoItemID { get; set; }
        public int CategoryID { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public ToDoItem(ToDoItem i)
            : this(i.ToDoItemID, i.CategoryID, i.Description, i.IsCompleted) {}

        public ToDoItem(int? id, int categoryID, string desc)
            : this(id, categoryID, desc, false) {}

        public ToDoItem(int? id, int categoryID, string desc, bool isCompleted)
        {
            ToDoItemID = id;
            CategoryID = categoryID;
            Description = desc;
            IsCompleted = isCompleted;
        }

        public override string ToString()
        {
            return Description;
        }
    }
}

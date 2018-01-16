using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoTrees
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// fields/props
        /// </summary>
        List<ToDoItem> allToDos;
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// initial start of programm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            RepopulateToDos();
        }

        #region helper methods
        /// <summary>
        /// checks if actions reflecting on the databse where succesful or not.
        /// </summary>
        /// <param name="TF"></param>
        private void successChecker(bool TF)
        {
            if (TF)
            {
                MessageBox.Show("Success!");
            }
            else
            {
                MessageBox.Show("Failure :(");
            }
        }


        #endregion


        #region crudtodo

        /// <summary>
        /// create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddToDo_Click_1(object sender, EventArgs e)
        {
            ToDoItem NewToDo = new ToDoItem(null, 1, txtDescrip.Text);
            bool successOrFail = ToDoItemDB.Create(NewToDo);
            successChecker(successOrFail);
            RepopulateToDos();
        }


        /// <summary>
        /// READ loading/repopulating our data grid
        /// </summary>

        private void RepopulateToDos()
        {

            this.allToDos = ToDoItemDB.GetAllToDoItems();
            dgToDos.DataSource = allToDos;
            /// hides columns that the user does not need to see.
            this.dgToDos.Columns["CategoryID"].Visible = false;
            this.dgToDos.Columns["ToDoItemID"].Visible = false;

        }

        /// <summary>
        /// update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            ToDoItem ItemToUpdate = (ToDoItem)dgToDos.CurrentRow.DataBoundItem;
            ToDoItemDB.UpdateDescription(ItemToUpdate.ToDoItemID, txtDescrip.Text);
            RepopulateToDos();
        }
        /// <summary>
        /// DELETE deletes a item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            ToDoItem ItemToDelete = (ToDoItem)dgToDos.CurrentRow.DataBoundItem;
            ToDoItemDB.Delete(ItemToDelete);
            RepopulateToDos();
        }


        #endregion

        #region crud Categories

        private void btnAddCat_Click_1(object sender, EventArgs e)
        {
            // issue loading in categories && todoitems..
        }

        #endregion
//
//        private void btnAddToDo_Click_1(object sender, EventArgs e)
//        {
//            MessageBox.Show("meow");
//        }
//
//        private void btnEdit_Click_1(object sender, EventArgs e)
//        {
//
//        }
//
//        private void btnDelete_Click_1(object sender, EventArgs e)
//        {
//
//        }
    }
}

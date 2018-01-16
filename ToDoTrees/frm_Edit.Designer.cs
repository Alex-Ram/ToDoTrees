namespace ToDoTrees
{
    partial class frm_Edit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtEditTask = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCanUp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtEditTask
            // 
            this.txtEditTask.Location = new System.Drawing.Point(54, 72);
            this.txtEditTask.Name = "txtEditTask";
            this.txtEditTask.Size = new System.Drawing.Size(282, 31);
            this.txtEditTask.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Edit Task";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Lime;
            this.btnUpdate.Location = new System.Drawing.Point(54, 239);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(123, 71);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCanUp
            // 
            this.btnCanUp.BackColor = System.Drawing.Color.Red;
            this.btnCanUp.Location = new System.Drawing.Point(246, 239);
            this.btnCanUp.Name = "btnCanUp";
            this.btnCanUp.Size = new System.Drawing.Size(133, 71);
            this.btnCanUp.TabIndex = 3;
            this.btnCanUp.Text = "cancel";
            this.btnCanUp.UseVisualStyleBackColor = false;
            // 
            // frm_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 353);
            this.Controls.Add(this.btnCanUp);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEditTask);
            this.Name = "frm_Edit";
            this.Text = "frm_Edit";
            this.Load += new System.EventHandler(this.frm_Edit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEditTask;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCanUp;
    }
}
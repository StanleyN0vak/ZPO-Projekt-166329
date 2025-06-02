namespace Zarzadzanie_Ksiazkami
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnFilter = new Button();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.AutoSize = true;
            btnAdd.Location = new Point(674, 12);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(114, 30);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Dodaj Książkę";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.AutoSize = true;
            btnEdit.Location = new Point(674, 47);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(114, 30);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Edytuj Książkę";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.AutoSize = true;
            btnDelete.Location = new Point(674, 82);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(114, 30);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Usuń Książkę";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnFilter
            // 
            btnFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFilter.AutoSize = true;
            btnFilter.Location = new Point(674, 117);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(114, 30);
            btnFilter.TabIndex = 3;
            btnFilter.Text = "Filtruj Książki";
            btnFilter.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnFilter);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Zarządzanie Książkami";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnFilter;
    }
}

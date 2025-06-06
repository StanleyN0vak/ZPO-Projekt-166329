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
            btnSearch = new Button();
            dataGridViewBooks = new DataGridView();
            txtSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.AutoSize = true;
            btnAdd.Location = new Point(1072, 12);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 30);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Dodaj Książkę";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.AutoSize = true;
            btnEdit.Location = new Point(1072, 47);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(150, 30);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Edytuj Książkę";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.AutoSize = true;
            btnDelete.Location = new Point(1072, 82);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 30);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Usuń Książkę";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSearch.AutoSize = true;
            btnSearch.Location = new Point(1072, 311);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(150, 30);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Szukaj";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dataGridViewBooks
            // 
            dataGridViewBooks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBooks.Location = new Point(12, 12);
            dataGridViewBooks.Name = "dataGridViewBooks";
            dataGridViewBooks.RowHeadersWidth = 51;
            dataGridViewBooks.Size = new Size(1054, 329);
            dataGridViewBooks.TabIndex = 4;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtSearch.Location = new Point(1072, 278);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(150, 27);
            txtSearch.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1234, 353);
            Controls.Add(txtSearch);
            Controls.Add(dataGridViewBooks);
            Controls.Add(btnSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            MinimumSize = new Size(600, 250);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Zarządzanie Książkami";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnSearch;
        private DataGridView dataGridViewBooks;
        private TextBox txtSearch;
    }
}


namespace Zarzadzanie_Ksiazkami
{
    partial class AddBookForm
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
            btnSaveBook = new Button();
            cmbGenre = new ComboBox();
            txtTitle = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtAuthor = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtPublisher = new TextBox();
            label5 = new Label();
            dtpPublished = new DateTimePicker();
            cmbType = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            txtFileFormat = new TextBox();
            label8 = new Label();
            nudPageCount = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)nudPageCount).BeginInit();
            SuspendLayout();
            // 
            // btnSaveBook
            // 
            btnSaveBook.Location = new Point(12, 409);
            btnSaveBook.Name = "btnSaveBook";
            btnSaveBook.Size = new Size(94, 29);
            btnSaveBook.TabIndex = 0;
            btnSaveBook.Text = "Zapisz";
            btnSaveBook.UseVisualStyleBackColor = true;
            btnSaveBook.Click += btnSaveBook_Click;
            // 
            // cmbGenre
            // 
            cmbGenre.FormattingEnabled = true;
            cmbGenre.Items.AddRange(new object[] { "Kryminał", "Thriller", "Literatura obyczajowa", "Fantastyka", "Horror", "Sci-Fi", "Literatura faktu", "Biografia", "Poradnik", "Rozwój osobisty", "Kuchnia", "Literatura obca", "Literatura polska", "Historia", "Komiks", "Sport i wypoczynek", "Turystyka i podróże" });
            cmbGenre.Location = new Point(12, 138);
            cmbGenre.Name = "cmbGenre";
            cmbGenre.Size = new Size(151, 28);
            cmbGenre.TabIndex = 1;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(12, 32);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(125, 27);
            txtTitle.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(40, 20);
            label1.TabIndex = 3;
            label1.Text = "Tytuł";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 62);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 4;
            label2.Text = "Autor";
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(12, 85);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(125, 27);
            txtAuthor.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 115);
            label3.Name = "label3";
            label3.Size = new Size(63, 20);
            label3.TabIndex = 6;
            label3.Text = "Gatunek";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 169);
            label4.Name = "label4";
            label4.Size = new Size(102, 20);
            label4.TabIndex = 7;
            label4.Text = "Wydawnictwo";
            // 
            // txtPublisher
            // 
            txtPublisher.Location = new Point(12, 192);
            txtPublisher.Name = "txtPublisher";
            txtPublisher.Size = new Size(125, 27);
            txtPublisher.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 222);
            label5.Name = "label5";
            label5.Size = new Size(103, 20);
            label5.TabIndex = 9;
            label5.Text = "Data Wydania";
            // 
            // dtpPublished
            // 
            dtpPublished.Location = new Point(12, 245);
            dtpPublished.Name = "dtpPublished";
            dtpPublished.Size = new Size(259, 27);
            dtpPublished.TabIndex = 10;
            // 
            // cmbType
            // 
            cmbType.FormattingEnabled = true;
            cmbType.Items.AddRange(new object[] { "Fizyczna", "E-Book" });
            cmbType.Location = new Point(12, 298);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(151, 28);
            cmbType.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 275);
            label6.Name = "label6";
            label6.Size = new Size(51, 20);
            label6.TabIndex = 12;
            label6.Text = "Forma";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 329);
            label7.Name = "label7";
            label7.Size = new Size(76, 20);
            label7.TabIndex = 13;
            label7.Text = "Ilość stron";
            // 
            // txtFileFormat
            // 
            txtFileFormat.Enabled = false;
            txtFileFormat.Location = new Point(168, 352);
            txtFileFormat.Name = "txtFileFormat";
            txtFileFormat.Size = new Size(125, 27);
            txtFileFormat.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(169, 329);
            label8.Name = "label8";
            label8.Size = new Size(56, 20);
            label8.TabIndex = 16;
            label8.Text = "Format";
            label8.Click += label8_Click;
            // 
            // nudPageCount
            // 
            nudPageCount.Enabled = false;
            nudPageCount.Location = new Point(12, 353);
            nudPageCount.Maximum = new decimal(new int[] { 51000, 0, 0, 0 });
            nudPageCount.Name = "nudPageCount";
            nudPageCount.Size = new Size(150, 27);
            nudPageCount.TabIndex = 17;
            // 
            // AddBookForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(nudPageCount);
            Controls.Add(label8);
            Controls.Add(txtFileFormat);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(cmbType);
            Controls.Add(dtpPublished);
            Controls.Add(label5);
            Controls.Add(txtPublisher);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtAuthor);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtTitle);
            Controls.Add(cmbGenre);
            Controls.Add(btnSaveBook);
            Name = "AddBookForm";
            Text = "Dodaj Książkę";
            ((System.ComponentModel.ISupportInitialize)nudPageCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            return;
        }

        #endregion

        private Button btnSaveBook;
        private ComboBox cmbGenre;
        private TextBox txtTitle;
        private Label label1;
        private Label label2;
        private TextBox txtAuthor;
        private Label label3;
        private Label label4;
        private TextBox txtPublisher;
        private Label label5;
        private DateTimePicker dtpPublished;
        private ComboBox cmbType;
        private Label label6;
        private Label label7;
        private TextBox txtFileFormat;
        private Label label8;
        private NumericUpDown nudPageCount;
    }
}
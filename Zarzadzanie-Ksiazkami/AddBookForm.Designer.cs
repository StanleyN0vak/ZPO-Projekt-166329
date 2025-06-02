
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
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            textBox3 = new TextBox();
            label5 = new Label();
            dateTimePicker1 = new DateTimePicker();
            comboBox2 = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            textBox5 = new TextBox();
            label8 = new Label();
            numericUpDown1 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
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
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Kryminał", "Thriller", "Literatura obyczajowa", "Fantastyka", "Horror", "Sci-Fi", "Literatura faktu", "Biografia", "Poradnik", "Rozwój osobisty", "Kuchnia", "Literatura obca", "Literatura polska", "Historia", "Komiks", "Sport i wypoczynek", "Turystyka i podróże" });
            comboBox1.Location = new Point(12, 138);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 32);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 2;
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
            // textBox2
            // 
            textBox2.Location = new Point(12, 85);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 5;
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
            // textBox3
            // 
            textBox3.Location = new Point(12, 192);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 8;
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
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(12, 245);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(259, 27);
            dateTimePicker1.TabIndex = 10;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Fizyczna", "E-Book" });
            comboBox2.Location = new Point(12, 298);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 11;
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
            // textBox5
            // 
            textBox5.Enabled = false;
            textBox5.Location = new Point(168, 352);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(125, 27);
            textBox5.TabIndex = 15;
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
            // numericUpDown1
            // 
            numericUpDown1.Enabled = false;
            numericUpDown1.Location = new Point(12, 353);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 27);
            numericUpDown1.TabIndex = 17;
            // 
            // AddBookForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(numericUpDown1);
            Controls.Add(label8);
            Controls.Add(textBox5);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(comboBox2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label5);
            Controls.Add(textBox3);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(btnSaveBook);
            Name = "AddBookForm";
            Text = "Dodaj Książkę";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            return;
        }

        #endregion

        private Button btnSaveBook;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private Label label4;
        private TextBox textBox3;
        private Label label5;
        private DateTimePicker dateTimePicker1;
        private ComboBox comboBox2;
        private Label label6;
        private Label label7;
        private TextBox textBox5;
        private Label label8;
        private NumericUpDown numericUpDown1;
    }
}
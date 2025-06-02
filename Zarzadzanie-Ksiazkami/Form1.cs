namespace Zarzadzanie_Ksiazkami
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addBookForm = new AddBookForm();
            addBookForm.ShowDialog();
        }
    }
}

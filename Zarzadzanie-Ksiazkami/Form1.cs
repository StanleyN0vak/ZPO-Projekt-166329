namespace Zarzadzanie_Ksiazkami
{
    public partial class Form1 : Form
    {
        public readonly BookRepository _bookRepository;
        public Form1()
        {
            InitializeComponent();
            _bookRepository = new BookRepository();
            this.FormClosing += Form1_FormClosing;
        }

        private void LoadBooks()
        {
            var books = _bookRepository.GetAll();

            dataGridViewBooks.DataSource = books;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addBookForm = new AddBookForm(_bookRepository);
            addBookForm.ShowDialog();
            LoadBooksToGrid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _bookRepository.SaveAll();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count == 0) 
            {
                MessageBox.Show("Zaznacz ksi¹¿kê do edycji.");
                return;
            }

            var selectedBook = (Book)dataGridViewBooks.SelectedRows[0].DataBoundItem;
            var editForm = new EditBookForm(selectedBook);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadBooksToGrid();
            }
        }

        private void LoadBooksToGrid()
        {
            var repo = new BookRepository();
            dataGridViewBooks.DataSource = null;
            dataGridViewBooks.DataSource = repo.GetAll();
        }
    }
}

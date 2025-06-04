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
            LoadBooksToGrid();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SyncChangesFromGridToRepository();
            _bookRepository.SaveAll();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zaznacz wiersz z ksi¹¿k¹ do edycji.");
                return;
            }
            else if (dataGridViewBooks.SelectedRows.Count > 1)
            {
                MessageBox.Show("Zaznacz jedn¹ wybran¹ ksi¹¿kê do edycji.");
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
            var books = repo.GetAll();
            dataGridViewBooks.DataSource = books;

            dataGridViewBooks.Columns["Id"].HeaderText = "ID";
            dataGridViewBooks.Columns["Title"].HeaderText = "Tytu³";
            dataGridViewBooks.Columns["Author"].HeaderText = "Autor";
            dataGridViewBooks.Columns["Genre"].HeaderText = "Gatunek";
            dataGridViewBooks.Columns["Publisher"].HeaderText = "Wydawnictwo";
            dataGridViewBooks.Columns["PublishedDate"].HeaderText = "Data publikacji";

            if (!dataGridViewBooks.Columns.Contains("BookType"))
                dataGridViewBooks.Columns.Add("BookType", "Typ");

            if (!dataGridViewBooks.Columns.Contains("Details"))
                dataGridViewBooks.Columns.Add("Details", "Szczegó³y");

            foreach (DataGridViewRow row in dataGridViewBooks.Rows)
            {
                if (row.DataBoundItem is Book book)
                {
                    if (book.GetFormat() == "Printed")
                        row.Cells["BookType"].Value = "Fizyczna";
                    else
                        row.Cells["BookType"].Value = book.GetFormat();

                    if (book is PrintedBook printed)
                        row.Cells["Details"].Value = $"{printed.PageCount} stron";
                    else if (book is EBook ebook)
                        row.Cells["Details"].Value = $"Format: {ebook.FileFormat}";
                }
            }
        }

        private void SyncChangesFromGridToRepository()
        {
            var updatedBooks = new List<Book>();

            foreach (DataGridViewRow row in dataGridViewBooks.Rows)
            {
                if (row.DataBoundItem is Book book)
                {
                    updatedBooks.Add(book);
                }
            }

            _bookRepository.SetBooks(updatedBooks);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Znaznacz wiersz ksi¹¿ki do usuniêcia.");
                return;
            }
            else if (dataGridViewBooks.SelectedRows.Count > 1)
            {
                MessageBox.Show("Zaznacz jedn¹ pozycjê do usniêcia.");
                return;
            }

            var selectedRow = dataGridViewBooks.SelectedRows[0];
            if (selectedRow.DataBoundItem is Book selectedBook)
            {
                var result = MessageBox.Show(
                    $"Czy na pewno chcesz usun¹æ '{selectedBook.Title} - {selectedBook.Author}'?",
                    "Potwierdzenie usuniêcia",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                    );

                if (result == DialogResult.Yes)
                {
                    _bookRepository.Remove(selectedBook.Id);
                    LoadBooksToGrid();
                }
            }
        }
    }
}

using System.ComponentModel;

namespace Zarzadzanie_Ksiazkami
{
    public partial class Form1 : Form
    {
        public readonly BookRepository _bookRepository;

        private string _lastSortedColumn = string.Empty;
        private bool _sortAscending = true;
        private int _lastSortedColumnIndex = -1;
        public Form1()
        {
            InitializeComponent();
            _bookRepository = new BookRepository();
            //this.FormClosing += Form1_FormClosing;
            dataGridViewBooks.ColumnHeaderMouseClick += dataGridViewBooks_ColumnHeaderMouseClick;
            AppConfig.Instance.LastOpened = DateTime.Now;
            AppConfig.Instance.SaveConfig();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addBookForm = new AddBookForm(_bookRepository);
            addBookForm.ShowDialog();
            LoadBooksToGrid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridViewBooks.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            LoadBooksToGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewBooks.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Zaznacz wiersz z ksi¹¿k¹ do edycji.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (dataGridViewBooks.SelectedRows.Count > 1)
                {
                    MessageBox.Show("Zaznacz jedn¹ wybran¹ ksi¹¿kê do edycji.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedBook = (Book)dataGridViewBooks.SelectedRows[0].DataBoundItem;
                var editForm = new EditBookForm(selectedBook);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadBooksToGrid();
                }
            }
            catch (BookNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "B³¹d danych", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wyst¹pi³ nieoczekiwany b³¹d: " + ex.Message, "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBooksToGrid()
        {
            var books = new BindingList<Book>(_bookRepository.GetAll());

            var sorted = books.OrderBy(b => b.Title).ToList();
            dataGridViewBooks.DataSource = new BindingList<Book>(sorted);

            dataGridViewBooks.Columns["Id"].HeaderText = "ID";
            dataGridViewBooks.Columns["Title"].HeaderText = "Tytu³";
            dataGridViewBooks.Columns["Author"].HeaderText = "Autor";
            dataGridViewBooks.Columns["Genre"].HeaderText = "Gatunek";
            dataGridViewBooks.Columns["Publisher"].HeaderText = "Wydawnictwo";
            dataGridViewBooks.Columns["PublishedDate"].HeaderText = "Data publikacji";
            dataGridViewBooks.Columns["BookType"].HeaderText = "Typ";
            dataGridViewBooks.Columns["Details"].HeaderText = "Szczegó³y";

            _lastSortedColumn = nameof(Book.Title);
            _lastSortedColumnIndex = dataGridViewBooks.Columns["Title"].Index;
            _sortAscending = true;

            foreach (DataGridViewColumn column in dataGridViewBooks.Columns)
                column.HeaderCell.SortGlyphDirection = SortOrder.None;

            dataGridViewBooks.Columns[_lastSortedColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
            ApplyPolishHeaderAndCustomColumns();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewBooks.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Zaznacz wiersz ksi¹¿ki do usuniêcia.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (dataGridViewBooks.SelectedRows.Count > 1)
                {
                    MessageBox.Show("Zaznacz jedn¹ pozycjê do usniêcia.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            catch (BookNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "B³¹d danych", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wyst¹pi³ nieoczekiwany b³¹d: " + ex.Message, "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewBooks_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dataGridViewBooks.Columns[e.ColumnIndex].HeaderText;

            if (string.IsNullOrEmpty(columnName))
                return;

            var books = _bookRepository.GetAll();

            if (_lastSortedColumn == columnName)
            {
                _sortAscending = !_sortAscending;
            }
            else
            {
                _lastSortedColumn = columnName;
                _sortAscending = true;
                _lastSortedColumnIndex = e.ColumnIndex;
            }

            IEnumerable<Book> sortedBooks = columnName switch
            {
                "Tytu³" => _sortAscending ? books.OrderBy(b => b.Title) : books.OrderByDescending(b => b.Title),
                "Autor" => _sortAscending ? books.OrderBy(b => b.Author) : books.OrderByDescending(b => b.Author),
                "Gatunek" => _sortAscending ? books.OrderBy(b => b.Genre) : books.OrderByDescending(b => b.Genre),
                "Wydawnictwo" => _sortAscending ? books.OrderBy(b => b.Publisher) : books.OrderByDescending(b => b.Publisher),
                "Data publikacji" => _sortAscending ? books.OrderBy(b => b.PublishedDate) : books.OrderByDescending(b => b.PublishedDate),
                "Typ" => _sortAscending ? books.OrderBy(b => b.GetFormat()) : books.OrderByDescending(b => b.GetFormat()),
                "Szczegó³y" => _sortAscending
                    ? books.OrderBy(b => b is PrintedBook pb ? pb.PageCount.ToString() : (b is EBook eb ? eb.FileFormat : ""))
                    : books.OrderByDescending(b => b is PrintedBook pb ? pb.PageCount.ToString() : (b is EBook eb ? eb.FileFormat : "")),
                _ => books
            };

            dataGridViewBooks.DataSource = sortedBooks.ToList();
            
            if (!dataGridViewBooks.Columns.Contains("BookType"))
                dataGridViewBooks.Columns.Add("BookType", "Typ");

            if (!dataGridViewBooks.Columns.Contains("Details"))
                dataGridViewBooks.Columns.Add("Details", "Szczegó³y");

            foreach (DataGridViewRow row in dataGridViewBooks.Rows)
            {
                if (row.DataBoundItem is Book book)
                {
                    row.Cells["BookType"].Value = book.GetFormat() == "Printed" ? "Fizyczna" : book.GetFormat();

                    if (book is PrintedBook printed)
                        row.Cells["Details"].Value = $"{printed.PageCount} stron";
                    else if (book is EBook eb)
                        row.Cells["Details"].Value = $"Format: {eb.FileFormat}";
                }
            }

            foreach (DataGridViewColumn column in dataGridViewBooks.Columns)
                column.HeaderCell.SortGlyphDirection = SortOrder.None;

            dataGridViewBooks.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = _sortAscending ? SortOrder.Ascending : SortOrder.Descending;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchGrid();
        }

        private void SearchGrid()
        {
            string searchTerm = txtSearch.Text.Trim().ToLower();

            var books = _bookRepository.GetAll();

            var filteredBooks = books.Where(book =>
                book.Title.ToLower().Contains(searchTerm) ||
                book.Author.ToLower().Contains(searchTerm) ||
                book.Publisher.ToLower().Contains(searchTerm)
            ).ToList();

            dataGridViewBooks.DataSource = null;
            dataGridViewBooks.DataSource = filteredBooks;
            ApplyPolishHeaderAndCustomColumns();
        }

        private void ApplyPolishHeaderAndCustomColumns()
        {
            if (dataGridViewBooks.Columns.Contains("Id"))
                dataGridViewBooks.Columns["Id"].HeaderText = "ID";
            if (dataGridViewBooks.Columns.Contains("Title"))
                dataGridViewBooks.Columns["Title"].HeaderText = "Tytu³";
            if (dataGridViewBooks.Columns.Contains("Author"))
                dataGridViewBooks.Columns["Author"].HeaderText = "Autor";
            if (dataGridViewBooks.Columns.Contains("Genre"))
                dataGridViewBooks.Columns["Genre"].HeaderText = "Gatunek";
            if (dataGridViewBooks.Columns.Contains("Publisher"))
                dataGridViewBooks.Columns["Publisher"].HeaderText = "Wydawnictwo";
            if (dataGridViewBooks.Columns.Contains("PublishedDate"))
                dataGridViewBooks.Columns["PublishedDate"].HeaderText = "Data publikacji";
            if (dataGridViewBooks.Columns.Contains("BookType"))
                dataGridViewBooks.Columns["BookType"].HeaderText = "Typ";
            if (dataGridViewBooks.Columns.Contains("Details"))
                dataGridViewBooks.Columns["Details"].HeaderText = "Szczegó³y";

            foreach (DataGridViewRow row in dataGridViewBooks.Rows)
            {
                if (row.DataBoundItem is Book book)
                {
                    row.Cells["BookType"].Value = book is PrintedBook ? "Fizyczna" :
                                                  book is EBook ? "E-Book" : book.GetFormat();

                    if (book is PrintedBook printed)
                        row.Cells["Details"].Value = $"{printed.PageCount} stron";
                    else if (book is EBook eb)
                        row.Cells["Details"].Value = $"Format: {eb.FileFormat}";
                }
            }
        }
    }
}

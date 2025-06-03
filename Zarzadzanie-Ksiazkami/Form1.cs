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

            var displayList = books.Select(b => new
            {
                b.Id,
                b.Title,
                b.Author,
                Format = b.GetFormat(),
                Details = b is EBook eb ? $"Format: {eb.FileFormat}" :
                          b is PrintedBook pb ? $"Strony: {pb.PageCount}" : ""
            }).ToList();

            dataGridViewBooks.DataSource = displayList;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addBookForm = new AddBookForm(_bookRepository);
            addBookForm.ShowDialog();
            LoadBooks();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _bookRepository.SaveAll();
        }
    }
}

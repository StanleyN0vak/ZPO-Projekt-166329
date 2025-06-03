using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zarzadzanie_Ksiazkami
{
    public partial class EditBookForm : Form
    {
        private Book _originalBook;
        public EditBookForm(Book bookToEdit)
        {
            InitializeComponent();
            _originalBook = bookToEdit;

            txtTitle.Text = bookToEdit.Title;
            txtAuthor.Text = bookToEdit.Author;
            cmbGenre.SelectedItem = bookToEdit.Genre;
            txtPublisher.Text = bookToEdit.Publisher;
            dtpPublished.Value = bookToEdit.PublishedDate;

            if (bookToEdit is PrintedBook printed)
            {
                cmbType.Text = "Fizyczna";
                cmbType.Enabled = false;
                nudPageCount.Value = printed.PageCount;
                nudPageCount.Enabled = true;
            }
            else if (bookToEdit is EBook eBook)
            {
                cmbType.Text = "E-Book";
                cmbType.Enabled = false;
                txtFileFormat.Text = eBook.FileFormat;
                txtFileFormat.Enabled = true;
            }
        }

        private void btnSaveBook_Click(object sender, EventArgs e)
        {
            _originalBook.Title = txtTitle.Text;
            _originalBook.Author = txtAuthor.Text;
            _originalBook.Genre = cmbGenre.Text;
            _originalBook.Publisher = txtPublisher.Text;
            _originalBook.PublishedDate = dtpPublished.Value;
            
            if (_originalBook is PrintedBook printedBook)
            {
                printedBook.PageCount = (int)nudPageCount.Value;
            }
            else if (_originalBook is EBook eBook)
            {
                eBook.FileFormat = txtFileFormat.Text;
            }

            BookRepository repo = new();
            repo.Update(_originalBook);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

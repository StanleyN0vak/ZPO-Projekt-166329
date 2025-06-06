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
    public partial class AddBookForm : Form
    {
        private readonly BookRepository _bookRepository;   
        public AddBookForm(BookRepository bookRepository)
        {
            InitializeComponent();
            _bookRepository = bookRepository;
            cmbType.SelectedIndexChanged += cmbType_SelectedIndexChanged;
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedItem?.ToString() == "Fizyczna") 
            {
                nudPageCount.Enabled = true;
                txtFileFormat.Enabled = false;
            }
            else if (cmbType.SelectedItem?.ToString() == "E-Book")
            {
                nudPageCount.Enabled = false;
                txtFileFormat.Enabled = true;
            }
            else
            {
                nudPageCount.Enabled = false;
                txtFileFormat.Enabled = false;
            }
        }

        private void btnSaveBook_Click(object sender, EventArgs e)
        {
            Book newbook;

            if (cmbType.SelectedItem == null) 
            {
                MessageBox.Show("Proszę podać format książki", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (cmbType.SelectedItem.ToString() == "Fizyczna")
            {
                newbook = new PrintedBook 
                {
                    Title = txtTitle.Text,
                    Author = txtAuthor.Text,
                    Genre = cmbGenre.Text,
                    Publisher = txtPublisher.Text,
                    PublishedDate = dtpPublished.Value.Date,
                    PageCount = (int)nudPageCount.Value
                };
            }
            else
            {
                newbook = new EBook
                {
                    Title = txtTitle.Text,
                    Author = txtAuthor.Text,
                    Genre = cmbGenre.Text,
                    Publisher = txtPublisher.Text,
                    PublishedDate = dtpPublished.Value.Date,
                    FileFormat = txtFileFormat.Text
                };
            }

            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                MessageBox.Show("Tytuł i autor są wymagane.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                _bookRepository.Add(newbook);
                MessageBox.Show("Książka dodana!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTitle.Text = string.Empty;
                txtAuthor.Text = string.Empty;
                cmbGenre.Text = string.Empty;
                txtPublisher.Text = string.Empty;
                dtpPublished.Value = DateTime.Now;
                nudPageCount.Value = 0;
                txtFileFormat.Text = string.Empty;

            }


        }
    }
}

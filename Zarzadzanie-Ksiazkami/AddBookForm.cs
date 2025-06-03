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
                throw new ArgumentException("Proszę podać format książki");
            }
            else if (cmbType.SelectedItem.ToString() == "Fizyczna")
            {
                newbook = new PrintedBook 
                {
                    Title = txtTitle.Text,
                    Author = txtAuthor.Text,
                    Genre = cmbGenre.Text,
                    Publisher = txtPublisher.Text,
                    PublishedDate = dtpPublished.Value,
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
                    PublishedDate = dtpPublished.Value,
                    FileFormat = txtFileFormat.Text
                };
            }
            
            _bookRepository.Add(newbook);
            MessageBox.Show("Książka dodana!");
        }
    }
}

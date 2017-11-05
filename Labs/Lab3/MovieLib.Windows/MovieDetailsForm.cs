/*Gena (Annie) Saenz
ITSE 1430
Lab 3 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieLib
{
    public partial class MovieDetailsForm : Form
    {
        #region Construction  
        public MovieDetailsForm()
        {
            InitializeComponent();

        }

        public MovieDetailsForm( string title ) : this()
        {
            Text = title;
        }

        public MovieDetailsForm( string title, Movie movie ) : this(title)
        {
            Movie = movie;
        }
        #endregion


        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            if (Movie != null)
            {
                _txtTitle.Text = Movie.Title;
                _txtDescription.Text = Movie.Description;
                _txtLength.Text = Movie.Length.ToString();
                _ckbxOwned.Checked = Movie.IsOwned;
            };

            ValidateChildren();
        }

        /// <summary>Gets or sets the movie being shown.</summary>
        public Movie Movie { get; set; }

        private void OnSave( object sender, EventArgs e )
        {
            if (!ValidateChildren())
            {
                return;
            };

            var movie = new Movie() {
                Id = Movie?.Id ?? 0,
                Title = _txtTitle.Text,
                Description = _txtDescription.Text,
                Length = GetLength(_txtLength),
                IsOwned = _ckbxOwned.Checked,
            };

            if (!ObjectValidator.TryValidate(movie, out var errors))
            {
                ShowError("Not Valid", "Validation Error");
                return;
            };

            Movie = movie;
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void OnCancel( object sender, EventArgs e )
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ShowError( string message, string title )
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private int GetLength( TextBox control )
        {
            string _txtLength;
            if (Int32.TryParse(control.Text, out int length))
                return length;
            _txtLength = length.ToString();    

            return -1;


        }

        private void OnValidatingLength( object sender, CancelEventArgs e )
        {
            var txtbx = sender as TextBox;

            if (GetLength(txtbx) < 0)
            {
                e.Cancel = true;
                _errors.SetError(_txtLength, "Length must be >= 0.");
            } else
                _errors.SetError(_txtLength, "");
        }

        private void OnValidatingTitle( object sender, CancelEventArgs e )
        {
            var txtbx = sender as TextBox;
            if (String.IsNullOrEmpty(txtbx.Text))
                _errors.SetError(txtbx, "Title is required.");
            else
                _errors.SetError(txtbx, "");
        }
    }
}

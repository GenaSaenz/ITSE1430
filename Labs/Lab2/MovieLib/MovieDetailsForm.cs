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

        public Movie Movie { get; set; }

        private void OnSave( object sender, EventArgs e )
        {
            if (!ValidateChildren())
            {
                return;
            };

            var movie = new Movie();
            movie.Title = _txtTitle.Text;
            movie.Description = _txtDescription.Text;
            movie.Length = GetLength(_txtLength);
            movie.IsOwned = _ckbxOwned.Checked;

            var error = movie.Validate();
            if (!String.IsNullOrEmpty(error))
            {
                ShowError(error, "Validation Error");
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

        private void MovieDetailsForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            var form = sender as Form;

            if (sender is int)
            {
                var intValue2 = (int)sender;
            };

            if (sender is int intValue)
            {

            };

            //if (MessageBox.Show(this, "Are you sure?", "Closing", MessageBoxButtons.YesNo) == DialogResult.No)
            //    e.Cancel = true;
        }

        private void MovieDetailsForm_FormClosed( object sender, FormClosedEventArgs e )
        {

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

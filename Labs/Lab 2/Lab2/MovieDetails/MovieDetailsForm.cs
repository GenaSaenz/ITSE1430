using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieDetails
{
    public partial class MovieDetails : Form
    {
        public MovieDetails()
        {
            InitializeComponent();
        }

        public MovieDetails( string title ) : this()
        {
            Text = title;
        }

        public MovieDetails( string title, MovieDetails movie ) : this(title)
        {
            Movie = movie;
        }
        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);


            if (Movie != null)
            {
                _txtBoxTitle.Text = Movie.Name;
                _txtBoxDescript.Text = Movie.Description;
                _txtBoxLength.Text = Movie.Price.ToString();  //Fix this
                _ckBoxOwned.Checked = Movie.IsDiscontinued;
            };
        }

        public MovieDetails Movie { get; set; }

        private void OnSave( object sender, EventArgs e )
        {
            var movie = new MovieDetails();
            movie.Name = _txtBoxTitle.Text;
            movie.Description = _txtBoxDescript.Text;
            movie.Price = GetPrice();
            movie.IsDiscontinued = _ckBoxOwned.Checked;

            //Add validation
            var error = movie.Validate();
            if (!String.IsNullOrEmpty(error))
            {
                //Show the error
                ShowError(error, "Validation Error");
                return;
            };

            MovieDetails = movie;
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void OnCancel( object sender, EventArgs e )
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ProductDetailForm_FormClosing( object sender, FormClosingEventArgs e )
        {

            var form = sender as Form;
            if (MessageBox.Show(this, "Are you sure?", "Closing", MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
        }
    }
}

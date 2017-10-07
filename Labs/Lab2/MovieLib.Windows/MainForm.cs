/*Gena (Annie) Saenz
ITSE 1430
Lab 2  - Due 10/9/17 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieLib.Windows
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void OnMoviesAdd( object sender, EventArgs e )
        {
            var child = new MovieDetailsForm("Movie Details");
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            _movie = child.Movie;
        }

        private Movie _movie;

        private void OnMoviesEdit( object sender, EventArgs e )
        {
            var child = new MovieDetailsForm("Movie Details");
            child.Movie = _movie;
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            _movie = child.Movie;
        }

        private void OnMoviesDelete( object sender, EventArgs e )
        {
            if (_movie == null)
                return;

            if (MessageBox.Show(this, $"Are you sure you want to delete '{_movie.Title}'?",
                  "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            _movie = null;
        }

        private void OnHelpAbout( object sender, EventArgs e )
        {
            var about = new AboutBox();
            about.ShowDialog(this);
        }
    }
}

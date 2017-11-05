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

namespace MovieLib.Windows
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);
            _gridMovies.AutoGenerateColumns = false;

            UpdateList();
        }

        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private Movie GetSelectedMovie ()
        {
            if (_gridMovies.SelectedRows.Count > 0)
                return _gridMovies.SelectedRows[0].DataBoundItem as Movie;

            return null;
        }

        private void UpdateList ()
        {
            _bsMovies.DataSource = _database.GetAll().ToList();
        }

        private void OnMoviesAdd( object sender, EventArgs e )
        {
            var child = new MovieDetailsForm("Movie Details");
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            _database.Add(child.Movie);
            UpdateList();
        }

        private void OnMoviesEdit( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
            {
                MessageBox.Show("No movies available.");
                return;
            };

            EditMovie(movie);
        }

        private void EditMovie (Movie movie)
        {
            var child = new MovieDetailsForm("Movie Details");
            child.Movie = movie;
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            _database.Update(child.Movie);
            UpdateList();
        }

        private void OnMoviesDelete( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            DeleteMovie(movie);
        }

        private void DeleteMovie (Movie movie)
        {
            if (MessageBox.Show(this, $"Are you sure you want to delete '{movie.Title}'?",
                  "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            _database.Remove(movie.Id);
            UpdateList();
        }

        private void OnHelpAbout( object sender, EventArgs e )
        {
            var about = new AboutBox();
            about.ShowDialog(this);
        }

        private IMovieDatabase _database = new MovieLib.Stores.SeededMemoryMovieDatabase();

        private void OnEditRow( object sender, DataGridViewCellEventArgs e)
        {
            var grid = sender as DataGridView;

            if (e.RowIndex < 0)
                return;

            var row = grid.Rows[e.RowIndex];
            var item = row.DataBoundItem as Movie;

            if (item != null)
                EditMovie(item);
        }

        private void OnKeyDownGrid( object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;

            var movie = GetSelectedMovie();
            if (movie != null)
                DeleteMovie(movie);

            e.SuppressKeyPress = true;
        }
    }
}

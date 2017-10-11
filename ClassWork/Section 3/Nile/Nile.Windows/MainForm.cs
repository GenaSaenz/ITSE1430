using System;
using System.Windows.Forms;

namespace Nile.Windows
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

            foreach (var product in _database.GetAll())
            _listProducts.Items.Add(product);
        }

        // private int FindAvailableElement ()
        // {
        //     for (var index = 0; index < _products.Length; ++index)
        //     {
        //         if (_products[index] == null)
        //             return index;
        //     };

        //     return -1;
        // }

        //  private int FindFirstProduct()
        // {
        //     for (var index = 0; index < _products.Length; ++index)
        //    {
        //        if (_products[index] != null)
        //            return index;
        //    };

        //    return -1;
        // }

        private void UpdateList ()
        {
            _listProducts.Items.Clear();

            foreach (var product in _database.GetAll())
                _listProducts.Items.Add(product);
        }

        private Product GetSelectedProduct()
        {
            return _listProducts.SelectedItem as Product;
        }

        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void OnProductAdd( object sender, EventArgs e )
        {
            //Make sure there is room left
           // var index = FindAvailableElement();
           // if (index < 0)
           // {
           //     MessageBox.Show("No more products available.");
           //     return;
           // };

            var child = new ProductDetailForm("Product Details");
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            //TODO: Save product
            _database.Add = child.Product;
        }

        private void OnProductEdit( object sender, EventArgs e )
        {
            //Are there any products?
            //var index = FindFirstProduct();
            //if (index < 0)
            // {
            //    return;
            //};

            var product = GetSelectedProduct();
            if (product == null)
            {
                MessageBox.Show("No products avaialble.");
                    return;
            };

            var child = new ProductDetailForm("Product Details");
            child.Product = product;
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            //TODO: Save product
           // _database.Update = child.Product;
        }

        private void OnProductDelete( object sender, EventArgs e )
        {
            //var index = FindFirstProduct();
            //if (index < 0)
            //    return;

            // var _product = _products[index];
            var product = GetSelectedProduct();
            if (product == null)
                return;

            //Confirm
            if (MessageBox.Show(this, $"Are you sure you want to delete '{product.Name}'?",
                  "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            //TODO: Delete product
            //_database.Remove = null;
        }

        

        private void OnHelpAbout( object sender, EventArgs e )
        {
            var about = new AboutBox();
            about.ShowDialog(this);
        }

       // private Product[] _products = new Product[100];
        private ProductDatabase _database = new ProductDatabase();

    }
}

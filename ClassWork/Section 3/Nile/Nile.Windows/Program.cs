using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nile.Windows
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //String Split example
           // var csv = "Field1 | Field2 ,, Field3 | Field4";
           // var delimeters = new char[2];
            //delimeters[0] = '|';
            //delimeters[1] = ',';
           // var tokens = csv.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
           // var numberOfElements = tokens.Length;
            
           /* var product = new Product();
           // product.Name = "Product A";
            var price = product.DiscountedPrice;
            var name = product.Name;
            */

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}

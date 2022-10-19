using DemoExamApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoExamApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageListProduct.xaml
    /// </summary>
    public partial class PageListProduct : Page
    {
        public PageListProduct()
        {
            InitializeComponent();

            LViewProduct.ItemsSource = TradeEntities.GetContext().Product.ToList();
            
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string search = TxtSearch.Text;
            if (TxtSearch.Text != null)
            LViewProduct.ItemsSource = TradeEntities.GetContext().Product.
                Where(x=>x.ProductManufacturer.Contains(search)
                || x.ProductName.Contains(search)
                || x.ProductDescription.Contains(search)
                || x.ProductCost.ToString().Contains(search)).ToList();
        }
    }
}

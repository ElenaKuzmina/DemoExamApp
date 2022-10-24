using DemoExamApp.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
        

        public DbQuery<Product> listProduct = TradeEntities.GetContext().Product;
        public PageListProduct()
        {
            InitializeComponent();

            LViewProduct.ItemsSource = listProduct.ToList();

            CmbFiltr.Items.Add("Все производители");
            foreach(var item in listProduct.
                Select(x => x.ProductManufacturer).Distinct().ToList())
                CmbFiltr.Items.Add(item);

        }

                   

        private void RbUp_Checked(object sender, RoutedEventArgs e)
        {//сортировка по возрастанию стоимости
            listProduct = (DbQuery<Product>)listProduct.OrderBy(x => x.ProductCost);
            LViewProduct.ItemsSource = listProduct.ToList();
        }

        private void RbDown_Checked(object sender, RoutedEventArgs e)
        {//сортировка по убыванию стоимости

            listProduct = (DbQuery<Product>)listProduct.OrderByDescending(x => x.ProductCost);
            LViewProduct.ItemsSource = listProduct.ToList();


        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {//поиск
            string search = TxtSearch.Text;
            if (TxtSearch.Text != null)
            {
                listProduct = (DbQuery<Product>)listProduct.Where(x => x.ProductManufacturer.Contains(search)
                        || x.ProductName.Contains(search)
                        || x.ProductDescription.Contains(search)
                        || x.ProductCost.ToString().Contains(search));

                LViewProduct.ItemsSource = listProduct.ToList();
            }
            


        }

        private void CmbFiltr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//фильтрация по производителю

            if (CmbFiltr.SelectedValue.ToString() == "Все производители")

            {
                listProduct = (DbQuery<Product>)listProduct.Select(x => x.ProductManufacturer);
                LViewProduct.ItemsSource = listProduct.ToList();

            }
               // LViewProduct.ItemsSource = TradeEntities.GetContext().Product.;
            else
            {
                listProduct = (DbQuery<Product>)listProduct.Where(x => x.ProductManufacturer == CmbFiltr.SelectedValue.ToString());

                LViewProduct.ItemsSource = listProduct.ToList();
            }

                
        }
    }
}

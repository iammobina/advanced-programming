using Assignment5;
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
using System.Windows.Shapes;

namespace Assignment7
{
    /// <summary>
    /// Interaction logic for IngredientForm.xaml
    /// </summary>
    public partial class IngredientForm : Window
    {
        public Ingredient NewIngredient
        {
            get
            {
                return new Ingredient(
                    this.Title.Text,
                    this.Description.Text,
                    double.Parse(this.Quantity.Text),
                    this.Unit.Text
                    );
            }
            set
            {
                this.Title.Text = value.Name;
                this.Description.Text = value.Description;
                this.Quantity.Text = value.Quantity.ToString();
                this.Unit.Text = value.Unit;
            }
        }
        public IngredientForm()
        {
            InitializeComponent();
        }

        private void ingOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void ingCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}

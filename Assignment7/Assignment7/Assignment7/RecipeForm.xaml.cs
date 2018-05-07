using Assignment5;
using Microsoft.Win32;
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
    /// Interaction logic for RecipeForm.xaml
    /// </summary>
    public partial class RecipeForm : Window
    {
        public Recipe NewRecipe
        {
            get
            {
                return new Recipe(
                this.RecipeTitle.Text,
                this.Instruction.Text,
                ConvertToIngredientArray(this.IngredientsListBox.Items),
                int.Parse(this.ServingSize.Text),
                this.Cuisine.Text,
                this.Keywords.Text.Split()
                );
            }
            set
            {
                this.RecipeTitle.Text = value.Title;
                this.Instruction.Text = value.Instructions;
                //this.IngredientsListBox.Items[] = value.ingredientlist;
                this.ServingSize.Text = value.ServingCount.ToString();
                this.Cuisine.Text = value.Cuisine;
                this.Keywords.Text = value.Keyword.ToString();
            }
        }

        private Ingredient[] ConvertToIngredientArray(ItemCollection items)
        {
            List<Ingredient> ingList = new List<Ingredient>();
            foreach(var item in items)
            {
                if (item is Ingredient)
                    ingList.Add(item as Ingredient);
            }
            return ingList.ToArray();
        }

        public RecipeForm()
        {
            InitializeComponent();
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            if (IngredientsListBox.SelectedItem != null)
                IngredientsListBox.Items.Remove(IngredientsListBox.SelectedItem);
            else
                MessageBox.Show($" مواد اولیه ای برای حذف انتخاب نشده است.");
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            IngredientForm ingredientForm = new IngredientForm();
            bool dialogResult = (bool)ingredientForm.ShowDialog();
            if (dialogResult)
                IngredientsListBox.Items.Add(ingredientForm.NewIngredient);
            else
                if(dialogResult == false)
                IngredientsListBox.Items.Remove(ingredientForm.NewIngredient);

        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            if (IngredientsListBox.SelectedItem != null)
            {
                Ingredient ing = IngredientsListBox.SelectedItem as Ingredient;
                IngredientForm ingredientForm = new IngredientForm();
                ingredientForm.NewIngredient = ing;
                bool dialogResult = (bool)ingredientForm.ShowDialog();
                if(dialogResult)
                {
                    IngredientsListBox.Items.Remove(ing);
                    IngredientsListBox.Items.Add(ingredientForm.NewIngredient);
                }
            }
            else
            {
                MessageBox.Show($" ماده ای برای حذف انتخاب نشده است.");
            }
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}

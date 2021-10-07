using Assignment5;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Assignment7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int Capacity = 100;
        public RecipeBook RecipeBook = new RecipeBook("دفترچه غذا", Capacity);
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            RecipeForm frm = new RecipeForm();
            bool dialogResult =(bool)frm.ShowDialog();
            if(dialogResult)
            {
                var recipe = frm.NewRecipe;
                this.RecipeListBox.Items.Add(frm.NewRecipe);
                this.RecipeBook.Add(recipe);
            }
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string loadFileName = openFileDialog.FileName;
                Load loadfile = new Load(File.ReadAllText(openFileDialog.FileName));
                loadfile.ShowDialog();

            }
            
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListBox.SelectedItem != null)
                RecipeListBox.Items.Remove(RecipeListBox.SelectedItem);
            else
                MessageBox.Show($" ماده ای برای حذف انتخاب نشده است.");
        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListBox.SelectedItem != null)
            {
                Recipe recipe = RecipeListBox.SelectedItem as Recipe;
                RecipeForm recipeForm = new RecipeForm();
                recipeForm.NewRecipe = recipe;
                bool dialogResult = (bool)recipeForm.ShowDialog();
                if (dialogResult)
                {
                    RecipeListBox.Items.Remove(recipe);
                    RecipeListBox.Items.Add(recipeForm.NewRecipe);
                }
            }
            else
            {
                MessageBox.Show($" مواد اولیه ای برای حذف انتخاب نشده است.");
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            Recipe recipe = RecipeBook.LookupByTitle(this.search.Text);
            RecipeForm recipeForm = new RecipeForm();
            recipeForm.NewRecipe = recipe;
            if ((bool)recipeForm.ShowDialog())
            {
                RecipeListBox.Items.Remove(recipe);
                RecipeListBox.Items.Add(recipeForm.NewRecipe);
            }
            else if (RecipeBook.LookupByCuisine(this.search.Text) != null)
            {
                Recipe recipes = RecipeBook.LookupByCuisine(this.search.Text);
                RecipeForm RecipeForm = new RecipeForm();
                recipeForm.NewRecipe = recipe;
                if ((bool)recipeForm.ShowDialog())
                {
                    RecipeListBox.Items.Remove(recipe);
                    RecipeListBox.Items.Add(recipeForm.NewRecipe);
                }
            }
            else if (RecipeBook.LookupByKeyword(this.search.Text) != null)
            {
                Recipe recipes =RecipeBook.LookupByCuisine(this.search.Text);
                RecipeForm RecipeForm = new RecipeForm();
                recipeForm.NewRecipe = recipe;
                if ((bool)recipeForm.ShowDialog())
                {
                    RecipeListBox.Items.Remove(recipe);
                    RecipeListBox.Items.Add(recipeForm.NewRecipe);
                }
            }           
        }
    }       
 }
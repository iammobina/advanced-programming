using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment5
{
    /// <summary>
    /// دستور پخت 
    /// </summary>
    public class Recipe
    {
        

        /// <summary>
        /// ایجاد دستور پخت جدید
        /// </summary>
        /// <param name="title">عنوان</param>
        /// <param name="instructions">دستورات</param>
        /// <param name="ingredients">لیست مواد مورد نیاز</param>
        /// <param name="servingCount">تعداد افراد</param>
        /// <param name="cuisine">سبک غذا</param>
        /// <param name="keywords">کلمات کلیدی</param>
        public Recipe(string title, string instructions, List<Ingredient> ingredients, int servingCount, string cuisine, List<string> keywords)
        {
            // بر عهده دانشجو
            this.Title = title;
            this.Instructions = instructions;
            this.ingredients = ingredients;
<<<<<<< HEAD
            this.ServingCount = servingCount;
            this.Cuisine = cuisine;
            this.Keyword = keywords;
=======
>>>>>>> a8
            this.ServingCount = servingCount;
            this.Cuisine = cuisine;
            this.Keyword = keywords;
        }

        /// <summary>
        /// ایجاد شئ دستور پخت جدید
        /// </summary>
        /// <param name="title">عنوان</param>
        /// <param name="instructions">دستورات</param>
        /// <param name="ingredientCount">تعداد مواد مورد نیاز</param>
        /// <param name="servingCount">تعداد افراد</param>
        /// <param name="cuisine">سبک غذا</param>
        /// <param name="keywords">کلمات کلیدی</param>
        public Recipe(string title, string instructions, int ingredientCount, int servingCount, string cuisine, List<string> keywords)
        {
            // بر عهده دانشجو
            this.Title = title;
            this.Instructions = instructions;
            this.ServingCount = servingCount;
            this.Cuisine = cuisine;
            this.Keyword = keywords;
            this.ingredients = new List<Ingredient>();
<<<<<<< HEAD

        }

        public List<Ingredient> ingredients;
            this.IngredientCount = ingredientCount;
            this.ingredientlist = new List <Ingredient>(IngredientCount);
=======
>>>>>>> a8

        }

        public List<Ingredient> ingredients;

        public string Title;
        public string Instructions;
        public int IngredientCount;
        public int ServingCount;
        public string Cuisine;
        public List<string> Keyword;

        /// <summary>
        /// ذخیره اطلاعات دستور پخت غذای این شیء در فایل.
        /// </summary>
        /// <param name="writer">شیء مورد استفاده برای نوشتن در فایل</param>
        public void Serialize(StreamWriter writer)
        {
            writer.WriteLine(this.Title);
            writer.WriteLine(this.Instructions);
<<<<<<< HEAD
            writer.WriteLine(this.ServingCount);
            for (int i = 0; i < this.Keyword.Count; i++)
                writer.Write($"{this.Keyword[i]},");
            writer.WriteLine();
            writer.WriteLine(this.Cuisine);
            writer.WriteLine(this.ingredients.Count);
            for (int i = 0; i < this.ingredients.Count; i++)
                this.ingredients[i].Serialize(writer);
            writer.WriteLine(this.IngredientCount);
=======
>>>>>>> a8
            writer.WriteLine(this.ServingCount);
            for (int i = 0; i < this.Keyword.Count; i++)
                writer.Write($"{this.Keyword[i]},");
            writer.WriteLine();
            writer.WriteLine(this.Cuisine);
            writer.WriteLine(this.ingredients.Count);
            for (int i = 0; i < this.ingredients.Count; i++)
                this.ingredients[i].Serialize(writer);
        }
        /// <summary>
        ///  خواندن اطلاعات دستور پخت غذا از فایل و ایجاد شیء جدید از نوع این کلاس 
        /// </summary>
        /// <param name="reader">شیء مورد استفاده برای خواندن از فایل</param>
        /// <returns>شیء جدید از نوع Recipe</returns>
        public static Recipe Deserialize(StreamReader reader,string title)
<<<<<<< HEAD
        {
            // بر عهده دانشجو
            string instructions = reader.ReadLine();
            int servingCount = int.Parse(reader.ReadLine());
            List<string> keyword = reader.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string cuisine = reader.ReadLine();
            int ingredientCount = int.Parse(reader.ReadLine());
            List<Ingredient> ing = new List<Ingredient>();
            Ingredient _ingredients;
            for (int i = 0; i < ingredientCount; i++)
            {
                _ingredients = Ingredient.Deserialize(reader);
                ing.Add(_ingredients);
            }
            return new Recipe(title, instructions, ing, servingCount, cuisine, keyword);
        public static Recipe Deserialize(StreamReader reader)
=======
>>>>>>> a8
        {
            // بر عهده دانشجو
            string instructions = reader.ReadLine();
            int servingCount = int.Parse(reader.ReadLine());
            List<string> keyword = reader.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string cuisine = reader.ReadLine();
            int ingredientCount = int.Parse(reader.ReadLine());
            List<Ingredient> ing = new List<Ingredient>();
            Ingredient _ingredients;
            for (int i = 0; i < ingredientCount; i++)
            {
                _ingredients = Ingredient.Deserialize(reader);
                ing.Add(_ingredients);
            }
            return new Recipe(title, instructions, ing, servingCount, cuisine, keyword);
        }
        /// <summary>
        /// حذف تمام مواد اولیه که با نام ورودی تطبیق میکند
        /// </summary>
        /// <param name="name">نام ماده اولیه برای حذف</param>
        /// <returns>آیا حداقل یک ماده اولیه حذف شد؟</returns>
        public bool RemoveIngredient(string name)
        {
            // بر عهده دانشجو
            foreach (var ing in this.ingredients)
                if (ing.Name == name)
<<<<<<< HEAD
                {
                    this.ingredients.Remove(ing);
            for (int i = 0; i < ingredientlist.Count; i++)
                if (ingredientlist[i].Name == name)
=======
>>>>>>> a8
                {
                    this.ingredients.Remove(ing);
                    return true;
                }
            return false;
        }

        /// <summary>
        /// بروز کردن تعداد افرادی که این دستور غذا برای آن تعداد مناسب است
        /// مقادیر مواد اولیه به نسبت لازم اضافه میشود
        /// </summary>
        /// <param name="newServingCount">تعداد افراد جدید</param>
        public void UpdateServingCount(int newServingCount)
        {
            // بر عهده دانشجو
<<<<<<< HEAD

            foreach (var ing in this.ingredients)
                ing.Quantity = (double)(newServingCount * ing.Quantity) / this.ServingCount;
            this.ServingCount = newServingCount;

            for (int i = 0; i < ingredientlist.Count; i++)
            {
                Ingredients[i].Quantity = (Ingredients[i].Quantity * newServingCount);
            }
            ServingCount = newServingCount;
            
        }
=======
            foreach (var ing in this.ingredients)
                ing.Quantity = (double)(newServingCount * ing.Quantity) / this.ServingCount;
            this.ServingCount = newServingCount;
>>>>>>> a8

        }
        
        public override string ToString()
        {
            // بر عهده دانشجو
            return "RecipeName :{Title} -instruction :{Instructions}  -ingCount : {IngredientCount} -ServingCount : {ServingCount} -Cuisine: {Cuisine}";
              

            
        }
    }
}

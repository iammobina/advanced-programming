using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    /// <summary>
    /// کتابچه دستور غذا
    /// </summary>
    public class RecipeBook
    {
        /// <summary>
        /// لیست دستور غذاها
        /// </summary>
       
        public List<Recipe> recipe;
        public string Title;
        public int Capacity;

        /// <summary>
        /// ایجاد شیء کتابچه دستور غذا
        /// </summary>
        /// <param name="title">عنوان کتابچه غذا</param>
        /// <param name="capacity">ظرفیت کتابچه</param>
        public RecipeBook(string title, int capacity)
        {
            // بر عهده دانشجو
            Title = title;
            Capacity = capacity;
            recipe = new List<Recipe>();
        }

        /// <summary>
        /// اضافه کردن یک دستور پخت جدید
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns>آیا اضافه کردن موفقیت آمیز انجام شد؟</returns>
        public bool Add(Recipe recipe)
        {
            for (int i = 0; i < this.recipe.Count; i++)
            {
                if (this.recipe[i] == null)
                {
                    this.recipe[i] = recipe;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// حذف دستور پخت
        /// </summary>
        /// <param name="recipeTitle">عنوان دستور پخت</param>
        /// <returns>آیا حذف دستور پخت درست انجام شد؟</returns>
        public bool Remove(string recipeTitle)
        {

            // بر عهده دانشجو
            foreach (var recipe in this.recipe)
                if (recipe.Title == recipeTitle)
                {
                    this.recipe.Remove(recipe);
                    return true;
                }
            return false;

        }

        /// <summary>
        /// پیدا کردن دستور پخت با عنوان
        /// </summary>
        /// <param name="title">عنوان دستور پخت</param>
        /// <returns>شیء دستور پخت</returns>
        public Recipe LookupByTitle(string title)
        {
            // بر عهده دانشجو
            foreach (var recipe in this.recipe)
                if (recipe.Title == title)
                {
                    return recipe;
                }
            //Console.WriteLine("not found");
            return null;
        }

        /// <summary>
        /// پیدا کردن دستور پخت غذا با سبک پخت
        /// </summary>
        /// <param name="cuisine">سبک پخت</param>
        /// <returns>لیست دستور غذاهای سبک پخت داده شده</returns>
        public List<Recipe> LookupByCuisine(string cuisine)
        {
            // بر عهده دانشجو
            List<Recipe> LookUpByCuisine = new List<Recipe>();
            for (int i = 0; i < recipe.Count; i++)
                if (recipe[i].Cuisine == cuisine)
                    LookUpByCuisine.Add(recipe[i]);
            return LookUpByCuisine;
        }

        /// <summary>
        /// پیدا کردن دستور پخت غذا با کلمه کلیدی
        /// </summary>
        /// <param name="keyword">کلمه کلیدی</param>
        /// <returns>دستور غذاهای دارای کلمه کلیدی</returns>
        public List<Recipe> LookupByKeyword(string keyword)
        {
            // بر عهده دانشجو
            List<Recipe> LookUpByKeyword = new List<Recipe>();
            for (int i = 0; i < recipe.Count; i++)
                for (int j = 0; j < recipe[i].Keyword.Count; j++)
                    if (recipe[i].Keyword[j] == keyword)
                        LookUpByKeyword.Add(recipe[i]);
            return LookUpByKeyword;
        }

        /// <summary>
        /// ذخیره لیست دستور پخت غذاها در فایل.
        /// </summary>
        /// <param name="receipeFilePath">آدرس فایل</param>
        public bool Save(string receipeFilePath)
        {
            using (StreamWriter writer = new StreamWriter(receipeFilePath, false, Encoding.UTF8))
            {

                foreach (var r in this.recipe)
                {
                    r.Serialize(writer);

                }
                return true;
            }
        }


        /// <summary>
        /// بارگزاری اطلاعات از فایل ذخیره شده
        /// </summary>
        /// <param name="receipeFilePath">آدرس فایل</param>
        /// <returns>آیا بارگزاری با موفقیت انجام ش؟</returns>
        public bool Load(string receipeFilePath)
        {
            if (!File.Exists(receipeFilePath))
                return false;
            using (StreamReader reader = new StreamReader(receipeFilePath))
            {
                string title;
                while ((title = reader.ReadLine()) != null)
                {
                    Recipe r = Recipe.Deserialize(reader, title);
                    this.recipe.Add(r);
                }
            }
            return true;
        }
     }
  }
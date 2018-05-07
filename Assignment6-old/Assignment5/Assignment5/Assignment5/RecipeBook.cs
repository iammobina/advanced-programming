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
       
        public Recipe[] recipe;
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
            recipe = new Recipe[Capacity];
        }

        /// <summary>
        /// اضافه کردن یک دستور پخت جدید
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns>آیا اضافه کردن موفقیت آمیز انجام شد؟</returns>
        public bool Add(Recipe recipe)
        {
            for (int i = 0; i < this.recipe.Length; i++)
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
            for (int i = 0; i < recipe.Length; i++)
            {
                if (recipe[i].Title == recipeTitle)
                {
                    recipe[i] = null;
                    return true;
                }
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
            for (int i=0;i<recipe.Length;i++)
            {
                    if (recipe[i] == null)
                    {
                        continue;
                    }
                    if (recipe[i].Title == title)
                {
                    return recipe[i];
                }
            }
            return null;
        }

        /// <summary>
        /// پیدا کردن دستور پخت غذا با کلمه کلیدی
        /// </summary>
        /// <param name="keyword">کلمه کلیدی</param>
        /// <returns>دستور غذاهای دارای کلمه کلیدی</returns>
        public Recipe LookupByKeyword(string keyword)
        {
            // بر عهده دانشجو
            for (int i = 0; i < recipe.Length; i++)
            {
                if (recipe[i] == null || recipe[i].Keyword==null)
                {
                    continue;
                }
                for (int k = 0; k < recipe[i].Keyword.Length; k++)
                    if (recipe[i].Keyword[k] == keyword)
                        return recipe[k];

            }

            return null;
        }

        /// <summary>
        /// پیدا کردن دستور پخت غذا با سبک پخت
        /// </summary>
        /// <param name="cuisine">سبک پخت</param>
        /// <returns>لیست دستور غذاهای سبک پخت داده شده</returns>
        public Recipe LookupByCuisine(string cuisine)
        {
            // بر عهده دانشجو
            for (int i = 0; i < recipe.Length; i++)
            {
                if (recipe[i] == null)
                {
                    continue;
                }
                if (recipe[i].Cuisine == cuisine)
                {
                    return recipe[i];
                }

            }
            return null;
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
                    if (r != null)
                    {
                        r.Serialize(writer);
                    }
                }
                return true;
            }
        }


        /// <summary>
        /// بارگزاری اطلاعات از فایل ذخیره شده
        /// </summary>
        /// <param name="receipeFilePath">آدرس فایل</param>
        /// <returns>آیا بارگزاری با موفقیت انجام شد؟</returns>
        public bool Load(string receipeFilePath)
            {
                if (!File.Exists(receipeFilePath))
                    return false;

               using (StreamReader reader = new StreamReader(receipeFilePath))
                {
                    //int recipeCount = int.Parse(reader.ReadLine());

                    for (int i = 0; i < this.recipe.Length; i++)
                    {
                        Recipe r = Recipe.Deserialize(reader);
                        if (null == r)
                        {
                            // Deserialize returns null if it reaches end of file.
                            break;
                        }
                        this.recipe[i] = r;
                    }
                }
                return true;
            }
        }

    }
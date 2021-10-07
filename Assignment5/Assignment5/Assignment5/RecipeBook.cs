using System;
using System.Collections.Generic;
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
        public Recipe[] listrecipe;
        public string Title { get;  set; }
        public int Capacity { get; set; }

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
            listrecipe = new Recipe[Capacity];
        }

        /// <summary>
        /// اضافه کردن یک دستور پخت جدید
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns>آیا اضافه کردن موفقیت آمیز انجام شد؟</returns>
        public bool Add(Recipe recipe)
        {
            for (int i = 0; i < listrecipe.Length; i++)
            {
                if (listrecipe[i] == null)
                {
                    listrecipe[i] = recipe;
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
            for (int i = 0; i < listrecipe.Length; i++)
            {
                if (listrecipe[i].Title == recipeTitle)
                {
                    listrecipe[i] = null;
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
            for (int i=0;i<listrecipe.Length;i++)
            {
                if(listrecipe[i].Title == title)
                {
                    return listrecipe[i];
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
            for (int i = 0; i < listrecipe.Length; i++)
                for (int k = 0; k < listrecipe.Length; k++)
                if (listrecipe[i].Keyword[k] == keyword)
                return listrecipe[k];
                
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
            for (int i = 0; i < listrecipe.Length; i++)
            {
                if (listrecipe[i].Cuisine == cuisine)
                {
                    return listrecipe[i];


                }
            }

            return null;
        }

    }
}

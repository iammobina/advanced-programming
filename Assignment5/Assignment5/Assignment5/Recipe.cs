using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Recipe(string title, string instructions, Ingredient[] ingredients, int servingCount, string cuisine, string[] keywords)
        {
            // بر عهده دانشجو
            this.Title = title;
            Instructions = instructions;
            ingredientlist = ingredients;
            IngredientCount = ingredients.Length;
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
        public Recipe(string title, string instructions, int ingredientCount, int servingCount, string cuisine, string[] keywords)
        {
            // بر عهده دانشجو
            this.Title = title;
            this.Instructions = instructions;
            this.IngredientCount = ingredientCount;
            this.ServingCount = servingCount;
            this.Cuisine = cuisine;
            this.Keyword = keywords;
            ingredientlist = new Ingredient[ingredientCount];
        }
        public int ingcount { get; set; }
        public string instructions { get; set; }
        public Ingredient[] ingredientCount { get; set; }
        public int servingcount { get; set; }
        public string[] keyword { get; set; }

        /// <summary>
        /// اضافه کردن ماده اولیه 
        /// </summary>
        /// <param name="ingredient">ماده اولیه</param>
        /// <returns>عمل اضافه کردن موفقیت آمیز انجام شد یا خیر. در صورت تکمیل ظرفیت مقدار برگشتی "خیر" میباشد.</returns>
        public bool AddIngredient(Ingredient ingredient)
        {
            // بر عهده دانشجو
            for (int i=0;i<ingredientlist.Length;i++)
            {
                if(ingredientlist[i] == null)
                {
                    ingredientlist[i] = ingredient;
                    return true;
                }

            }
            return false;
        }

        /// <summary>
        /// حذف تمام مواد اولیه که با نام ورودی تطبیق میکند
        /// </summary>
        /// <param name="name">نام ماده اولیه برای حذف</param>
        /// <returns>آیا حداقل یک ماده اولیه حذف شد؟</returns>
        public bool RemoveIngredient(string name)
        {
            // بر عهده دانشجو
            for (int i = 0; i < ingredientlist.Length; i++)
            {
                if (ingredientlist[i].Name == name)
                {
                    ingredientlist[i] = null;
                    return true;
                }
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
            for (int i = 0; i < ingredientlist.Length; i++)
            {
                Ingredients[i].Quantity = (Ingredients[i].Quantity * newServingCount);
            }
            ServingCount = newServingCount;
            
        }

        /// <summary>
        /// فیلد پیشتیبان برای Ingredients.
        /// </summary>
        private Ingredient[] _Ingredients;

        /// <summary>
        /// مواد اولیه
        /// </summary>
        public Ingredient[] Ingredients {
            get
            {
                return _Ingredients;
            }
            private set
            {
                // بر عهده دانشجو
                            
            }
        }

        public string[] Keyword { get;  set; }
        public string Cuisine { get; set; }
        public int ServingCount { get;  set; }
        public int IngredientCount { get;  set; }
        public string Instructions { get;  set; }
        public string Title { get;  set; }
        public Ingredient[] ingredientlist { get;  set; }
        public int servingcounter { get; set; }

        public override string ToString()
        {
            // بر عهده دانشجو
            return $"Recipe Name :{Title}" +
                $"-describtion :{Instructions}  " +
                $"-cuisine: {Cuisine} " +
                $" -ServingCount : {ServingCount} " +
                $"-keyword{Keyword}";
            
        }
    }
}

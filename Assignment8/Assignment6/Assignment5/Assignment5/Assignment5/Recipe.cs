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
            this.ServingCount = servingCount;
            this.Cuisine = cuisine;
            this.Keyword = keywords;
            this.IngredientCount = ingredients.Count;
            this.ingredientlist = ingredients;
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
            this.IngredientCount = ingredientCount;
            this.ingredientlist = new List <Ingredient>(IngredientCount);

        }

        public string Title;
        public string Instructions;
        public int IngredientCount;
        public int ServingCount;
        public string Cuisine;
        public List<string> Keyword;
        public List<Ingredient> ingredientlist;
        public List<Ingredient> ingredients;



        /// <summary>
        /// اضافه کردن ماده اولیه 
        /// </summary>
        /// <param name="ingredient">ماده اولیه</param>
        /// <returns>عمل اضافه کردن موفقیت آمیز انجام شد یا خیر. در صورت تکمیل ظرفیت مقدار برگشتی "خیر" میباشد.</returns>
        public bool AddIngredient(Ingredient ingredient)
        {
            // بر عهده دانشجو
            for (int i = 0; i < ingredientlist.Count; i++)
            { 
                if (ingredientlist[i] == null)
                {
                    ingredientlist[i] = ingredient;
                    return true;
                }    
            }
            return false;
        }
        /// <summary>
        /// ذخیره اطلاعات دستور پخت غذای این شیء در فایل.
        /// </summary>
        /// <param name="writer">شیء مورد استفاده برای نوشتن در فایل</param>
        public void Serialize(StreamWriter writer)
        {
            writer.WriteLine(this.Title);
            writer.WriteLine(this.Instructions);
            writer.WriteLine(this.IngredientCount);
            writer.WriteLine(this.ServingCount);
            writer.WriteLine(this.Cuisine);
            for (int i = 0; i < this.Keyword.Count; i++)
                writer.WriteLine($"{this.Keyword[i]}");
            for (int i = 0; i < this.ingredientlist.Count; i++)
                this.ingredientlist[i].Serialize(writer);
        }
        /// <summary>
        ///  خواندن اطلاعات دستور پخت غذا از فایل و ایجاد شیء جدید از نوع این کلاس 
        /// </summary>
        /// <param name="reader">شیء مورد استفاده برای خواندن از فایل</param>
        /// <returns>شیء جدید از نوع Recipe</returns>
        public static Recipe Deserialize(StreamReader reader)
        {
            // بر عهده دانشجو
            string title = reader.ReadLine();
            if (title == null) return null;
            string instructions = reader.ReadLine();
            int ingredientCount = int.Parse(reader.ReadLine());
            int servingCount = int.Parse(reader.ReadLine());
            string cuisine = reader.ReadLine();
            List<string> keyword= reader.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<Ingredient> inging = new List<Ingredient>();
            for (int i = 0; i < inging.Count; i++)
                inging[i] = Ingredient.Deserialize(reader);
            return new Recipe(title, instructions, inging, servingCount, cuisine, keyword);
        }
        /// <summary>
        /// حذف تمام مواد اولیه که با نام ورودی تطبیق میکند
        /// </summary>
        /// <param name="name">نام ماده اولیه برای حذف</param>
        /// <returns>آیا حداقل یک ماده اولیه حذف شد؟</returns>
        public bool RemoveIngredient(string name)
        {
            // بر عهده دانشجو
            for (int i = 0; i < ingredientlist.Count; i++)
                if (ingredientlist[i].Name == name)
                {
                    ingredientlist[i] = null;
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
            for (int i = 0; i < ingredientlist.Count; i++)
            {
                Ingredients[i].Quantity = (Ingredients[i].Quantity * newServingCount);
            }
            ServingCount = newServingCount;
            
        }

        /// <summary>
        /// فیلد پیشتیبان برای Ingredients.
        /// </summary>
         //Ingredient[] _Ingredients;

        /// <summary>
        /// مواد اولیه
        /// </summary>
        public Ingredient[] Ingredients {
            get
            {
                return Ingredients;
            }
            private set
            {
                // بر عهده دانشجو
                            
            }
        }
        
        public override string ToString()
        {
            // بر عهده دانشجو
            return "Recipe Name :{Title} -instruction :{Instructions}  -ingCount : {IngredientCount} -ServingCount : {ServingCount} -Cuisine: {Cuisine}";
              

            
        }
    }
}

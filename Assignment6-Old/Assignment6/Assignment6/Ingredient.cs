using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Assignment5
{
    /// <summary>
    /// یک جزء از ترکیبات دستور غذا
    /// </summary>
    public class Ingredient
    {
        /// <summary>
        /// ایجاد شئ مشخصات یکی از مواد اولیه دستور غذا
        /// </summary>
        /// <param name="name">نام</param>
        /// <param name="description">توضیح</param>
        /// <param name="quantity">مقدار</param>
        /// <param name="unit">واحد مقدار</param>
        public Ingredient(string name, string description, double quantity, string unit)
        {
            // بر عهده دانشجو
            Name = name;
            Description = description;
            Quantity = quantity;
            Unit = unit;
        }

        /// <summary>
        /// ذخیره اطلاعات مواد اولیه این شیء در فایل.
        /// </summary>
        /// <param name="writer">شیء مورد استفاده برای نوشتن در فایل</param>
        public void Serialize(StreamWriter writer)
        {
            // بر عهده دانشجو
            writer.WriteLine(this.Name);
            writer.WriteLine(this.Description);
            writer.WriteLine(this.Quantity);
            writer.WriteLine(this.Unit);
        }

        /// <summary>
        ///  خواندن اطلاعات مواد اولیه از فایل و ایجاد شیء جدید از نوع این کلاس 
        /// </summary>
        /// <param name="reader">شیء مورد استفاده برای خواندن از فایل</param>
        /// <returns>شیء جدید از نوع Ingredient</returns>
        public static Ingredient Deserialize(StreamReader reader)
        {
            // بر عهده دانشجو
            string name = reader.ReadLine();
            string describtion = reader.ReadLine();
            double quantity = double.Parse(reader.ReadLine());
            string unit = reader.ReadLine();
            return new Ingredient(name, describtion, quantity, unit);
        }
        /// <summary>
        /// نام ماده اولیه
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// توضیح: از کجا پیدا کنیم یا اگر نداشتیم جایگزین چه چیزی استفاده کنیم
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// مقدار
        /// </summary>
        public double Quantity { get; set; }

        /// <summary>
        /// واحد مقدار: مثلا گرم، کیلوگرم، عدد
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// تبدیل به متن
        /// </summary>
        /// <returns>متن معادل برای این ماده اولیه - قابل استفاده برای چاپ در خروجی</returns>
        public override string ToString()
        {
            return $"{Name}:" +$"{Description}"+ $"{Quantity}" + $" {Unit} ";
               

        }
    }
}

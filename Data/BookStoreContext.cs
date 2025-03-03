using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryToProduct> CategoryToProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryToProduct>()
               .HasKey(t => new { t.ProductId, t.CategoryId });
            //modelBuilder.Entity<Item>()
            //            .HasOne(i => i.Product)
            //            .WithOne(p => p.Item)
            //            .HasForeignKey<Product>(p => p.ItemId); // تعیین کلید خارجی در Product
            //modelBuilder.Entity<Product>(p => 
            //{
            //    p.HasKey(w => new { w.Id, w.ItemdId});
            //    p.OwnsOne<Item>(w => w.Item);
            //    p.HasOne<Item>(w => w.Item).WithOne(w => w.Product).HasForeignKey<Item>(w => w.Id);


            //  });
            modelBuilder.Entity<Item>(i =>
            {
                i.Property(w => w.Price).HasColumnType("Money");
                i.HasKey(w => w.Id);
            });
            modelBuilder.Entity<CategoryToProduct>().HasKey(t => new { t.ProductId, t.CategoryId });
            #region seedData
            modelBuilder.Entity<Category>().HasData(new Category()
            {
                Id = 1,
                Name = "فانتزی (Fantasy)",
                Description = "این ژانر در جهان داستانی‌ای واقع شده که غالبا از افسانه‌ها و فولکور در جهان واقعی الهام گرفته شده است. ریشه این ژانر در سنت‌های شفاهی است و از قرن بیستم به رسانه های مختلفی از جمله فیلم، تلویزیون، رمان، فیلم‌های متحرک و بازی های ویدیویی راه یافته است.\r\nبا وجود همپوشانی برخی ژانرها با هم، این ژانر از کتاب به دلیل عدم وجود مضامین علمی و خیلی مهم، از ژانرهای دیگری چون علمی و ترسناک، متمایز است. این ژانر یکی از محبوب‌ترین انواع کتاب است"

            }, new Category()
            {
                Id = 2,
                Name = "ماجراجویی (Action and adventure)",
                Description = "داستانهای ماجراجویی، ژانری از داستان‌ها هستند که معمولاً خطرآفرینند یا هیجان را به خواننده القا می کنند."

            }, new Category()
            {
                Id = 3,
                Name = "عاشقانه (Romance)",
                Description = "این نوع کتاب، بر اساس روابط و احساسات بین دو نفر شکل گرفته شده‌است. اینگونه رمان‌ها خود به زیردسته‌هایی تقسیم می‌شوند. مثلا بهترین رمان های تاریخی عاشقانه یکی از این زیردسته‌هاست."
            }, new Category()
            {
                Id = 4,
                Name = " ترسناک (Horror)",
                Description = "نویسنده در این سبک با تصویر کردن یک فضای وهم آور و ترسناک سعی در ترساندن و تهییج خواننده دارد. غالباً آنچه در یک کتاب داستانی ترسناک یک تهدید محسوب می‌شود، استعاره ای از ترس بزرگتر یک جامعه است."

            }, new Category()
            {
                Id = 5,
                Name = "مهیج (Thriller)",
                Description = "در این نوع از انواع کتاب، اغلب قهرمانی سرسخت و باهوش دیده می‌شود. اما این قهرمان انسانی معمولی است که در برابر اشرار قرار می‌گیرد و سعی در نجات کشور و … است."

            }, new Category()
            {
                Id = 6,
                Name = " علمی تخیلی (Science fiction)",
                Description = "داستان‌های علمی-تخیلی، ژانری از کتاب است که به‌طور معمول با مفاهیم خیالی و آینده نگرانه سروکار دارد. مفاهیمی چون علم و فناوری، اکتشافات فضایی، سفر در زمان، جهان‌های موازی و زندگی فرازمینی.\r\nاین ژانر علاوه بر سرگرمی، می‌تواند جامعه‌ی امروزی را نیز مورد انتقاد قرار دهد و در بسیاری موارد نیز الهام‌بخش و زمینه‌ساز اکتشافات جدید باشد."

            }, new Category()
            {
                Id = 7,
                Name = "هنری(Art)",
                Description = "بیشتر کتاب‌های هنری،به شرح چگونگی خلق آثار هنری می‌پردازد. این آثار می‌تواند شامل آثار دیداری، شنیداری، نمایشی و … باشند.\r\nبسیاری ازین نوع کتاب‌ها، به بررسی زندگی هنرمندان بزرگ و معروف می‌پردازند و یا آثار هنری آنها را مورد نمقد و بررسی قرار می‌دهند. مطالعه تاریخ هنر و بررسی جنبه‌های زیباشناسانه‌ی آثار هنری از دیگر مباحثی است که در کتاب‌های هنری مورد توجه قرار می‌گیرد."

            }, new Category()
            {
                Id = 8,
                Name = "انگیزشی(Motivational)",
                Description = "کتاب‌های انگیزشی ما را برای روبرویی با چالش‌های احتمالی زندگی واقعی آماده می‌کنند. در زندگی تمام انسان‌ها لحظاتی پیش می‌آید که از زندگی ناامید می‌شویم و تمام نیرو و انرژی‌مان تحلیل می‌رود. اینجاست که کتاب‌های انگیزشی به کمک ما می‌آیند.\r\nکتاب‌های روانشناسی و انگیزشی به خواننده فرصت شناخت خود را می‌دهد و به این ترتیب با نیروی بازیافته، مصمم به سمت هدف می‌رویم."

            }, new Category()
            {
                Id = 9,
                Name = "طنز(Humer)",
                Description = "نویسنده در کتاب‌های طنز، با ادبیاتی شیرین و نغز، مسائل مهم اجتماعی و سیاسی را با نگاهی نقادانه به رشته‌ی تحریر در می‌آورد. در این کتاب‌ها، تمام معایب و مفاسد و کمبودها به گونه‌ای اغراق‌آمیز بیان می‌شود تا زشتی آن مسئله بیشتر دیده‌شود.\r\n\r\n"

            }, new Category()
            {
                Id = 10,
                Name = "کودکان(Children’s)",
                Description = "کودک تنها به خوراک و پوشاک نیاز ندارد. هرچند این‌ها نیازهای اولیه‌ی هر انسانی‌ست، اما رشد ذهنی نیز اهمیت ویژه‌ای در تربیت کودکان دارد.\r\nوظیفه‌ی هر والدی اینست که زمینه را برای چگونه زیستن و نحوه‌ی شکل‌گیری افکار و شخصیت کودکانمان هموار کند. چاپ کتاب‌ کودک و نوجوان کمک بزرگی برای خانواده‌ها محسوب می‌شوند."

            }, new Category()
            {
                Id = 11,
                Name = " کتاب های زندگینامه",
                Description = "در این کتاب ها به شرح حال زندگی افراد پرداخته می‌شود، معمولا این نوع از کتاب ها به زبان خوده شخص و یا یک فرد دیگر برای افراد مشهور و شناخته شده نوشته میشود."

            }


            );
            modelBuilder.Entity<Item>().HasData(
                new Item() { Id = 1, Price = 85000, QuantityInStock = 5 },
                new Item() { Id = 2, Price = 115000, QuantityInStock = 8 },
                new Item() { Id = 3, Price = 320000, QuantityInStock = 3 }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, ItemId = 2, Name = "مزرعه حیوانات", Description = "این توضیحات جهت تست کردن می باشد و هیچگونه استفاده دیگری از آن ممنون می‌باشد" },
                new Product() { Id = 2, ItemId = 3, Name = "1984", Description = "این توضیحات جهت تست کردن می باشد و هیچگونه استفاده دیگری از آن ممنون می‌باشد" },
                new Product() { Id = 3, ItemId = 1, Name = "انسان خردمند", Description = "این توضیحات جهت تست کردن می باشد و هیچگونه استفاده دیگری از آن ممنون می‌باشد" }

                );
            modelBuilder.Entity<CategoryToProduct>().HasData(
                new CategoryToProduct() { CategoryId = 1, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 2, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 3, ProductId = 3 },
                new CategoryToProduct() { CategoryId = 4, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 5, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 6, ProductId = 3 }


                );

            #endregion
            base.OnModelCreating(modelBuilder);

        }
    }
}

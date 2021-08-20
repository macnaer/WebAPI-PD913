using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_15.Controllers;

namespace WebAPI_15.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(
                    new Book()
                    {
                        Title = "C# 8.0 and .NET Core 3.0 – Modern Cross-Platform Development: Build applications with C#",
                        Description = "C# 8.0 and .NET Core 3.0 – Modern Cross-Platform Development: Build applications with C#",
                        IsRead = true,
                        Rate = 4,
                        DateRead = DateTime.Now.AddDays(-24),
                        Genre = "Programming",
                        ImageURL = "https://m.media-amazon.com/images/I/51+AEbYTT8L.jpg",
                        DateAdded = DateTime.Now.AddDays(-48)
                    },
                    new Book()
                    {
                        Title = "1984",
                        Description = "Последний роман «1984» культового британского писателя Джорджа Оруэлла вышел в 1949 году — за год до его смерти. Он имел бешеную популярность в Англии и США, был переведен более чем на шестьдесят языков, неоднократно экранизировался. Но в Советском Союзе долгие годы даже имени его автора никто не слышал... Отечественные политики называли Оруэлла троцкистом. Его книги были под запретом сорок лет. «Роман Оруэлла представляет собой разнузданную клевету на социализм и социалистическое общество», — говорилось об антиутопии «1984» в секретной записке Всесоюзного общества культурной связи с заграницей.",
                        IsRead = false,
                        Genre = "Romance",
                        ImageURL = "https://img.yakaboo.ua/media/catalog/product/cache/1/image/398x565/31b681157c4c1a5551b0db4896e7972f/c/o/cover1__w600_1__120.jpg",
                        DateAdded = DateTime.Now.AddDays(-178)
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}

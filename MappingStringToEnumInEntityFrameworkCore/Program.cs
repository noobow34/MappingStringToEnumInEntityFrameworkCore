using EnumStringValues;
using Microsoft.EntityFrameworkCore;
using System;

namespace MappingStringToEnumInEntityFrameworkCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //InMemoryDBを使う
            var options = new DbContextOptionsBuilder<TestDbContext>()
                            .UseInMemoryDatabase(databaseName: "TEST")
                            .Options;

            //登録
            using(var context = new TestDbContext(options))
            {
                context.Users.Add(new User { Id = 1, Name = "Bob", Gender = GenderEnum.Male }); //Maleは'M'として登録される
                context.Users.Add(new User { Id = 2, Name = "Elizabeth", Gender = GenderEnum.Female }); //Femaleは'F'として登録される
                context.SaveChanges();
            }

            //取得
            using (var context = new TestDbContext(options))
            {
                foreach (var user in context.Users)
                {
                    Console.WriteLine($"Id:{user.Id}");
                    Console.WriteLine($"Name:{user.Name}");
                    Console.WriteLine($"Gender(Enum):{user.Gender}");
                    Console.WriteLine($"Gender(String):{user.Gender.GetStringValue()}");
                    Console.WriteLine("---------------------------");
                }
            }
        }
    }
}

using EnumStringValues;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace MappingStringToEnumInEntityFrameworkCore
{
    class Program
    {
        //SQLiteのファイルパス（変更してください）
        //SQLiteの場合、ファイルが存在しない場合は自動的に作成される
        const string dbFileName = @"C:\temp\test.sqlite3";
        static void Main(string[] args)
        {
            //フォルダが存在しない場合は作成
            Directory.CreateDirectory(Path.GetDirectoryName(dbFileName));

            var options = new DbContextOptionsBuilder<TestDbContext>()
                            .UseSqlite($"Data Source={dbFileName}")
                            .Options;

            //テーブルが存在しない場合は作成
            using (var context = new TestDbContext(options))
            {
                context.Database.EnsureCreated();
            }

            //登録
            using (var context = new TestDbContext(options))
            {
                context.Users.Add(new User { Name = "Bob", Gender = GenderEnum.Male }); //Maleは'M'として登録される
                context.Users.Add(new User { Name = "Elizabeth", Gender = GenderEnum.Female }); //Femaleは'F'として登録される
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

using EnumStringValues;
using Microsoft.EntityFrameworkCore;

namespace MappingStringToEnumInEntityFrameworkCore
{
    public class TestDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public TestDbContext(DbContextOptions<TestDbContext> option) : base(option) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Conversionを使用してEnumとの対応関係を定義
            modelBuilder.Entity<User>()
               .Property(u => u.Gender)
               .HasConversion
               (g => g.GetStringValue() //EnumをGetStringValueしたものがDBに登録される
               , g => ((string)g).ParseToEnum<GenderEnum>()); //DBから取得した値をParseToEnumしたものがEnumとしてプロパティに格納される
        }
    }
}

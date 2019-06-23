using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MappingStringToEnumInEntityFrameworkCore
{
    [Table("USER")]
    public class User
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("NAME")]
        public string Name { get; set; }
        [Column("GENDER")]
        public GenderEnum Gender { get; set; }
    }
}

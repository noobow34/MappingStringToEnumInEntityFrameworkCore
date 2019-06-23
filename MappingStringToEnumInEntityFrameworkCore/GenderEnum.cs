using EnumStringValues;

namespace MappingStringToEnumInEntityFrameworkCore
{
    public enum GenderEnum
    {
        [StringValue("M")]
        Male,
        [StringValue("F")]
        Female
    }
}

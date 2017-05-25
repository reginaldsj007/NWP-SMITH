using DapperExtensions.Mapper;

namespace CategoryAPI.Mappers
{
    public class CategoryMapper : ClassMapper<Category>
    {
        public CategoryMapper()
        {
            base.Schema("dbo");
            base.Table("Categories");
            Map(x => x.CategoryID).Key(KeyType.Identity);
            AutoMap();
        }
    }
}

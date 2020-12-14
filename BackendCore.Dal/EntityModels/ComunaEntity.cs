using Dapper.Contrib.Extensions;

namespace BackendCore.Dal.EntityModels
{
    [Table("Comuna")]
    public class ComunaEntity : BaseEntityModel
    {
        public string Name { get; set; }
    }
}

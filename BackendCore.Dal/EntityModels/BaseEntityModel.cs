using Dapper.Contrib.Extensions;
using System;

namespace BackendCore.Dal.EntityModels
{
    public class BaseEntityModel
    {
        [Key]
        public long Id { get; set; }

        [Computed]
        public DateTime CreatedAt { get; set; }
    }
}

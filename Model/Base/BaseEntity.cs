using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIFornecedor.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}

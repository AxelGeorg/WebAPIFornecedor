using System.ComponentModel.DataAnnotations.Schema;
using WebAPIFornecedor.Model.Base;

namespace WebAPIFornecedor.Model
{
    [Table("fornecedor")]
    public class Fornecedor : BaseEntity
    {
        [Column("nome")]
        public string Nome { get; set; }

        [Column("email")]
        public string Email { get; set; }
    }
}

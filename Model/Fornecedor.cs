using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using WebAPIFornecedor.Model.Base;

namespace WebAPIFornecedor.Model
{
    [Table("fornecedor")]
    public class Fornecedor : BaseEntity
    {
        [Column("nome")]
        [JsonPropertyOrder(2)]
        public string Nome { get; set; }

        [Column("email")]
        [JsonPropertyOrder(3)]
        public string Email { get; set; }
    }
}

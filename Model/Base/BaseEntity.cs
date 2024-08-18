using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPIFornecedor.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        [JsonPropertyOrder(1)]
        public long Id { get; set; }
    }
}

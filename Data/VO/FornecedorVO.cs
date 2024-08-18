using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPIFornecedor.Data.VO
{
    public class FornecedorVO
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace WebApp.Model
{
    public class AutorModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        
        /// Livros associados ao autor.
        [JsonIgnore]
        public ICollection<LivroModel> Livros { get; set; }
    }
}

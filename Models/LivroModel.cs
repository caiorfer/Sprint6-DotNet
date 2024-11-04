namespace WebApp.Model
{
    public class LivroModel
    {
        public int Id { get; set; }

        public string Titulo { get; set; }
        
        /// Autor do livro.
        public AutorModel Autor { get; set; }
    }
}

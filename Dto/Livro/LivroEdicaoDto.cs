using WebApp.Model;

namespace WebApp.Dto.Livro
{
    public class LivroEdicaoDto
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public AutorModel Autor { get; set; }
    }
}

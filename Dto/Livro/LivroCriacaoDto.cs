using WebApp.Model;

namespace WebApp.Dto.Livro
{
    public class LivroCriacaoDto
    {
        public string Titulo { get; set; }

        public AutorVinculoDto Autor { get; set; }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq; 
using WebApp.Services.Autor;
using WebApp.Model;
using WebApp.Dto.Autor;

namespace WebApp.Testes
{
    public class WebAppTeste
    {
        private readonly Mock<IAutorInterface> _autorInterfaceMock;
        private readonly AutorService _autorService;

        public WebAppTeste()
        {
            // Criar um mock para IAutorInterface
            _autorInterfaceMock = new Mock<IAutorInterface>();
            _autorService = new AutorService(_autorInterfaceMock.Object);
        }

        [Fact]
        public async Task ListarAutores_DeveRetornarListaDeAutores()
        {
            // Arrange
            var autores = new List<AutorModel>
            {
                new AutorModel { Id = 1, Nome = "Autor 1", Sobrenome = "Sobrenome 1" },
                new AutorModel { Id = 2, Nome = "Autor 2", Sobrenome = "Sobrenome 2" }
            };

            _autorInterfaceMock.Setup(a => a.ListarAutores()).ReturnsAsync(new ResponseModel<List<AutorModel>> { Dados = autores, Status = true });

            // Act
            var resultado = await _autorService.ListarAutores();

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.Status);
            Assert.Equal(2, resultado.Dados.Count);
        }

        [Fact]
        public async Task CriarAutor_DeveRetornarAutorCriado()
        {
            // Arrange
            var autorCriacaoDto = new AutorCriacaoDto { Nome = "Novo Autor", Sobrenome = "Novo Sobrenome" };
            var novoAutor = new AutorModel { Id = 3, Nome = "Novo Autor", Sobrenome = "Novo Sobrenome" };

            _autorInterfaceMock.Setup(a => a.CriarAutor(autorCriacaoDto)).ReturnsAsync(new ResponseModel<List<AutorModel>> { Dados = new List<AutorModel> { novoAutor }, Status = true });

            // Act
            var resultado = await _autorService.CriarAutor(autorCriacaoDto);

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.Status);
            Assert.Single(resultado.Dados);
            Assert.Equal("Novo Autor", resultado.Dados[0].Nome);
        }
    }
}

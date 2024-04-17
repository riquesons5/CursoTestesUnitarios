using CursoTesteUnitario.DominioTest._Util;
using ExpectedObjects;
using System;
using Xunit;

namespace CursoTesteUnitario.DominioTest.Cursos
{
    public class CursoTest
    {
        [Fact]
        public void DeveCriarCurso()
        {
            var cursoEsperado = new
            {
                Nome = "Informática básica",
                CargaHoraria = (decimal)80,
                PublicoAlvo = PulbicoAlvo.Estudante,
                Valor = (decimal)950,
            };

            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerUmNomeInvalido(string nomeInvalido)
        {
            var cursoEsperado = new
            {
                Nome = nomeInvalido,
                CargaHoraria = (decimal)80,
                PublicoAlvo = PulbicoAlvo.Estudante,
                Valor = (decimal)950,
            };

            Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor)).ComMensagem("Nome inválido");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmaCargaHorariaMenorQueUm(decimal cargaHoraria)
        {
            var cursoEsperado = new
            {
                Nome = "Informática básica",
                CargaHoraria = cargaHoraria,
                PublicoAlvo = PulbicoAlvo.Estudante,
                Valor = (decimal)950,
            };

            Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor)).ComMensagem("Carga horária inválida");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmValorMenoQueUm(decimal valorInvalido)
        {
            var cursoEsperado = new
            {
                Nome = "Informática básica",
                CargaHoraria = (decimal)80,
                PublicoAlvo = PulbicoAlvo.Estudante,
                Valor = valorInvalido,
            };

            Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor)).ComMensagem("Valor inválido");
        }
    }

    public enum PulbicoAlvo
    {
        Estudante,
        Universitario,
        Empregado,
        Empreendedor
    }

    public class Curso
    {
        public Curso(string nome, decimal cargaHoraria, PulbicoAlvo publicoAlvo, decimal valor)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome inválido");

            if (cargaHoraria < 1)
                throw new ArgumentException("Carga horária inválida");

            if (valor < 1)
                throw new ArgumentException("Valor inválido");

            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
        }

        public string Nome { get; private set; }
        public decimal CargaHoraria { get; private set; }
        public PulbicoAlvo PublicoAlvo { get; private set; }
        public decimal Valor { get; private set; }
    }
}

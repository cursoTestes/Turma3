using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SistemaVendas;

namespace TesteVendas
{
    [TestClass]
    public class TesteCalculadoraRoyalties
    {
        private Mock<IRepositorioVendas> mockRepository = null;
        private Mock<CalculadoraComissao> mockCalculadoraComissao = null;

        [TestInitialize]
        public void prepara()
        {
            mockRepository = new Mock<IRepositorioVendas>();
            mockCalculadoraComissao = new Mock<CalculadoraComissao>();
        }

        [TestMethod]
        public void teste_calcula_royalties_mes_sem_vendas_retorna_0()
        {
            int mes = 1;
            int ano = 2012;
            decimal royalties_esperado = 0;


            mockRepository.Setup(mock => mock.GetVendas(mes, ano)).Returns(new List<double>());
            mockCalculadoraComissao.Setup(mock => mock.calcula(0)).Returns(0);
            CalculadoraRoyalties calculadora = new CalculadoraRoyalties(mockRepository.Object, mockCalculadoraComissao.Object);

            decimal royalties_retornado = calculadora.CalculaRoyalties(mes, ano);

            Assert.AreEqual(royalties_esperado, royalties_retornado);

        }

        [TestMethod]
        public void teste_calcula_royalties_mes_com_vendas_1000_retorna_190()
        {
            int mes = 1;
            int ano = 2012;
            decimal royalties_esperado = 190;

            mockRepository.Setup(mock => mock.GetVendas(mes, ano)).Returns(new List<double> { 1000 });
            mockCalculadoraComissao.Setup(mock => mock.calcula(1000)).Returns(50);
            CalculadoraRoyalties calculadora = new CalculadoraRoyalties(mockRepository.Object, mockCalculadoraComissao.Object);

            decimal royalties_retornado = calculadora.CalculaRoyalties(mes, ano);

            Assert.AreEqual(royalties_esperado, royalties_retornado);

        }

        [TestMethod]
        public void teste_calcula_royalties_mes_com_uma_venda()
        {
            int mes = 1;
            int ano = 2012;
            double valor_venda = 1000;
            decimal royalties_esperado = 200;

            mockRepository.Setup(mock => mock.GetVendas(mes, ano)).Returns(new List<double> { valor_venda });
            mockCalculadoraComissao.Setup(mock => mock.calcula(valor_venda)).Returns(0);
            CalculadoraRoyalties calculadora = new CalculadoraRoyalties(mockRepository.Object, mockCalculadoraComissao.Object);

            decimal royalties_retornado = calculadora.CalculaRoyalties(mes, ano);

            Assert.AreEqual(royalties_esperado, royalties_retornado);
            mockCalculadoraComissao.Verify(mock => mock.calcula(valor_venda), Times.AtLeastOnce());

        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaVendas;

namespace TesteVendas
{
    
    [TestClass]
    public class TesteCalculoComissao
    {

        [TestMethod]
        public void teste_calcula_comissao_venda_100_retorna_5()
        {
            double valorVenda = 100;
            double valorEsperado = 5;
            CalculadoraComissao calculadoraComissao = new CalculadoraComissao();
            double valoRetorno = calculadoraComissao.calcula(valorVenda);
            Assert.AreEqual(valorEsperado, valoRetorno);           
        }

        [TestMethod]
        public void teste_calcula_comissao_venda_10000_retorna_500()
        {
            double valorVenda = 10000;
            double valorEsperado = 500;
            CalculadoraComissao calculadoraComissao = new CalculadoraComissao();
            double valoRetorno = calculadoraComissao.calcula(valorVenda);
            Assert.AreEqual(valorEsperado, valoRetorno);
        }

        [TestMethod]
        public void teste_calcula_comissao_venda_1_retorna_5_centavos()
        {
            double valorVenda = 1;
            double valorEsperado = 0.05;
            CalculadoraComissao calculadoraComissao = new CalculadoraComissao();
            double valoRetorno = calculadoraComissao.calcula(valorVenda);
            Assert.AreEqual(valorEsperado, valoRetorno);
        }

        [TestMethod]
        public void teste_calcula_comissao_venda_11000_retorna_660()
        {
            double valorVenda = 11000;
            double valorEsperado = 660;
            CalculadoraComissao calculadoraComissao = new CalculadoraComissao();
            double valoRetorno = calculadoraComissao.calcula(valorVenda);
            Assert.AreEqual(valorEsperado, valoRetorno);
        }

        [TestMethod]
        public void teste_calcula_comissao_venda_110000_retorna_6600()
        {
            double valorVenda = 110000;
            double valorEsperado = 6600;
            CalculadoraComissao calculadoraComissao = new CalculadoraComissao();
            double valoRetorno = calculadoraComissao.calcula(valorVenda);
            Assert.AreEqual(valorEsperado, valoRetorno);
        }

        [TestMethod]
        public void teste_calcula_comissao_venda_55_reais_59_centavos_retorna_2_reais_77_centavos()
        {
            double valorVenda = 55.59;
            double valorEsperado = 2.77;
            CalculadoraComissao calculadoraComissao = new CalculadoraComissao();
            double valoRetorno = calculadoraComissao.calcula(valorVenda);
            Assert.AreEqual(valorEsperado, valoRetorno);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVendas
{
    public class CalculadoraRoyalties
    {
        private IRepositorioVendas repositorioVendas = null;

        private CalculadoraComissao calculadoraComissao = null;

        public CalculadoraRoyalties(IRepositorioVendas pRepositorioVendas, CalculadoraComissao pCalculadoraComissao)
        {
            repositorioVendas = pRepositorioVendas;
            calculadoraComissao = pCalculadoraComissao;
        }

        public decimal CalculaRoyalties(int mes, int ano)
        {
            List<double> listaVendas = repositorioVendas.GetVendas(mes, ano);

            double valorTotalRoyalties = 0;            

            foreach (var valorVenda in listaVendas)
	        {
                valorTotalRoyalties += valorVenda -calculadoraComissao.calcula(valorVenda);                
	        }
            
            return Convert.ToDecimal(valorTotalRoyalties * 0.2);
        }
    }
}

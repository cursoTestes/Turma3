using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVendas
{
    public class CalculadoraComissao
    {
        public virtual double calcula(double valorVenda)
        {
            double comissao = 0;

            if (valorVenda <= 10000)
                comissao = valorVenda * 0.05;
            else
                comissao = valorVenda * 0.06;

            comissao = Math.Floor(comissao * 100) /100;

            return comissao;
        }
    }
}

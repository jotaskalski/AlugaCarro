using AlugaCarro.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlugaCarro.ModuloCarro
{
    internal class TelaCarro : TelaBase
    {
        public TelaCarro(RepositorioCarro repositorioCarros)
        {
            repositorio = repositorioCarros;
            titulo = "Carro";
        }

        protected override void MostrarRegistros()
        {
            ArrayList carro = repositorio.RetornarRegistro();
            Console.WriteLine("{0,-10} |{1,-10} |{2,-10} | {3,-10}", "ID", "Cor", "Marca", "Modelo");
            foreach (Carro c in carro)
            {
                Console.WriteLine("{0,-10} |{1,-10} |{2,-10} | {3,-10}", c.id, c.cor, c.marca, c.modelo);
            }
            Console.ReadLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.WriteLine("Digite a cor do carro: ");
            string cor = Console.ReadLine();
            Console.WriteLine("Digite a placa do carro: ");
            string placa = Console.ReadLine();
            Console.WriteLine("Digite a modelo do carro: ");
            string modelo = Console.ReadLine();
            Console.WriteLine("Digite a chassi do carro: ");
            string chassi = Console.ReadLine();
            Console.WriteLine("Digite a data de fabricação do carro: ");
            string dataFabricacao = Console.ReadLine();
            Console.WriteLine("Digite a marca do carro: ");
            string marca = Console.ReadLine();

            return new Carro(cor, placa, modelo, chassi, dataFabricacao, marca);


        }
    }
}

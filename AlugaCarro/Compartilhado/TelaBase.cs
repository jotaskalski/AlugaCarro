using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlugaCarro.Compartilhado
{
    abstract class TelaBase
    {
        //interaçao usuario
        protected RepositorioBase repositorio = null;
        public string titulo = "";
        protected abstract void MostrarRegistros();
        protected abstract EntidadeBase ObterRegistro();
        protected int InserirId()
        {
            int id = 0;
            try
            {
                Console.WriteLine("Digite o ID");
                id = Convert.ToInt32(Console.ReadLine());

            }
            catch (FormatException)
            {
                Console.WriteLine("Entre com um ID válido");
                Console.ReadLine();
                InserirId();
                return 0;
            }
            return id;
        }
        protected void EditarRegistro()
        {
            int id = InserirId();
            if (repositorio.VerificarRegistro())
                return;
            EntidadeBase novoRegistro = ObterRegistro();
            repositorio.Editar(id, novoRegistro);
        }
        protected void Cadastrar()
        {
            EntidadeBase entidadeBase = ObterRegistro();
            repositorio.Inserir(entidadeBase);
        }
        public virtual void Menu()
        {
            int opcao = 0;
            do
            {
                Console.Clear();
                Cabecalho();
                Console.WriteLine("[1] Cadastrar [2] Visualizar [3] Editar [4] Excluir [5]");
                Console.WriteLine("Escolha uma opção");
                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1: Cadastrar(); break;
                    case 2: Visualizar(); break;
                    case 3: EditarRegistro(); break;
                    case 4: Excluir(); break;
                    case 5: Console.WriteLine($"Saindo do {titulo}"); break;
                    default:
                        Console.WriteLine("Digite uma opção válida.");
                        Console.ReadLine();
                        break;
                }
            } while (opcao != 5);
        }
        protected virtual void Cabecalho()
        {
            Console.WriteLine($"{titulo}");
            Console.WriteLine("------- > < ------");
        }
        protected virtual void Visualizar()
        {
            repositorio.VerificarRegistro();
            MostrarRegistros();
            //adicionar a visualização de tela depois.
        }
        protected virtual void Excluir()
        {
            int id = InserirId();
            repositorio.Excluir(id);

        }
    }
}

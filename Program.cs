using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Gerenciador_de_Livros
{
    class Program
    {
        static int Numero = 0;
        static string[] Livros;
        static string caminhoPasta = @"C:\Users\anaju\OneDrive\Documentos\IBRATEC\Gerenciador de Livros\Gerenciador de Livros\TxT\Livraria.txt";

        static void Main()
        {

            Livros = new string[0];

            carregarDadosVetor();

            while (Numero != 5)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(@"         __  ___ _         _                     _____       _                  _              ");
                Console.WriteLine(@"        |  \/  |(_)       | |                   |  ___|     | |                | |             ");
                Console.WriteLine(@"        | .  . | _  _ __  | |__    __ _         | |__   ___ | |_   __ _  _ __  | |_   ___      ");
                Console.WriteLine(@"        | |\/| || || '_ \ | '_ \  / _` |        |  __| / __|| __| / _` || '_ \ | __| / _ \     ");
                Console.WriteLine(@"        | |  | || || | | || | | || (_| |        | |___ \__ \| |_ | (_| || | | || |_ |  __/     ");
                Console.WriteLine(@"        \_|  |_/|_||_| |_||_| |_| \__,_|        \____/ |___/ \__| \__,_||_| |_| \__| \___|     ");
                Console.WriteLine("                                                                                                ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("[----------------------------------------------------------------------------------------------]");
                Console.WriteLine("[------------------------------DE ACORDO COM O MENU ABAIXO-------------------------------------]");
                Console.WriteLine("[----------------------------------------------------------------------------------------------]");
                Console.WriteLine("[----------------------------------Digite um número--------------------------------------------]");
                Console.WriteLine("[                               (1) Adicionar Livros                                           ]");
                Console.WriteLine("[                               (2) Visualizar Livros                                          ]");
                Console.WriteLine("[                               (3) Excluir Livro                                              ]");
                Console.WriteLine("[                               (4) Editar                                                     ]");
                Console.WriteLine("[                               (5) Fechar Programa                                            ]");
                Console.WriteLine("[----------------------------------------------------------------------------------------------]");
                Console.WriteLine("[----------------------------------------------------------------------------------------------]");
                Console.WriteLine("[----------------------------------------------------------------------------------------------]");
                Console.ResetColor();

                try
                {
                    Numero = Convert.ToInt32(Console.ReadLine());

                    if (Numero > 5)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Digite um número referente a ação desejada! Aperte ENTER para continuar!");
                        Console.ResetColor();
                        continue;
                    }
                    if (Numero < 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Digite um número referente a ação desejada! Aperte ENTER para continuar!");
                        Console.ResetColor();
                        Console.ReadKey();
                        continue;
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Digite apenas uma das opções acima! Aperte ENTER para continuar!");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }
                switch (Numero)
                {
                    case 1:
                        AdicionarLivros();
                        break;
                    case 2:
                        VizualizarLivros();
                        break;
                    case 3:
                        ExcluirLivro();
                      
                        break;
                    case 4:
                        Editar();
                        break;
                    case 5:
                        Numero = 5;
                        break;
                    default:
                        Console.WriteLine("Digite apenas os dados sugeridos. ");
                        Console.ReadKey();
                        return;

                }
            }
        }

        static void AdicionarLivros()
        {
            while (true)
            {
                Array.Resize(ref Livros, Livros.Length + 1);

                string StatusDeLeitura;
                string Nome, Autor, Editora, GeneroLiterario;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("[--------------------------------------------]");
                Console.WriteLine("[--------------CADASTRO DE LIVROS------------]");
                Console.WriteLine("[--------------------------------------------]");
                Console.WriteLine("Digite o nome do Livro");
                Nome = Console.ReadLine();
                if (Nome.Length <= 0)
                {
                    Console.WriteLine("Campo em branco");
                    Thread.Sleep(2000);
                    continue;
                }
                Console.WriteLine("Digite o nome do Autor");
                Autor = Console.ReadLine();
                if (Autor.Length <= 0)
                {
                    Console.WriteLine("Campo em branco");
                    Thread.Sleep(2000);
                    continue;
                }
                Console.WriteLine("Digite o nome da Editora");
                Editora = Console.ReadLine();
                if (Editora.Length <= 0)
                {
                    Console.WriteLine("Campo em branco");
                    Thread.Sleep(2000);
                    continue;
                }
                Console.WriteLine("Digite o Gênero Literario pertencente ao livro");
                GeneroLiterario = Console.ReadLine();
                if (GeneroLiterario.Length <= 0)
                {
                    Console.WriteLine("Campo em branco");
                    Thread.Sleep(2000);
                    continue;
                }
                Console.WriteLine("Digite o Status de Leitura");
                Console.WriteLine("Lido\t Em andamento\t Não lido");
                StatusDeLeitura = Console.ReadLine();
                if (StatusDeLeitura.Length <= 0)
                {
                    Console.WriteLine("Campo em branco");
                    Thread.Sleep(2000);
                    continue;
                }
                Console.WriteLine("[--------------------------------------------]");
                Console.WriteLine("[--------------------------------------------]");
                Console.WriteLine("[--------------------------------------------]");
                Console.ResetColor();

                if (StatusDeLeitura == "0" || StatusDeLeitura == "1" || StatusDeLeitura == "2" || StatusDeLeitura == "3" || StatusDeLeitura == "4" || StatusDeLeitura == "5" || StatusDeLeitura == "6" || StatusDeLeitura == "7" || StatusDeLeitura == "8" || StatusDeLeitura == "9")
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Ação invalida ! Aperte ENTER para continuar!");
                    Console.ResetColor();
                    continue;
                }
                else
                {
                    Livros[Livros.Length - 1] = $"Nome: {Nome} / Autor: {Autor} / Editoa: {Editora} / Genero: {GeneroLiterario} / Status: {StatusDeLeitura}";

                    atualizarDados();
                    break;
                }






            }
        }
        static void VizualizarLivros()
        {

            for (int i = 0; i < Livros.Length; i++)
            {
                Console.WriteLine("ID: " + (i + 1) + " / " + Livros[i]);
            }
            Console.ReadKey();

        }
        static void ExcluirLivro()
        {
            VizualizarLivros();
            int ID;
            Console.WriteLine("Digite o ID pertencente ao livro");
            ID = int.Parse(Console.ReadLine());

            for (int a = ID - 1; a < Livros.Length - 1; a++)
            {
                Livros[a] = Livros[a + 1];
            }
            Array.Resize(ref Livros, Livros.Length - 1);
            atualizarDados();
        }
        static void Editar()
        {
            string StatusDeLeitura;
            string Nome, Autor, Editora, GeneroLiterario;

            VizualizarLivros();
            int ID;
            Console.WriteLine("[-------------------------------------------------------------]");
            Console.WriteLine("[----------------------EDIÇÃO DE CADASTRO---------------------]");
            Console.WriteLine("[-------------------------------------------------------------]");
            Console.WriteLine("[Digite corretamente as opções abaixo para conclusão da edição]");
            Console.WriteLine("[-------------------------------------------------------------]");
            Console.WriteLine("Digite o ID pertencente ao livro");
            ID = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o nome do Livro");
            Nome = Console.ReadLine();
            Console.WriteLine("Digite o nome do Autor");
            Autor = Console.ReadLine();
            Console.WriteLine("Digite o nome da Editora");
            Editora = Console.ReadLine();
            Console.WriteLine("Digite o Gênero Literario pertencente ao livro");
            GeneroLiterario = Console.ReadLine();
            Console.WriteLine("Digite o Status de Leitura");
            Console.WriteLine("Lido\t Em andamento\tNão lido");
            StatusDeLeitura = Console.ReadLine();

            Livros[ID - 1] = $"Nome: {Nome} / Autor: {Autor} / Editroa: {Editora} / Genero: {GeneroLiterario} / Status: {StatusDeLeitura}";
            atualizarDados();
        }

        static void atualizarDados()
        {
            StreamWriter escArq = new StreamWriter(caminhoPasta, false);

            for (int i = 0; i < Livros.Length; i++)
            {
                escArq.WriteLine(Livros[i]);
            }

            escArq.Dispose();
        }

        static void carregarDadosVetor()
        {
            StreamReader lerArq = new StreamReader(caminhoPasta);

            while (!lerArq.EndOfStream)
            {
                Array.Resize(ref Livros, Livros.Length + 1);
                Livros[Livros.Length - 1] = lerArq.ReadLine();
            }

            lerArq.Dispose();

        }

    }
}


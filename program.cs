using System;

namespace ProjetoMedicamento
{
    class Program
    {
        static void Main(string[] args)
        {
            Medicamentos medicamentos = new Medicamentos();
            int opcao;

            do
            {
                Console.WriteLine("\n=== MENU MEDICAMENTOS ===");
                Console.WriteLine("0. Finalizar processo");
                Console.WriteLine("1. Cadastrar medicamento");
                Console.WriteLine("2. Consultar medicamento (sintético)");
                Console.WriteLine("3. Consultar medicamento (analítico)");
                Console.WriteLine("4. Comprar medicamento (cadastrar lote)");
                Console.WriteLine("5. Vender medicamento");
                Console.WriteLine("6. Listar medicamentos");
                Console.Write("Escolha: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();
                        Console.Write("Laboratório: ");
                        string lab = Console.ReadLine();

                        Medicamento med = new Medicamento(id, nome, lab);
                        medicamentos.Adicionar(med);
                        Console.WriteLine("Medicamento cadastrado!");
                        break;

                    case 2:
                        Console.Write("Informe o ID: ");
                        int idPesquisa = int.Parse(Console.ReadLine());
                        Medicamento encontrado = medicamentos.Pesquisar(new Medicamento(idPesquisa, "", ""));
                        if (encontrado != null)
                            Console.WriteLine(encontrado);
                        else
                            Console.WriteLine("Medicamento não encontrado.");
                        break;

                    case 3:
                        Console.Write("Informe o ID: ");
                        int idAnalitico = int.Parse(Console.ReadLine());
                        Medicamento analitico = medicamentos.Pesquisar(new Medicamento(idAnalitico, "", ""));
                        if (analitico != null)
                        {
                            Console.WriteLine(analitico);
                            analitico.ListarLotes();
                        }
                        else
                            Console.WriteLine("Medicamento não encontrado.");
                        break;

                    case 4:
                        Console.Write("ID do medicamento: ");
                        int idCompra = int.Parse(Console.ReadLine());
                        Medicamento medCompra = medicamentos.Pesquisar(new Medicamento(idCompra, "", ""));
                        if (medCompra != null)
                        {
                            Console.Write("ID do lote: ");
                            int idLote = int.Parse(Console.ReadLine());
                            Console.Write("Quantidade: ");
                            int qtdeLote = int.Parse(Console.ReadLine());
                            Console.Write("Data de vencimento (dd/mm/aaaa): ");
                            DateTime venc = DateTime.Parse(Console.ReadLine());

                            medCompra.Comprar(new Lote(idLote, qtdeLote, venc));
                            Console.WriteLine("Lote adicionado!");
                        }
                        else
                            Console.WriteLine("Medicamento não encontrado.");
                        break;

                    case 5:
                        Console.Write("ID do medicamento: ");
                        int idVenda = int.Parse(Console.ReadLine());
                        Medicamento medVenda = medicamentos.Pesquisar(new Medicamento(idVenda, "", ""));
                        if (medVenda != null)
                        {
                            Console.Write("Quantidade a vender: ");
                            int qtdeVenda = int.Parse(Console.ReadLine());
                            if (medVenda.Vender(qtdeVenda))
                                Console.WriteLine("Venda realizada com sucesso!");
                            else
                                Console.WriteLine("Estoque insuficiente.");
                        }
                        else
                            Console.WriteLine("Medicamento não encontrado.");
                        break;

                    case 6:
                        medicamentos.ListarTodos();
                        break;

                    case 0:
                        Console.WriteLine("Encerrando o programa...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

            } while (opcao != 0);
        }
    }
}

// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using CADASTRO_PESSOA.Classes;

Console.Clear();
Console.WriteLine(@"
======================================
|  Bem vindo ao sistema de Cadastros |
|     Pessoas Física e Jurídica      |
======================================
");

Console.BackgroundColor = ConsoleColor.DarkBlue;
Console.ForegroundColor = ConsoleColor.White;

barradecarregamento("Carregando ", 250);

List<PessoaFisica> listaPf = new List<PessoaFisica>();

string? opcao;

do
{
    Console.Clear();
    Console.WriteLine(@"

======================================
|     Escolha uma das opções         |
|------------------------------------|
|       1. PESSOA FÍSICA             |
|       2. PESSOA JURÍDICA           |
|                                    |
|       0. SAIR                      |
======================================
");

    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            PessoaFisica metodopf = new PessoaFisica();

            string? opcaoPf;

            do
            {
                Console.Clear();
                Console.WriteLine(@"
======================================
|     Escolha uma das opções         |
|------------------------------------|
|       1. CADASTRA PESSOA FÍSICA    |
|       2. MOSTRAR PESSOA FÍSICA     |
|                                    |
|       0. VOLTAR AO MENU ANTERIOR   |
======================================
");

                opcaoPf = Console.ReadLine();

                switch (opcaoPf)
                {
                    case "1":
                        PessoaFisica novaPF = new PessoaFisica();
                        Endereco novoEnd = new Endereco();

                        Console.WriteLine($"Digite o nome da pessoa física que deseja cadastrar: ");
                        novaPF.nome = Console.ReadLine();

                        bool dataValida;

                        do
                        {
                            Console.WriteLine($"Digite a data de nascimento ex.: dd/mm/aaa: ");
                            string dataNasc = Console.ReadLine();

                            dataValida = metodopf.ValidarDataNascimento(dataNasc);

                            if (dataValida)
                            {
                                novaPF.dataNascimento = dataNasc;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"Data digitada inválida. Favor digitar outra data");
                                Console.ResetColor();
                            }
                        } while (dataValida == false);


                        Console.WriteLine($"Digite o CPF: ");
                        novaPF.cpf = Console.ReadLine();

                        Console.WriteLine($"Digite o rendimento: ");
                        novaPF.rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o logradouro: ");
                        novoEnd.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o número: ");
                        novoEnd.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento: ");
                        novoEnd.complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é comercial? S/N. ");
                        string endCom = Console.ReadLine().ToUpper();
                        if (endCom == "S")
                        {
                            novoEnd.endComercial = true;
                        }
                        else
                        {
                            novoEnd.endComercial = false;
                        }

                        novaPF.endereco = novoEnd;

                        listaPf.Add(novaPF);

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Cadastro Realizado com Sucesso!");
                        Console.ResetColor();

                        break;

                    case "2":
                        Console.Clear();

                        if (listaPf.Count > 0)
                        {
                            foreach (PessoaFisica cadaPessoa in listaPf)
                            {
                                Console.Clear();
                                Console.WriteLine(@$"
                            Nome: {cadaPessoa.nome}
                            Endereço: {cadaPessoa.endereco.logradouro}, {cadaPessoa.endereco.numero}
                            Data de Nascimento: {cadaPessoa.dataNascimento}
                            Taxa de imposto a ser paga é: {metodopf.PagarImposto(cadaPessoa.rendimento).ToString("C")}
                            ");

                                Console.WriteLine($"Aperte enter para continuar");
                                Console.ReadLine();


                            }

                        }
                        else
                        {
                            Console.WriteLine($"Lista Vazia!");
                            Thread.Sleep(3000);
                        }


                        break;

                    case "0":
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine($"Opção inválida. Escolha outra opção");
                        Thread.Sleep(2000);
                        break;
                }


            } while (opcaoPf != "0");


            Console.Clear();

            break;

        case "2":
            //AQUI É A PESSOA JURIDICA SÓ PASSANDO OS DADOS

            PessoaJuridica metodoPJ = new PessoaJuridica();

            PessoaJuridica novaPj = new PessoaJuridica();
            Endereco novoEndPj = new Endereco();

            novaPj.nome = "Bruno Grecco";
            novaPj.cnpj = "00.000.000/0001-00";
            novaPj.razaoSocial = "Grecco Melo Company";
            novaPj.rendimento = 8000.5f;

            novoEndPj.logradouro = "Alameda Barão de Limeira";
            novoEndPj.numero = 590;
            novoEndPj.complemento = "Perto do Senai";
            novoEndPj.endComercial = true;

            Console.Clear();

            Console.WriteLine(@$"
            Nome: {novaPj.nome}
            Razão Social: {novaPj.razaoSocial}
            CNPJ: {novaPj.cnpj}
            CNPJ Válido?: {metodoPJ.ValidarCNPJ("00.000.000/0001-00")}
            Endereço: {novoEndPj.logradouro}, {novoEndPj.numero}, {novoEndPj.complemento}
            ");

            // Console.WriteLine($"{metodoPJ.ValidarCNPJ("00.000.000/0001-00")}");
            // Console.WriteLine($"{metodoPJ.ValidarCNPJ("00000000000100")}");

            Console.WriteLine($"Aperte enter para voltar");
            Console.ReadLine();

            break;

        case "0":
            Console.Clear();
            Console.WriteLine($"Obrigado por utilizar nosso sistema");

            barradecarregamento("Finalizando ", 200);

            Console.Clear();

            break;
        default:
            Console.Clear();
            Console.WriteLine($"Opção inválida. Escolha outra opção");
            Thread.Sleep(2000);
            break;
    }
} while (opcao != "0");

static void barradecarregamento(string texto, int tempo)
{

    Console.BackgroundColor = ConsoleColor.DarkBlue;
    Console.ForegroundColor = ConsoleColor.White;

    Console.Write($"{texto}");

    for (var contador = 0; contador < 10; contador++)
    {
        Console.Write(". ");
        Thread.Sleep(tempo);
    }

    Console.ResetColor();

}

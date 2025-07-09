
/*
                    Fazer em seguida: Sistema de gestão de biblioteca (console) com CRUD de livros e usuários.


    1. Cadastro de livros
        Título, 
        autor, 
        editora, 
        ano, 
        categoria. 
        Quantidade de exemplares disponíveis.

    2. Cadastro de usuários
        Nome, 
        matrícula ou número de identificação, 
        e-mail, 
        telefone.

    3. Empréstimo de livros
        Registro de qual livro foi emprestado a qual usuário.
        Datas de empréstimo e de devolução previstas.

    4. Devolução de livros
        Atualização do status do livro como disponível.
        Cálculo de multa por atraso, se aplicável.
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using TREINO.Entities;
using TREINO.Services;

namespace TREINO
{
    class Program
    {
        static void Main()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\n\n==== SISTEMA DE GESTÃO DE BIBLIOTECA ====");
                Console.WriteLine("1. Cadastrar Livro");
                Console.WriteLine("2. Cadastrar Usuário");
                Console.WriteLine("3. Realizar Empréstimo");
                Console.WriteLine("4. Realizar Devolução");
                Console.WriteLine("5. Listar Livros");
                Console.WriteLine("6. Listar Usuários");
                Console.WriteLine("7. Listar Empréstimos Ativos");
                Console.WriteLine("8. Gerenciar Usuário");
                Console.WriteLine("9. Gerenciar Livro");
                Console.WriteLine("10. Sair");

                int op;
                while (true) 
                {
                    Console.Write("\nEscolha uma das opções digitando um número: ");
                    string numero = Console.ReadLine().Trim();
                    if (!int.TryParse(numero, out op) || op <= 0 || op > 10)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um número 'inteiro' de 1 à 10 válido!");
                        continue;
                    }
                    break;
                }
                switch (op)
                {
                    case 1: 
                        CadastrarLivro(); 
                        break;
                    
                    case 2: 
                        CadastrarUsuario(); 
                        break;
                    
                    case 3: 
                        RealizarEmprestimo(); 
                        break;

                    case 4:
                        RealizarDevolucao();
                        break;

                    case 5:
                        ListarLivros();
                        break;

                    case 6:
                        ListarUsuarios();
                        break;

                    case 7:
                        ListarEmprestimosAtivos();
                        break;

                    case 8:
                        GerenciarUsuario();
                        break;

                    case 9:
                        GerenciarLivro();
                        break;

                    case 10:
                        return;

                    default: Console.WriteLine("Opção inválida!"); 
                        break;
                }
            }
        }

        private static List<Livros> listaLivros = new List<Livros>();

        private static List<Usuarios> listaUsuarios = new List<Usuarios>();

        private static List<Emprestimo> listaEmprestimos = new List<Emprestimo>();

        private static EmprestimoService emprestimoService = new EmprestimoService();

        private static DevolucaoService devolucaoService = new DevolucaoService();

        public static void CadastrarLivro()
        {
            string titulo, autor, editora, categoria; 
            int ano, quantidadeExemplares;

            Console.Clear();
            Console.WriteLine("1. Cadastrar Livro\n");
            while (true)
            {

                Console.Write("Título: ");
                titulo = Console.ReadLine().Trim().ToLower();
                if (!ValidarNome(titulo))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um titulo válido!");
                    continue;
                }
                titulo = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(titulo.ToLower());
                break;
            }
            while (true)
            {

                Console.Write("Autor: ");
                autor = Console.ReadLine().Trim().ToLower();
                if (!ValidarNome(autor))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um autor válido!");
                    continue;
                }
                autor = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(autor.ToLower());
                break;
            }
            while (true)
            {

                Console.Write("Editora: ");
                editora = Console.ReadLine().Trim().ToLower();
                if (string.IsNullOrWhiteSpace(editora) || !editora.All(c => char.IsLetter(c) || c == ' '))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite uma editora válida!");
                    continue;
                }
                editora = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(editora.ToLower());
                break;
            }
            while (true)
            {

                Console.Write("Ano lançamento: ");
                string anoLan = Console.ReadLine().Trim();
                if (!int.TryParse(anoLan, out ano) || anoLan.Length <= 0 || ano < 1700 || ano > 2025)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um ano válido!");
                    continue;
                }
                break;
            }
            while (true)
            {

                Console.Write("Categoria: ");
                categoria = Console.ReadLine().Trim().ToLower();
                if (string.IsNullOrWhiteSpace(categoria) || !categoria.All(c => char.IsLetter(c) || c == ' '))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite uma categoria válida!");
                    continue;
                }
                categoria = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(categoria.ToLower());
                break;
            }
            while (true)
            {

                Console.Write("Quantidade disponível: ");
                string qtd = Console.ReadLine().Trim();
                if (!int.TryParse(qtd, out quantidadeExemplares) || quantidadeExemplares <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite uma quantidade válida maior que zero!");
                    continue;
                }
                break;
            }
            Livros livro = new Livros(titulo, autor, editora, ano, categoria, quantidadeExemplares);
            listaLivros.Add(livro);
        }
        public static void CadastrarUsuario()
        {
            string nome, email;
            int matricula, telefone;

            Console.Clear();
            Console.WriteLine("2. Cadastrar Usuário\n");
            while (true)
            {

                Console.Write("Nome: ");
                nome = Console.ReadLine().Trim().ToLower();
                if (string.IsNullOrWhiteSpace(nome) || !nome.All(c => char.IsLetter(c) || c == ' '))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um nome válido!");
                    continue;
                }
                nome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());
                break;
            }
            while (true)
            {

                Console.Write("Matrícula: ");
                string matri = Console.ReadLine().Trim();
                if (!int.TryParse(matri, out matricula) || matri.Length <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite alguns números 'inteiros'!");
                    continue;
                }
                break;
            }
            while (true)
            {

                Console.Write("Email: ");
                email = Console.ReadLine().Trim().ToLower();
                if (string.IsNullOrWhiteSpace(email) || !email.Contains('@') || !email.Contains('.') || email.StartsWith("@") || email.EndsWith("@") || email.StartsWith(".") || email.EndsWith("."))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um email válido!");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.Write("Número celular: ");
                string tell = Console.ReadLine().Trim();
                if (!int.TryParse(tell, out telefone) || tell.Length <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite alguns números 'inteiros'!");
                    continue;
                }
                break;
            }
            Usuarios usuario = new Usuarios(nome, matricula, email, telefone);
            listaUsuarios.Add(usuario);
        }
        public static void RealizarEmprestimo()
        {
            Console.Clear();
            Console.WriteLine("3. Realizar Empréstimo\n");

            if (!listaLivros.Any() || !listaUsuarios.Any())
            {
                Console.Clear();
                Console.WriteLine("Cadastre livros e usuários primeiro! Tente novamente");
                return;
            }


            Console.WriteLine("Escolha um livro: ");
            for (int i = 0; i < listaLivros.Count; i++)
            {
                Console.WriteLine($"{i + 1}ª {listaLivros[i].Titulo}");
            }

            int indexEscolhaLivro;

            while (true)
            {
                string index = Console.ReadLine().Trim();
                if (!int.TryParse(index, out indexEscolhaLivro) || indexEscolhaLivro <= 0 || indexEscolhaLivro > listaLivros.Count)
                {
                    Console.Clear();
                    Console.WriteLine($"Entrada inválida. Digite um número 'inteiro' de 1 à {listaLivros.Count}!");
                    continue;
                }
                indexEscolhaLivro = indexEscolhaLivro - 1;
                break;
            }

            Console.Clear();
            Console.WriteLine("Escolha um usuário: ");
            for (int i = 0; i < listaUsuarios.Count; i++)
            {
                Console.WriteLine($"{i + 1}ª {listaUsuarios[i].Nome}");
            }
            int indexEscolhaUsuario;

            while (true)
            {
                string index = Console.ReadLine().Trim();
                if (!int.TryParse(index, out indexEscolhaUsuario) || indexEscolhaUsuario <= 0 || indexEscolhaUsuario > listaUsuarios.Count)
                {
                    Console.Clear();
                    Console.WriteLine($"Entrada inválida. Digite um número 'inteiro' de 1 à {listaUsuarios.Count}!");
                    continue;
                }
                indexEscolhaUsuario = indexEscolhaUsuario - 1;
                break;
            }

            try
            {
                var emprestimo = emprestimoService.RealizarEmprestimo(listaLivros[indexEscolhaLivro], listaUsuarios[indexEscolhaUsuario]);
                listaEmprestimos.Add(emprestimo);
                Console.WriteLine($"\nEmpréstimo realizado com sucesso!\nDevolução prevista: {emprestimo.DataDevolucaoPrevista:dd/MM/yyyy}\n\n");

            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"\nErro: {ex.Message}");
            }
        }
        public static void RealizarDevolucao() 
        {
            while (true)
            {
                Console.Clear();
                int indexEscolha;
                var emprestimoAtivos = listaEmprestimos.Where(e => !e.Devolvido).ToList();

                if (!emprestimoAtivos.Any())
                {
                    Console.Clear();
                    Console.WriteLine("Não há empréstimos ativos!");
                    break;
                }
                else
                {
                    Console.WriteLine("\nSelecione o empréstimo:");
                    for (int e = 0; e < emprestimoAtivos.Count; e++) 
                    {
                        Console.WriteLine($"{e + 1}ª {emprestimoAtivos[e].Livro.Titulo} - {emprestimoAtivos[e].Usuario.Nome}");
                    }

                    string indexEsc = Console.ReadLine().Trim();
                    if(!int.TryParse(indexEsc, out indexEscolha))
                    {
                        Console.Clear(); 
                        Console.WriteLine($"Entrada inválida. Digite um número 'inteiro' de 1 à {emprestimoAtivos.Count}");
                        continue;
                    }
                    indexEscolha = indexEscolha - 1;
                    devolucaoService.RealizarDevolucao(emprestimoAtivos[indexEscolha]);

                    if (emprestimoAtivos[indexEscolha].Multa > 0)
                    {
                        Console.WriteLine($"\nDevolução realizada com multa de R${emprestimoAtivos[indexEscolha].Multa:F2}");
                    }
                    else
                    {
                        Console.WriteLine("\nDevolução realizada com sucesso!");
                    }
                    break;
                }
            }
        }
        public static void ListarLivros() 
        {
            Console.Clear();
            while (true)
            {
                if (!listaLivros.Any())
                {
                    Console.WriteLine("Não há livros.");
                    break;
                }
                else
                {

                    Console.WriteLine("\t\tTodos os livros\n");
                    foreach (var l in listaLivros)
                    {
                        Console.WriteLine(l.ToString());
                    }
                    Console.WriteLine("==========================================\n");
                    break;
                }

            }
        }
        public static void ListarUsuarios() 
        {

            Console.Clear();
            while (true)
            {
                if (!listaUsuarios.Any())
                {
                    Console.WriteLine("Não há usuários.");
                    break;
                }
                else
                {
                    Console.WriteLine("\t\tTodos os Usuários\n");
                    foreach (var l in listaUsuarios)
                    {
                        Console.WriteLine(l.ToString());
                    }
                    Console.WriteLine("==========================================\n");
                    break;
                }
            }
        }
        public static void ListarEmprestimosAtivos() 
        {
            Console.Clear();
            while (true)
            {
                if (!listaEmprestimos.Any())
                {
                    Console.WriteLine("Não há empréstimos de livros.");
                    break;
                }
                else
                {
                    Console.WriteLine("\t\tTodos os Empréstimos\n");
                    foreach (var l in listaEmprestimos)
                    {
                        Console.WriteLine(l.ToString());
                    }
                    Console.WriteLine("==========================================\n");
                    break;
                }
            }

        }

        public static void GerenciarUsuario()
        {
            Console.Clear();
            if (!listaUsuarios.Any())
            {
                Console.WriteLine("Não há usuários cadastrados!");
                return;
            }

            int op;
            while (true)
            {
                Console.WriteLine("\n\n==== Gerenciar Usuário ====");
                Console.WriteLine("1. Remover Usuário");
                Console.WriteLine("2. Atualizar Usuário");
                Console.WriteLine("3. Voltar\n");


                Console.WriteLine("Escolha uma opção digitando o número de sua posição: ");
                string opcao = Console.ReadLine().Trim();
                if (!int.TryParse(opcao, out op) || op <= 0 || op > 3)
                {
                    Console.Clear();
                    Console.WriteLine($"Entrada inválida. Digite um número de 1 à 3");
                    continue;
                }

                if(op == 1)
                {
                    Console.Clear();
                    while (true)
                    { 
                        Console.WriteLine("Escolha um usuário digitando o número de sua posição para remove-lo: ");
                        for (int u = 0; u < listaUsuarios.Count; u++) 
                        {
                            Console.WriteLine($"{u+1}ª {listaUsuarios[u].Nome}");
                        }

                        int indexEscolha;
                        while (true)
                        {
                            string indexPosi = Console.ReadLine().Trim();
                            if(!int.TryParse(indexPosi, out indexEscolha) || indexEscolha < 1 || indexEscolha > listaUsuarios.Count) 
                            {
                                Console.Clear();
                                Console.WriteLine($"Entrada inválida. Digite um número de 1 à {listaUsuarios.Count}");
                                continue;
                            }
                            break;

                        }
                        Usuarios usuarioSelecionado = listaUsuarios[indexEscolha-1];

                        // Verificar se há empréstimos ativos
                        //Compara se o usuário do empréstimo (e.Usuario) é o mesmo objeto que o usuário selecionado (usuarioSelecionado)
                        bool temEmprestimosAtivos = listaEmprestimos.Any(e =>
                            e.Usuario.Matricula == usuarioSelecionado.Matricula &&
                            !e.Devolvido
                        );

                        if (temEmprestimosAtivos)
                        {
                            Console.WriteLine("Este usuário possui empréstimos ativos e não pode ser removido.");
                        }
                        else
                        {
                            listaUsuarios.RemoveAt(indexEscolha - 1);
                            Console.WriteLine($"Usuário {usuarioSelecionado.Nome} removido com sucesso!");
                            break;
                        }
                    
                    }
                    
                }
                else if (op == 2) 
                {
                    Console.Clear();

                    int escolhaUsuario,escolhaAtualizar;

                    Console.WriteLine("Escolha um usuário digitando o número de sua posição para atualizá-lo: ");
                    for(int u  = 0; u < listaUsuarios.Count; u++)
                    {
                        Console.WriteLine($"{u+1}ª {listaUsuarios[u].Nome}");
                    }
                    while (true)
                    {
                        string escolhaU = Console.ReadLine().Trim();
                        if(!int.TryParse(escolhaU, out escolhaUsuario) || escolhaUsuario<= 0 || escolhaUsuario> listaUsuarios.Count)
                        {
                            Console.Clear();
                            Console.WriteLine($"Entrada inválida. Digite um número 'inteiro' de 1 à {listaUsuarios.Count}");
                            continue;
                        }
                        break;
                    }
                    Usuarios usuarioEscolhido = listaUsuarios[escolhaUsuario- 1];

                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine($"Atualizando: {usuarioEscolhido.Nome}");
                        Console.WriteLine("1. Nome");
                        Console.WriteLine("2. Email");
                        Console.WriteLine("3. Telefone");
                        Console.WriteLine("4. Voltar");

                        Console.Write("\nEscolha o atributo: ");
                 
                        string escolhaU = Console.ReadLine().Trim();
                        if (!int.TryParse(escolhaU, out escolhaAtualizar) || escolhaAtualizar <= 0 || escolhaAtualizar > 4)
                        {
                            Console.Clear();
                            Console.WriteLine($"Entrada inválida. Digite um número 'inteiro' de 1 à 4");
                            continue;
                        }

                        if(escolhaAtualizar == 4)
                        {
                            break;
                        }

                        switch (escolhaAtualizar)
                        {
                            case 1:
                                
                                Console.Write("Novo nome: ");
                                string novoNome = Console.ReadLine().Trim().ToLower();

                                if (!ValidarNome(novoNome))
                                {
                                    Console.Clear();
                                    Console.WriteLine("Nome inválido!");
                                    continue;
                                }
                                novoNome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(novoNome.ToLower());

                                usuarioEscolhido.Nome = novoNome;

                                Console.WriteLine("Nome atualizado!");
                                break;
                                

                            case 2:
                                Console.Write("Novo Email: ");
                                
                                string novoEmail = Console.ReadLine().Trim().ToLower();

                                if (!ValidarEmail(novoEmail))
                                {
                                    Console.Clear();
                                    Console.WriteLine("Email inválido!");
                                    continue;
                                }
                                usuarioEscolhido.Email = novoEmail;
                                Console.WriteLine("Email atualizado!");
                                break;

                            case 3:
                                
                                int novoTelefone;

                                Console.Write("Novo telefone: ");
                                string nvTell = Console.ReadLine().Trim().ToLower();
                                if (!int.TryParse(nvTell, out novoTelefone))
                                {
                                    Console.Clear();
                                    Console.WriteLine("Telefone inválido!");
                                    continue;
                                }
                                usuarioEscolhido.Telefone = novoTelefone;
                                Console.WriteLine("Telefone atualizado!");
                                break;

                            case 4:
                                break;

                            default:
                                Console.WriteLine("Opção inválida!");
                                break;
                        }

                    }
                }
                else if(op == 3)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Entrada inválida. Digite um número de 1 à 3");
                    continue;
                }
            }
        }
        public static void GerenciarLivro()
        {
            Console.Clear();
            if (!listaLivros.Any())
            {
                Console.WriteLine("Não há livros cadastrados!");
                return;
            }

            int op;
            while (true)
            {
                Console.WriteLine("\n\n==== Gerenciar Livros ====");
                Console.WriteLine("1. Remover Livros");
                Console.WriteLine("2. Atualizar Livros");
                Console.WriteLine("3. Voltar\n");


                Console.WriteLine("Escolha uma opção digitando o número de sua posição: ");
                string opcao = Console.ReadLine().Trim();
                if (!int.TryParse(opcao, out op) || op <= 0 || op > 3)
                {
                    Console.Clear();
                    Console.WriteLine($"Entrada inválida. Digite um número de 1 à 3");
                    continue;
                }
                if(op == 1)
                {
                    Console.Clear();

                    int escolha;
                    Console.WriteLine("Escolha um livro para remove-lo: ");
                    for (int l = 0; l < listaLivros.Count; l++) 
                    {
                        Console.WriteLine($"{l+1}ª {listaLivros[l].Titulo}");
                    }

                    while (true)
                    {
                        string escLivro = Console.ReadLine().Trim();
                        if(!int.TryParse(escLivro, out escolha) || escolha <= 0 || escolha > listaLivros.Count)
                        {
                            Console.Clear();
                            Console.WriteLine($"Entrada inválida. Digite um número de 1 à {listaLivros.Count}");
                            continue;
                        }
                        Livros livroSelecionado = listaLivros[escolha - 1];

                        //Verificar se não há devolução ativas
                        bool temEmprestimosAtivos = listaEmprestimos.Any(l =>
                            l.Livro.Titulo == livroSelecionado.Titulo &&
                            !l.Devolvido
                        );

                        if (temEmprestimosAtivos)
                        {
                            Console.WriteLine("Este livro possui empréstimos ativos e não pode ser removido.");
                        }
                        else
                        {
                            listaLivros.RemoveAt(escolha - 1);
                            Console.WriteLine($"Livro {livroSelecionado.Titulo} removido com sucesso!"); // Mensagem corrigida
                            break;
                        }
                    }

                }
                else if (op == 2)
                {
                    Console.Clear();

                    int escolhaLivro, escolhaAtualizar;

                    Console.WriteLine("Escolha um livro digitando o número de sua posição para atualizá-lo: ");
                    for (int u = 0; u < listaLivros.Count; u++)
                    {
                        Console.WriteLine($"{u + 1}ª {listaLivros[u].Titulo}");
                    }
                    while (true)
                    {
                        string escolhaU = Console.ReadLine().Trim();
                        if (!int.TryParse(escolhaU, out escolhaLivro) || escolhaLivro<= 0 || escolhaLivro> listaLivros.Count)
                        {
                            Console.Clear();
                            Console.WriteLine($"Entrada inválida. Digite um número 'inteiro' de 1 à {listaLivros.Count}");
                            continue;
                        }
                        break;
                    }
                    Livros livroEscolhido = listaLivros[escolhaLivro- 1];

                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine($"Atualizando: {livroEscolhido.Titulo}");
                        Console.WriteLine("1. Autor");
                        Console.WriteLine("2. Editora");
                        Console.WriteLine("3. Ano");
                        Console.WriteLine("4. Categoria");
                        Console.WriteLine("5. QuantidadeExemplares");
                        Console.WriteLine("6. Voltar");

                        Console.Write("\nEscolha o atributo: ");

                        string escolhaU = Console.ReadLine().Trim();
                        if (!int.TryParse(escolhaU, out escolhaAtualizar) || escolhaAtualizar <= 0 || escolhaAtualizar > 6)
                        {
                            Console.Clear();
                            Console.WriteLine($"Entrada inválida. Digite um número 'inteiro' de 1 à 4");
                            continue;
                        }

                        if(escolhaAtualizar == 6)
                        {
                            break;
                        }
                        switch (escolhaAtualizar)
                        {
                            case 1:
                                Console.Write("Novo Autor: ");
                                string novoAutor = Console.ReadLine().Trim().ToLower();

                                if (!ValidarNome(novoAutor))
                                {
                                    Console.Clear();
                                    Console.WriteLine("Autor inválido!");
                                    continue;
                                }
                                novoAutor = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(novoAutor.ToLower());

                                livroEscolhido.Autor = novoAutor;

                                Console.WriteLine("Autor atualizado!");
                                break;

                            case 2:
                                Console.Write("Nova Editora: ");
                                string novaEditora = Console.ReadLine().Trim().ToLower();

                                if (!ValidarNome(novaEditora))
                                {
                                    Console.Clear();
                                    Console.WriteLine("Editora inválida!");
                                    continue;
                                }
                                livroEscolhido.Editora = novaEditora;
                                Console.WriteLine("Editora atualizada!");
                                break;
                                

                            case 3:

                                int novoAno;

                                Console.Write("Novo Ano: ");
                                string nvAno = Console.ReadLine().Trim();
                                if (!int.TryParse(nvAno, out novoAno) || novoAno < 1800 || novoAno > 2025)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Ano inválido!");
                                    continue;
                                }
                                livroEscolhido.Ano = novoAno;
                                Console.WriteLine("Ano atualizado!");
                                break;

                            case 4:

                                Console.Write("Nova Categoria: ");
                                
                                string novaCategoria = Console.ReadLine().Trim().ToLower();

                                if (!ValidarNome(novaCategoria))
                                {
                                    Console.Clear();
                                    Console.WriteLine("Categoria inválida!");
                                    continue;
                                }
                                livroEscolhido.Categoria = novaCategoria;
                                Console.WriteLine("Categoria atualizada!");
                                break;
                                

                            case 5:

                                int novoQuantidadeExemplares;

                                Console.Write("Nova quantidade de exemplares: ");
                                string qtd = Console.ReadLine().Trim();
                                if (!int.TryParse(qtd, out novoQuantidadeExemplares) || novoQuantidadeExemplares <= 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Quantidade de exemplares inválido!");
                                    continue;
                                }
                                livroEscolhido.QuantidadeExemplares = novoQuantidadeExemplares;
                                Console.WriteLine("Quantidade de exemplares atualizado!");
                                break;

                            case 6:
                                break;

                            default:
                                Console.WriteLine("Opção inválida!");
                                break;
                        }
                    }
                }
                else if (op == 3)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Entrada inválida. Digite um número de 1 à 3");
                    continue;
                }
            }
        }

        private static bool ValidarNome(string nome)
        {
            return !string.IsNullOrWhiteSpace(nome) &&
                   nome.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        private static bool ValidarEmail(string email)
        {
            return !string.IsNullOrWhiteSpace(email) &&
                   email.Contains('@') &&
                   email.Contains('.') &&
                   !email.StartsWith("@") &&
                   !email.EndsWith("@") &&
                   !email.StartsWith(".") &&
                   !email.EndsWith(".");
        }
    }
}


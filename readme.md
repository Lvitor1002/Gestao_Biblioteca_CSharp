# Sistema de Gestão de Biblioteca em C#

## Descrição Completa
Sistema completo para gestão de bibliotecas com controle de acervo, usuários, empréstimos e devoluções. Desenvolvido em C# para ambiente console, oferece funcionalidades robustas de CRUD (Create, Read, Update, Delete) para gerenciamento de livros e usuários, além de operações completas de empréstimo e devolução com cálculo automático de multas.

<img>

</img>


---

## Funcionalidades Implementadas

### 📚 Gestão de Acervo

#### Cadastro Completo de Livros
- Título (validação de formato)  
- Autor (validação de formato)  
- Editora (validação de formato)  
- Ano (validação 1700-2025)  
- Categoria (classificação temática)  
- Quantidade de exemplares (controle de estoque)  

#### Recursos Avançados
- Atualização de informações dos livros  
- Remoção segura (verificação de empréstimos ativos)  
- Listagem completa do acervo  
- Controle automático de disponibilidade  

---

### 👥 Gestão de Usuários

#### Cadastro Completo
- Nome completo (validação de formato)  
- Matrícula/Número de identificação  
- E-mail (validação de formato)  
- Telefone  

#### Recursos Avançados
- Atualização de dados cadastrais  
- Remoção segura (verificação de empréstimos ativos)  
- Listagem completa de usuários  
- Histórico de empréstimos associados  

---

### 🔁 Sistema de Empréstimos

#### Fluxo Completo
- Associação entre livro e usuário  
- Data automática de empréstimo (data atual)  
- Devolução prevista em 14 dias  
- Redução automática do estoque  
- Validação de disponibilidade  

#### Controle
- Bloqueio de empréstimo sem exemplares disponíveis  
- Registro completo das transações  
- Listagem de empréstimos ativos  

---

### 🔄 Sistema de Devoluções

#### Processo Automatizado
- Atualização instantânea do estoque  
- Cálculo de multa diária (R$ 2,00/dia)  
- Registro de data real de devolução  
- Marcação de empréstimo como finalizado  

#### Controle
- Visualização de empréstimos pendentes  
- Cálculo automático de atrasos  
- Gestão de multas por atraso  

---

### 📊 Relatórios e Consultas

#### Visualizações Completas
- Listagem detalhada de todos os livros  
- Relatório completo de usuários cadastrados  
- Painel de empréstimos ativos  
- Histórico de transações  

---

## Como Executar o Projeto

### Clone o repositório:
```bash
git clone https://github.com/seu-usuario/sistema-biblioteca-csharp.git
```

### Abra a solução no Visual Studio

### Compile e execute o projeto

### Utilize o menu interativo via console:
```text
==== SISTEMA DE GESTÃO DE BIBLIOTECA ====
1. Cadastrar Livro
2. Cadastrar Usuário
3. Realizar Empréstimo
4. Realizar Devolução
5. Listar Livros
6. Listar Usuários
7. Listar Empréstimos Ativos
8. Gerenciar Usuário
9. Gerenciar Livro
10. Sair
```

---

## Estrutura do Código

### Entidades Principais
- **Livros**: Gerencia propriedades do acervo  
- **Usuarios**: Administra dados dos usuários  
- **Emprestimo**: Controla transações de empréstimo  

### Serviços Especializados
- **EmprestimoService**: Lógica de negócio para empréstimos  
- **DevolucaoService**: Processamento de devoluções e multas  

### Validações
- `ValidarNome()`: Garante formatos corretos para textos  
- `ValidarEmail()`: Verifica padrões de e-mail válidos  
- `ValidarTelefone()`: Confirma números corretos  

---

## Melhorias Futuras
- Persistência em banco de dados  
- Sistema de autenticação de usuários  
- Relatórios estatísticos  
- Interface gráfica (GUI)  
- Módulo de reservas antecipadas

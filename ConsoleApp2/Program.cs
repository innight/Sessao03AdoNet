using System;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Diagrama Entidade Associação");

            //O Diagrama Entidade Associação/Relação é constituido por:

            //Entidades                     ->   Classes Modelo             ->   Tabelas
            //Atributos(para cada entidade) ->   Propriedades               ->   Colunas
            //Associações                   ->   Propriedades de navegação  ->   Relações

            //Sistema a analisar: Biblioteca
            //"Na nossa biblioteca temos diariamente muitos utentes que requisitam livros. Esses livros poderão ser pesquisados por titulo, autor e editora."

            //1º Determinar as Entidades (candidatas a entidades)
            //   Identificar os substantivos/nomes no enunciado.
            //
            //   Biblioteca
            //   Utentes
            //   Livros
            //   Titulo
            //   Autor
            //   Editora

            //2º Determinar os Atributos de cada Entidade
            //   Se uma "entidade" não tiver atributos então não será entidade mas sim atributo de outra entidade.
            //
            //   Biblioteca: Nome, Endereço, Telefone - UTIL NO CASO DO SOFTWARE PODER SER USADO POR MUITAS SIMULTANEAMENTE
            //   Utentes: Nome, Endereço, Email, Telefone, Género, NumSócio, LivrosRequisitados
            //   Livros: Título, NúmPags, DataPublicação, Edição, Género, Autor, Editora, Pais, Edioma/Lingua
            //   Titulo: não tem mais atributos que não a própria string -> não é entidade, é atributo do livro.
            //   Autor: Nome, Livros/Obras, Nacionalidade, Bio, DataNascimento
            //   Editora: Nome, Ano, Endereço, Telefone, Livros

            //Resultado: 5 Entidades:
            //   (Biblioteca: Nome, Endereço, Telefone)
            //   Utentes: Nome, Endereço, Email, Telefone, Género, NumSócio, LivrosRequisitados
            //   Livros: Título, NúmPags, DataPublicação, Edição, Género, Autor, Editora, Pais, Edioma/Lingua
            //   Autor: Nome, Livros/Obras, Nacionalidade, Bio, DataNascimento
            //   Editora: Nome, Ano, Endereço, Telefone, Livros

            //3º Determinar as Associações entre as Entidades
            //   As associações poderão ser determinadas pelos verbos do enunciado.
            //   Pegar em cada par de entidades e verificar se há relação (direta) entre elas. Sabendo que, numa BD (num SGBR - Sistema de Gestão de BD Reelacionais) só são possíveis relações:
            //          1-1
            //          1-M
            //          relações de M-M terão que ser decompostas
            //   
            //   Utentes e Livros? Estão relacionados? Qual o tipo de relação? No enunciado "Utentes REQUISITAM Livros"
            //          Utente M-M Livros - A DECOMPOR!!!
            //          1 Utente pode requisitar Muitos Livros, 1 Livro pode ser requisitado por Muitos Utentes.
            //
            //          Decomposição: Criar mais uma entidade chamada, por exemplo, Requisicoes:
            //              Requisicoes: Id, IdUtente, IdLivro, e ainda DataReq, DataDevolucao, ....
            //
            //   Utentes e Autores?
            //          A menos que queira registar os autores preferidos de cada utente, a relação não existe diretamente mas sim indiretamente através do livro: Utente -> requisita livros -> tem autor
            //
            //   Utentes e Editoras? O mesmo que Utentes e Autores.
            //
            //   Livro e Autor?
            //          1 Livro tem 1 Autor, 1 Autor tem Muitos Livros   =>   Livro M-1 Autor
            //      Mas para manuais de informática temos vários autores:
            //          1 Livro tem Muitos Autores, 1 Autor tem Muitos Livros   =>   Livro M-M Autor
            //      Ou então, para fugir à associação M-M podemos ter no livro o atributo "Autores"
            //      Ou então várias colunas Autor2, Autor3, Autor4, ...
            //
            //         
            //
            //   Livro e Editora?
            //          1 Livro tem uma Editora e 1 Editora tem Muitos Livros.
            //          Livro M-1 Editora

            //SUMÁRIO DAS ASSOCIAÇÕES:
            //          Utente 1-M Requisicoes M-1 Livros
            //          Livro M-1 Editora
            //          Livro ?-? Autor

            //4º Normalizar o Diagrama
            //      Aplicar regras ao diagrama de forma a evitar erros, redundâncias na BD.
            //
            //      Todas as entidade deverão ter uma PK (Primary Key / Chave Primária)
            //
            //      https://learn.microsoft.com/pt-br/office/troubleshoot/access/database-normalization-description
            //
            //      1º Forma Normal - 1ª regra:
            //      Primeira forma normal
            //          Elimine grupos repetidos em tabelas individuais.
            //          Crie uma tabela separada para cada conjunto de dados relacionados.
            //          Identifique cada conjunto de dados relacionados com uma chave primária.
            //      
            //          Aplicação: 1 livro poder ter muitos autores e 1 autor muitos livros: Livro M-M Autores
            //                     Não vamos criar colunas Autor1, Autor2, Autor3, ... no Livro
            //                     Não vamos criar colunas Livro1, Livro, Livro3, ... no Autor
            //                     Vamos é criar uma Entidade que faça a associação M-M
            //
            //                     Livro 1-M Autorias(Id, IdLivro, IdAutor) M-1 Autores
            //
            //Eliminando os campos repetitivos:
            //Resultado: 6 Entidades:
            //   Utentes: Id/NúmSócio, Nome, Endereço, Email, Telefone, Género
            //   Requisicoes: Id, IdUtente, IdLivro, DataReq, DataDev, ...
            //   Livros: Id, Título, NúmPags, DataPublicação, Edição, Género, Autor, Editora, Pais, Edioma/Lingua
            //   Autorias: Id, IdLivro, IdAutor
            //   Autor: Id, Nome, Nacionalidade, Bio, DataNascimento
            //   Editora: Id, Nome, Ano, Endereço, Telefone
            //
            //      2ª Forma Normal - 2ª Regra:
            //               Crie tabelas separadas para conjuntos de valores que se aplicam a registos diversos.
            //               Relacione estas tabelas com uma chave externa.
            //
            //      Aplicação: Na entidade Livro, o atributo País vai conter "portugal" ou "Portugal" ou "PT" - e muitos livros podem ter como país portugal... Logo devemos ter uma entidades Paises!
            //                 No livro, em vez de ter um atributo String para escrever o país, passo a ter uma FK para indicar o registo do país.
            //                 O mesmo para Género e Edioma
            //                 
            //Resultado: 10 Entidades:
            //   Utentes: Id/NúmSócio, Nome, Endereço, Email, Telefone, ___IDGéneroUtente___
            //   GeneroUtente: Id, Nome
            //   Requisicoes: Id, IdUtente, IdLivro, DataReq, DataDev, ...
            //   Livros: Id, Título, NúmPags, DataPublicação, Edição, __IDGénero__, IdEditora, __IDPais__, __IDEdioma/Lingua__
            //   Paises: Id, Nome
            //   Idiomas: Id, Nome (será que não pode ser usada a tabela de Paises: Id, Nome, Lingua)
            //   Géneros: Id, Nome
            //   Autorias: Id, IdLivro, IdAutor
            //   Autor: Id, Nome, __IdPais__, Bio, DataNascimento
            //   Editora: Id, Nome, Ano, Endereço, Telefone
            //
            //      3ª Forma Normal
            //              Elimine os campos que não dependem da chave.
            //
            //              Aplicação:
            //                  Se tiver na tabela de Utentes eu decompor o endereço:
            //                          Utentes: Id, Nome, Morada, CodigoPostal, Localidade, ....
            //                      Será sempre útil se eu quiser enviar correspondencia para ter desconto nos CTT agrupando as cartas por CodigoPostal.
            //      
            //                      Se reparamos, a Localidade DEPENDE DO CÓDIGO POSTAL e não do Id do Utente
            //                      Se eu tiver um Utente com CP 1000-001 tem de ter localidade Lisboa!
            //                      Portanto vou deixar o código postal no utente (pois é o seu código postal)
            //                      mas vou criar uma nova entidade com as localidades:
            //                          Localidades: Id, CodigoPostal(PK?), Localidade (até posso usar o CP como PK!)
            //                      E passa o Utente: Id, Nome, Morada, IdCodigoPostal/CodigoPostal


            // //Resultado FINAL: 11 Entidades:
            //   Utentes: Id/NúmSócio, Nome, Endereço, Email, Telefone, ___IDGéneroUtente___
            //   GeneroUtente: Id, Nome
            //   Requisicoes: Id, IdUtente, IdLivro, DataReq, DataDev, ...
            //   Livros: Id, Título, NúmPags, DataPublicação, Edição, __IDGénero__, IdEditora, __IDPais__, __IDEdioma/Lingua__
            //   Paises: Id, Nome
            //   Idiomas: Id, Nome (será que não pode ser usada a tabela de Paises: Id, Nome, Lingua)
            //   Géneros: Id, Nome
            //   Autorias: Id, IdLivro, IdAutor
            //   Autor: Id, Nome, __IdPais__, Bio, DataNascimento
            //   Editora: Id, Nome, Ano, Endereço, Telefone
            //   Localidades: Id, CodigoPostal(PK?), Localidade (até posso usar o CP como PK!)



            //EXERCÍCIOS:
            //      1 - Criar as classes modelo para a biblioteca (com as associações).
            //      2 - Criar o Modelo Entidade Associação - e enviar a imagem para j.andrade.pt@gmail.com 
            //          de uma solução de gestão de eventos:
            //              https://bilheteira.fnac.pt/?utm_source=MMbilheteira
        }
    }
}

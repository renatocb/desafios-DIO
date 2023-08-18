--1 - Buscar o nome e ano dos filmes

SELECT Nome, Ano FROM Filmes;

--2 - Buscar o nome e ano dos filmes, ordenados por ordem crescente pelo ano

SELECT Nome, Ano FROM Filmes ORDER BY Ano;

--3 - Buscar pelo filme de volta para o futuro, trazendo o nome, ano e a duração

SELECT Nome, Ano, Duracao FROM Filmes Where nome='De volta para o futuro';

--4 - Buscar os filmes lançados em 1997

SELECT Nome, Ano, Duracao FROM Filmes Where Ano=1997;

--5 - Buscar os filmes lançados APÓS o ano 2000

SELECT Nome, Ano, Duracao FROM Filmes Where Ano>2000;

--6 - Buscar os filmes com a duracao maior que 100 e menor que 150, ordenando pela duracao em ordem crescente

SELECT Nome, Ano, Duracao FROM Filmes Where Duracao>100 and Duracao<150 order by Duracao;

--7 - Buscar a quantidade de filmes lançadas no ano, agrupando por ano, ordenando pela duracao em ordem decrescente

SELECT Count(Ano) Contador, Ano FROM Filmes Group By Ano order by Contador Desc;

--8 - Buscar os Atores do gênero masculino, retornando o PrimeiroNome, UltimoNome

SELECT PrimeiroNome , UltimoNome FROM Atores Where Genero='M';

--9 - Buscar os Atores do gênero feminino, retornando o PrimeiroNome, UltimoNome, e ordenando pelo PrimeiroNome

SELECT PrimeiroNome , UltimoNome FROM Atores Where Genero='F' Order By PrimeiroNome;

--10 - Buscar o nome do filme e o gênero

SELECT Nome, Ge.Genero FROM Filmes F 
Inner Join FilmesGenero Fg on fg.IdFilme = F.Id 
Inner Join Generos Ge on Ge.Id = Fg.IdGenero;

--11 - Buscar o nome do filme e o gênero do tipo "Mistério"

SELECT Nome, Ge.Genero FROM Filmes F 
Inner Join FilmesGenero Fg on fg.IdFilme = F.Id 
Inner Join Generos Ge on Ge.Id = Fg.IdGenero
Where Ge.Genero='Mistério';

--12 - Buscar o nome do filme e os atores, trazendo o PrimeiroNome, UltimoNome e seu Papel

SELECT Nome, Ato.PrimeiroNome, Ato.UltimoNome, Ef.Papel FROM Filmes F 
Inner Join ElencoFilme Ef on Ef.IdFilme = F.Id
Inner Join Atores Ato on Ato.Id = Ef.IdAtor 

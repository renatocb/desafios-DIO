using TestesUnitarios.Desafio.Console.Services;

ValidacoesLista _validacoes = new ValidacoesLista();

var lista = new List<int> { 5, 7, 8, 9 };
//var resultadoEsperado = new List<int> { 10, 14, 16, 18 };

var resultado = _validacoes.MultiplicarNumerosLista(lista, 2);

foreach (var item in resultado)
{
    Console.WriteLine(item);    
}


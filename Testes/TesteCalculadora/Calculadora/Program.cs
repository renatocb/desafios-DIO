// See https://aka.ms/new-console-template for more information
using Calculadora.Services;

CalculadoraImp c = new CalculadoraImp();

int num1=5;
int num2 = 5;

Console.WriteLine($"{num1} + {num2} = {c.Somar(num1,num2)} ");
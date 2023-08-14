using System.Runtime.InteropServices;
using DesafioPOO.Models;

// TODO: Realizar os testes com as classes Nokia e Iphone

Console.WriteLine("Nokia");
Nokia nokia = new Nokia("1500", "Mokia N95", "1244444", 64);
nokia.ReceberLigacao();
nokia.InstalarAplicativo("Whats");

Console.WriteLine("Iphone");
Iphone iphone = new Iphone("3500", "Iphone XII", "250086", 256);
iphone.ReceberLigacao();
iphone.InstalarAplicativo("Telegram");
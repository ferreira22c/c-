using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var pessoas = new Dictionary<string, string>();
        var listasDeContatos = new Dictionary<string, List<string>>();

        Console.WriteLine("Quantas pessoas você deseja adicionar?");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Insira o nome da pessoa {i + 1}:");
            string nome = Console.ReadLine();

            Console.WriteLine($"Insira o número de telefone da pessoa {i + 1}:");
            string numeroTelefone = Console.ReadLine();
            pessoas[nome] = numeroTelefone;

            Console.WriteLine($"Quantos contatos a pessoa {nome} possui? (deve ser maior que 1 e menor que {n})");
            int l = int.Parse(Console.ReadLine());

            if (l <= 1 || l >= n)
            {
                Console.WriteLine("Número inválido de contatos. Deve ser maior que 1 e menor que o número total de pessoas.");
                i--;
                continue;
            }

            var contatos = new List<string>();
            for (int j = 0; j < l; j++)
            {
                Console.WriteLine($"Insira o nome do contato {j + 1} da pessoa {nome}:");
                contatos.Add(Console.ReadLine());
            }

            listasDeContatos[nome] = contatos;
        }

        var contagemDeContatos = new Dictionary<string, int>();

        foreach (var lista in listasDeContatos.Values)
        {
            foreach (var contato in lista)
            {
                if (contagemDeContatos.ContainsKey(contato))
                    contagemDeContatos[contato]++;
                else
                    contagemDeContatos[contato] = 1;
            }
        }

        if (contagemDeContatos.Count > 0)
        {
            var pessoaMaisRegistrada = contagemDeContatos.OrderByDescending(p => p.Value).First();
            Console.WriteLine($"A pessoa mais registrada nos contatos é {pessoaMaisRegistrada.Key} com {pessoaMaisRegistrada.Value} registros.");
        }
        else
        {
            Console.WriteLine("Nenhum contato foi registrado.");
        }
    }
}
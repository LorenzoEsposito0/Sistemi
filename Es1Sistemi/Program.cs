﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.Write("Inserisci la targa nel formato AA000AA: ");
        string inputTarga = Console.ReadLine();
        string Targa = Converter(inputTarga);
        int ValTarga = ValoreTarga(Targa);
        Console.WriteLine($"Il valore della targa convertita {Targa} è: {ValTarga}");

        Console.ReadLine();
    }

    static string Converter(string targa)
    {
        // Converti la targa nel formato "AAAA000".
        return $"{targa.Substring(0, 2)}{targa.Substring(5, 2)}{targa.Substring(2, 3)}";
    }

    static int ValoreTarga(string targa)
    {
        int val = 0;
        for (int i = 0; i < targa.Length; i++)
        {
            if (char.IsDigit(targa[i]))
            {
                val *= 10; //vado a vedere il sistema numerico posizionale
                val += targa[i] - '0'; // Converto il carattere numerico in valore numerico.
            }
            else if (char.IsLetter(targa[i]))
            {
                val *= 26; // 26 lettere nell'alfabeto inglese, quindi moltiplico per 26
                val += char.ToUpper(targa[i]) - 'A'; // Converto la lettera in maiuscolo e la trasformo in valore da 0 a 25.
            }
        }

        return val; //ritorno la stringa
    }
}
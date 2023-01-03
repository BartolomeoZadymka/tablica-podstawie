using System;

namespace Cipher
{
    class Program
    {
        static void Main(string[] args)
        {

            // Wiadomość do zaszyfrowania
            Console.WriteLine("Wpisz wiadomość do zaszyfrowania");
            string message = Console.ReadLine();
            Console.WriteLine("Wiadomość do zaszyfrowania: " + message);

            // Tablica podstawień
            char[] substitutionTable = {'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p',
                                        'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z',
                                        'x', 'c', 'v', 'b', 'n', 'm'};
            
                        // Zaszyfrowanie wiadomości
                        string encryptedMessage = Encrypt(message, substitutionTable);
                        Console.WriteLine("Zaszyfrowana wiadomość: " + encryptedMessage);
                        
               
                        // Odszyfrowanie wiadomości
                        string decryptedMessage = Decrypt(encryptedMessage, substitutionTable);
                        Console.WriteLine("Odszyfrowana wiadomość: " + decryptedMessage);
                       
            
        }
                // Metoda szyfrująca wiadomość przy użyciu algorytmu podstawieniowego
        static string Encrypt(string message, char[] substitutionTable)
        {
            // Zmienna przechowująca zaszyfrowaną wiadomość
            string encryptedMessage = "";

            // Szyfrowanie każdego znaku wiadomości za pomocą tablicy podstawień
            for (int i = 0; i < message.Length; i++)
            {
                // Pobranie kodu ASCII znaku
                int character = message[i];

                // Sprawdzenie, czy znak jest literą
                if (character >= 'a' && character <= 'z')
                {
                    // Zaszyfrowanie znaku przy użyciu tablicy podstawień
                    character = substitutionTable[character - 'a'];
                }
                else if (character >= 'A' && character <= 'Z')
                {
                    // Zaszyfrowanie znaku przy użyciu tablicy podstawień
                    character = char.ToUpper(substitutionTable[character - 'A']);
                }

                // Dodanie zaszyfrowane
                // Dodanie zaszyfrowanego znaku do zaszyfrowanej wiadomości
                encryptedMessage += (char)character;
            }

            // Zwrócenie zaszyfrowanej wiadomości
            return encryptedMessage;
        }

        // Metoda odszyfrowująca wiadomość przy użyciu algorytmu podstawieniowego
        static string Decrypt(string message, char[] substitutionTable)
        {
            // Zmienna przechowująca odszyfrowaną wiadomość
            string decryptedMessage = "";

            // Odszyfrowanie każdego znaku wiadomości za pomocą tablicy podstawień
            for (int i = 0; i < message.Length; i++)
            {
                // Pobranie kodu ASCII znaku
                int character = message[i];

                // Sprawdzenie, czy znak jest literą
                if (character >= 'a' && character <= 'z')
                {
                    // Przeszukanie tablicy podstawień w celu odnalezienia znaku
                    for (int j = 0; j < substitutionTable.Length; j++)
                    {
                        // Sprawdzenie, czy znak został odnaleziony
                        if (substitutionTable[j] == character)
                        {
                            // Odszyfrowanie znaku przy użyciu tablicy podstawień
                            character = 'a' + j;
                            break;
                        }
                    }
                }
                else if (character >= 'A' && character <= 'Z')
                {
                    // Przeszukanie tablicy podstawień w celu odnalezienia znaku
                    for (int j = 0; j < substitutionTable.Length; j++)
                    {
                        // Sprawdzenie, czy znak został odnaleziony
                        if (char.ToUpper(substitutionTable[j]) == character)
                        {
                            // Odszyfrowanie znaku przy użyciu tablicy podstawień
                            character = 'A' + j;
                            break;
                        }
                    }
                }

                // Dodanie odszyfrowanego znaku do odszyfrowanej wiadomości
                decryptedMessage += (char)character;
            }

            // Zwrócenie odszyfrowanej wiadomości
            return decryptedMessage;
        }
    }
}

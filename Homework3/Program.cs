using System;
namespace Homework3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine(CaesarCipher.Decrypt("Gur dhvpx oebja sbk whzcf bire gur ynml qbt", 13));

            Console.WriteLine(VigenereCipher.Encrypt("The quick brown fox jumps over the lazy dog", "key"));
            Console.WriteLine(VigenereCipher.Decrypt("Jlc ussgi fpyal jmh heqnc mfip xfo jkdw hmq", "key"));
        }
    }
    class CaesarCipher
    {
        public static string Encrypt(string text, int key)
        {
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                char current = text[i];
                if (char.IsLetter(current))
                {
                    char offset = char.IsUpper(current) ? 'A' : 'a';
                    result += (char)((current + key - offset) % 26 + offset);
                }
                else
                {
                    result += current;
                }
            }
            return result;
        }
        public static string Decrypt(string text, int key)
        {
            return Encrypt(text, 26 - key);
        }
    }
    class VigenereCipher
    {
        public static string Encrypt(string text, string key)
        {
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                char current = text[i];
                if (char.IsLetter(current))
                {
                    char offset = char.IsUpper(current) ? 'A' : 'a';
                    result += (char)((current + key[i % key.Length] - offset * 2) % 26 + offset);
                }
                else
                {
                    result += current;
                }
            }
            return result;
        }
        public static string Decrypt(string text, string key)
        {
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                char current = text[i];
                if (char.IsLetter(current))
                {
                    char offset = char.IsUpper(current) ? 'A' : 'a';
                    result += (char)(Math.Abs(current - key[i % key.Length] + 26) % 26 + offset);
                }
                else
                {
                    result += current;
                }
            }
            return result;
        }
    }
}

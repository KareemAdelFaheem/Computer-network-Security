using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class Ceaser : ICryptographicTechnique<string, int>
    {
            char[] alphabetarray = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        public string Encrypt(string plainText, int key)
        {
            var ciphertext = new StringBuilder();
            plainText = plainText.ToLower();
            for (int i = 0; i < plainText.Count(); i++)
            {
                var cipherindex = (Array.IndexOf(alphabetarray, plainText[i]) + key) % 26;
                ciphertext.Append(alphabetarray[cipherindex]);
            }
            Console.WriteLine(ciphertext);
            return ciphertext.ToString();
        }

        public string Decrypt(string cipherText, int key)
        {
            //char[] alphabetarray = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            var PlainText = new StringBuilder();
            cipherText = cipherText.ToLower();
            for (int i = 0; i < cipherText.Count(); i++)
            {
                var Plainindex = (Array.IndexOf(alphabetarray, cipherText[i]) - key + 26) % 26; 
                PlainText.Append(alphabetarray[Plainindex]);
            }
            Console.WriteLine(PlainText);
            return PlainText.ToString();
        }

        public int Analyse(string plainText, string cipherText)
        {
            //char[] alphabetarray = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            plainText = plainText.ToLower();
            cipherText = cipherText.ToLower();
            int Temp=(Array.IndexOf(alphabetarray, cipherText[0]) - Array.IndexOf(alphabetarray, plainText[0]));
            int mainkey= Temp >= 0? Temp : Temp + 26;
            return mainkey;
        }
    }
}

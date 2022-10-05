using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Caesar
    {
        

        public static string Alphabet_ru = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        public static string Alphabet_en = "abcdefghijklmnopqrstuvwxyz";

        public static string Alphabet_num = "0123456789";
        public static string Alphabet_sym = " !\"#$%^&*()+=-_'?.,|/`~№:;@[]{}";
        public static int Shift { private get; set; }
        public string Encoder(string text)
        {
            text = text.ToLower();
            var res = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < Alphabet_sym.Length; j++)
                {
                    if (text[i] == Alphabet_sym[j])
                    {
                        res.Append(text[i]);
                        break;
                    }
                }
            
                    for (int j = 0; j < Alphabet_ru.Length; j++)
                        if (text[i] == Alphabet_ru[j]) res.Append(Alphabet_ru[(j + Shift) % Alphabet_ru.Length]);
                    for (int j = 0; j < Alphabet_en.Length; j++)
                        if (text[i] == Alphabet_en[j]) res.Append(Alphabet_en[(j + Shift) % Alphabet_en.Length]);
                    for (int j = 0; j < Alphabet_num.Length; j++)
                        if (text[i] == Alphabet_num[j]) res.Append(Alphabet_num[(j + Shift) % Alphabet_num.Length]);
               
            }

            return res.ToString();
        }
    
        public string Decoder(string crypt)
        {
            crypt = crypt.ToLower();
            var res = new StringBuilder();
            for (int i = 0; i < crypt.Length; i++)
            {
                for (int j = 0; j < Alphabet_sym.Length; j++)
                {
                    if (crypt[i] == Alphabet_sym[j])
                    {
                        res.Append(crypt[i]);
                        break;
                    }
                }

                for (int j = 0; j < Alphabet_en.Length; j++)
                        if (crypt[i] == Alphabet_en[j]) res.Append(Alphabet_en[(j - Shift + Alphabet_en.Length) % Alphabet_en.Length]);
                    for (int j = 0; j < Alphabet_ru.Length; j++)
                        if (crypt[i] == Alphabet_ru[j]) res.Append(Alphabet_ru[(j - Shift + Alphabet_ru.Length) % Alphabet_ru.Length]);
                    for (int j = 0; j < Alphabet_num.Length; j++)
                        if (crypt[i] == Alphabet_num[j]) res.Append(Alphabet_num[(j - Shift + Alphabet_num.Length) % Alphabet_num.Length]);
                
            }
            return res.ToString();
        }

    }
}

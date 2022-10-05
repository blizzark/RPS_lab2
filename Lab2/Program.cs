using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab2
{
    class Program
    {
        public static string Alphabet_en = "abcdefghijklmnopqrstuvwxyz";
        static Random rand = new Random();


        static void Main()
        {
            Menu.Info();
            Menu.MainMenu();
        }

        public static void Distributor(int work, int cipher, int UserChoice)
        {
            string text = "";
            switch (UserChoice)
            {
                case (int)Menu.Input.Manual:
                    text = ManualInput(cipher);
                    SaveCheck(text);
                    break;
                case (int)Menu.Input.Random:
                    text = RandomInput(cipher);
                    SaveCheck(text);
                    break;
                case (int)Menu.Input.File:
                    text = FileInput(cipher);

                    break;
            }



            Console.WriteLine("Введите ключ");
            if (work == (int)Menu.Work.Encode)
            {
                if (cipher == (int)Menu.Сipher.Caesar)
                {
                    Caesar.Shift = CheckInt((int)Menu.Interval.Min, (int)Menu.Interval.MaxShift);
                    Caesar crypt = new Caesar();
                    text = crypt.Encoder(text);
                }
                if (cipher == (int)Menu.Сipher.Hill)
                {
                    
                        string keyString = CheckChar();
                        List<int> key = new List<int>();
                        List<int> plain = new List<int>();
                        for (int i = 0; i < keyString.Length; i++)
                        {
                            for (int j = 0; j < Alphabet_en.Length; j++)
                            {
                                if (keyString[i] == Alphabet_en[j])
                                {
                                    key.Add(j);
                                    break;
                                }
                            }
                        }
                        for (int i = 0; i < text.Length; i++)
                        {
                            for (int j = 0; j < Alphabet_en.Length; j++)
                            {
                                if (text[i] == Alphabet_en[j])
                                {
                                    plain.Add(j);
                                    break;
                                }
                            }
                        }
                        Hill crypt = new Hill();
                        List<int> cipher1 = new List<int>();

                        cipher1 = crypt.Encoder(plain, key);
                        text = "";
                        for (int i = 0; i < cipher1.Count; i++)
                        {
                            for (int j = 0; j < Alphabet_en.Length; j++)
                            {
                                if (cipher1[i] == j)
                                {
                                    text = text + Alphabet_en[j];
                                    break;
                                }
                            }
                        }
                    

                }
            }
            if (work == (int)Menu.Work.Decrypt)
            {
                if (cipher == (int)Menu.Сipher.Caesar)
                {
                    Caesar.Shift = CheckInt((int)Menu.Interval.Min, (int)Menu.Interval.MaxShift);
                    Caesar crypt = new Caesar();
                    text = crypt.Decoder(text);
                }
                if (cipher == (int)Menu.Сipher.Hill)
                {
                   
                        string keyString = CheckChar();
                        List<int> key = new List<int>();
                        List<int> plain = new List<int>();
                        for (int i = 0; i < keyString.Length; i++)
                        {
                            for (int j = 0; j < Alphabet_en.Length; j++)
                            {
                                if (keyString[i] == Alphabet_en[j])
                                {
                                    key.Add(j);
                                    break;
                                }
                            }
                        }
                        for (int i = 0; i < text.Length; i++)
                        {
                            for (int j = 0; j < Alphabet_en.Length; j++)
                            {
                                if (text[i] == Alphabet_en[j])
                                {
                                    plain.Add(j);
                                    break;
                                }
                            }
                        }
                        Hill crypt = new Hill();
                        List<int> cipher1 = new List<int>();

                        cipher1 = crypt.Decoder(plain, key);
                        text = "";
                        for (int i = 0; i < cipher1.Count; i++)
                        {
                            for (int j = 0; j < Alphabet_en.Length; j++)
                            {
                                if (cipher1[i] == j)
                                {
                                    text = text + Alphabet_en[j];
                                    break;
                                }
                            }
                        }
                   
                }
            }
            Console.WriteLine("Результат: {0}", text);
            SaveCheck(text);
        } // выход в MainMenu();
        public static string CheckChar()
        {
            string text = "";
            do
            {
                text = Console.ReadLine();
                if (!(text.Length == 9) && !(text.Length == 4))
                {
                    Console.WriteLine("Введите ключ длинной 4 или 9 символов! Вы ввели: " + text.Length + " символов!");
                }
            } while (!(text.Length == 9) && !(text.Length == 4));
            return text;
        }
        public static bool YesNo()
        {
            Console.WriteLine("1. Да");
            Console.WriteLine("2. Нет");
            Console.Write("Ваш выбор: ");

            int UserChoice = CheckInt((int)Menu.NoYes.Yes, (int)Menu.NoYes.No);
            if (UserChoice == (int)Menu.NoYes.Yes)
                return true;
            else
                return false;
        }

        public static void Save(string path, string text)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {

                for (int i = 0; i < text.Length; i++)
                {
                    sw.Write(text[i]);
                }
            }
            Console.WriteLine("Файл успешно записан!");
        }

        public static void SaveCheck(string text)
        {
            Console.WriteLine("Хотите сохранить?");
            if (YesNo())
            {
                try
                {
                    Console.WriteLine("Введите путь к файлу или имя файла:");
                    string path = Console.ReadLine();
                    if (File.Exists(path))
                    {
                        Console.WriteLine("Данный файл уже существует. Пезераписать?");
                        if (YesNo())
                        {
                            Save(path, text);
                        }
                        else
                        {
                            SaveCheck(text);
                        }
                    }
                    else
                    {
                        Save(path, text);
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка! " + e.Message);
                    Console.WriteLine("Попробовать ещё раз?");
                    SaveCheck(text);
                }
            }
        }

        public static string CheckStringForHill( int cipher)
        {
            
            string text;
            if (cipher == (int)Menu.Сipher.Hill){
                bool check = true;
               

                do
                {
                    text = Console.ReadLine();
                    int count = 0;
                   
                    


                    if ((count > 4) || (count % 2 == 0))
                    {
                       check = false;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка! Введите строку состоящую из чётного количества латинский символов, а также содержащую больше 3 символов в себе. ");
                        Console.WriteLine("Все символы других алфавитов будут пропущены");
                    }
                } while (check);
            }
            else
            {
                text = Console.ReadLine();
            }
            return text;
        }
        


            public static string ManualInput(int cipher)
        {

            Console.WriteLine("Введите текст для шифрования");
            string text = "";
            
            if (cipher == (int)Menu.Сipher.Hill)
            {
                int count = 0;
                string Alphabet_en = "abcdefghijklmnopqrstuvwxyz";
                Console.WriteLine("Чётное количество символов, латинские символы, больше 3 символов:");
                do
                {
                    count = 0;
                    text = Console.ReadLine();
                    for (int i = 0; i < text.Length; i++)
                    {
                        for (int j = 0; j < Alphabet_en.Length; j++)
                        {
                            if (text[i] == Alphabet_en[j])
                            {
                                count++;
                                break;
                            }
                        }
                    }

                } while ((count < 4) || !(count % 2 == 0));
            }
            else
            {
                text = Console.ReadLine();
            }

                return text;
        }

        public static string RandomInput(int cipher)
        {

            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            Console.WriteLine("Введите длину строки:");
            int size = 0; 
            if (cipher == (int)Menu.Сipher.Hill)
            {
                Console.WriteLine("Она должна быть чётной и больше 3:");
                do
                {
                    size = CheckInt((int)Menu.Interval.Min, (int)Menu.Interval.MaxSize);
                } while (size < 3 || !(size % 2 == 0));
            }
            else
            {
                size = CheckInt((int)Menu.Interval.Min, (int)Menu.Interval.MaxSize);
            }
            
            string text = "";
            for (int i = 0; i < size; i++)
            {
                text += alphabet[rand.Next(0, alphabet.Length)];
            }

            Console.WriteLine("Сгенерированная строка: {0}", text);
            
            return text;

        }
        public static string FileInput(int cipher)
        {
            Console.WriteLine("Введите имя файла:");
            
            string path = "";
            string text = "";

            try
            {
                if (cipher == (int)Menu.Сipher.Hill)
                {
                    int count = 0;
                    string Alphabet_en = "abcdefghijklmnopqrstuvwxyz";
                    
                    do
                    {
                        count = 0;
                        path = Console.ReadLine();
                        text = File.ReadAllText(path);
                        Console.WriteLine("Вы ввели: {0}", text);
                        for (int i = 0; i < text.Length; i++)
                        {
                            for (int j = 0; j < Alphabet_en.Length; j++)
                            {
                                if (text[i] == Alphabet_en[j])
                                {
                                    count++;
                                    break;
                                }
                            }
                        }
                        if ((count < 4) || !(count % 2 == 0))
                        {
                            Console.WriteLine("Файл не подходит");
                        }

                    } while ((count < 4) || !(count % 2 == 0));

                }
                else
                {
                    path = Console.ReadLine();
                    text = File.ReadAllText(path);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Ошибка.", e);
                FileInput(cipher);
            }
            return text;
        }


        public static int CheckInt(int start, int finish)
        {
            bool cycle = true;
            int num = 0;


            while (cycle)
            {
                string strPick = Console.ReadLine();
                if (int.TryParse(strPick, out num))
                {

                    if ((num >= start) && (num <= finish))
                    {
                        cycle = false;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка! Вводите числа от " + start + " до " + finish);
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод! Вводите цифры!");
                }
            }
            return num;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Menu
    {

        public enum NoYes : int
        {
            Yes = 1,
            No,

        }
        public enum Interval : int
        {
            Min = 1,
            MaxShift = 10,
            MaxSize = 100,
        }
        public enum MenuConst : int
        {
            Start = 1,
            Exit,
        }
        public enum Сipher : int
        {
            Hill = 1,
            Caesar,
            
        }
        public enum Work : int
        {
            Encode = 1,
            Decrypt,
        }
        public enum Input : int
        {
            Manual = 1,
            Random,
            File,
            FileDecrypt = 2,
      
        }
        public static void Info()
        {
            Console.WriteLine("Лабораторная работа №1");
            Console.WriteLine("Выполнил студент 475 группы: Овчинников Роман");
            Console.WriteLine("Написать программу шифровки алгоритмами Хилла и Цезаря.");
        }
        public static void MainMenu()
        {
            Console.WriteLine("1. Начать программу");
            Console.WriteLine("2. Выход из программы");

            int caseSwitch = Program.CheckInt((int)MenuConst.Start, (int)MenuConst.Exit);
            switch (caseSwitch)
            {
                case (int)MenuConst.Start:
                    СhoiceWork();
                    break;
                case (int)MenuConst.Exit:
                    break;
            }
        }

        public static void СhoiceWork()
        {
            Console.WriteLine("Выбор действия:");
            Console.WriteLine("1. Шифровать");
            Console.WriteLine("2. Дешифровать");

            int caseSwitch = Program.CheckInt((int)Input.Manual, (int)Input.File);
            switch (caseSwitch)
            {
                case (int)Work.Encode:
                    SecondMenu((int)Work.Encode);
                    break;
                case (int)Work.Decrypt:
                    SecondMenu((int)Work.Decrypt);
                    break;
            }
        }

            public static void SecondMenu(int work)
        {
            Console.WriteLine("Выбор шифра:");
            Console.WriteLine("1. Хилла");
            Console.WriteLine("2. Цезаря");
            int caseSwitch = Program.CheckInt((int)Input.Manual, (int)Input.File);
            switch (caseSwitch)
            {
                case (int)Сipher.Hill:
                    ThirdMenu(work, (int)Сipher.Hill);
                    break;
                case (int)Сipher.Caesar:
                    ThirdMenu(work, (int)Сipher.Caesar);
                    break;
            }
        }

        public static void ThirdMenu(int work, int cipher)
        {


           
                Console.WriteLine("Выбор способа ввода:");
                Console.WriteLine("1. Ручное заполнение");
                Console.WriteLine("2. Случайное заполнение");
                Console.WriteLine("3. Заполнение из файла");
                int caseSwitch = Program.CheckInt((int)Input.Manual, (int)Input.File);

                Program.Distributor(work, cipher, caseSwitch);
                MainMenu();
               
        }



    }
}

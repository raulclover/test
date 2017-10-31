using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace project
//класс по работе с консолью
{
    public class ConsOps
    {
        private String dirNameIn;   //Исходный каталог IN (вводится пользователем)
        private String dirNameOut;  //Конечный каталог OUT(вводится пользователем)
        private int i;          //пауза чтения данных

        //Сеттер для исходного каталога
        public void SetInDir()
        {
            try
            {
                do
                {
                    Console.Clear();
                    // Считывание строки ввода
                    Console.WriteLine("Введите путь до исходного каталога");
                    Console.Write("> ");
                    dirNameIn = Console.ReadLine();
                    // Проверка существования каталога
                    if (System.IO.Directory.Exists(dirNameIn))
                    {
                        Console.WriteLine("Каталог найден, считываю данные...");
                        
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка! Каталог не существует.");
                    }
                    

                }
                while (Console.ReadKey().Key != ConsoleKey.Escape);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //Геттер для исходного каталога
        public String GetInputDir()
        {
            return dirNameIn;
        }

        
        //Сеттер для конечного каталога
        public void SetOutDir()
        {
            try
            {
                do
                {
                    Console.WriteLine("Введите путь до выходного каталога");
                    Console.Write("> ");
                    dirNameOut = Console.ReadLine();

                    if (System.IO.Directory.Exists(dirNameOut))
                    {
                        Console.WriteLine("Выходной каталог найден...");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка! Выходной каталог не существует.");
                    }

                }
                while (Console.ReadKey().Key != ConsoleKey.Escape);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //Геттер для конечного каталога
        public String GetOutDir()
        {
            return dirNameOut;
        }
        //Метод чтения файлов
        public void Read()
        {
            Console.Write("Задайте интервал чтения данных, мс. ");
            i=Convert.ToInt32(Console.ReadLine());
            string[] dirs = Directory.GetFiles(@dirNameIn, "*.*");
            foreach (string dir in dirs)
            {
                Console.WriteLine(dir);
                System.Threading.Thread.Sleep(i);
            }
        }



    }
}

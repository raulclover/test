using System;

namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            //Создание объекта ввода с консоли
            ConsOps test = new ConsOps();
            //Ввод исходного каталога
            test.SetInDir();
            //Чтение файлов
            test.Read();
            //Ввод конечного каталога
            test.SetOutDir();
            //Создание объекта для работы с файлами
            DirOps dtest = new DirOps(test);
            //Копирование файлов
            dtest.CopyFiles();
            //Удаление исходных файлов, если необходимо 
            Console.Write("Нажмите 'Y', чтобы удалить исходные файлы" +
                "(или любую другую кнопку, чтобы их оставить) ");
            String d = Console.ReadLine();
            if (d == "Y")
            {
                dtest.DelFiles();
            }
            //Вывод на консоль скопированных файлов, если необходимо
            Console.Write("Нажмите 'Y', чтобы посмотреть список скопированных файлов" +
               "(или любую другую кнопку, чтобы не смотреть) ");
            String c = Console.ReadLine();
            if (c == "Y")
            {
                dtest.CopiedFiles();
            }
            //Вывод на консоль размера скопированных файлов
            dtest.SizeOfFiles();
            Console.Write("Press any key...");
            Console.ReadKey(true);

        }
    }
}

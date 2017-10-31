using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace project
 // Класс по работе с файлами и каталогами
{ 
    public class DirOps
    {
        private String[] files;                             // список файлов
        private readonly String dirNameIn;                  // исходный каталог
        private readonly String dirNameOut;                 // конечный каталог
        private ConsOps objInput;

        

        public DirOps()
        {
            files = null;
            dirNameIn = "";
            dirNameOut = "";
            objInput = null;
        }

        //Конструктор с параметрами, принимающий объекта класса ConsOps
        public DirOps(ConsOps obj)
        {
            objInput = obj;
            files = System.IO.Directory.GetFileSystemEntries(objInput.GetInputDir());
            dirNameIn = obj.GetInputDir();
            dirNameOut = obj.GetOutDir();
        }

        //Метод, выбирающий файлы для копирования
        public void SetFiles(ConsOps obj)
        {
            files = System.IO.Directory.GetFileSystemEntries(obj.GetInputDir());
            Array.Sort(files);                                   
        }


        //Метод, копирующий файлы
        public void CopyFiles()
        {

            foreach (string file in files)
            {
               
                string fileName = file.Substring(dirNameIn.Length + 1);

                try
                {
                    
                    File.Copy(Path.Combine(dirNameIn, fileName), Path.Combine(dirNameOut, fileName));
                }
                catch (IOException copyError)
                {
                    Console.WriteLine(copyError.Message);
                }
            }
        }
        //Метод, удаляющий файлы
        public void DelFiles()
        {
            foreach (string file in files)
            {
                File.Delete(file);
            }
        }
        //Метод, выводящий на консоль скопированные файлы
        public void CopiedFiles()
        {
            DirectoryInfo di = new DirectoryInfo(dirNameOut);
            Console.WriteLine("Copied Files: ");

            foreach (var fi in di.GetFiles())
            {
                Console.WriteLine(fi.Name);
            }
        }
        //Метод, выводящий на консоль размер скопированных файлов
        public void SizeOfFiles()
        {
            DirectoryInfo di = new DirectoryInfo(dirNameOut);
            long size = 0;
            foreach (var fi in di.GetFiles())
            {
                size += fi.Length;
            }

            Console.WriteLine("Размер скопированных файлов в байтах: " + size);

        }

    }
}

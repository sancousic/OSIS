using System;
using System.Collections.Generic;
using System.IO;

namespace SP1
{
    class Program
    {
        static Dictionary<int, string> Files = new Dictionary<int, string>();
        static int _counter = 1;
        static string _surname = "Znosok";        

        static string FileName { get; set; }
        static string OutputFile { get; set; }
        static void getFiles(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo fileInfo = new FileInfo(path + @"\" + FileName);
            if(fileInfo.Exists)
            {
                Files.Add(_counter, path);
                _counter++;
            }
            //foreach (var a in directoryInfo.GetDirectories())
            //{
            //    try
            //    {
            //        getFiles(path + @"\" + a.Name);
            //    }
            //    catch {
            //        Console.WriteLine("Нет доступа к "+ path + @"\" + a.Name);
            //    }
            //}
        }
        static void lab1()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            Console.WriteLine("Имя искомого файла:");
            while (true)
            {
                if (string.IsNullOrEmpty(FileName))
                {
                    FileName = Console.ReadLine();
                }
                else break;
            }
            Console.WriteLine("Имя файла, хранящего результат");

            while (true)
            {
                if (string.IsNullOrEmpty(OutputFile))
                {
                    OutputFile = Console.ReadLine();
                }
                else break;
            }

            //foreach(var drive in drives)
            //{
            //    getFiles(drive.Name);
            //}
            getFiles(@"C:\Users\Пользователь\Documents\asd");

            if (Files.Count > 0)
            {
                foreach (var a in Files)
                {
                    Console.WriteLine(a);
                }

                Console.WriteLine("Выберите путь к файлу:");
                int chosen;
                if (Int32.TryParse(Console.ReadLine(), out chosen))
                {
                    using (FileStream reader = new FileStream(Files[chosen] + @"\" + FileName, FileMode.Open))
                    {
                        FileInfo info = new FileInfo(OutputFile);
                        if (!info.Exists)
                        {
                            using (FileStream writer = new FileStream(OutputFile, FileMode.Create))
                            {
                                byte[] buffer = new byte[256];

                                while (reader.Read(buffer, 0, 256) > 0)
                                {
                                    writer.Write(XOR(buffer, _surname));
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Результирующий файл существует!");
                        }
                    }
                    Console.WriteLine("OK!");
                }     
            }
            else
            {
                Console.WriteLine("Файл не найден");
            }
            
        }

        static byte[] XOR(byte[] buffer, string KEY)
        {
            byte[] result = new byte[256];

            for(int i = 0, j = 0; i < buffer.Length; i++, j++)
            {
                if (j == KEY.Length) j = 0;
                result[i] = (byte)(KEY[j] ^ buffer[i]);
            }

            return result;
        }
        static void test()
        {
            //Console.WriteLine("Input filename");
            if (Files.Count > 0)
            {
                using (FileStream reader = new FileStream(OutputFile, FileMode.Open))
                {
                    using (FileStream writer = new FileStream("TESTRESULT.TXT", FileMode.OpenOrCreate))
                    {
                        byte[] buffer = new byte[256];

                        while (reader.Read(buffer, 0, 256) > 0)
                        {
                            writer.Write(XOR(buffer, _surname));
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            lab1();
            test();
        }
    }
}

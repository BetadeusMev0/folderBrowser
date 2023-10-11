namespace FolderBrowser
{
    class Program
    {

        private static string path = "C:\\Users\\User";

        static void Main(string[] args) 
        {
            char key = ' ';

            bool Crutch = false;
             while (true) 
            {
                Console.Clear();
                if (Crutch) break;
                Output();
                key = Console.ReadKey().KeyChar;
                switch (key) 
                {
                    case 'q':
                        Crutch = true;
                        break;
                    case '1':
                        Console.WriteLine("\nВведите имя директории: ");
                        string str = Console.ReadLine();
                        MoveTo(str);
                        break;
                    case '2':
                        Console.WriteLine("\nВведите имя директории: ");
                        string name = Console.ReadLine();
                        CreateDirectory(name);
                        break;
                    case '3':
                        Console.WriteLine("\nВведите старое имя: ");
                        string lastName = Console.ReadLine();
                        Console.WriteLine("\nВведите новое имя: ");
                        string newName = Console.ReadLine();
                        Rename(lastName, newName);
                        break;
                    case '4':
                        Console.WriteLine("\nВведите имя Файла: ");
                        string fileName = Console.ReadLine();
                        CreateFile(fileName);
                        break;
                    case '5':
                        List();
                        break;
                    case '6':
                        MoveBack();
                        break;
                    case '7':
                        Console.Clear();
                        Crutch = true;
                        break;

                }
                dlc = "";

            }


        }


        private static bool CheckDirectory(string name) 
        {
            directory = new DirectoryInfo(path);
            foreach (var vr in directory.GetDirectories()) 
            {
                if (vr.Name == name) return true;
            } 



            return false;
        }


        private static void CreateFile(string name) 
        {
            string tmp = path + "\\" + name + ".txt";
            File.Create(tmp);
        }


        private static string dlc = "";


        private static void Rename(string name, string newName) 
        {
            FileInfo tmp = new FileInfo(path+"\\"+name);
            bool isFile = false; 
            bool isDirectory = false;
            foreach (FileInfo file in directory.GetFiles()) 
            {
                if(file.Name.ToLower() == name.ToLower()) isFile = true;
            }
            if (isFile) { tmp.CopyTo(path + "\\" + newName); tmp.Delete(); }
            else 
            {
                foreach (DirectoryInfo dir in directory.GetDirectories()) 
                {
                    if (dir.Name.ToLower() == name.ToLower()) isDirectory = true;
                }
                if (isDirectory) 
                {
                    DirectoryInfo dir = new DirectoryInfo(path+"\\"+name);
                    Directory.CreateDirectory(path+"\\"+newName);

                    dir.MoveTo(path + "\\" + newName);

                    
                }

            }

        }

        private  static void Output() 
        {
            Console.WriteLine("Текущий путь к файлу: " + path);
            Console.WriteLine("1. Перейти в директорию\n2. Создать директорию\n3. Переименовать что то\n4. Создать пустой текстовый файл\n5. Вывести список\n6. Вернуться на шаг назад\n7. Сделать консоль читаемой\nq - Выйти\n" + dlc);




        }

        private static void CreateDirectory(string name) 
        {
            try
            {
                directory = directory.CreateSubdirectory(name);
                path = directory.FullName;
            }
            catch 
            {
                dlc = "Ничего не вышло";
            }
        }



        private static DirectoryInfo directory = new DirectoryInfo(path);
        private static void List() 
        {
            Console.WriteLine();

            

            foreach (DirectoryInfo dr in directory.GetDirectories())
            {
                Console.WriteLine(dr.Name);
            }

            foreach (FileInfo file in directory.GetFiles()) 
            {
                Console.WriteLine(file.Name);
            }
            Console.ReadKey();
            Console.Clear();
        }

        private static void MoveTo(string str) 
        {
            if (CheckDirectory(str))
            {
                path += "\\";
                path += str;
                directory = new DirectoryInfo(path);
            }
            else dlc = "Нет";
            }
        private static void MoveBack() 
        {
            directory = directory.Parent;
            path = directory.FullName;
        }

    }





}
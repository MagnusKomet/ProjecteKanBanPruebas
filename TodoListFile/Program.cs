using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TodoListFile
{
    class Program
    {
        static String filename = ".\\todo.txt";
        static List<String> todos = new List<string>();
        static void Main(string[] args)
        {
            int menuItem;
            do
            {
                menuItem = menu();
                switch (menuItem)
                {
                    case 1:
                        //MotrarLlista
                        showList();
                        break;
                    case 2:
                        //Afegir element
                        addItem();
                        break;
                    case 3:
                        //eliminar element
                        removeItem();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("No es reconeix l'entrada");
                        break;
                }

            } while (menuItem != 0);
        }
        static int menu()
        {
            int choice;
            Console.WriteLine("Main Menu\n");
            Console.WriteLine("0. Surt del programa\n");
            Console.WriteLine("1. Mostrar ToDoList\n");
            Console.WriteLine("2. Afegir item a la llista\n");
            Console.WriteLine("3. Suprimir item de la llista\n");
            Console.WriteLine();
            Console.WriteLine("Escull una opció");
            choice = Convert.ToInt32(Console.ReadLine());
            return choice;


        }

        static void addItem()
        {
            Console.WriteLine("\nAdd Item\n");
            StreamWriter outFile = File.AppendText(filename);
            Console.Write("Introdueix un item: ");
            string item = Console.ReadLine();
            outFile.WriteLine(item);
            outFile.Close();

        }
        
        static void removeItem()
        {
            int choice;
            showList();
            Console.WriteLine("Quin element vols eliminar? ");
            choice = Convert.ToInt32(Console.ReadLine());
            List<string> items = new List<string>();
            int number = 1;
            string item;
            StreamReader inFile = new StreamReader(filename);
            while (inFile.Peek() != -1)
            {
                item = inFile.ReadLine();
                if (number != choice)
                {
                    items.Add(item);
                }
                number++;
            }
            inFile.Close();
            StreamWriter outFile = new StreamWriter(filename);
            for (int i = 0; i < items.Count; i++)
            {
                outFile.WriteLine(items[i]);
            }
            outFile.Close();
        }
        

        static void showList()
        {
            Console.WriteLine("\nTo-do List\n");
            StreamReader inFile = new StreamReader(filename);
            String line;
            int number = 1;
            while (inFile.Peek() != -1)
            {
                line = inFile.ReadLine();
                Console.Write(number + " ");
                Console.WriteLine(line);
                ++number;
            }
            Console.WriteLine();
            inFile.Close();

        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ToDoListPersist
{
    class Program
    {
        static String filename = ".\\todo.txt";
        static List<String> todos = new List<string>();
        static void Main(string[] args)
        {
            onLoad();
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
                        onClose();
                        break;
                    default:
                        Console.WriteLine("No es reconeix l'entrada");
                        break;
                }

            } while (menuItem != 0);
        }

        //Quan es tanca el programa hauriem de guardar els elements al fitxer
        private static void onClose()
        {
            if(File.Exists(filename))
            {
                StreamWriter outFile = new StreamWriter(filename);
                for (int i = 0; i < todos.Count; i++)
                {
                    outFile.WriteLine(todos[i]);
                }
                outFile.Close();
            }
        }
        //En obrir el programa carreguem les dades de fitxer
        private static void onLoad()
        {
            // Si existeix el el fitxer
            if (File.Exists(filename))
            {
                //Llegim el contingut del fitxer i ho introduim a una llista
                StreamReader inFile = new StreamReader(filename);
                while (inFile.Peek() != -1)
                {
                    string item = inFile.ReadLine();
                    todos.Add(item);
                }
                inFile.Close();
            }
            else//Si no existeix el fitxer el creem
            {
                StreamWriter outFile = File.AppendText(filename);
                outFile.Close();
            }
            //throw new NotImplementedException();
        }

        //Mostrem el menu
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
        //Afegim item
        static void addItem()
        {
            Console.WriteLine("\nAdd Item\n");
            Console.Write("Introdueix un item: ");
            string item = Console.ReadLine();
            todos.Add(item);

        }

        //Eliminem item
        static void removeItem()
        {
            int choice;
            showList();
            Console.WriteLine("Quin element vols eliminar? ");
            choice = Convert.ToInt32(Console.ReadLine());
            todos.RemoveAt(choice - 1);
        }

        //Mostrem la llista
        static void showList()
        {
            Console.WriteLine("\nTo-do List\n");
            for (int i = 0; i < todos.Count; i++)
            {
                Console.WriteLine($"{i + 1}.-{todos[i]}");
            }
            Console.WriteLine();
        }
    }
}

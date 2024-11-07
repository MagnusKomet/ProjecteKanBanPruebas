using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ToDoList
{
    //probando probando
    class Program
    {
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
            Console.Write("Introdueix un item: ");
            string item = Console.ReadLine();
            todos.Add(item);
        }

        
        static void removeItem()
        {
            int choice;
            //Mostrem la llista per facilitar la feina
            showList();
            //
            Console.WriteLine("Quin element vols eliminar? ");
            choice = Convert.ToInt32(Console.ReadLine());
            todos.RemoveAt(choice-1);
        }

       
        static void showList()
        {
            Console.WriteLine("\nTo-do List\n");

            //Recorrem tots els elements del List i els mostrem
            //No fem servir un foreach perquè ens interessa la i per mostrar l'índex(i+1)
            for (int i = 0; i < todos.Count;i++)
            {
                Console.WriteLine($"{i+1}.-{todos[i]}");
            }
            Console.WriteLine();
        }
    }
}

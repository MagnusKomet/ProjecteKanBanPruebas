using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TodoListForms
{
    
    public partial class Form1 : Form
    {
        static string filename = ".\\todo.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            todoListBox.Items.Add(addTexbox.Text);
            addTexbox.Clear();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            todoListBox.Items.RemoveAt(todoListBox.SelectedIndex);
        }

        private void onClose()
        {
            if (File.Exists(filename))
            {
                StreamWriter outFile = new StreamWriter(filename);
                for (int i = 0; i < todoListBox.Items.Count; i++)
                {
                    outFile.WriteLine(todoListBox.Items[i]);
                }
                outFile.Close();
            }
        }
        //En obrir el programa carreguem les dades de fitxer
        private void onLoad()
        {
            // Si existeix el el fitxer
            if (File.Exists(filename))
            {
                //Llegim el contingut del fitxer i ho introduim a una llista
                StreamReader inFile = new StreamReader(filename);
                while (inFile.Peek() != -1)
                {
                    string item = inFile.ReadLine();
                    todoListBox.Items.Add(item);
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

        private void Form1_Load(object sender, EventArgs e)
        {
            onLoad();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            onClose();
        }
    }
}

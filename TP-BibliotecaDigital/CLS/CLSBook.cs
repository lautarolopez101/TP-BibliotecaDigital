using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_BibliotecaDigital.CLS
{
    public class CLSBook
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int ISBN { get; set; }

        public CLSBook()
        {

        }

        public CLSBook(string title, string author, int year, int isbn)
        {
            Author = author;
            Title = title;
            Year = year;
            ISBN = isbn;

        }

        private List<CLSBook> listbooks = new List<CLSBook>();
        public void Cargarlista(DataGridView dgv)
        {
            listbooks.Clear();

            try
            {

                using (StreamReader sr = new StreamReader("books.csv"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var data = line.Split(',');
                        CLSBook book = new CLSBook(data[0], data[1], Convert.ToInt32(data[2]), Convert.ToInt32(data[3]));
                        listbooks.Add(book);
                        dgv.Rows.Add(data[0], data[1], data[2], data[3]);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public void Modificar(int index, string title, string author, int year, int isbn)
        {
            listbooks[index].Title = title;
            listbooks[index].Author = author;
            listbooks[index].Year = year;
            listbooks[index].ISBN = isbn;
            using (StreamWriter sw = new StreamWriter("books.csv", false))
            {
                foreach (var book in listbooks)
                {
                    sw.WriteLine($"{book.Title},{book.Author},{book.Year},{book.ISBN}");
                }
            }
            DataGridView dataGridView1 = new DataGridView();
            Cargarlista(dataGridView1);
        }
    }
}

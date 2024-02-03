using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohirdev
{
    public class Book
    {
        // private field
        private string title;
        private string author;
        private double price;

        //property
        public int Year {  get; set; }
        public string Genre { get; set; }

        //Constructor
        public Book(string title, string author, double price)
        {
            this.title = title;
            this.author = author;
            this.price = price;

        }

        public Book()
        {
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public void BookInfo()
        {
            Console.WriteLine($"Nomi: {title}\nMuallifi: {author}\nNarxi: {price}\nYili: {Year}\nJanri: {Genre}");
        }
    }
}



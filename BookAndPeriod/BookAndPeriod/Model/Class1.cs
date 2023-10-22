using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndPeriod.Model
{
    internal class Book
    {
       private long id;
       private string? title ;
        private string author = "Anonymous";
        private int price;

        public Book(long id) {
            this.id = id;
        }
        public Book(long id, string title, string author, int price)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.price = price;
        }

        public long Id
        {
            set { id = value; }
            get { return id; }
        }
        public string Title
        { 
            get { return title; }
            set { title = value; }
        }
          public int Price
        {
            get { return price; }
            set {  price = value; } 
        }
           public string Author
        { 
            get { return author; }
            set { author = value; }
        }
    }
}

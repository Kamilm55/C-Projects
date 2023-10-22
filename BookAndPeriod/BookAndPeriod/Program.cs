using BookAndPeriod.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        //BOOK
        Book book = new Book(1,"java","Davud",15);
        Book book2 = new Book(2);
        book2.Title = "C#";
        book2.Price = 100;

        Console.WriteLine(book.Id + " , " + book.Title + " , " + book.Author + " , " + book.Price);
        Console.WriteLine(book2.Id + " , " + book2.Title + " , " + book2.Author + " , " + book2.Price);
        
        //PERIOD
    
    
    }   
}
namespace bb205_acces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("Ali ve nino", 24.5, 2, "drama");
            Book book2 = new Book("Kesr", 50, 8, "qorxu,drama");
            Book book3 = new Book("Kesr", 50, 8, "qorxu,drama");
            Library library = new Library();

            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);

            Console.WriteLine(library.GetBook("ali ve nino"));
        }
    }
}
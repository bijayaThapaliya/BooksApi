using TheBookApp.Models;

namespace TheBookApp;

public interface IBookService
{
    IEnumerable<Book> GetAllBooks();
    Book GetBookById(int Id);
    void AddBook(Book book);
    void UpdateBook(Book book);
    void DeleteBook(Book book);
    
    Publisher GetPublisherOfBook(int bookId);
}

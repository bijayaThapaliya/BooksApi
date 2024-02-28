using TheBookApp.Models;

namespace TheBookApp;

public class BookService : IBookService
{
    private readonly List<Book> _books;
    private readonly IPublisherService _publisherServices;

    public BookService(IPublisherService publisherService){
        _books = new List<Book>();
        _publisherServices = publisherService;
    }
    public IEnumerable<Book> GetAllBooks()
    {
        return _books;
    }

    public Book GetBookById(int Id)
    {
        // throw new NotImplementedException();
        return _books.FirstOrDefault(b=>b.Id == Id);
    }


    private bool IsDuplicateBook(Book book)
    {
        return _books.Any(b =>
            b.Id != book.Id &&
            b.Title == book.Title &&
            b.Year == book.Year &&
            b.Edition == book.Edition &&
            b.ISBN == book.ISBN);
    }
    public void AddBook(Book book)
    {
        if(IsDuplicateBook(book))
        {
            throw new ArgumentException("Duplication Found!!");
        }
        _books.Add(book);
    }

    public void UpdateBook(Book book)
    {
        var existingBook = GetBookById(book.Id);
        if(existingBook is null){
            throw new NotImplementedException();
        }

        if(IsDuplicateBook(book)){
            throw new ArgumentException("Duplication Found");
        }

        existingBook.Title = book.Title;
        existingBook.Author = book.Author;
        existingBook.Year = book.Year;
        existingBook.Edition = book.Edition;
        existingBook.ISBN = book.ISBN;
        existingBook.PublisherId = book.PublisherId;
    }

    public void DeleteBook(Book book)
    {
        var _book =GetBookById(book.Id);

        if(_book != null){
            _books.Remove(book);
        }
    }

    public Publisher GetPublisherOfBook(int BookId)
    {
        var book = GetBookById(BookId);
        if (book is null){
            throw new ArgumentException("Book Not Found");
        }

        return _publisherServices.GetPublisherById(book.PublisherId);
    }

}

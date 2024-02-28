using TheBookApp.Models;
namespace TheBookApp;

public interface IPublisherService
{
    IEnumerable<Publisher> GetAllPublishers();
    Publisher GetPublisherById(int id);
    void AddPublisher(Publisher publisher);
    void UpdatePublisher(Publisher publisher);
    void DeletePublisher(int id);
    // IEnumerable<Book> GetBooksByPublisher(int publisherId);
}

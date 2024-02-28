using TheBookApp.Models;

namespace TheBookApp;

public class PublisherService:IPublisherService
{
    public readonly List<Publisher> _publishers;

    public PublisherService()
    {
        _publishers = new List<Publisher>();
    }

    public Publisher GetPublisherById(int Id){
        return _publishers.FirstOrDefault(p=> p.Id==Id);
    }

    public void AddPublisher(Publisher publisher){
        if(_publishers.Any(p => p.Name == publisher.Name)){
            throw new ArgumentException("Publisher already Exist");
        }
        
        _publishers.Add(publisher);
    }

    public void UpdatePublisher(Publisher publisher)
    {
        var existingPublisher = GetPublisherById(publisher.Id);
        if(existingPublisher is null){
            throw new ArgumentException("Pulisher Not Found");
        }

        if(_publishers.Any(p => p.Id !=publisher.Id && p.Name == publisher.Name)){
            throw new ArgumentException("Publisher with same name already Exist!");
        }

        existingPublisher.Name = publisher.Name;
        existingPublisher.Location = publisher.Location;
        existingPublisher.Email = publisher.Email;
    }

    public void DeletePublisher(Publisher publisher){
        var _publisher = GetPublisherById(publisher.Id);
        if(_publisher != null){
            _publishers.Remove(_publisher);
        }
    }

    // public IEnumerable<Book> GetBooks(int PublisherId){
    //     var publisher = GetPublisherById(PublisherId);
    //     if(publisher is null){
    //         throw new ArgumentException("Publisher Not Found");
    //     }
    //     return publisher.Books;
    // }

    public IEnumerable<Publisher> GetAllPublishers()
    {
        return _publishers;
    }

    void IPublisherService.DeletePublisher(int id)
    {
        var _publisher = GetPublisherById(id);
        if(_publisher != null){
            _publishers.Remove(_publisher);
        }
        throw new ArgumentException();
    }

    // public IEnumerable<Book> GetBooksByPublisher(int publisherId)
    // {
    //     throw new NotImplementedException();
    // }

    // IEnumerable<Book> IPublisherService.GetBooksByPublisher(int publisherId)
    // {
    //     var publisher = GetPublisherById(publisherId);
    //     if(publisher is null){
    //         throw new ArgumentException("Publisher Not Found");
    //     }
    //     return publisher.Books;
    // }
}

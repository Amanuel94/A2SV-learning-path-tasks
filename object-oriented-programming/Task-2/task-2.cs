namespace Tasks{
public class Library{
    private string Name{get; init;}
    private string Address {get; init;}
    public List<Book> Books{get; set;}
    public List<MediaItem> MediaItems{get; set;}
    public HashSet<string> ISBNPool;
    public Library(string Name, string Address){
        this.Name = Name;
        this.Address = Address;
        Books = new List<Book>();
        MediaItems = new List<MediaItem>();
        ISBNPool = new HashSet<string>();
    }
    public void AddBook(Book book){
        Books.Add(book);
        ISBNPool.Add(book.ISBN);
    }
    public void RemoveBook(Book book){
        Books.Remove(book);
        ISBNPool.Remove(book.ISBN);
    }
    public void AddMediaItem(MediaItem item){
        MediaItems.Add(item);
    }
    public void RemoveMediaItem(MediaItem item){
        MediaItems.Remove(item);
    }
    public void PrintCatalog(){
        Console.WriteLine("Here is the list of all books in the library");
        Console.WriteLine($"\tTitle\tAuthor\tISBN\tPublication Year");
        foreach (Book item in Books)
        {
            Console.WriteLine($"\t{item.Title}\t{item.Author}\t{item.ISBN}\t{item.PublicationYear}");
        }
        Console.WriteLine("");
        Console.WriteLine("Here is the list of all media items in the library");
        Console.WriteLine($"\tTitle\tMedia Type\tDuration");
        foreach (MediaItem item in MediaItems)
        {
            Console.WriteLine($"\t{item.Title}\t{item.MediaType}\t{item.Duration}");
        }
    }

    public List<object> SearchItem(string query){
        List<object> searchResults = new List<object>();
        foreach (var book in Books)
        {
            if(book.ToString().Split(':').Contains<string>(query)){
                searchResults.Add(book);
            }
            
        }

        foreach (var media in MediaItems)
        {
            if(media.ToString().Split(':').Contains<string>(query)){
                searchResults.Add(media);
            }
            
        }
        return searchResults;

    }
}

public class Book{
    public string Title{get; set;}
    public string Author{get; set;}
    public string ISBN{get; set;}
    public int PublicationYear{get; set;}

    

    public Book(string Title, string Author, string ISBN, int PublicationYear){
        this.Title = Title;
        this.Author = Author;
        this.ISBN = ISBN;
        this.PublicationYear = PublicationYear;
        
    }

        public override string ToString()
        {
            return $"{Title}:{Author}:{ISBN}:{PublicationYear}";
        }

    

}

public class MediaItem{
    public string Title{get; set;}
    public string MediaType{get; set;}
    public int Duration{get; set;}

    public MediaItem(string Title, string MediaType, int Duration){
        this.Title = Title;
        this.MediaType = MediaType;
        this.Duration = Duration;
    }

    public override string ToString()
        {
            return $"{Title}:{MediaType}:{Duration}";
        }

}
}
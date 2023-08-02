// using Tasks;
namespace Tasks
{
    static class Program
    {


        private static void CheckInvalidInput<T>(string input, decimal? upperBound = null)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new Exception("Input cannot be empty.");
            }

            if (typeof(T) == typeof(decimal) || typeof(T) == typeof(Int32))
            {
                if (upperBound == null)
                {
                    throw new Exception("Upper bound cannot be null");
                }
                decimal output;
                if (decimal.TryParse(input, out output))
                {
                    if (!(output >= 0 && output <= upperBound))
                    {
                        throw new Exception($"The Input cannot be greater than {upperBound} and lower than 0.");
                    }

                }
                else
                {
                    throw new Exception("Input needs to be a number.");
                }
            }
        }

        // a method to continously prompt the user when there is an invalid input
        private static T DisplayPrompt<T>(string prompt, decimal? upperBound = null)
        {
            Console.Write($"{prompt}: ");
            string variable = Console.ReadLine().Trim();
            try
            {
                CheckInvalidInput<T>(variable, upperBound);
            }
            catch (Exception error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error.Message);
                Console.ResetColor();
                return DisplayPrompt<T>(prompt, upperBound);
            }

            return (T)Convert.ChangeType(variable, typeof(T));
        }



        static void Main()
        {

            Library library = new Library("My Library", "Here");
            while(true){
                string prompt = "What do you want to do?"+
                                "\n\t 1. Add Book" +
                                "\n\t 2. Remove Book" +
                                "\n\t 3. Add Media Item" +
                                "\n\t 4. Add Media Item" +
                                "\n\t 5. Print Catalog" +
                                "\n\t 0. Exit";
                int choice = DisplayPrompt<int>(prompt, 5);

                switch (choice){

                    case 1: 
                            CreateBook(library);
                            break;
                    case 2: DeleteBook(library);
                            break;
                    case 3: CreateMedia(library);
                            break;
                    case 4: DeleteMedia(library);
                            break;
                    case 5: library.PrintCatalog();
                            break;
                    case 0: Environment.Exit(0); 
                            break;
                    // exit
                }
            }


        }

        private static void CreateBook(Library library){
            string prompt;
            prompt= "Enter the title of the book";
            string title = DisplayPrompt<string>(prompt);
            prompt= "Enter the Author of the book";
            string author = DisplayPrompt<string>(prompt);
            prompt= "Enter the ISBN of the book";
            string ISBN = DisplayPrompt<string>(prompt);

            prompt= "Enter the year the book is published";
            int publicationYear = DisplayPrompt<int>(prompt, DateTime.Now.Year);

            library.AddBook(new Book(title, author, ISBN, publicationYear));

        }

        private static void DeleteBook(Library library){
            string prompt;
            prompt= "Enter the ISBN of the book";
            string ISBN = DisplayPrompt<string>(prompt);

            foreach (Book book in library.Books)
            {
                if(book.ISBN.Equals(ISBN)){
                    library.RemoveBook(book);
                    return;
                }
            }

            Console.WriteLine("ISBN not found in library.");
        }

        private static void CreateMedia(Library library){
            string prompt;
            prompt= "Enter the title of the media item";
            string title = DisplayPrompt<string>(prompt);
            prompt= "Enter the media type";
            string type = DisplayPrompt<string>(prompt);

            prompt= "Enter the duration of the media item in minutes";
            // every media should be less than 100 days long
            int duration = DisplayPrompt<int>(prompt, 60*24*100);

            library.AddMediaItem(new MediaItem(title, type, duration));

    }

    private static void DeleteMedia(Library library){
        string prompt;
        prompt= "Enter the title of the media";
        string title = DisplayPrompt<string>(prompt);

        foreach (MediaItem media in library.MediaItems)
        {
            if(media.Title.Equals(title)){
                library.RemoveMediaItem(media);
            }
        }

        Console.WriteLine("Media Item not found in library.");
        }

}
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3A
{
    /*
    Class:  Program.cs
    Student Name: Dhwani Patel
    Student number : 000811565
    Date:   March 23, 2021
    Authorship: I, Dhwani Patel, 000811565 certify that this material is my original work. No other person's work has been used without due acknowledgement.

    */


    /// <summary>
    /// Purpose: Program class (Basic class) from which all class objects will be made and functions will be called on them.
    /// </summary>
    class Program
    {

        public Media[] mediaArrayForObjects = new Media[100];          // Media array to store all objects

        /// <summary>
        /// This will load the data from the Data.txt file into array.
        /// </summary>
        public void readTextFile()
        {
            try
            {
                string lineString;
                string pathOfTextFile = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + "/Data.txt";
                System.IO.StreamReader file =
                    new System.IO.StreamReader(pathOfTextFile);
                int count = 0;
                while ((lineString = file.ReadLine()) != null)
                {
                    if (lineString == "-----")
                    {
                        continue;
                    }
                    
                    string[] spliitedLine = lineString.Split('|');
                    if (spliitedLine.Length > 1)
                    {
                        string bookTitle = spliitedLine[1];    
                        int year = Convert.ToInt32(spliitedLine[2]);      
                        if (spliitedLine[0].ToLower() == "book")
                        {
                            string author = spliitedLine[3];        
                            Book book = new Book(bookTitle, year, author, "");
                            mediaArrayForObjects[count] = book;
                        }
                        else if (spliitedLine[0].ToLower() == "song")
                        {
                            string album = spliitedLine[3];     
                            string artist = spliitedLine[4];   
                            Song song = new Song(bookTitle, year, album, artist);
                            mediaArrayForObjects[count] = song;
                        }
                        else if (spliitedLine[0].ToLower() == "movie")
                        {
                            string director = spliitedLine[3];    
                            Movie movie = new Movie(bookTitle, year, director, "");
                            mediaArrayForObjects[count] = movie;
                        }


                        count++;
                    }
                    else
                    {
                        
                        Type type = mediaArrayForObjects[count - 1].GetType();
                        if (type.Name == "Book")
                        {
                            Book lastObject = (Book)mediaArrayForObjects[count - 1];
                            lastObject.bookSummary = lineString;
                            mediaArrayForObjects[count - 1] = lastObject;
                        }

                        if (type.Name == "Movie")
                        {
                            Movie lastObject = (Movie)mediaArrayForObjects[count - 1];
                            lastObject.MovieSummary = lineString;
                            mediaArrayForObjects[count - 1] = lastObject;
                        }
                    }    
                }
                file.Close();

            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File Error! No file.");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }

        }


        /// <summary>
        /// This is to prompt options to user and call functions
        /// </summary>
        public void promptMenuOptions()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Lab 3A");
            Console.WriteLine("=========================");
            int menuOption;
            
            Console.WriteLine("Choose from the following options:");
            Console.WriteLine("1 - List All Books");
            Console.WriteLine("2 - List All Movies");
            Console.WriteLine("3 - List All Songs");
            Console.WriteLine("4 - List All Media");
            Console.WriteLine("5 - Search All Media by Title");
            Console.WriteLine("6 - Exit Program");

            try
            {
                menuOption = Convert.ToInt32(Console.ReadLine());

                switch (menuOption)
                {
                    case 1:
                        Console.WriteLine("*** LIST OF ALL BOOKS ***");
                        listOfBooks();
                        break;
                    case 2:
                        Console.WriteLine("*** LIST OF ALL MOVIES ***");
                        listOfMovies();
                        break;
                    case 3:
                        Console.WriteLine("*** LIST OF ALL SONGS ***");
                        listOfSongs();
                        break;
                    case 4:
                        Console.WriteLine("*** LIST OF ALL MEDIA ***");
                        listOfMediaObjects();
                        break;
                    case 5:
                        Console.WriteLine("*** LIST OF ALL SEARCHED TITLE ***");
                        listMediaByKeyword();
                        break;
                    case 6:
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        Environment.Exit(1);
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please choose from given options!");
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        promptMenuOptions();
                        break;
                }
                promptMenuOptions();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter digits only!");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                promptMenuOptions();
            }
        }

        /// <summary>
        /// List all the books from media array
        /// </summary>
        public void listOfBooks()
        {
            foreach (Media i in mediaArrayForObjects)
            {
                if (i == null)
                {
                    break;
                }
                Type type = i.GetType();
                if (type.Name == "Book")
                {
                    Console.WriteLine("********************");
                    Book book = (Book)i;
                    book.showBooks();
                }
            }
        }


        /// <summary>
        /// List all the songs from media array
        /// </summary>
        public void listOfSongs()
        {
            foreach (Media i in mediaArrayForObjects)
            {
                if (i == null)
                {
                    break;
                }
                Type type = i.GetType();
                if (type.Name == "Song")
                {
                    Console.WriteLine("********************");
                    Song song = (Song)i;
                    song.DisplaySong();
                }
            }
        }


        /// <summary>
        /// List all the movies from media array
        /// </summary>
        public void listOfMovies()
        {
            foreach (Media i in mediaArrayForObjects)
            {
                if (i == null)
                {
                    break;
                }
                Type type = i.GetType();
                if (type.Name == "Movie")
                {
                    Console.WriteLine("********************");
                    Movie movie = (Movie)i;
                    movie.showMovies();

                }

            }
        }


        /// <summary>
        /// List all the media from media array
        /// </summary>
        public void listOfMediaObjects()
        {
            
            foreach (Media i in mediaArrayForObjects)
            {
                if (i == null)
                {
                    break;
                }
                Type type = i.GetType();
                Console.WriteLine("********************");
                if (type.Name == "Book")
                {
                    Console.WriteLine("*** BOOK ***");
                    Book book =(Book)i;
                    book.showBooks();
                }
                if (type.Name == "Movie")
                {
                    Console.WriteLine("*** MOVIE ***");
                    Movie movie = (Movie)i;
                    movie.showMovies();

                }
                if (type.Name == "Song")
                {
                    Console.WriteLine("*** SONG ***");
                    Song song = (Song)i;
                    song.DisplaySong();
                }
            }
        }


        /// <summary>
        /// List all the media from media array according to given keyword by user
        /// </summary>
        public void listMediaByKeyword()
        {
            string key = "";
            bool checkFlag = false;
            Console.WriteLine("Enter keyword to search: ");
            key = Console.ReadLine();
            if (key != "")
            {
                foreach (Media i in mediaArrayForObjects)
                {
                    if (i == null)
                    {
                        break;
                    }
                    bool flag = i.Search(key);
                    if (flag)
                    {
                        Console.WriteLine("********************");
                        Type type = i.GetType();
                        if (type.Name == "Book")
                        {
                            Book book = (Book)i;
                            book.showBooksAndSummary();
                        }
                        if (type.Name == "Movie")
                        {
                            Movie movie = (Movie)i;
                            movie.showMoviesAndSummary();
                        }
                        checkFlag = true;
                    }
                }
            }

            if (!checkFlag)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No media with this keyword!");
                Console.ForegroundColor = ConsoleColor.DarkBlue;

            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.readTextFile();
            program.promptMenuOptions();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }


    }
}

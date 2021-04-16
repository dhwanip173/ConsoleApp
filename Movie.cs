using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3A
{
    /*
    Class:  Movie.cs
    Student Name: Dhwani Patel
    Student number : 000811565
    Date:   March 23, 2021
    Authorship: I, Dhwani Patel, 000811565 certify that this material is my original work. No other person's work has been used without due acknowledgement.
     */


    /// <summary>
    /// Purpose: Derived class of media class used to create movies objects.
    /// </summary>
    class Movie : Media, IEncryptable
    {

        public string MovieDirector { get; set; }          // Name of movie director 
        public string MovieSummary { get; set; }         // Summary of movie

        /// <summary>
        /// Parameterized constructor for movie class to create/set object attributes
        /// </summary>
        /// <param name="movieTitle">Movie title</param>
        /// <param name="movieYear">Year of movie</param>
        /// <param name="movieDirector">Director of movie</param>
        /// <param name="movieSummary">Summary of movie</param>
        public Movie(string movieTitle, int movieYear, string movieDirector, string movieSummary) : base(movieTitle, movieYear)
        {
            MovieDirector = movieDirector;
            MovieSummary = movieSummary;
        }

        /// <summary>
        /// Show all the details of movies except summary
        /// </summary>
        public void showMovies()
        {
            Console.WriteLine("Movie Title: " + MediaTitle);
            Console.WriteLine("Movie Released Year: " + MediaYear);
            Console.WriteLine("Movie Director Name: " + MovieDirector);
        }

        /// <summary>
        /// Show all the details of movies with summary
        /// </summary>
        public void showMoviesAndSummary()
        {
            Console.WriteLine("Movie Title: " + MediaTitle);
            Console.WriteLine("Movie Released Year: " + MediaYear);
            Console.WriteLine("Movie Director Name: " + MovieDirector);
            // We need to call decrypt function because summary is decrypted
            Console.WriteLine("Movie Summary: " + Decrypt());
        }


        #region IEncrytable

        /// <summary>
        /// This function signature is taken IEncrytable interface.
        /// This will implement the Rot13 algorithm and encrypt the Summary
        /// </summary>
        /// <returns>Encrypted Summary</returns>
        public string Encrypt()
        {
            // converting the summaryName string into an array of Charachters
            char[] array = MovieSummary.ToCharArray();

            // looping through the array of chars
            for (int i = 0; i < array.Length; i++)
            {
                // Running the Rot13 algorithm
                // This transformation cipher shifts letters 13 places in the alphabet. Generally, we can change the individual characters in a string based on logic.
                int number = (int)array[i];

                if (number >= 'a' && number <= 'z')
                {
                    if (number > 'm')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                else if (number >= 'A' && number <= 'Z')
                {
                    if (number > 'M')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                array[i] = (char)number;
            }
            return new string(array);
        }

        /// <summary>
        /// This function signature is taken IEncrytable interface.
        /// This will implement the Rot13 algorithm and decrypt the Summary
        /// </summary>
        /// <returns>Decrypted Summary</returns>
        public string Decrypt()
        {
            // converting the Summary string into an array of Charachters
            char[] array = MovieSummary.ToCharArray();

            // looping through the array of chars
            for (int i = 0; i < array.Length; i++)
            {
                // Running the Rot13 algorithm
                // This transformation cipher shifts letters 13 places in the alphabet. Generally, we can change the individual characters in a string based on logic.
                int number = (int)array[i];

                if (number >= 'a' && number <= 'z')
                {
                    if (number > 'm')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                else if (number >= 'A' && number <= 'Z')
                {
                    if (number > 'M')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                array[i] = (char)number;
            }
            return new string(array);
        }

        #endregion

    }
}

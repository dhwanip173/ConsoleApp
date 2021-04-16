using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3A
{

    /*
    Class:  Book.cs
    Student Name: Dhwani Patel
    Student number : 000811565
    Date:   March 23, 2021
    Authorship: I, Dhwani Patel, 000811565 certify that this material is my original work. No other person's work has been used without due acknowledgement.
    */


    /// <summary>
    /// Purpose: Derived class of media class used to create book objects.
    /// </summary>
    class Book : Media, IEncryptable
    {
        public string authorName { get; set; }          // Name of bookAuthor of book
        public string bookSummary { get; set; }         // Summary of book

        /// <summary>
        /// Parameterized constructor for book class to create/set object attributes
        /// </summary>
        /// <param name="bookTitle">Title of book</param>
        /// <param name="bookYear">Year of book</param>
        /// <param name="bookAuthor">Author of book</param>
        /// <param name="bookSummary">Summary of Book</param>
        public Book(string bookTitle, int bookYear,string bookAuthor,string bookSummary) : base(bookTitle,bookYear)
        {
            authorName = bookAuthor;
            this.bookSummary = bookSummary;
        }

        /// <summary>
        /// Show all the books with all details except summary
        /// </summary>
        public void showBooks()
        {
            Console.WriteLine("Book Title: " + MediaTitle);
            Console.WriteLine("Book Published Year: " + MediaYear);
            Console.WriteLine("Book Author Name: " + authorName);
        }

        /// <summary>
        /// Show all the books with all details with summary
        /// </summary>
        public void showBooksAndSummary()
        {
            Console.WriteLine("Book Title: " + MediaTitle);
            Console.WriteLine("Book Published Year: " + MediaYear);
            Console.WriteLine("Book Author Name: " + authorName);
            // We need to call decrypt function because summary is decrypted
            Console.WriteLine("Book Summary: " + Decrypt());
        }

        #region IEncrytable

        /// <summary>
        /// This function signature is taken IEncrytable interface.
        /// This will implement the Rot13 algorithm and encrypt the summaryName
        /// </summary>
        /// <returns>Encrypted Summary</returns>
        public string Encrypt()
        {
            // converting the summaryName string into an array of Charachters
            char[] array = bookSummary.ToCharArray();

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
            char[] array = bookSummary.ToCharArray();

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

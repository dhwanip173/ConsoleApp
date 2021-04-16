using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3A
{
    /*
    Class:  Media.cs
    authorName: Nicholas J. Corkigian
    Date:   October 5, 2017

          This code is not to be altered.
    */  

    /// <summary>
    /// Purpose: This abstract class represents a single object of a media type,
    ///          be it something like a book, movie, or song.
    ///          
    ///          Other classes must be derived from this class.
    ///          
    ///          Because it implements the ISearchable interface, all derived
    ///          classes will also need to implement the methods of that
    ///          interface as well.
    /// </summary>

    public abstract class Media : ISearchable
    {
        public string MediaTitle { get; protected set; }          // Title for media types
        public int MediaYear { get; protected set; }              // Year for media types

        /// <summary>
        /// Two-argument constructor sets the two properties that all Media objects have
        /// </summary>
        /// <param name="mediaTitle">The bookTitle of the media object</param>
        /// <param name="mediaYear">The year of publication and/or release</param>

        public Media(string mediaTitle, int mediaYear)
        {
            MediaTitle = mediaTitle;
            MediaYear = mediaYear;
        }

        #region ISearchable

        /// <summary>
        /// All Media objects are searchable on their MediaTitle property.
        /// 
        /// For an individual Media object, this means that given a string as a
        /// search key, the Search() method will either locate that string in
        /// the MediaTitle property or it will not.
        /// 
        /// If not overridden, this method can be used by all derived classes 'as is'.
        /// </summary>
        /// <param name="key">The string to be searching for</param>
        /// <returns>A flag indicating whether the search string was found (true) or not (false)</returns>

        public bool Search(string key)
        {
            // Make the search case insensitive by treating strings as lowercase
            string temp = MediaTitle.ToLower();

            if (temp.IndexOf(key.ToLower()) >= 0)
                return true;                        // Found it
            else
                return false;                       // Didn't find it
        }

        #endregion  // End ISearchable
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3A
{
    /*
   Class:  Song.cs
    Student Name: Dhwani Patel
    Student number : 000811565
    Date:   March 23, 2021
    Authorship: I, Dhwani Patel, 000811565 certify that this material is my original work. No other person's work has been used without due acknowledgement.

   */


    /// <summary>
    /// Purpose: Derived class of media class used to create song objects.
    /// </summary>
    class Song : Media
    {

        public string SongAlbum { get; set; }          // Album name of song
        public string ArtistName { get; set; }         // Name of artist of song

        /// <summary>
        /// Parameterized constructor for book class to create/set object attributes
        /// </summary>
        /// <param name="songTitle">Title of song</param>
        /// <param name="songYear">Year of song</param>
        /// <param name="songAlbum">Album of song</param>
        /// <param name="songArtist">Name of artist of song</param>
        public Song(string songTitle, int songYear, string songAlbum, string songArtist) : base(songTitle, songYear)
        {
            SongAlbum = songAlbum;
            ArtistName = songArtist;
        }

        /// <summary>
        /// Display movie with all the attributes except the summaryName
        /// </summary>
        public void DisplaySong()
        {
            Console.WriteLine("Song Title: " + MediaTitle);
            Console.WriteLine("Song Released Year: " + MediaYear);
            Console.WriteLine("Song Album Name: " + SongAlbum);
            Console.WriteLine("Song Artist Name: " + ArtistName);
        }

       
    }
}

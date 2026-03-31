using System;
using System.Collections.Generic;
using System.Text;

namespace C__Collection_Assignment
{
    using System;
    using System.Collections.Generic;

    class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
    }

     internal class Assignment_6
    {
        static void Main()
        {
            // ➤ LinkedList for playlist
            LinkedList<Song> playlist = new LinkedList<Song>();

            // ➤ Add songs at beginning
            playlist.AddFirst(new Song { Id = 1, Title = "Song A", Artist = "Artist 1" });

            // ➤ Add songs at end
            playlist.AddLast(new Song { Id = 2, Title = "Song B", Artist = "Artist 2" });
            playlist.AddLast(new Song { Id = 3, Title = "Song C", Artist = "Artist 3" });

            // ➤ Add song in middle (after first node)
            var firstNode = playlist.First;
            if (firstNode != null)
            {
                playlist.AddAfter(firstNode, new Song { Id = 4, Title = "Song D", Artist = "Artist 4" });
            }

            Console.WriteLine("Playlist (Forward):");
            DisplayForward(playlist);

            // ➤ Remove a specific song (by title)
            Console.WriteLine("\nEnter song title to remove:");
            string removeTitle = Console.ReadLine();

            var nodeToRemove = playlist.First;
            while (nodeToRemove != null)
            {
                if (nodeToRemove.Value.Title.Equals(removeTitle, StringComparison.OrdinalIgnoreCase))
                {
                    playlist.Remove(nodeToRemove);
                    Console.WriteLine("Song removed.");
                    break;
                }
                nodeToRemove = nodeToRemove.Next;
            }

            // ➤ Traverse backward
            Console.WriteLine("\nPlaylist (Backward):");
            DisplayBackward(playlist);

            // ➤ Find a song by title
            Console.WriteLine("\nEnter song title to search:");
            string searchTitle = Console.ReadLine();

            var node = playlist.First;
            bool found = false;

            while (node != null)
            {
                if (node.Value.Title.Equals(searchTitle, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Found: {node.Value.Title} by {node.Value.Artist}");
                    found = true;
                    break;
                }
                node = node.Next;
            }

            if (!found)
            {
                Console.WriteLine("Song not found.");
            }

            // ➤ BONUS: Play Next feature
            Console.WriteLine("\nEnter current song title (Play Next):");
            string currentTitle = Console.ReadLine();

            var currentNode = playlist.First;
            while (currentNode != null)
            {
                if (currentNode.Value.Title.Equals(currentTitle, StringComparison.OrdinalIgnoreCase))
                {
                    if (currentNode.Next != null)
                    {
                        Console.WriteLine($"Next Song: {currentNode.Next.Value.Title}");
                    }
                    else
                    {
                        Console.WriteLine("This is the last song.");
                    }
                    break;
                }
                currentNode = currentNode.Next;
            }
        }

        // ➤ Display forward
        static void DisplayForward(LinkedList<Song> list)
        {
            foreach (var song in list)
            {
                Console.WriteLine($"Id: {song.Id}, Title: {song.Title}, Artist: {song.Artist}");
            }
        }

        // ➤ Display backward
        static void DisplayBackward(LinkedList<Song> list)
        {
            var node = list.Last;
            while (node != null)
            {
                Console.WriteLine($"Id: {node.Value.Id}, Title: {node.Value.Title}, Artist: {node.Value.Artist}");
                node = node.Previous;
            }
        }
    }
 
}

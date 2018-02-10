using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun
{
    //User can able to store there personal Choice
    //User can able to search by Collection Type
    //User can able to prepare custom playlist - CRUD is allowed

    #region EnumSection
        public enum SongType
        {
            Romantic, Sad, Fun
        }
    #endregion

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MusicLibrary Library { get; set; }
        public UserPlayList PlayList { get; set; }
    }
    
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Artist Artist { get; set; }
        public SongType SongType { get; set; }
    }

    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class MusicLibrary
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<Song> Songs { get; set; }
    }
    
    public interface IUserActivity
    {
        List<Song> SearchSong(Func<Song, bool> where);
        void AddSongInLibrary(List<Song> Songs);
        void RemoveSong(List<Song> Songs);
    }

    public class UserLibraryActivity : IUserActivity
    {
        MusicLibrary UserLibrary;
        List<MusicLibrary> LibraryCollection = new List<MusicLibrary>();

        public UserLibraryActivity(int UserId)
        {
            this.UserLibrary = LibraryCollection.Where(f => f.UserId == UserId).FirstOrDefault();
        }
        public List<Song> SearchSong(Func<Song, bool> where)
        {
            return this.UserLibrary.Songs.Where(where).ToList();
        }
        public void AddSongInLibrary(List<Song> Songs)
        {
            if(UserLibrary != null)
            {
                UserLibrary.Songs.AddRange(Songs);
            }
        }
        public void RemoveSong(List<Song> Songs)
        {
            if(UserLibrary != null)
            {
                foreach (var item in Songs)
                {
                    var tempSong = UserLibrary.Songs.Where(f => f.Id == item.Id).FirstOrDefault();
                    UserLibrary.Songs.Remove(tempSong);
                }
            }
        }
    }
    public class UserPlayList
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Queue<Song> CurrentList { get; set; }
    }
    public interface IPlayListActivity
    {
        void Play();
        void Pause();
        void Stop();
        void PlayNext();
        List<Song> ShowPlayList();
    }
    public class PlayListActivity : IPlayListActivity
    {
        UserPlayList UserPlayList;

        public PlayListActivity(UserPlayList UserPlayList)
        {
            this.UserPlayList = UserPlayList;
        }

        public void Pause()
        {
            Console.WriteLine("Paused");
        }

        public void Play()
        {
            var currentSong = UserPlayList.CurrentList.Dequeue();
            Console.WriteLine("Current Song" + currentSong.Name);
        }

        public void PlayNext()
        {
            var currentSong = UserPlayList.CurrentList.Dequeue();
            Console.WriteLine("Current Song" + currentSong.Name);
        }

        public List<Song> ShowPlayList()
        {
            return UserPlayList.CurrentList.ToList();
        }

        public void Stop()
        {
            Console.WriteLine("Stopped");
        }
    }

}

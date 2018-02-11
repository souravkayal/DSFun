using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatModelImplementation
{
    //Implementation of basic model of Chat application

    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string ConnectionId { get; set; } //Unique GUID
        public UserStatus UserStatus { get; set; }

        public User()
        {
            this.ConnectionId = Guid.NewGuid().ToString();
        }
    }

    public enum RoomType
    {
        Private,Public
    }

    public class ChatRoom
    {
        public int Id { get; set; }
        public string RoomName { get; set; } //Room Name Must be unique
        public List<User> Members { get; set; }
        public RoomType RoomType { get; set; }
        public List<Message> Messages { get; set; }
    }

    public class Message
    {
        public string Id { get; set; }
        public int RoomId { get; set; }
        public string SendFrom { get; set; }
        public DateTime SendAt { get; set; }
    }


    public enum UserStatus
    {
        Online, Offline , Away, Busy
    }

    public interface IChatActivity
    {
        void ChangeStatus(string RoomName, string UserId, UserStatus CurrentStatus);
        void LeaveRoom(string RoomName, User User);
        void JoinInRoom(string RoomName, User User);
        void SendMessage(string RoomName, User User, string Message);
    }

    public class Chat : IChatActivity
    {
        public List<ChatRoom> AllRooms;
        public ChatRoom CurrentRoom;
        public Chat()
        {
            this.AllRooms = new List<ChatRoom>();
        }
        public void ChangeStatus(string RoomName, string UserId, UserStatus CurrentStatus)
        {
            CurrentRoom = this.AllRooms.Where(f => f.RoomName == RoomName).FirstOrDefault();
            if(CurrentRoom != null)
            {
                var User = CurrentRoom.Members.Where(f => f.Id == UserId).FirstOrDefault();
                User.UserStatus = CurrentStatus;
            }
        }
        public void JoinInRoom(string RoomName, User User)
        {
            var Room = this.AllRooms.Where(f => f.RoomName == RoomName).FirstOrDefault();
            if(Room != null)
            {
                Room.Members.Add(User);
            }
        }
        public void LeaveRoom(string RoomName, User User)
        {
            var Room = this.AllRooms.Where(f => f.RoomName == RoomName).FirstOrDefault();
            if (Room != null)
            {
                Room.Members.Remove(User);
            }
        }
        public void SendMessage(string RoomName, User User, string Message)
        {
            var Room = this.AllRooms.Where(f => f.RoomName == RoomName).FirstOrDefault();
            if(Room != null)
            {
                Room.Messages.Add(new Message { Id = Guid.NewGuid().ToString(), SendAt = DateTime.Now, SendFrom = Message });
            }
        }
    }
}

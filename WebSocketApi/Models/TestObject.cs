using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProtoBuf;

namespace WebSocketApi.Models
{
    [ProtoContract]
    public class TestObject
    {
        [ProtoMember(1)]
        public string Name { get; set; }

        [ProtoMember(2)]
        public int TestId { get; set; }

        [ProtoMember(3)]
        public bool IsWorking { get; set; }

        [ProtoMember(4)]
        public Priority Priority { get; set; }

        [ProtoMember(5)]
        public double Balance { get; set; }

        private readonly List<Contact> contacts = new List<Contact>();
        [ProtoMember(6)]
        public List<Contact> Contacts { get { return contacts; } }
    }
    public enum Priority
    {
        LOW = 1,
        MEDIUM = 2,
        HIGH = 3
    }

    [ProtoContract]
    public class Contact
    {
        [ProtoMember(1)]
        public string Name { get; set; }

        [ProtoMember(2)]
        public string ContactDetails { get; set; }
    }
}
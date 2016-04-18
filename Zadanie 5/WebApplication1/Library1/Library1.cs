using System.Runtime.Serialization;

namespace Library1
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string BookTitle { get; set; }
        [DataMember]
        public string ISBN { get; set; }
    }
    [DataContract]
    public class Author
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string AuthorName { get; set; }
        [DataMember]
        public string AuthorSurname { get; set; }
    }
}
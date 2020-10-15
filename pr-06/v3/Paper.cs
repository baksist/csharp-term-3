using System;

namespace pr_06
{
    public class Paper
    {
        public string Title { get; set; }
        public Person Author { get; set; }
        public DateTime PublicationDate { get; set; }

        public Paper(string title, Person author, DateTime publicationDate)
        {
            Title = title;
            Author = author;
            PublicationDate = publicationDate;
        }

        public Paper()
        {
            Title = "DefaultTitle";
            Author = new Person();
            PublicationDate = DateTime.UnixEpoch;
        }

        public override string ToString()
        {
            return Title + ' ' + Author.ToShortString() + ' ' + PublicationDate.ToString("dd/MM/yyyy");
        }
    }
}
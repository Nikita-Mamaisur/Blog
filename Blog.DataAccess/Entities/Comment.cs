using System;

namespace Blog.DataAccess.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public Post Post { get; set; }

        public User Author { get; set; }

		public DateTime _date { get; set; }    //date
	}
}
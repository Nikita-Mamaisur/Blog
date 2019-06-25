using System;

namespace Blog.DataServices.Models.Posts
{
    public class CommentModel
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public string Text { get; set; }
		public DateTime _date { get; set; }   //date

	}
}

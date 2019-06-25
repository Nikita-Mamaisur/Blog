using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Blog.DataServices.Models.Posts
{
    public class PostModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Slug { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        [StringLength(maximumLength: 2147483647, MinimumLength = 10)]   // use maximumLength for Int32 
		public string Body { get; set; }

        public DateTime Date { get; set; }

        public List<CommentModel> Comments { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace OnlineLearningg.Models;

public partial class Post
{
    public int PostId { get; set; }

    public int UserId { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime Datetime { get; set; }

    public int Upvote { get; set; }

    public int Downvote { get; set; }

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual User User { get; set; } = null!;
}

﻿using System;
using System.Collections.Generic;

namespace OnlineLearningg.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Role { get; set; }

    public string? Image { get; set; }

    public int? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public int? Age { get; set; }

    public string? Gender { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual ICollection<Course> Courses { get; } = new List<Course>();

    public virtual ICollection<Enrollment> Enrollments { get; } = new List<Enrollment>();

    public virtual ICollection<Post> Posts { get; } = new List<Post>();

    public virtual ICollection<StudentAnswer> StudentAnswers { get; } = new List<StudentAnswer>();
}

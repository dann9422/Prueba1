﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSnippets
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; } = String.Empty;
        public string Title { get; set; } = String.Empty;
        public DateTime Created { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}

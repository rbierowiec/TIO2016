﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zad6b.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string ISBN { get; set; }
        public int pageCount { get; set; }
    }
}
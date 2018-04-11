﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace MyBookHub
{
    public class Book 
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
		public string BookImagePath { get; set; }
        public string BookTitle { get; set; }
        public string ISBNnumber { get; set; }
        public string AuthorName { get; set; }
		public string BookCategory { get; set; }
		//public string NoOfBooks { get; set; }
		public string BookDescription { get; set; }

		public override string ToString()
		{
			return string.Format("[Book: Id={0}, BookTitle={1}, ISBNnumber={2}]", Id, BookTitle, ISBNnumber);
		}
    }
}

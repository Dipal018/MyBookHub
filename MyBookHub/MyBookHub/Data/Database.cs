using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using MyBookHub.Model;

namespace MyBookHub.Data
{
	public class Database
	{
		private SQLiteConnection _sqlconnection;
		public Database()
		{
			_sqlconnection = DependencyService.Get<ISQLite>().GetConnection();
			_sqlconnection.CreateTable<Book>();
			_sqlconnection.CreateTable<User>();
		}
		//Get all books
		public IEnumerable<Book> GetBooks()
		{
			return (from t in _sqlconnection.Table<Book>() select t).ToList();
		}

		//Get all books
		public IEnumerable<Book> GetBooks(int owner_id)
		{
			return _sqlconnection.Table<Book>().Where(b => b.owner_id == owner_id);
		}

		//Get specific book  
		public Book GetBook(int id)
		{
			return _sqlconnection.Table<Book>().FirstOrDefault(t => t.Id == id);
		}

		public Book GetBookByBarcode(string barcode, int owner_id)
		{
			return _sqlconnection.Table<Book>().Where(b => b.owner_id == owner_id && b.ISBNnumber.Equals(barcode)).FirstOrDefault();
		}

		//Delete specific book  
		public void DeleteBook(int id)
		{
			_sqlconnection.Delete<Book>(id);
		}

		//Add new book to DB  
		public void AddBook(Book book)
		{
			_sqlconnection.Insert(book);
		}

		public IEnumerable<Book> SearchBookByTitle(string bookName, int owner_id)
		{
			return _sqlconnection.Table<Book>().Where(b => b.BookTitle.ToUpper().Contains(bookName.ToUpper()) && b.owner_id == owner_id);
		}

		public IEnumerable<Book> SearchBookByAuthor(string authorName, int owner_id)
		{
			return _sqlconnection.Table<Book>().Where(b => b.AuthorName.ToUpper().Contains(authorName.ToUpper()) && b.owner_id == owner_id);
		}

		public IEnumerable<Book> SearchBookByCategory(string category, int owner_id)
		{
			return _sqlconnection.Table<Book>().Where(b => b.BookCategory.ToUpper().Contains(category.ToUpper()) && b.owner_id == owner_id);
		}

		//Get all issued books
		public IEnumerable<Book> GetIssuedBooksFromUser(int owner_id)
		{
			return _sqlconnection.Table<Book>().Where(b => b.IsIssued && b.owner_id== owner_id).ToList();
		}

		//Get all issued books to given user
		public IEnumerable<Book> GetIssuedBooksToUser(int user_id)
		{
			return _sqlconnection.Table<Book>().Where(b => b.IsIssued && b.IssuedToUserId == user_id).ToList();
		}

		//Delete specific issued book 
		public void ReturnIssuedBook(Book book)
		{
			book.IsIssued = false;
			book.IssuedToUserId = -1;
	 
			_sqlconnection.Update(book);
		}

		public void IssueBook(Book book, int user_id, DateTime issue_date, DateTime return_date)
		{
			book.IsIssued = true;
			book.IssuedToUserId = user_id;
			book.DateOfIssue = issue_date;
			book.DateOfReturn = return_date;
			_sqlconnection.Update(book);
		}
		//Get all users
        public IEnumerable<User> GetUsers()
		{
			return (from t in _sqlconnection.Table<User>() select t).ToList();
		}

		//Get all users
        public IEnumerable<User> GetUsersByType(string usertype)
		{
			return _sqlconnection.Table<User>().Where(u => u.user_type == usertype).ToList();
		}

		//Get specific user  
		public User GetUser(int id)
		{
			return _sqlconnection.Table<User>().FirstOrDefault(t => t.user_id == id);
		}

		public User GetUserByUserName(string username)
		{
			return _sqlconnection.Table<User>().Single(t => t.user_name == username);
		}

		public User GetUserType(string firstname)
		{
			return _sqlconnection.Table<User>().FirstOrDefault(t => t.first_name.Contains(firstname));
		}
		//authenticate user
		public User Authenticate(string username, string password)
		{
			return _sqlconnection.Table<User>().FirstOrDefault(t => t.user_name == username && t.password == password);
		}

		//update user
		public int updateProfile(User user)
		{
			return _sqlconnection.Update(user);
		}

		//get book owner name
		public IEnumerable<User> GetBookOwnerNames()
		{
			//   lock (locker)
			// {
			return _sqlconnection.Query<User>("SELECT * FROM [User] WHERE [user_type] like '%Owner%'").ToList();
			//}
		}

		public User GetBookOwnerId(string firstname, string lastname)
		{
			return _sqlconnection.Table<User>().FirstOrDefault(t => t.first_name.Equals(firstname) && t.last_name.Equals(lastname));
		}

		//Delete specific user  
		public void DeleteUser(int id)
		{
			_sqlconnection.Delete<User>(id);
		}

		//Add new user to DB  
		public void AddUser(User user)
		{
			_sqlconnection.Insert(user);
		}
    }
}

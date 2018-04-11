using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using System;
using SQLite;

namespace MyBookHub
{
	public class Issuebooktbl
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string DateOfIssue { get; set; }
		public string DateOfReturn { get; set; }
		public string NoOfDays { get; set; }
		public string SMSsent { get; set; }
		public string BookAvailable { get; set; }
	
		public override string ToString()
		{
			return string.Format("[Book: Id={0}, DateOfIssue={1}, DateOfReturn={2}]", Id, DateOfIssue, DateOfReturn);
		}
	}

}

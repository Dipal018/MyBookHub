Title: BookHub

Desciption: A cross platform mobile application using Xamarin with C# for managing home library in Android, iOS and Windows devices. 
The application allows users to manage their book catalog, issue books, send automated SMS reminders.
Inspiration behind this project : https://goo.gl/photos/XgLYE6VKZN2Q5KkN7

These are the few features of Bookhub app
- Personal Library Management System for Home Library
- User profile management
- Sign up and Login 
- Add a new book, remove a book
- Search book by Name, Title and Category
- Issue a book, Return a book
- Sending SMS notifications to readers to remind about returning of book.
- Barcode Scanning of book for quick access of library functionalities

Prerequisites
- Visual Studio 
- Xamarin Studio for Desktop/MAC

Demo instructions and known limits
- Set permission: Set permission for read, write from external storage, SMS sender, Camera  and Flash light in Android Manifest file if not assigned. (iOS will handle the runtime permissions in the app automatically
- Install packages - We have used two packages 
sqlite-net PCL package in all projects including PCL for database.
ZXing.net mobile nuget package for barcode scanner
- Set Document path of our database - We are running the app in our device(mobile) because of convenience in accessing data from SQLite database. Changes required in SQLite_Android.cs file under MyBookHub.Droid folder in order to run the app.

1. If you are running this app in emulator 
string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
2. If you are running this app in android device/phone              
string documentsPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
(Note: Both the lines of code are already written, comment or uncomment accordingly)
- Scan and SMS Notification Testing : These must be tested in Android/iOS device only. Testing these functionalities with emulator is not possible. 
- Create new user and owner - There are two types of users for our app & they have different privileges for access
Owner of the BookHub
Borrower
You can create account for both of these users by clicking ‘Sign Up’. For further instructions, you can refer to the wireframe or video attached with the submission.
- Email validation: Email address will be used to send the activation account link to reader if he/she forgets the password. As ‘Forget password’ feature is our future enhancement we have not put any specific validation for email entry in profile page. Kindly ignore that.

Application Demo Video: https://www.youtube.com/watch?v=1leEqz82C0c&feature=youtu.be


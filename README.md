# Library-Management

<strong># CodeAcademy C# Exam #</strong>

Create an application that will help the employees of the library manage book stocks, manage members, rent books, track rented books and close book rents. Users of the application will be the employees of the library. 
Every book has:
-Unique Id
-Title
-Number of copies
Books can be rented only by library members and each member can rent up to 3 books at a time. 
Each member has: 

-Unique Id – which the member needs to give when renting a book
-Name
-Surname
E-mail – there can not be two members with the same email address

The application should have the following functionalities: 

Rent
<li>Input member Id (validate if there is a member with input Id and if the member can rent more books)</li>
<li>Present available books for rent so the member can choose</li>
<li>Based on the member’s choice mark the book as rented and assign it to the member</li>
Close rent    
<li>Input member Id (validate)</li>
<li>Show the list of books that the user has rented</li>
<li>Based on the member's input close the rent of the book and unassign it from the member</li>
Manage members
<li>Show all members</li>
<li>Create new member</li>
<li>Delete existing member</li>
Manage books
<li>Show all books</li>
<li>Add new book (can not have multiple books with the same title)</li>
<li>Delete existing book</li>
<li>Print all rented books</li>

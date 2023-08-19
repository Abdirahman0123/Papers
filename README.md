# Papers
A web application for selling stationery items, developed using C#, .Net core, ASP.NET CORE MVC, Entity Framework core, LINQ and SQL SERVER 

Download Papers.bacpack file
First open SQL SERVER 2019 and click on “Connect”. After that, right-click on Databases and choose “Import Data-tier application” to import the database file. On the popup window, click on “Next” and then click on “Browse” on the second window to find the file location. When you select the database file, click on “Next”. On the new popup window, give the name as “Papers”, click on “Next” and then click on “Finish” to import the database. It is important you give the database name as “Papers” because this is the name the web application uses to connect to the database. If a different name is supplied, the web application will not work.


To run the application, download the project and extract the files from the zip file. Click on the extracted files and find Papers with .sln extension and double click on it (install vs 2022). When the project opens, click on “Debug” and then choose “Start without debugging” to run the application. If you get error like path not found when you are running your project then your just need to Build ->Select Clean Solution and then again Build -> Rebuild Solution. 

Admin and supplier pages can only be accessed by admins. so use this details login :
* Email: Admin1@hotmail.com
* Password: Admin1@hotmail.com
Admins can new products and suppliers through Admin and Supplier pages respectively.
customers can buy products by going to Products and clicking on buy button next the product, which then directed to the cart. at the checkout, they need to register or login for the invoice

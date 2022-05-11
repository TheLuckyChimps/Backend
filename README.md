# TPL-Backend
To run the server use the following command in terminal inside the project
```
dotnet run
```
Use Sql Server Management to save the migrations into the database with the following command in Visual Studion in Package Manager Console:
```
 Update-Database
```
If you want to test the api, first you should call the register endpoint and after that authenticate. The result will be the JWT that has to be coppied to the Authorize section on top of the page with the format "Bearer <token>". After that you can call any other endpoints.


# Loan

## Description

You can login as an Accountant(admin) and also as an user with Role Based Authorization.Users and admins are able to request a loan and make some changes.

The API has 1 controller:

* **UserController**: This repository contains a controller which is dealing with Loans and Users.

### UserController

The `UserController` contains the login, registration, GetUserByID,GetAllUsers,AddLoanByID,
GetLoanByID,DeleteUser,DeleteLoan,PutUserBlock and PutLoan methods.

* POST `/login`

    * Returns the JWT token along with the user information from the database after the user enters their email and password.
    *Password must contain:
          *At least one lower case letter,
          *At least one upper case letter,
          *At least special character,
          *At least one number
          *At least 8 characters length
    * Request Body Example(This is admin's email and password, which is registered in DB'):


        ```
{
  "email": "Admin@gmail.com",
  "password": ".Admin@123"
}
        ```

    * Response Example:

        ```json
{
  "id": 19,
  "email": "Admin@gmail.com",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjE5Iiwicm9sZSI6IkFkbWluIiwibmJmIjoxNjcxMzY3MTY0LCJleHAiOjE2NzE0NTM1NjQsImlhdCI6MTY3MTM2NzE2NH0.MXSGpDAJMp27IlFB7S6YjjcBaNTyiREXwD_5gqUnJW8"
}
        ```

* POST `/registration`

    * Adds the user's details to the database and returns  user information after the user enters their information.
   
    * Request Body Example:

        ```json
{
  "firstName": "Ana",
  "lastName": "Bnedeliani",
  "age": 5,
  "salary": 5,
  "email": "User2@gmail.com",
  "userName": "User",
  "password": ".User@123"
}
        ```

    * Response Example:

        ```json
  {
    "id": 20,
    "firstName": "Ana",
    "lastName": "Bnedeliani",
    "userName": "User",
    "password": "rGs3oC3zlYBB6hxhp9ZGeI3Qa7uzNOfT/x6DuMh8t7w=",
    "email": "User2@gmail.com",
    "age": 5,
    "salary": 5,
    "isBlocked": false,
    "loans": [],
    "role": "User",
    "salt": "s1d3XsuRIhHwG5+SJvVxCg=="
  }
        ```

       

* GET `/person/{id}`

    * Returns person by its ID
   
  

    * Response Example:

        ```json
  {
    "firstName": "Ana",
    "lastName": "Bnedeliani",
    "age": 5,
    "salary": 5,
    "email": "User2@gmail.com",
    "userName": "User",
    "password": "rGs3oC3zlYBB6hxhp9ZGeI3Qa7uzNOfT/x6DuMh8t7w="
  }
        ```



    * GET `/GetAllUsers`

    * Returns all users and admins

    *Only admin has the right
   
    

    * Response Example:

        ```json
 {
    "id": 19,
    "firstName": "Admin",
    "lastName": "Admin",
    "userName": "Admin",
    "password": "M3/5fLtmamVznHNzxyEb6d0kDU4RN6KPpVsL9Q1EJFI=",
    "email": "Admin@gmail.com",
    "age": 0,
    "salary": 0,
    "isBlocked": false,
    "loans": [],
    "role": "Admin",
    "salt": "LrOxuucllCrjBtxLodSiZA=="
  },
  {
    "id": 20,
    "firstName": "Ana",
    "lastName": "Bnedeliani",
    "userName": "User",
    "password": "rGs3oC3zlYBB6hxhp9ZGeI3Qa7uzNOfT/x6DuMh8t7w=",
    "email": "User2@gmail.com",
    "age": 5,
    "salary": 5,
    "isBlocked": false,
    "loans": [],
    "role": "User",
    "salt": "s1d3XsuRIhHwG5+SJvVxCg=="
  }
        ```




        * POST `/Loan/{id}`

    *Returns new loan
     * Adds the user's details to the database
     * Request Body Example: 
    UserId - 20
    id - 20

        ```json
{
  "loanType": "fast",
  "amount": 10,
  "currency": "gel",
  "loanPeriod": 1,
  "userId": 0,
  "id": 0
}
        ```

    * Response Example:

 

        ```json
  {
    "id": 13,
    "loanType": "fast",
    "amount": 10,
    "currency": "gel",
    "loanPeriod": 1,
    "status": "Processing",
    "user": null,
    "userId": 20
  }
        ```



* GET `/User/Loan/{id}`

    * Returns loan by users' ID 
     * Request Body Example: 
      
    ID - 20
   

    * Response Example:

        ```json
  {
    "loanType": "fast",
    "amount": 10,
    "currency": "gel",
    "loanPeriod": 1,
    "userId": 20,
    "id": 13
  }
        ```



        * DELETE `/DELETE/{id}`
    
    * Return rest of the users
    * Deletes user by its ID and saves changes in databases
    * Only Admin has the right to delete user
       * Request Body Example: 
    ID - 20
   

    * Response Example:

        ```json
  {
    "id": 19,
    "firstName": "Admin",
    "lastName": "Admin",
    "userName": "Admin",
    "password": "M3/5fLtmamVznHNzxyEb6d0kDU4RN6KPpVsL9Q1EJFI=",
    "email": "Admin@gmail.com",
    "age": 0,
    "salary": 0,
    "isBlocked": false,
    "loans": [],
    "role": "Admin",
    "salt": "LrOxuucllCrjBtxLodSiZA=="
  },
  {
    "id": 20,
    "firstName": "Ana",
    "lastName": "Bnedeliani",
    "userName": "User",
    "password": "rGs3oC3zlYBB6hxhp9ZGeI3Qa7uzNOfT/x6DuMh8t7w=",
    "email": "User2@gmail.com",
    "age": 5,
    "salary": 5,
    "isBlocked": false,
    "loans": [],
    "role": "User",
    "salt": "s1d3XsuRIhHwG5+SJvVxCg=="
  }
        ```




        * DELETE `/DELETE/{id}`
    
    * Returns deleted loan
    * Deletes loans by its ID and saves changes in databases
    * Admin has the right to delete loan, and user can delete loan if its status is in processing
       * Request Body Example: 
    ID(user) - 13
    LoanID - 10

    * Response Example:

        ```json
  {
    "loanType": "fast",
    "amount": 10,
    "currency": "gel",
    "loanPeriod": 1,
    "userId": 13,
    "id": 10
  }
        ```



        
* PUT `/Admin/Put/{id}`

    * Admin can change Blocked status (true or false) by user's ID
    * Saves changes in databases
    * Returns All the users
    * Request Body Example:

    ID - 20

        ```json
{
  "isBlocked": true
}
        ```

    * Response Example:

        ```json
  {
    "id": 20,
    "firstName": "Ana",
    "lastName": "Bnedeliani",
    "userName": "User",
    "password": "rGs3oC3zlYBB6hxhp9ZGeI3Qa7uzNOfT/x6DuMh8t7w=",
    "email": "User2@gmail.com",
    "age": 5,
    "salary": 5,
    "isBlocked": true,
    "loans": [],
    "role": "User",
    "salt": "s1d3XsuRIhHwG5+SJvVxCg=="
  }
        ```




        * PUT `/Admin/Loan/Put/{id}"`

    * Admin and user can change loan by UserID and LoanID
    * Saves changes in databases
    * Returns changed loan
    * Request Body Example:

    ID(user) - 13
    LoanID - 10

        ```json
{
  "loanType": "changed",
  "amount": 0,
  "currency": "changed",
  "loanPeriod": 0,
  "status": "Processing"
}
        ```

    * Response Example:

        ```json
  {
    "loanType": "changed",
    "amount": 0,
    "currency": "changed",
    "loanPeriod": 0,
    "userId": 13,
    "id": 10
  }
        ```






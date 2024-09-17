# KindnessAPI

KindnessAPI is an api that provides random acts of kindness to promote positivity and well-being. It allows users to retrieve random acts, filter them by various criteria, and suggest new acts of kindness.


**Features**

* Retrieve random acts of kindness.
* Suggest new acts of kindness.
* Filter acts by difficulty, location, time required, and impact type.
* Update and delete existing acts based on the roles
* JWT-based authentication (access token and refresh token).


**Getting Started**

Follow these steps to get KindnessAPI running locally.
1. Clone the Repository

First, clone the repository to your local machine:


```
git clone https://github.com/ShriraamNagarajan/kindness-api.git
cd kindness-api
```

2. Update the Connection String

Navigate to the appsettings.json file in the project and update the connection string to point to your local or cloud-based database:

```
"ConnectionStrings": {
  "DefaultConnection": "Your_Connection_String_Here"
}
```
3. Set Up JWT Secret Key

In the appsettings.json file, under ApiSettings, set your JWT secret key for authentication:

```
"ApiSettings": {
  "Secret": "Your_Secret_Key_Here"
}
```

4. Build the Project

Once the configurations are set up, build the project using the .NET CLI:

```
dotnet build
```

5. Run the Project

Finally, run the project:

```
dotnet run
```

By default, the API will be available at https://localhost:7242 or http://localhost:5198.


**API Documentation**

Once the project is running, you can refer to the  <mark>WIKI Page</mark> full API Documentation for details on available endpoints, authentication, and more.

Thank you for checking out this project!😊

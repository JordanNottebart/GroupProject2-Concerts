API (Application Programming Interface)

Introduction

	- This is the documentation for the API, which provides access to various resources and functionalities. The API allows users to interact with the system by sending HTTP requests and receiving corresponding responses. This document provides an overview of the API's controllers, DTOs (Data Transfer Objects), and the JwtHelper class.

Used technologies

	- ASP.NET Core
	- C#
	- Entity Framework Core
	- JWT (JSON Web Tokens)
	- DTOs (Data Transfer Objects)
	- Swagger/OpenAPI
	- Microsoft SQL Server
	- Postman

	These technologies work together to build a robust and secure API, allowing users to interact with
	the system efficiently and effectively.

Base URL

	- The base URL for all API endpoints is: https://localhost:7266/swagger/index.html. To use this you need to run the CENV_JMH.API project.

Authentication

	- To access protected endpoints, you need to include an authentication token in the request headers. The token should be provided as a bearer token in the 'Authorization' header.   

		Example:
					Authorization: Bearer <token>
	
	- To obtain an authentication token, you can use the '/auth/login' endpoint with valid credentials. The token will be returned in the response.
	
Error Handling

	- If an error occurs while making a request, the API will respond with an appropriate HTTP status code and an error message in the response body. It is important to handle these errors smoothly in your application.
	
Controllers

- HallsController

		- GET /api/Halls:				
			- Retrieve a list of all halls.
		- GET /api/Halls/{id}:			
			- Retrieve information about a specific hall.
		- GET /api/Halls/byid:			
			- Retrieve information about a hall using query parameters.
		- POST /api/Halls/create:		
			- Create a new hall.

		- HttpPatch /api/Halls/MaxNumberOfPlaces/{id}: 
			- Update the maximum number of places for a hall.
		- HttpPut /api/Halls/update/{id}:			   
			- Update information about a hall.
		- DELETE /api/Halls/{id}:		
			- Delete a hall.

- ShowingsController

		- GET /api/Showings:			
			- Retrieve a list of all showings.
		- GET /api/Showings/{id}:		
			- Retrieve information about a specific showing.
		- GET /api/Showings/byid:		
			- Retrieve information about a showing using query parameters.
		- POST /api/Showings/create:	
			- Create a new showing.
		- DELETE /api/Showings/{id}:	
			- Delete a showing.

- ShowingInstancesController

		- GET /api/ShowingInstances:	  
			- Retrieve a list of all showing instances.
		- GET /api/ShowingInstances/{id}: 
			- Retrieve information about a specific showing instance.
		- GET /api/ShowingInstances/byid: 
			- Retrieve information about a showing instance using query parameters.
		- POST /api/ShowingInstances/create: 
			- Create a new showing instance.
		- HttpPatch /api/ShowingInstances/StartTime/{id}: 
			- Update the the start time for a showing instance.
		- HttpPut /api/ShowingInstances/update/{id}:
			- Update information about a showing instance.
		- DELETE /api/ShowingInstances/{id}: 
			- Delete a showing instance.

- UsersController
	
		- GET /api/Users/{username}:	  
			- Retrieve information about a specific user.
		- POST /api/Users/create: 
			- Create a new user.
		- POST /api/Users/authenticate: 
			- Used to verify the credentials of a user and obtain an authentication token in response.

DTOs (Data Transfer Objects)

	- AuthenticationDto: Contains user credentials for authentication.
	- AuthorizationDto: Contains user authorization information.
	- HallDto: Represents a hall and its properties.
	- ShowingDto: Represents a showing and its properties.
	- ShowingInstanceDto: Represents a showing instance and its properties.
	- UpdateMaxNumberOfPlacesDto: Contains the updated maximum number of places for a hall.
	- UpdateStartTimeDto: Contains the updated start time for a showing instance.
	- UserDto: Represents a user and its properties.

JwtHelper

	- The 'JwtHelper' class provides methods for creating JSON Web Tokens (JWTs) for user authentication. It uses the provided configuration to generate JWTs with the necessary claims and signing credentials. The 'CreateToken' method is used to create a JWT for a given 'IdentityUser' object, including an expiration time.

Conclusion

	This API documentation provides an overview of the available controllers, DTOs, and the
	JwtHelper class. Refer to the specific endpoint documentation for detailed information on how to
	interact with the API and the expected request/response formats.
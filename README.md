The solution CENV_JMH ( Concert & Entertainment Naamloze Vennootschap _ Jordan, Michiel and Hassan)
exists of 5 projects.

1. UI = User Interface
2. DA = Data Access
3. DO = Data Onjects
4. Services
5. API = Application Programming Interface


Frontend

	- The frontend is responsible for displaying content, storing user input, and communicating with the backend to fetch or send data.


Used Technologies

	- HTML/CSS


Tutorial

	- Home Screen
		- On the home screen, you can find the navigation bar at the top.
			- "Home" button:
				- This button takes you back to the home screen with the featured shows.
			- "Show" button:
				- Here you can find a list of shows.
					- The shows have a name and a price.
						- Clicking on a show takes you to the show detail page.
							- Here you can read the description and buy a ticket for a show on a specific date and time.
								- If you click "Buy Ticket," you need to log in or register first, and then you'll have the option to buy a ticket for that show at the chosen time.
									- When you confirm your ticket, you'll see all the tickets you have purchased so far.
			- "My Tickets" button:
				- If you are logged in or registered, you can see all your purchased tickets here, including the date, show, and venue.
			- "Register" button:
				- Here you can register if you don't have an account yet.
					- Enter an email address and choose a strong password.
			- "Login" button:
				- Here you can log in if you already have an account.
		- The home screen also features highlighted shows, which are the most popular shows at the moment.
			- Clicking on a show takes you to its detail page.


Controllers
	
	- AdminHallController
		- Index
			- Displays a list of halls in the view.
		- Edit
			- Edits a specific hall based on the provided ID.
		- Create
			- Creates a new hall with the given parameters.
		- Delete
			- Deletes a hall based on the provided ID.

	- AdminShowingDetailController
		- Index
		 - Retrieves the show and its associated instances and passes them to the view.

	- AdminShowingInstanceController
		- CreateAsync (GET)
			- Retrieves a specific showing instance and gathers the necessary data for the view.
		- CreateAsync 'POST)
			- Creates a new showing instance or updates an existing one. Receives and processes the required data.

	- AdminShowingsController
		- Index
			- Retrieves all showings via the ShowingService and passes them to the view.
		- Create (GET)
			- Passes an empty Showing object to the view for creating a new show.
		- Create (POST)
			- Creates a new show with the provided data and adds it via the ShowingService.
				The user is redirected to the "Index" action.
		- Edit (GET)
			- Retrieves a specific show via the ShowingService and passes it to the view for editing.
		- Edit (POST)
			- Updates an existing show with the received data using the TryUpdateModelAsync method and saves the changes via the ShowingService.
				The user is redirected to the "Index" action.
		- Delete (GET)
			- Retrieves a specific show via the ShowingService and passes it to the view for deletion confirmation.
		- Delete (POST)
			- Deletes a show via the ShowingService. The user is redirected to the "Index" action.

	- HomeController
		- Index
			- Retrieves the homepage show data via the ShowingService and passes it to the view.
		- Privacy
			- Returns the privacy page view.
		- Error	
			- Returns the error page view, including an ErrorViewModel containing the unique RequestId of the current request.

	- ShowingController
		- Index
			- Retrieves all shows via the ShowingService and passes them to the view.

	- ShowingDetailController
		- Index
			- Retrieves the details of a specific show via the ShowingService and the associated showing instances via the ShowingInstanceService.
				- The retrieved data is combined into a ShowDetailModel and passed to the view.

	- TicketController
		- Index
			- Retrieves the tickets for the current user and passes them to the view.
		- BuyTickets (GET)
			- Retrieves the details of a specific showing instance via the ShowingInstanceService and passes them to the view.
		- BuyTickets (POST)
			- Handles the ticket purchase request. Checks if there are still seats available for the showing instance and creates a new ticket via the TicketService.
				The number of seats sold and relevant information are updated. Upon completion, the user is redirected to the Index action.


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
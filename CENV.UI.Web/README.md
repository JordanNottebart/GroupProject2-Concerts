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
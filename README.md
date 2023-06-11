Frontend

	- De frontend is verantwoordelijk voor het tonen van inhoud, het opslaan van gebruikersinvoer en communicatie met de backend om gegevens op te halen of te verzenden.


Gebruikte technologieën

	- HTML/CSS


Tutorial

	- Beginscherm
		- Op het beginscherm kunt u eerst en vooral de taakbalk bovenaan vinden.
			- Knop "Home":
				- Deze knop brengt je terug naar het beginscherm met de uitgelichte shows.
			- Knop "Show":
				- Hier vindt u alle shows in een lijst terug.
					- De shows hebben een naam en een prijs
						- Als u op een show klikt komt u terecht op het detail van de show
							- Hier kunt u de omschrijving lezen en een ticket kopen voor een show op een bepaalde datum en tijdstip
								- Als u op "Buy Ticket" klikt, moet u u eerst inloggen of registreren daarna krijg je de optie om een ticket te kopen voor deze show op het gekozen tijdstip
									- Als u uw ticket bevestigt, dan krijg je al uw tickets te zien die u al heeft aangekocht
			- Knop "My Tickets":
				- Als u bent ingelogd of geregistreerd bent, kan u hier al uw reeds aangekochte tickets zien met daarbij de datum, de show en de zaal waar deze zich bevindt
			- Knop "Register"
				- Hier kan u zich registreren mocht het zijn dat u nog geen account hebt
					- Vul hier een mail adres in en kies een sterk wachtwoord
			- Knop "Login"
				- Hier kan u zich inloggen als u al een account heeft
		- Op het beginscherm zijn er ook uitgelichte show te zien, deze zijn de meest populaire shows op dit moment.
			- Als u op een show klikt komt u terecht op het detail van deze show


Controllers
	
	- AdminHallController
		- Index
			- Toont een lijst van hallen op de weergave.
		- Edit
			- Bewerkt een specifieke hal op basis van het meegegeven id.
		- Create
			- Maakt een nieuwe hal aan met de gegeven parameters.
		- Delete
			- Verwijdert een hal op basis van het meegegeven id.

	- AdminShowingDetailController
		- Index
		 - Haalt de voorstelling en de bijbehorende exemplaren op en geeft deze door aan de weergave.

	- AdminShowingInstanceController
		- CreateAsync (GET)
			- Haalt een specifieke voorstellingsinstantie op en verzamelt de benodigde gegevens voor de weergave.
		- CreateAsync 'POST)
			- Maakt een nieuwe voorstellingsinstantie aan of werkt een bestaande bij. De benodigde gegevens worden ontvangen en verwerkt.

	- AdminShowingsController
		- Index
			- Haalt alle voorstellingen op via de ShowingService en geeft ze door aan de weergave.
		- Create (GET)
			- Geeft een leeg Showing-object door aan de weergave voor het maken van een nieuwe voorstelling.
		- Create (POST)
			- Maakt een nieuwe voorstelling aan met de opgegeven gegevens en voegt deze toe via de ShowingService. 
				De gebruiker wordt omgeleid naar de "Index" actie.
		- Edit (GET)
			- Haalt een specifieke voorstelling op via de ShowingService en geeft deze door aan de weergave voor bewerking.
		- Edit (POST)
			- Werkt een bestaande voorstelling bij met de ontvangen gegevens via de TryUpdateModelAsync-methode en slaat de wijzigingen op via de ShowingService. 
				De gebruiker wordt omgeleid naar de "Index" actie.
		- Delete (GET)
			- Haalt een specifieke voorstelling op via de ShowingService en geeft deze door aan de weergave voor bevestiging van verwijdering.
		- Delete (POST)
			- Verwijdert een voorstelling via de ShowingService. De gebruiker wordt omgeleid naar de "Index" actie.

	- HomeController
		- Index
			- Haalt de startpagina-voorstellingsgegevens op via de ShowingService en geeft deze door aan de weergave.
		- Privacy
			- Geeft de privacy-pagina-weergave terug.
		- Error	
			- Geeft de foutpagina-weergave terug, met een ErrorViewModel dat het unieke RequestId van de huidige aanvraag bevat.

	- ShowingController
		- Index
			- Haalt alle voorstellingen op via de ShowingService en geeft ze door aan de weergave.

	- ShowingDetailController
		- Index
			- Haalt de details van een specifieke voorstelling op via de ShowingService en de bijbehorende voorstellingsexemplaren via de ShowingInstanceService.
				- De opgehaalde gegevens worden samengevoegd in een ShowDetailModel en doorgegeven aan de weergave.

	- TicketController
		- Index
			- Haalt de tickets op voor de huidige gebruiker en geeft ze door aan de weergave.
		- BuyTickets (GET)
			- Haalt de details van een specifiek voorstellingsexemplaar op via de ShowingInstanceService en geeft ze door aan de weergave.
		- BuyTickets (POST)
			- Verwerkt het koopverzoek voor een ticket. Controleert of er nog plaatsen beschikbaar zijn voor het voorstellingsexemplaar en maakt vervolgens een nieuw ticket aan via de TicketService. 
				Het aantal verkochte plaatsen en de relevante informatie worden bijgewerkt. Na voltooiing wordt de gebruiker omgeleid naar de Index-actie.

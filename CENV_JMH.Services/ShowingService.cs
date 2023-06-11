using CENV_JMH.DA;
using CENV_JMH.DO;
using Microsoft.EntityFrameworkCore;
using System;

namespace CENV_JMH.Services
{
    #region Showing Services
    /// <summary>
    /// This class encapsulates the logic for CRUD (Create, Read, Update and Delete) operations on
    /// the "Showing" entity using a repository instance.
    /// </summary>
    #endregion

    public class ShowingService
    {
        public Showing[] GetHomeShowings(int amountOfShowings)
        {
            using (var repo = new Repository())
            {
                // Create an array to hold the return values
                var returnArray = new Showing[amountOfShowings];

                // Retrieve all showi
                var showings = repo.Showings.ToList();

                // Check if the number of retrieved showings is less than the desired amount
                if (showings.Count < amountOfShowings)
                {
                    // Add empty showings to the list until it reaches the desired amount
                    while (showings.Count < amountOfShowings)
                        while (showings.Count < amountOfShowings)
                        {
                            showings.Add(new Showing());
                        }
                }
                // Copy the desired number of showings to the return array
                showings.CopyTo(0, returnArray, 0, amountOfShowings);

                // Return the pupulated return array
                return returnArray;
            }
        }

        /// <summary>
        /// Retrieves a list of all showings.
        /// </summary>
        /// <returns>A list of showings.</returns>
        public List<Showing> GetShowings()
        {
            using (var repo = new Repository())
            {
                return repo.Showings.ToList();
            }
        }

        /// <summary>
        /// Retrieves a showing by its ID.
        /// </summary>
        /// <param name="id">The ID of the showing to retrieve.</param>
        /// <returns>The showing with the specified ID, or a new empty showing if not found.</returns>
        public Showing GetShowingById(int id)
        {
            using (var repo = new Repository())
            {
                return repo.Showings.FirstOrDefault(h => h.ShowingID == id) ?? new Showing();
            }
        }

        /// <summary>
        /// Updates a showing with the specified ID and new show data.
        /// </summary>
        /// <param name="id">The ID of the showing to update.</param>
        /// <param name="show">The updated showing data.</param>
        /// <returns>The updated showing if found and updated, or null if not found.</returns>
        public Showing? UpdateShowing(int id, Showing show)
        {
            using (var repo = new Repository())
            {
                var showToUpdate = repo.Showings.Where(h => h.ShowingID == id).FirstOrDefault();

                if (showToUpdate != null)
                {
                    showToUpdate.Name = show.Name;
                    showToUpdate.TicketPrice = show.TicketPrice;
                    showToUpdate.Picture_URL = show.Picture_URL;
                    repo.Update(showToUpdate);
                    repo.SaveChanges();
                    return showToUpdate;
                }
                return null;
            }
        }

        /// <summary>
        /// Deletes a showing with the specified ID.
        /// </summary
        public bool DeleteShowing(int id)
        {
            using (var repo = new Repository())
            {

                var todelete = repo.Showings.ToList().FirstOrDefault(c => c.ShowingID == id, null);
                if (todelete != null)
                {

                    repo.Showings.Remove(todelete);
                    repo.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Creates a new showing and saves it to the repository.
        /// </summary>
        /// <param name="showing">The showing object to be created.</param>
        /// <returns>The created showing object</returns>
        public Showing CreateShowing(Showing showing)
        {
            using (var repo = new Repository())
            {
                repo.Showings.Add(showing);
                repo.SaveChanges();
                return showing;
            }
        }
    }
}
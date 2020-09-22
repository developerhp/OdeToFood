using System.Collections.Generic;
using OdeToFood.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext dbCon;

        public SqlRestaurantData(OdeToFoodDbContext dbCon)
        {
            this.dbCon = dbCon;
        }

        public Restaurant Add(Restaurant addRestaurant)
        {
            dbCon.Add(addRestaurant);
            return addRestaurant;
        }

        public int Commit()
        {
            return dbCon.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetRestaurantsbyId(id);
            if (restaurant != null)
            {
                dbCon.Restaurants.Remove(restaurant);

            }
            return restaurant;
        }

        public int GetRestaurantCount()
        {
            return dbCon.Restaurants.Count();
        }

        public Restaurant GetRestaurantsbyId(int restaurantId)
        {
            return dbCon.Restaurants.Find(restaurantId);
        }

        public IEnumerable<Restaurant> GetRestaurantsbyName(string name)
        {
            return from res in dbCon.Restaurants
                   where string.IsNullOrEmpty(name) || res.Name.StartsWith(name)
                   orderby res.Name
                   select res;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = dbCon.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}

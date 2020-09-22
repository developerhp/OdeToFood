using System;
using System.Collections.Generic;
using OdeToFood.Core;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
                {
                    new Restaurant { Id = 1, Name = "Sindh Shahbaz", Cuisine = CuisineType.Asian, Location = "Ajman" },
                    new Restaurant { Id = 2, Name = "Chowking", Cuisine = CuisineType.Chinese, Location = "Sharjah" },
                    new Restaurant { Id = 3, Name = "Pizza Hut", Cuisine = CuisineType.Italian, Location = "Ajman" },
                    new Restaurant { Id = 4, Name = "Tim Hortons", Cuisine = CuisineType.Mexican, Location = "Sharjah" },
                    new Restaurant { Id = 5, Name = "Vanelies", Cuisine = CuisineType.Italian, Location = "Ajman" },

                };
        }

        public IEnumerable<Restaurant> GetRestaurantsbyName(string name = null)
        {
            return from res in restaurants
                   where string.IsNullOrEmpty(name) || res.Name.StartsWith(name)
                   orderby res.Name
                   select res;
        }

        public Restaurant Add(Restaurant addRestaurant)
        {
            restaurants.Add(addRestaurant);
            addRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return addRestaurant;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            Restaurant restaurant = restaurants.FirstOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;

            }
            return restaurant;
        }

        public Restaurant GetRestaurantsbyId(int restaurantId)
        {
            return restaurants.FirstOrDefault(r => r.Id == restaurantId);
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);

            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public int GetRestaurantCount()
        {
            return restaurants.Count();
        }
    }


}

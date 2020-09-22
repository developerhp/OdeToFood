using System.Collections.Generic;
using OdeToFood.Core;

namespace OdeToFood.Data
{

    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsbyName(string name);
        Restaurant GetRestaurantsbyId(int restaurantId);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Add(Restaurant addRestaurant);
        Restaurant Delete(int id);
        int GetRestaurantCount();
        int Commit();
    }
}

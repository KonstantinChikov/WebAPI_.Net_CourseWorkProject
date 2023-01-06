using CWProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWProject.Data.SeedData
{
    public class DbInitializer
    {

        // Seed for LocationType
        private static Dictionary<string, LocationType> locations;
        public static Dictionary<string, LocationType> Locations
        {
            get
            {
                if (locations == null)
                {
                    var locationList = new LocationType[]
                    {
                        new LocationType { Name = "Sea"},
                        new LocationType { Name = "Mountain"},
                        new LocationType { Name = "City"},
                        new LocationType { Name = "Village"}
                    };

                    locations = new Dictionary<string, LocationType>();

                    foreach (LocationType location in locationList)
                    {
                        locations.Add(location.Name, location);
                    }
                }
                return locations;
            }
        }

        // Seed for Amenities
        private static Dictionary<string, Amenities> amenities;
        public static Dictionary<string, Amenities> Amenities
        {
            get
            {
                if (amenities == null)
                {
                    var facilityList = new Amenities[]
                    {
                        new Amenities { Name = "Gym"},
                        new Amenities { Name = "Spa"},
                        new Amenities { Name = "Swimming Pool"},
                        new Amenities { Name = "Restaurant"}
                    };

                    amenities = new Dictionary<string, Amenities>();

                    foreach (Amenities facility in facilityList)
                    {
                        amenities.Add(facility.Name, facility);
                    }
                }
                return amenities;
            }
        }
         /*
          
        // Seed For Roles
        private static Dictionary<string, Role> roles;
        public static Dictionary<string, Role> Roles
        {
            get
            {
                if (roles == null)
                {
                    var roleList = new Role[]
                    {
                        new Role { Name = "User"},
                        new Role { Name = "Admin"}
                    };

                    roles = new Dictionary<string, Role>();

                    foreach (Role role in roleList)
                    {
                        roles.Add(role.Name, role);
                    }
                }
                return roles;
            }
        }

        // Seed for User - Creates Admin
        private static Dictionary<string, User> users;
        public static Dictionary<string, User> Users
        {
            get
            {
                if (users == null)
                {
                    var userList = new User[]
                    {
                        new User { Username = "admin", Role = Roles["Admin"],
                                    PasswordSalt = new HMACSHA512().Key,
                                    PasswordHash = new HMACSHA512().ComputeHash(System.Text.Encoding.UTF8.GetBytes("admin"))
                    } };
            

                    users = new Dictionary<string, User>();

                    foreach (User user in userList)
                    {
                        users.Add(user.Username, user);
                    }
                }
                return users;
            }
        }

        */

    }
}

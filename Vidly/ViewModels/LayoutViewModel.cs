using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class LayoutViewModel
    {
        public List<Movies> Movies { get; set; }
        public List<Customer> Customers { get; set; }
        public int CustomerSelected { get; set; }
        public int MovieSelected { get; set; }

        public LayoutViewModel()
        {
            Movies = new List<Movies> { new Movies { name = "Shrek!", id = 1 }, new Movies { name = "La guerra de las patatas", id = 2 } };
            Customers = new List<Customer> { new Customer { Name = "Sr. Patata", Id = 1 }, new Customer { Name = "Juanito", Id = 2 } };
        }

        public LayoutViewModel demoDataInstance()
        {
            List<Movies> movies = new List<Movies> { new Movies { name = "Shrek!", id = 1 }, new Movies { name = "La guerra de las patatas", id=2} };
            List<Customer> customers = new List<Customer> { new Customer { Name = "Sr. Patata", Id = 1 }, new Customer { Name = "Juanito", Id = 2 } };

            return new LayoutViewModel { Movies = movies, Customers = customers};
        }

        public string GetApplicationName()
        {
            return Assembly.GetExecutingAssembly().GetName().Name;
        }

        public Customer GetCustomerById(int id)
        {
            foreach(Customer customer in this.Customers)
            {
                if (customer.Id == id)
                {
                    return customer;
                }
            }
            return null;
        }

        public Movies GetMoviesById(int id)
        {
            foreach(Movies movie in this.Movies)
            {
                if (movie.id == id)
                {
                    return movie;
                }
            }
            return null;
        }
    }

}
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LazyLoading();
        }

        public static void LazyLoading()
        {
            using (SampleEntities1 dbContext = new SampleEntities1())
            {
                //dbContext.Log = Console.Out;

                foreach (Department dept in dbContext.Departments)
                {
                    Console.WriteLine(dept.Name);
                    foreach (Employee emp in dept.Employees)
                    {
                        Console.WriteLine("\t" + emp.FirstName + " " + emp.LastName);
                    }
                }
            }
        }

        //public void EagerLoading()
        //{
        //    using (SampleEntities1 dbContext = new SampleEntities1())
        //    {
        //        //dbContext.Log = Console.Out;

        //        // Load related Employee entities along with the Department entity
        //        DataLoadOptions loadOptions = new DataLoadOptions();
        //        loadOptions.LoadWith<Department>(d => d.Employees);
        //        dbContext.LoadOptions = loadOptions;

        //        foreach (Department dept in dbContext.Departments)
        //        {
        //            Console.WriteLine(dept.Name);
        //            foreach (Employee emp in dept.Employees)
        //            {
        //                Console.WriteLine("\t" + emp.FirstName + " " + emp.LastName);
        //            }
        //        }
        //    }
        //}
    }
}

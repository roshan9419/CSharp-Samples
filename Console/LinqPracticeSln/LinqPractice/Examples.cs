using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    internal class Examples
    {
        public void Projection()
        {
            //var q1 = from x in list
            //         select new
            //         {
            //             x.Id,
            //             x.Name
            //         };

            //var q2 = list.Select(x => new
            //{
            //    x.Id,
            //    x.Name
            //});
        }

        public void Joining()
        {
            //var query = from car in cars
            //            join manufacturer in manufactures
            //                on car.Manufacturer equals manufacturer.Name
            //            orderby car.Combined descending, car.Name ascending
            //            select new
            //            {
            //                manufacturer.Headquaters,
            //                car.Name,
            //                car.Combined
            //            };

            //var query2 = cars.Join(manufacturers,
            //                        c => c.Manufacturer,
            //                        m => m.Name,
            //                        (c, m) =>
            //                        {
            //                            Car = c,
            //                            Manufacturer = m
            //                        })
            //            .OrderByDescending(c => c.Car.Combined)
            //            .ThenByDescending(c => c.Car.Name)
            //            .Select(c => new
            //            {
            //                c.Manufacturer.Headquaters,
            //                c.Car.Name,
            //                c.Car.Combined
            //            });
        }

        public void Grouping()
        {

        }
    }
}

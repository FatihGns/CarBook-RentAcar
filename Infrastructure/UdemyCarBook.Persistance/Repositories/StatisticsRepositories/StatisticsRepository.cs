﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistance.Context;

namespace UdemyCarBook.Persistance.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public string GetBlogTitleByMaxBlogComment()
        {
            //Select Top(1) BlogId,Count(*) as 'Sayi' From Comments Group By BlogID Order By Sayi Desc 
            var values = _context.Comments.GroupBy(x => x.BlogId).
                              Select(y => new
                              {
                                  BlogID = y.Key,
                                  Count = y.Count()
                              }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
            string blogName = _context.Blogs.Where(x => x.BlogID == values.BlogID).Select(y => y.Title).FirstOrDefault();
            return blogName;
        }

        public string GetBrandNameByMaxCar()
        {
            //Select Top(1) BrandId,Count(*) as 'ToplamArac' From Cars Group By Brands.Name  order By ToplamArac Desc

            var values = _context.Cars.GroupBy(x => x.BrandID).
                             Select(y => new
                             {
                                 BrandID = y.Key,
                                 Count = y.Count()
                             }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
            string brandName = _context.Brands.Where(x => x.BrandID == values.BrandID).Select(y => y.Name).FirstOrDefault();
            return brandName;
        }

        public int GetAuthorCount()
        {
            var value = _context.Authors.Count();
            return value;
        }
      


        public decimal GetAvgRentPriceForDaily()
        {
            //select AVG(Amount) from CarPricings where PricingID = (select PricingID from Pricings where Name='Günlük');
            int id = _context.Pricings.Where(y => y.Name == "Günlük").Select(z=>z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingID==id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Aylık").Select(z => z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Haftalık").Select(z => z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
            return value;
        }

        public int GetBlogCount()
        {
            var value = _context.Blogs.Count();
            return value;
        }

        public int GetBrandCount()
        {
          var value=_context.Brands.Count();
          return value;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            // Select* from CarPricings where Amount = (Select MAX(Amount) from CarPricings WHERE PricingID = 3);
            int pricingID = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.PricingID == pricingID).Max(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            int pricingID = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.PricingID == pricingID).Min(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
        }

        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public int GetCarCountByFuelElectric()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
            return value;
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
           var value=_context.Cars.Where(x=>x.Fuel=="Benzin" || x.Fuel == "Dizel").Count(); 
           return value;

        }
        public int GetCarCountByKmSmallerThen1000()
        {
            var value=_context.Cars.Where(k=>k.Km<=1000).Count();
            return value;
        }

        public int GetCarCountByTransmissonIsAuto()
        {
            //select count(*) from Cars where Transmisson = 'otomatik';
            var value = _context.Cars.Where(t => t.Transmisson == "otomatik").Count();
            return value;
        }

        public int GetLocationCount()
        {
            var value=_context.Locations.Count();
            return value;
        }
    }
}

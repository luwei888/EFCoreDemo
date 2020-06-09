using Demo.Data;
using Demo.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new DemoContext();

            #region 插入      
            //var serieA = context.Leagues.Single(x => x.Name == "Serie A");

            //var serieB = new League { Country = "Italy", Name = "Serie B" };

            //var serieC = new League { Country = "Italy", Name = "Serie C" };

            //var milan = new Club
            //{
            //    Name = "AC Milan",
            //    City = "Milan",
            //    DateOfEstablishment = new DateTime(1899, 12, 16),
            //    League = serieA
            //};

            //context.AddRange(serieB, serieC, milan);

            //context.Leagues.Add(serieA);
            //context.Leagues.AddRange(serieA, serieB);
            //context.Leagues.AddRange(new List<League> { serieA, serieB });
            #endregion


            #region 查询  

            var italy = "Italy";

            var leagues = context.Leagues.Where(x => x.Country == italy).ToList();

            //尽量不这么写
            foreach (var item in context.Leagues)
            {
                Console.WriteLine(item.Name);
            }

            var leagues2 = (from lg in context.Leagues where lg.Country == "Italy" select lg).ToList();

            // Country LIKE "%e%"

            var leagues3 = context.Leagues.Where(x => EF.Functions.Like(x.Country, "%e%")).FirstOrDefault();

            var first = context.Leagues.SingleOrDefault(x => x.Id == 2);

            //主键查询
            var first2 = context.Leagues.Find(2);

            #endregion

            //var count = context.SaveChanges();

            //Console.WriteLine(count);
        }
    }
}

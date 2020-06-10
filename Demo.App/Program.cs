using Demo.Data;
using Microsoft.EntityFrameworkCore;
using System;
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

            //var count = context.SaveChanges();

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

            #region 删除

            //只能删除被追踪的数据
            //var milan = context.Clubs.Single(x=>x.Name == "AC Milan");

            //调用删除方法
            //context.Clubs.Remove(milan);
            //context.Remove(milan);

            //context.Clubs.RemoveRange(milan, milan);
            //context.RemoveRange(milan,milan);

            //var count = context.SaveChanges();

            #endregion

            #region 改

            //必须被追踪才能更改
            var league = context.Leagues.First();
            league.Name += "~~";


            var league2 = context.Leagues.Skip(1).Take(3).ToList();
            foreach (var item in league2)
            {
                item.Name += "~~";
            }

            //不追踪，相当于前台传的数据
            var league3 = context.Leagues.AsNoTracking().First();
            league3.Name += "~";
            context.Leagues.Update(league3);

            var count = context.SaveChanges();

            #endregion

            Console.WriteLine(count);
        }
    }
}

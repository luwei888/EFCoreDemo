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


            #region 增删改查  

            //#region 插入      
            ////var serieA = context.Leagues.Single(x => x.Name == "Serie A");

            ////var serieB = new League { Country = "Italy", Name = "Serie B" };

            ////var serieC = new League { Country = "Italy", Name = "Serie C" };

            ////var milan = new Club
            ////{
            ////    Name = "AC Milan",
            ////    City = "Milan",
            ////    DateOfEstablishment = new DateTime(1899, 12, 16),
            ////    League = serieA
            ////};

            ////context.AddRange(serieB, serieC, milan);

            ////context.Leagues.Add(serieA);
            ////context.Leagues.AddRange(serieA, serieB);
            ////context.Leagues.AddRange(new List<League> { serieA, serieB });

            ////var count = context.SaveChanges();

            //#endregion

            //#region 查询  

            //var italy = "Italy";

            //var leagues = context.Leagues.Where(x => x.Country == italy).ToList();

            ////尽量不这么写
            //foreach (var item in context.Leagues)
            //{
            //    Console.WriteLine(item.Name);
            //}

            //var leagues2 = (from lg in context.Leagues where lg.Country == "Italy" select lg).ToList();

            //// Country LIKE "%e%"

            //var leagues3 = context.Leagues.Where(x => EF.Functions.Like(x.Country, "%e%")).FirstOrDefault();

            //var first = context.Leagues.SingleOrDefault(x => x.Id == 2);

            ////主键查询
            //var first2 = context.Leagues.Find(2);

            //#endregion

            //#region 删除

            ////只能删除被追踪的数据
            ////var milan = context.Clubs.Single(x=>x.Name == "AC Milan");

            ////调用删除方法
            ////context.Clubs.Remove(milan);
            ////context.Remove(milan);

            ////context.Clubs.RemoveRange(milan, milan);
            ////context.RemoveRange(milan,milan);

            ////var count = context.SaveChanges();

            //#endregion

            //#region 改
            ////必须被追踪才能更改
            //var league = context.Leagues.First();
            //league.Name += "~~";

            //var league2 = context.Leagues.Skip(1).Take(3).ToList();
            //foreach (var item in league2)
            //{
            //    item.Name += "~~";
            //}

            ////不追踪，相当于前台传的数据
            //var league3 = context.Leagues.AsNoTracking().First();
            //league3.Name += "~";
            // 离线数据使用Update
            //context.Leagues.Update(league3);

            ////var count = context.SaveChanges();
            //#endregion

            ////Console.WriteLine(count);

            #endregion 结束增删改查


            // League - club - player
            // 一对多，一对多
            #region 添加关系数据

            #region 插入新俱乐部

            //var serieA = context.Leagues.FirstOrDefault(x => x.Name == "Serie A");

            //var juventus = new Club
            //{
            //    //将俱乐部关联到联赛中
            //    League = serieA,
            //    Name = "Juventus",
            //    City = "Torino",
            //    DateOfEstablishment = new DateTime(1897, 11, 11),
            //    Players = new List<Player>
            //    {
            //        new Player
            //        {
            //            Name = "C.Ronaldo",
            //            DateOfBirth = new DateTime(1985,2,5)
            //        }
            //    }
            //};

            //context.Clubs.Add(juventus);

            //int count = context.SaveChanges();

            #endregion

            #region 现有俱乐部中添加球员

            var juventus = context.Clubs.FirstOrDefault(x => x.Name == "Juventus");

            //juventus.Players.Add(new Player
            //{
            //    Name = "Gonzalo Higuain",
            //    DateOfBirth = new DateTime(1987, 12, 10)
            //});

            //var count = context.SaveChanges();

            //模拟离线数据
            //juventus.Players.Add(new Player
            //{
            //    Name = "Matthijs de Ligt",
            //    DateOfBirth = new DateTime(1999, 12, 10)
            //});
            //using var newContext = new DemoContext();
            //newContext.Clubs.Attach(juventus);
            //var count = newContext.SaveChanges();

            #endregion

            #region 球员更新简历

            var resume = new Resume
            {
                PlayerId = 1,
                Description = "..."
            };

            context.Resumes.Add(resume);
            var count = context.SaveChanges();

            #endregion


            // 有主键的数据
            // Add 添加数据 || Update 修改数据 || Attach 不变化

            // 没有主键的数据
            // Add || Update || Attach || 添加数据

            #endregion

            //Console.WriteLine(count);
        }
    }
}

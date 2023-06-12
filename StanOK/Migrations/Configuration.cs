namespace StanOK.Migrations
{
    using StanOK.Authorization.Model;
    using StanOK.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;
    using System.Windows;

    internal sealed class Configuration : DbMigrationsConfiguration<StanOK.Utils.UserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StanOK.Utils.UserContext context)
        {
            context.Users.Add(new LoginModel { Id = 1, Login = "user1", Role = "user", Password = "123" });
            context.Users.Add(new LoginModel { Id = 2, Login = "user2", Role = "user", Password = "/Dtmj4B5Mg" });
            context.Users.Add(new LoginModel { Id = 3, Login = "user3", Role = "user", Password = "l@lM}2rrG$" });
            context.Users.Add(new LoginModel { Id = 4, Login = "user4", Role = "user", Password = "ioxzv9?kg7" });
            context.Users.Add(new LoginModel { Id = 5, Login = "admin1", Role = "admin", Password = "321" });
            context.Users.Add(new LoginModel { Id = 6, Login = "admin2", Role = "admin", Password = "SGk7pEJ4ij" });
            context.RepairTypes.Add(
                new RepairTypeModel
                {
                    Id = 1,
                    Repair_name = "Мелкий ремонт",
                    Cost = 5600,
                    Comment = "Ремонт малой продолжительности, c которым может справиться один мастер в течение рабочей смены",
                    Duration = "1 день"
                }
            );
            context.RepairTypes.Add(
                new RepairTypeModel
                {
                    Id = 2,
                    Repair_name = "Замена узлов",
                    Cost = 13000,
                    Comment = "Полная разборка прибора с заменой изношеных узлов",
                    Duration = "13 дней"
                }
            );
            context.RepairTypes.Add(
                new RepairTypeModel
                {
                    Id = 3,
                    Repair_name = "Шлифовка направляющих",
                    Cost = 60000,
                    Comment = "Шлифовка проводится на специальном шлифовальном станке",
                    Duration = "17 дней"
                }
            );
            context.RepairTypes.Add(
                new RepairTypeModel
                {
                    Id = 4,
                    Repair_name = "Восстановление геометрической базы",
                    Cost = 15000,
                    Comment = "Восстановления геометрической и технологической точностей, в соответствии паспортным данным станка.",
                    Duration = "12 дней"
                }
            );
            context.RepairTypes.Add(
                new RepairTypeModel
                {
                    Id = 5,
                    Repair_name = "Сбор станков",
                    Cost = 60400,
                    Comment = "Общая сборка станка из комплектующих",
                    Duration = "20 дней"
                }
            );
            context.RepairTypes.Add(
                new RepairTypeModel
                {
                    Id = 6,
                    Repair_name = "Регулировка станков",
                    Cost = 5600,
                    Comment = "Регулировка станка на точность и обкатка под нагрузкой",
                    Duration = "3 дня"

                }
            );
            context.Machines.Add(new MachineModel { Id = 1, Year = 2007, Brand = "JET", MachineType = "Токарный", Country = "Швейцария", Repairs = 1 });
            context.Machines.Add(new MachineModel { Id = 2, Year = 2020, Brand = "СНВШ-2", MachineType = "Сверлильный", Country = "Россия", Repairs = 5 });
            context.Machines.Add(new MachineModel { Id = 3, Year = 2017, Brand = "CNC", MachineType = "Фрезировочный", Country = "Китай", Repairs = 2 });
            context.Machines.Add(new MachineModel { Id = 4, Year = 2005, Brand = "TAKISAWA", MachineType = "Токарный", Country = "Япония", Repairs = 8 });
            context.Repairs.Add(new RepairModel { Id = 1, MachineType = 1, Comment = "Требуется заменить охлаждающую жидкость", DateBegin = DateTime.UtcNow, RepairType = 1 });
            context.Repairs.Add(new RepairModel { Id = 2, MachineType = 2, Comment = "Отрегулировать сверло", DateBegin = DateTime.UtcNow, RepairType = 6 });
            context.Repairs.Add(new RepairModel { Id = 3, MachineType = 3, Comment = "Заполнить маслом", DateBegin = DateTime.UtcNow, RepairType = 1 });
            context.Repairs.Add(new RepairModel { Id = 4, MachineType = 4, Comment = "Починить ножку", DateBegin = DateTime.UtcNow, RepairType = 4 });

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}

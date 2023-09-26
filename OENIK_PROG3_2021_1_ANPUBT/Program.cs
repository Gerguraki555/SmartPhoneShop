// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SmartPhoneShop.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ConsoleTools;
    using SmartPhoneShop.Data.Models;
    using SmartPhoneShop.Logic;

    /// <summary>
    /// SmartPhoneShop menu.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// BLogic.
        /// </summary>
        private static Factory fact = new Factory();

        private static void Main()
        {
            Console.Title = "SmartPhoneShop";
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            var menu = new ConsoleMenu()
                   .Add(">> ELEMEK LISTÁZÁSA", () => ListMethods())
                   .Add(">> ELEMEK HOZZÁADÁSA", () => AddMethods())
                   .Add(">> ELEMEK ELTÁVOLÍTÁSA", () => RemoveMethods())
                   .Add(">> ELEMEK MÓDOSÍTÁSA", () => ModifyMethods())
                   .Add(">> NON CRUD METÓDUSOK", () => NonCrudMethods())
                   .Add(">> TASK METÓDUSOK", () => Page2())
                   .Add(">> KILÉPÉS", ConsoleMenu.Close);
            menu.Show();
            Console.Beep();
        }

        /// <summary>
        /// List all Brand objects from Database.
        /// </summary>
        private static void ListallBrands()
        {
            Console.Clear();
            Console.WriteLine("BRANDEK:");
            Console.WriteLine();
            fact.GetLog().GetAllBrands().ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.Beep();
            Console.ReadKey();
        }

        /// <summary>
        /// Navigate to the List methods.
        /// </summary>
        private static void ListMethods()
        {
            var menu = new ConsoleMenu()
              .Add(">> BRANDEK LISTÁZÁSA:", () => ListallBrands())
              .Add(">> TÍPUSOK LISTÁZÁSA:", () => ListallTypes())
              .Add(">> PARAMÉTEREK LISTÁZÁSA:", () => ListallParameters())
              .Add(">> VISSZA", ConsoleMenu.Close);
            menu.Show();
        }

        /// <summary>
        /// Navigate to the Add methods.
        /// </summary>
        private static void AddMethods()
        {
            var menu = new ConsoleMenu()
              .Add(">> BRAND HOZZÁADÁSA", () => Addbrands())
              .Add(">> TÍPUS HOZZÁADÁSA", () => AddTypes())
              .Add(">> PARAMÉTER HOZZÁADÁSA", () => AddParameters())
              .Add(">> VISSZA", ConsoleMenu.Close);
            menu.Show();
        }

        /// <summary>
        /// Navigate to the Remove methods.
        /// </summary>
        private static void RemoveMethods()
        {
            var menu = new ConsoleMenu()
              .Add(">> BRANDEK ELTÁVOLÍTÁSA", () => Removebrands())
              .Add(">> TÍPUS ELTÁVOLÍTÁSA", () => RemoveTypes())
              .Add(">> PARAMÉTER ELTÁVOLÍTÁSA", () => RemoveParameters())
              .Add(">> VISSZA", ConsoleMenu.Close);
            menu.Show();
        }

        /// <summary>
        /// Navigate to the Modify methods.
        /// </summary>
        private static void ModifyMethods()
        {
            var menu = new ConsoleMenu()
              .Add(">> BRAND MÓDOSÍTÁSA", () => Updatebrands())
              .Add(">> TÍPUS MÓDOSÍTÁSA", () => UpdateTypes())
              .Add(">> PARAMÉTER MÓDOSÍTÁSA", () => UpdateParameters())
              .Add(">> VISSZA", ConsoleMenu.Close);
            menu.Show();
        }

        /// <summary>
        /// Navigate to the Non Crud methods.
        /// </summary>
        private static void NonCrudMethods()
        {
            var menu = new ConsoleMenu()
            .Add(">> BRANDEK ADATAINAK SZŰRÉSE ADOTT SZÖVEGRÉSZLET ALAPJÁN", () => DoSomething())
            .Add(">> TÍPUSOK KERESÉSE MÁRKANÉV ALAPJÁN", () => FindTypeByBrandName())
            .Add(">> ADOTT TÍPUS ALAPMODELLJEINEK LISTÁZÁSA", () => NoHalfPriceByBrandname())
            .Add(">> MODELLEK KERESÉSE TÍPUS ALAPJÁN", () => FindParameterByTypeName())
            .Add(">> BRANDEK ÁTLAGOS ÉRTÉKELÉSEINEK MEGTEKINTÉSE", () => BrandRateByName())
            .Add(">> ADOTT MODELLHEZ TARTOZÓ FELÁRAK ÖSSZEGÉNEK MEGTEKINTÉSE", () => AllHalfPrice())
            .Add(">> ADOTT MODELLHEZ TARTOZÓ ÖSSZESÍTETT RAM ÉS ROM MEGTEKINTÉSE", () => AllRamAndRomByTypeName())
            .Add(">> VISSZA", ConsoleMenu.Close);
            menu.Show();
        }

        /// <summary>
        /// Navigate to the Task methods.
        /// </summary>
        private static void Page2()
        {
            var taskmenu = new ConsoleMenu()
              .Add(">> BRANDEK ADATAINAK SZŰRÉSE ADOTT SZÖVEGRÉSZLET ALAPJÁN", () => DoSomethingAsync())
              .Add(">> ADOTT TÍPUS ALAPMODELLJEINEK LISTÁZÁSA", () => NoHalfPriceByBrandnameAsync())
              .Add(">> MODELLEK KERESÉSE TÍPUS ALAPJÁN", () => FindParameterByTypeNameAsync())
              .Add(">> ADOTT MODELLHEZ TARTOZÓ ÖSSZESÍTETT RAM ÉS ROM MEGTEKINTÉSE", () => SumRamAndRomByTypeNameAsync())
              .Add(">> VISSZA", ConsoleMenu.Close);
            taskmenu.Show();
        }

        /// <summary>
        /// List all Parameters objects from Database.
        /// </summary>
        private static void ListallParameters()
        {
            Console.Clear();
            Console.WriteLine("PARAMÉTEREK:");
            Console.WriteLine();
            fact.GetLog().GetAllParameters().ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.Beep();
            Console.ReadKey();
        }

        /// <summary>
        /// List all Types objects from Database.
        /// </summary>
        private static void ListallTypes()
        {
            Console.Clear();
            Console.WriteLine("TÍPUSOK:");
            Console.WriteLine();
            fact.GetLog().GetAllTypes().ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.Beep();
            Console.ReadKey();
        }

        /// <summary>
        /// Add a Brands object to Database.
        /// </summary>
        private static void Addbrands()
        {
                Console.Clear();
                Console.WriteLine("Name");
                Console.WriteLine();
                string name = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Country");
                Console.WriteLine();
                string country = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Popularity");
                Console.WriteLine();
                string popu = Console.ReadLine();
                bool check = ErrorChecker(popu);
                if (check)
                {
                    int popularity = Convert.ToInt32(popu);
                    Console.WriteLine();
                    Console.WriteLine("Total Income");
                    Console.WriteLine();
                    string total = Console.ReadLine();
                    bool totalcheck = ErrorChecker(total);
                    if (totalcheck)
                    {
                        int totalincome = Convert.ToInt32(total);
                        fact.GetLog().AddBrands(name, country, popularity, totalincome);
                        Console.WriteLine("Sikeres hozzáadás!");
                        Console.ReadKey();
                    }
                    else
                    {
                    ErrorMessage();
                    }
                }
                else
                {
                ErrorMessage();
                }
        }

        /// <summary>
        /// Add a Types object to Database.
        /// </summary>
        private static void AddTypes()
        {
                Console.Clear();
                Console.WriteLine("Name");
                Console.WriteLine();
                string name = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("BrandId");
                Console.WriteLine();
                string brandinput = Console.ReadLine();
                bool brandcheck = ErrorChecker(brandinput);
                if (brandcheck)
                {
                    int brandid = Convert.ToInt32(brandinput);
                    bool exits = BrandIdChecker(brandid);
                    if (exits)
                {
                    Console.WriteLine();
                    Console.WriteLine("Rating");
                    Console.WriteLine();
                    string rateinput = Console.ReadLine();
                    bool ratecheck = ErrorChecker(rateinput);
                    if (ratecheck)
                    {
                        int rating = Convert.ToInt32(rateinput);
                        Console.WriteLine();
                        Console.WriteLine("Starter Price");
                        Console.WriteLine();
                        string priceinput = Console.ReadLine();
                        bool pricecheck = ErrorChecker(priceinput);
                        if (pricecheck)
                        {
                            int starterprice = Convert.ToInt32(priceinput);
                            fact.GetLog().AddTypes(brandid, name, rating, starterprice);
                            Console.WriteLine("Sikeres hozzáadás!");
                            Console.ReadKey();
                        }
                        else
                        {
                            ErrorMessage();
                        }
                    }
                    else
                    {
                        ErrorMessage();
                    }
                }
                else
                {
                    Console.WriteLine("HIBA: Nem létező azonosítót adott meg.");
                    Console.ReadKey();
                }
                }
                else
                {
                ErrorMessage();
            }
        }

        /// <summary>
        /// Add a Parameters object to Database.
        /// </summary>
        private static void AddParameters()
        {
                Console.Clear();
                Console.WriteLine("Name");
                Console.WriteLine();
                string name = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Halfprice");
                Console.WriteLine();
                string halfinput = Console.ReadLine();
                bool halfcheck = ErrorChecker(halfinput);
                if (halfcheck)
                {
                    int halfprice = Convert.ToInt32(halfinput);
                    Console.WriteLine();
                    Console.WriteLine("Ram");
                    Console.WriteLine();
                    string raminput = Console.ReadLine();
                    bool ramcheck = ErrorChecker(raminput);
                    if (ramcheck)
                    {
                    int ram = Convert.ToInt32(raminput);
                    Console.WriteLine();
                    Console.WriteLine("Rom");
                    Console.WriteLine();
                    string rominput = Console.ReadLine();
                    bool romcheck = ErrorChecker(rominput);
                    if (romcheck)
                    {
                        int rom = Convert.ToInt32(rominput);
                        Console.WriteLine();
                        Console.WriteLine("TypeId");
                        Console.WriteLine();
                        string typeidinput = Console.ReadLine();
                        bool typeidcheck = ErrorChecker(typeidinput);
                        if (typeidcheck)
                        {
                            int typeid = Convert.ToInt32(typeidinput);
                            bool exits = ParameterIdChecker(typeid);
                            if (exits)
                            {
                                fact.GetLog().AddParameters(name, halfprice, ram, rom, typeid);
                                Console.WriteLine("Sikeres hozzáadás!");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("HIBA: Nem létező azonosítót adott meg");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            ErrorMessage();
                        }
                    }
                    else
                    {
                        ErrorMessage();
                    }
                    }
                    else
                    {
                    ErrorMessage();
                }
                }
                else
                {
                ErrorMessage();
            }
        }

        /// <summary>
        /// Remove a Brands object from Database.
        /// </summary>
        private static void Removebrands()
        {
                Console.Clear();
                Console.WriteLine("Adja meg a törlendő elem azonosítóját");
                Console.WriteLine();
                string input = Console.ReadLine();
                bool inputcheck = ErrorChecker(input);
                if (inputcheck)
                {
                int id = Convert.ToInt32(input);
                bool exits = BrandIdChecker(id);
                if (exits)
                {
                    fact.GetLog().RemoveBrands(id);
                    Console.WriteLine("Sikeres eltávolítás!");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("HIBA: Ilyen azonosítójú márka nem szerepel az adatbázisban.");
                    Console.ReadKey();
                }
                }
                else
                {
                ErrorMessage();
                }
        }

        /// <summary>
        /// Remove a Types object from Database.
        /// </summary>
        private static void RemoveTypes()
        {
            Console.Clear();
            Console.WriteLine("Adja meg a törlendő elem azonosítóját");
            Console.WriteLine();
            string input = Console.ReadLine();
            bool inputcheck = ErrorChecker(input);
            if (inputcheck)
            {
                int id = Convert.ToInt32(input);
                bool exits = TypeIdChecker(id);
                if (exits)
                {
                    fact.GetLog().RemoveTypes(id);
                    Console.WriteLine("Sikeres eltávolítás!");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("HIBA: Ilyen azonosítójú márka nem szerepel az adatbázisban.");
                    Console.ReadKey();
                }
            }
            else
            {
                ErrorMessage();
            }
        }

        /// <summary>
        /// Remove a Parameters object from Database.
        /// </summary>
        private static void RemoveParameters()
        {
            Console.Clear();
            Console.WriteLine("Adja meg a törlendő elem azonosítóját");
            Console.WriteLine();
            string input = Console.ReadLine();
            bool inputcheck = ErrorChecker(input);
            if (inputcheck)
            {
                int id = Convert.ToInt32(input);
                bool exits = ParameterIdChecker(id);
                if (exits)
                {
                    fact.GetLog().RemoveParameters(id);
                    Console.WriteLine("Sikeres eltávolítás!");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("HIBA: Ilyen azonosítójú márka nem szerepel az adatbázisban.");
                    Console.ReadKey();
                }
            }
            else
            {
                ErrorMessage();
            }
        }

        /// <summary>
        /// Update a Brands object from Database.
        /// </summary>
        private static void Updatebrands()
        {
            Console.Clear();
            Console.WriteLine("Azonosító");
            string idinput = Console.ReadLine();
            bool idcheck = ErrorChecker(idinput);
            if (idcheck)
            {
                int id = Convert.ToInt32(idinput);
                bool exits = BrandIdChecker(id);
                if (exits)
                {
                    Console.Clear();
                    Console.WriteLine("Name");
                    Console.WriteLine();
                    string name = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Country");
                    Console.WriteLine();
                    string country = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Popularity");
                    Console.WriteLine();
                    string popu = Console.ReadLine();
                    bool check = ErrorChecker(popu);
                    if (check)
                    {
                        int popularity = Convert.ToInt32(popu);
                        Console.WriteLine();
                        Console.WriteLine("Total Income");
                        Console.WriteLine();
                        string total = Console.ReadLine();
                        bool totalcheck = ErrorChecker(total);
                        if (totalcheck)
                        {
                            int totalincome = Convert.ToInt32(total);
                            fact.GetLog().UpdateBrands(id, name, country, popularity, totalincome);
                            Console.WriteLine("Sikeres módosítás!");
                            Console.ReadKey();
                        }
                        else
                        {
                            ErrorMessage();
                        }
                    }
                    else
                    {
                        ErrorMessage();
                    }
                }
                else
                {
                    Console.WriteLine("HIBA: Ilyen azonosító nem szerepel az adatbázisban.");
                    Console.ReadKey();
                }
            }
            else
            {
                ErrorMessage();
            }
        }

        /// <summary>
        /// Update a Types object from Database.
        /// </summary>
        private static void UpdateTypes()
        {
            Console.Clear();
            Console.WriteLine("Azonosító");
            string idinput = Console.ReadLine();
            bool idcheck = ErrorChecker(idinput);
            if (idcheck)
            {
                int id = Convert.ToInt32(idinput);
                bool exits = TypeIdChecker(id);
                if (exits)
                {
                    Console.Clear();
                    Console.WriteLine("Name");
                    Console.WriteLine();
                    string name = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("BrandId");
                    Console.WriteLine();
                    string brandinput = Console.ReadLine();
                    bool brandcheck = ErrorChecker(brandinput);
                    if (brandcheck)
                    {
                        int brandid = Convert.ToInt32(brandinput);
                        bool brandexists = BrandIdChecker(brandid);
                        if (brandexists)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Rating");
                            Console.WriteLine();
                            string rateinput = Console.ReadLine();
                            bool ratecheck = ErrorChecker(rateinput);
                            if (ratecheck)
                            {
                                int rating = Convert.ToInt32(rateinput);
                                Console.WriteLine();
                                Console.WriteLine("Starter Price");
                                Console.WriteLine();
                                string priceinput = Console.ReadLine();
                                bool pricecheck = ErrorChecker(priceinput);
                                if (pricecheck)
                                {
                                    int starterprice = Convert.ToInt32(priceinput);
                                    fact.GetLog().UpdateTypes(id, brandid, name, rating, starterprice);
                                    Console.WriteLine("Sikeres módosítás!");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    ErrorMessage();
                                }
                            }
                            else
                            {
                                ErrorMessage();
                            }
                        }
                        else
                        {
                            Console.WriteLine("HIBA: Ilyen azonosító nem szerepel az adatbázisban.");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        ErrorMessage();
                    }
                }
                else
                {
                    Console.WriteLine("HIBA: Ilyen azonosító nem szerepel az adatbázisban.");
                    Console.ReadKey();
                }
            }
            else
            {
                ErrorMessage();
            }
        }

        /// <summary>
        /// Update a Parameters object from Database.
        /// </summary>
        private static void UpdateParameters()
        {
            Console.Clear();
            Console.WriteLine("Azonosító");
            string idinput = Console.ReadLine();
            bool idcheck = ErrorChecker(idinput);
            if (idcheck)
            {
                int id = Convert.ToInt32(idinput);
                bool exists = ParameterIdChecker(id);
                if (exists)
                {
                    Console.Clear();
                    Console.WriteLine("Name");
                    Console.WriteLine();
                    string name = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Halfprice");
                    Console.WriteLine();
                    string halfinput = Console.ReadLine();
                    bool halfcheck = ErrorChecker(halfinput);
                    if (halfcheck)
                    {
                        int halfprice = Convert.ToInt32(halfinput);
                        Console.WriteLine();
                        Console.WriteLine("Ram");
                        Console.WriteLine();
                        string raminput = Console.ReadLine();
                        bool ramcheck = ErrorChecker(raminput);
                        if (ramcheck)
                        {
                            int ram = Convert.ToInt32(raminput);
                            Console.WriteLine();
                            Console.WriteLine("Rom");
                            Console.WriteLine();
                            string rominput = Console.ReadLine();
                            bool romcheck = ErrorChecker(rominput);
                            if (romcheck)
                            {
                                int rom = Convert.ToInt32(rominput);
                                Console.WriteLine();
                                Console.WriteLine("TypeId");
                                Console.WriteLine();
                                string typeidinput = Console.ReadLine();
                                bool typeidcheck = ErrorChecker(typeidinput);
                                if (typeidcheck)
                                {
                                    int typeid = Convert.ToInt32(typeidinput);
                                    bool typeexists = TypeIdChecker(typeid);
                                    if (typeexists)
                                    {
                                        fact.GetLog().UpdateParameters(id, name, halfprice, ram, rom, typeid);
                                        Console.WriteLine("Sikeres módosítás!");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("HIBA: Ilyen azonosító nem szerepel az adatbázisban.");
                                        Console.ReadKey();
                                    }
                                }
                                else
                                {
                                    ErrorMessage();
                                }
                            }
                            else
                            {
                                ErrorMessage();
                            }
                        }
                        else
                        {
                            ErrorMessage();
                        }
                    }
                    else
                    {
                        ErrorMessage();
                    }
                }
                else
                {
                    Console.WriteLine("HIBA: Ilyen azonosító nem szerepel az adatbázisban.");
                    Console.ReadKey();
                }
            }
            else
            {
                ErrorMessage();
            }
        }

        /// <summary>
        /// This method return Types objects and using Brand name.
        /// </summary>
        private static void FindTypeByBrandName()
        {
            Console.Clear();
            Console.WriteLine("Adja meg a márkanevet, amelynek a típusaira kíváncsi.");
            Console.WriteLine();
            string nev = Console.ReadLine();
            var data = fact.GetLog().FindTypeByBrandName(nev);
            Console.WriteLine();
            Console.WriteLine("Találatok: ");
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Find all roms and all rams by typename.
        /// </summary>
        private static void AllRamAndRomByTypeName()
        {
            Console.Clear();
            Console.WriteLine("Adja meg a típus nevét, amelynek az összesített ramjára és romjára kíváncsi.");
            Console.WriteLine();
            string nev = Console.ReadLine();
            var data = fact.GetLog().SumRamAndRomByType(nev);
            Console.WriteLine();
            Console.WriteLine(value: "Találat: ");
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// This method return parameters objects where halfprice equals 0 and using Brand name.
        /// </summary>
        private static void NoHalfPriceByBrandname()
        {
            Console.Clear();
            Console.WriteLine("Adja meg a típus nevét, amelynek az alapmodelljeire kíváncsi.");
            Console.WriteLine();
            string nev = Console.ReadLine();
            var data = fact.GetLog().NoHalfPriceByTypename(nev);
            Console.WriteLine();
            Console.WriteLine("Találatok: ");
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// This method return parameters objects where halfprice equals 0 and using Brand name.
        /// </summary>
        private static void NoHalfPriceByBrandnameAsync()
        {
            Console.Clear();
            Console.WriteLine("Adja meg a típus nevét, amelynek az alapmodelljeire kíváncsi.");
            Console.WriteLine();
            string nev = Console.ReadLine();
            var result = fact.GetLog().NoHalfPriceByTypenameAsync(nev).Result;
            var task2 = fact.GetLog().NoHalfPriceByTypenameAsync(nev);
            task2.Wait();
            var result2 = task2.Result;
            Console.WriteLine();
            Console.WriteLine("Találatok: ");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// This method return Parameters objects and using the Brand name.
        /// </summary>
        private static void FindParameterByTypeName()
        {
            Console.Clear();
            Console.WriteLine("Adja meg a típus nevét, amelynek a modelljeire kíváncsi.");
            Console.WriteLine();
            string nev = Console.ReadLine();
            var data = fact.GetLog().FindParameterByTypeName2(nev);
            Console.WriteLine();
            Console.WriteLine("Találatok: ");
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// This method return Parameters objects and using the Brand name.
        /// </summary>
        private static void FindParameterByTypeNameAsync()
        {
            Console.Clear();
            Console.WriteLine("Adja meg a típus nevét, amelynek a modelljeire kíváncsi.");
            Console.WriteLine();
            string nev = Console.ReadLine();
            var result = fact.GetLog().FindParameterByTypeName2Async(nev).Result;
            var task2 = fact.GetLog().FindParameterByTypeName2Async(nev);
            task2.Wait();
            var result2 = task2.Result;
            Console.WriteLine();
            Console.WriteLine("Találatok: ");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// This method return Parameters objects and using the Brand name.
        /// </summary>
        private static void SumRamAndRomByTypeNameAsync()
        {
            Console.Clear();
            Console.WriteLine("Adja meg a típus nevét, amelynek a modelljeire kíváncsi.");
            Console.WriteLine();
            string nev = Console.ReadLine();
            var result = fact.GetLog().SumRamAndRomByTypeAsync(nev).Result;
            var task2 = fact.GetLog().SumRamAndRomByTypeAsync(nev);
            task2.Wait();
            var result2 = task2.Result;
            Console.WriteLine();
            Console.WriteLine(value: "Találat: ");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// This method return Brands objects where Brandname contains the input text.
        /// </summary>
        private static void DoSomething()
        {
            Console.Clear();
            Console.WriteLine("Írjon be egy szövegrészletet, amelynek segítségével kiszűrjük a márkák adatait.");
            Console.WriteLine();
            string beker = Console.ReadLine();
            Console.WriteLine();
            var data = fact.GetLog().DoSomething(beker);
            Console.Clear();
            Console.WriteLine("Találatok:");
            Console.WriteLine();
            foreach (var item in data)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();
        }

        /// <summary>
        /// This method return Brands objects where Brandname contains the input text.
        /// </summary>
        private static void DoSomethingAsync()
        {
            Console.Clear();
            Console.WriteLine("Írjon be egy szövegrészletet, amelynek segítségével kiszűrjük a márkák adatait.");
            Console.WriteLine();
            string beker = Console.ReadLine();
            Console.WriteLine();
            var result = fact.GetLog().DoSomethingAsync(beker).Result;
            var task2 = fact.GetLog().DoSomethingAsync(beker);
            task2.Wait();
            var result2 = task2.Result;
            Console.Clear();
            Console.WriteLine("Találatok:");
            Console.WriteLine();
            foreach (var item in result)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();
        }

        /// <summary>
        /// This method list the average rating of brands.
        /// </summary>
        private static void BrandRateByName()
        {
            Console.WriteLine("A brandek összértékelése nevek alapján:");
            Console.WriteLine();
            foreach (var item in fact.GetLog().BrandAverageRating())
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// This method list the all halfprice of models.
        /// </summary>
        private static void AllHalfPrice()
        {
            Console.WriteLine("A típusokhoz tartozó felárak összege");
            Console.WriteLine();
            foreach (var item in fact.GetLog().AllHalfPriceByType())
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Check the integer convert errors.
        /// <param name="input">Input string.</param>
        /// </summary>
        private static bool ErrorChecker(string input)
        {
            try
            {
                int number = Convert.ToInt32(input);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Integer convert error message.
        /// </summary>
        private static void ErrorMessage()
        {
            Console.WriteLine("HIBA: Nem konvertálható adatot adott meg.");
            Console.ReadKey();
        }

        /// <summary>
        /// Check to see if this ID is in the database.
        /// </summary>
        /// <param name="input">id of brand.</param>
        /// <returns>exits or not.</returns>
        private static bool BrandIdChecker(int input)
        {
            var brands = fact.GetLog().GetAllBrands();
            foreach (var item in brands)
            {
                if (item.ToString().Contains("ID: " + input))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check to see if this ID is in the database.
        /// </summary>
        /// <param name="input">id of type.</param>
        /// <returns>exits or not.</returns>
        private static bool TypeIdChecker(int input)
        {
            var types = fact.GetLog().GetAllTypes();
            foreach (var item in types)
            {
                if (item.ToString().Contains("ID: " + input))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check to see if this ID is in the database.
        /// </summary>
        /// <param name="input">id of parameter.</param>
        /// <returns>exits or not.</returns>
        private static bool ParameterIdChecker(int input)
        {
            var parameters = fact.GetLog().GetAllParameters();
            foreach (var item in parameters)
            {
                if (item.ToString().Contains("ID: " + input))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

// <copyright file="UnitTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SmartPhoneShop.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Moq;
    using NUnit.Framework;
    using SmartPhoneShop.Data.Models;
    using SmartPhoneShop.Repository;
    using SmartPhoneShop.Repository.Interfaces;

    /// <summary>
    /// Test logic class.
    /// </summary>
    [TestFixture]
    public static class UnitTests
    {
        private static List<Brands> brandlist;
        private static List<Parameters> parameterslist;
        private static List<Types> typeslist;
        private static string brandscontents;
        private static string typescontents;
        private static string parameterscontents;
        private static Mock<BrandRepository> brandsmock;
        private static Mock<ParametersRepository> parametersmock;
        private static Mock<TypesRepository> typesmock;
        private static Blogic blogic;

        /// <summary>
        /// This Method set the tests up.
        /// </summary>
        [OneTimeSetUp]
        public static void Setup()
        {
            DatabaseContext ctx = new DatabaseContext();
            brandsmock = new Mock<BrandRepository>(ctx);
            parametersmock = new Mock<ParametersRepository>(ctx);
            typesmock = new Mock<TypesRepository>(ctx);
            brandlist = new List<Brands>
            {
                 new Brands() { Id = 2, BrandName = "Apple", Country = "USA", Popularity = 9, TotalIncome = 439000000 },
                 new Brands() { Id = 4, BrandName = "Samsung", Country = "South Korea", Popularity = 8, TotalIncome = 445000000 },
            };
            typeslist = new List<Types>
            {
                new Types() { Id = 12, BrandId = 2, ModelName = "Iphone 11", Rating = 4, StarterPrice = 500 },
                new Types() { Id = 17, BrandId = 4, ModelName = "Galaxy s20", Rating = 5, StarterPrice = 700 },
            };

            parameterslist = new List<Parameters>
            {
                new Parameters() { Id = 1, Name = "Standard", HalfPrice = 0, Ram = 4, Rom = 64, TypeId = 12 },
                new Parameters() { Id = 13, Name = "Premium", HalfPrice = 170, Ram = 12, Rom = 512, TypeId = 17 },
            };
            foreach (var item in brandlist)
            {
                brandscontents += "Id: " + item.Id + " Brand:" + item.BrandName + " Country: " + item.Country + " Popularity: " + item.Popularity + " Total Income: " + item.TotalIncome + "\n";
            }

            foreach (var item in typeslist)
            {
                typescontents += "Id: " + item.Id + " BrandId: " + item.BrandId + " Name: " + item.ModelName + " Rating: " + item.Rating + " Starter Price: " + item.StarterPrice + "\n";
            }

            foreach (var item in parameterslist)
            {
                parameterscontents += " Id: " + item.Id + " Name: " + item.Name + " RAM: " + item.Ram + " ROM " + item.Rom + " TypeId: " + item.TypeId;
            }

            brandsmock.Setup(x => x.GetAllContentsFromTable()).Returns(brandscontents);
            typesmock.Setup(x => x.GetAllContentsFromTable()).Returns(typescontents);
            parametersmock.Setup(x => x.GetAllContentsFromTable()).Returns(parameterscontents);
            brandsmock.Setup(x => x.All).Returns(brandlist.AsQueryable());
            typesmock.Setup(x => x.Getall()).Returns(typeslist.AsQueryable());
            parametersmock.Setup(x => x.Getall()).Returns(parameterslist.AsQueryable());
            blogic = new Blogic(brandsmock.Object, typesmock.Object, parametersmock.Object);
        }

        /// <summary>
        /// Tests the AddaBrand method.
        /// </summary>
        [Test]
        public static void Addbrand()
        {
            brandsmock.Setup(z => z.AddaBrand("Teszter", "Tesztcountry", 5, 20000)).Verifiable();
            blogic.AddBrands("Teszter", "Tesztcountry", 5, 20000);
            brandsmock.Verify(z => z.AddaBrand("Teszter", "Tesztcountry", 5, 20000));
        }

        /// <summary>
        /// Tests the AddaTypes method.
        /// </summary>
        [Test]
        public static void Addtypes()
        {
            typesmock.Setup(z => z.AddType(2, "Teszter", 4, 700)).Verifiable();
            blogic.AddTypes(2, "Teszter", 4, 700);
            typesmock.Verify(z => z.AddType(2, "Teszter", 4, 700));
        }

        /// <summary>
        /// Tests the AddaParameter method.
        /// </summary>
        [Test]
        public static void Addparameters()
        {
            parametersmock.Setup(z => z.Addaparameter("Teszter", 300, 6, 32, 17)).Verifiable();
            blogic.AddParameters("Teszter", 300, 6, 32, 17);
            parametersmock.Verify(z => z.Addaparameter("Teszter", 300, 6, 32, 17));
        }

        /// <summary>
        /// readability test of the BrandsRepository.
        /// </summary>
        /// <param name="text">Test content.</param>
        [TestCase("Apple")]
        public static void BrandsRepositoryReadTest(string text)
        {
            string content = blogic.BrandsContents;
            Assert.That(content.Contains(text));
        }

        /// <summary>
        /// readability test of the TypesRepository.
        /// </summary>
        /// <param name="text">Test content.</param>
        [TestCase("Iphone 11")]
        public static void TypesRepositoryReadTest(string text)
        {
            string content = blogic.TypesContents;
            Assert.That(content.Contains(text));
        }

        /// <summary>
        /// readability test of the ParametersRepository.
        /// </summary>
        /// <param name="text">Test content.</param>
        [TestCase("Premium")]
        public static void ParametersRepositoryReadTest(string text)
        {
            string content = blogic.ParameterssContents;
            Assert.That(content.Contains(text));
        }

        /// <summary>
        /// Test of the UpdateBrands method.
        /// </summary>
        [Test]
        public static void BrandupdateTest()
        {
            brandsmock.Setup(r => r.UpdateBrands(4, "Teszter", "Teszt country", 5, 20000)).Verifiable();
            blogic.UpdateBrands(4, "Teszter", "Teszt country", 5, 20000);
            brandsmock.Verify(r => r.UpdateBrands(4, "Teszter", "Teszt country", 5, 20000));
        }

        /// <summary>
        /// Test of the UpdateTypes method.
        /// </summary>
        [Test]
        public static void TypesupdateTest()
        {
            typesmock.Setup(r => r.UpdateTypes(12, 2, "Teszter", 5, 700)).Verifiable();
            blogic.UpdateTypes(12, 2, "Teszter", 5, 700);
            typesmock.Verify(r => r.UpdateTypes(12, 2, "Teszter", 5, 700));
        }

        /// <summary>
        /// Test of the UpdateBrands method.
        /// </summary>
        [Test]
        public static void ParametersupdateTest()
        {
            parametersmock.Setup(r => r.UpdateParameters(1, "Teszter", 30, 6, 32, 12)).Verifiable();
            blogic.UpdateParameters(1, "Teszter", 30, 6, 32, 12);
            parametersmock.Verify(r => r.UpdateParameters(1, "Teszter", 30, 6, 32, 12));
        }

        /// <summary>
        /// Get a brands object by Id.
        /// </summary>
        [Test]
        public static void Getbrandsbyid()
        {
            brandsmock.Setup(r => r.GetBrandsTostringbyId(4)).Verifiable();
            blogic.Getbrandsbyid(4);
            brandsmock.Verify(r => r.GetBrandsTostringbyId(4));
        }

        /// <summary>
        /// Get a types object by Id.
        /// </summary>
        [Test]
        public static void Gettypesbyid()
        {
            typesmock.Setup(r => r.GetTypesTostringbyId(12)).Verifiable();
            blogic.Gettypesbyid(12);
            typesmock.Verify(r => r.GetTypesTostringbyId(12));
        }

        /// <summary>
        /// Get a parameters object by Id.
        /// </summary>
        [Test]
        public static void Getparametersbyid()
        {
            parametersmock.Setup(r => r.GetParametersTostringbyId(13)).Verifiable();
            blogic.Getparametersbyid(13);
            parametersmock.Verify(r => r.GetParametersTostringbyId(13));
        }

        /// <summary>
        /// Remove a types object from the Database.
        /// </summary>
        [Test]
        public static void RemoveTypes()
        {
            typesmock.Setup(x => x.Remove(12)).Verifiable();
            blogic.RemoveTypes(12);
            typesmock.Verify(x => x.Remove(12));
        }

        /// <summary>
        /// Remove a brands object from the Database.
        /// </summary>
        [Test]
        public static void RemoveBrands()
        {
            brandsmock.Setup(x => x.Remove(2)).Verifiable();
            blogic.RemoveBrands(2);
            brandsmock.Verify(x => x.Remove(2));
        }

        /// <summary>
        /// Remove a parameters object from the Database.
        /// </summary>
        [Test]
        public static void RemoveParameters()
        {
            parametersmock.Setup(x => x.Remove(1)).Verifiable();
            blogic.RemoveParameters(1);
            parametersmock.Verify(x => x.Remove(1));
        }

        /// <summary>
        /// Return all Parameters object from the Database.
        /// </summary>
        [Test]
        public static void GetAllParametersTest()
        {
            parametersmock.Setup(x => x.Getall()).Verifiable();
            blogic.GetAllParameters();
            parametersmock.Verify(x => x.Getall());
        }

        /// <summary>
        /// Return all Brands object from the Database.
        /// </summary>
        [Test]
        public static void GetAllBrandsTest()
        {
            brandsmock.Setup(x => x.Getall()).Verifiable();
            blogic.GetAllBrands();
            brandsmock.Verify(x => x.Getall());
        }

        /// <summary>
        /// Return all Types object from the Database.
        /// </summary>
        [Test]
        public static void GetAllTypesTest()
        {
            typesmock.Setup(x => x.Getall()).Verifiable();
            blogic.GetAllTypes();
            typesmock.Verify(x => x.Getall());
        }

        /// <summary>
        /// Test the FindTypeByBrandname method.
        /// </summary>
        /// <param name="input">Test content.</param>
        [TestCase("Apple")]
        public static void FindTypeByBrandnameTest(string input)
        {
            IEnumerable<Brands> brand = from x in brandlist where x.BrandName.Equals(input) select x;
            string id = Convert.ToString(brand.First().Id);
            Assert.That(blogic.FindTypeByBrandName(input).ToList().TrueForAll(x => x.ToString().Contains(id)));
            brandsmock.Verify(x => x.Getall(), Times.AtLeastOnce());
            typesmock.Verify(x => x.Getall(), Times.AtLeastOnce());
        }

        /// <summary>
        /// Test the NoHalfPriceByBrandName method.
        /// </summary>
        /// <param name="input">Test content.</param>
        [TestCase("Samsung")]
        public static void NoHalfPriceTest(string input)
        {
            Assert.That(blogic.NoHalfPriceByTypename(input).ToList().TrueForAll(x => x.ToString().Contains("Halfprice=0")) && blogic.NoHalfPriceByTypename(input).ToList().TrueForAll(x => x.ToString().Contains(input)));
            parametersmock.Verify(x => x.Getall(), Times.AtLeastOnce());
            typesmock.Verify(x => x.Getall(), Times.AtLeastOnce());
        }

        /// <summary>
        /// Test the FindParameterByTypeName method.
        /// </summary>
        /// <param name="input">Test content.</param>
        [TestCase("Iphone 12")]
        public static void FindParameterByTypeNameTest(string input)
        {
            Assert.That(blogic.FindParameterByTypeName2(input).ToList().TrueForAll(x => x.ToString().Contains(input)));
            parametersmock.Verify(x => x.Getall(), Times.AtLeastOnce());
            typesmock.Verify(x => x.Getall(), Times.AtLeastOnce());
        }

        /// <summary>
        /// Test the SumRamAndRom method.
        /// </summary>
        /// <param name="input">Test content.</param>
        [TestCase("Iphone 12")]
        [TestCase("Iphone SE")]
        public static void SumRamAndRomTest(string input)
        {
            Assert.That(blogic.SumRamAndRomByType(input).ToList().TrueForAll(x => x.ToString()
            .Contains(input)));
            typesmock.Verify(x => x.Getall(), Times.AtLeastOnce());
            parametersmock.Verify(x => x.Getall(), Times.AtLeastOnce());
        }

        /// <summary>
        /// Test the BrandAverageRating method.
        /// </summary>
        [Test]
        public static void BrandAverageRatingTest()
        {
            var result = blogic.BrandAverageRating();
            Assert.That(blogic.BrandAverageRating().ToList(), Is.EqualTo(result));
            brandsmock.Verify(x => x.Getall(), Times.AtLeastOnce());
            typesmock.Verify(x => x.Getall(), Times.AtLeastOnce());
        }

        /// <summary>
        /// Test the AllHalfPriceByType method.
        /// </summary>
        public static void SumHalfPriceByTypesTest()
        {
            var result = blogic.AllHalfPriceByType();
            Assert.That(blogic.AllHalfPriceByType().ToList(), Is.EqualTo(result));
            typesmock.Verify(x => x.Getall(), Times.AtLeastOnce());
            parametersmock.Verify(x => x.Getall(), Times.AtLeastOnce());
        }
    }
}

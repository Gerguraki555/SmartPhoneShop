// <copyright file="Blogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SmartPhoneShop.Logic
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using SmartPhoneShop.Logic.NonCrudObjects;
    using SmartPhoneShop.Repository;
    using SmartPhoneShop.Repository.Interfaces;
    using SmartPhoneShop.Repository.NonCrudObjects;

    /// <summary>
    /// Blogic class.
    /// </summary>
    public class Blogic : ILogic
    {
        private readonly IBrandsRepository brandrepo;

        private readonly ITypesRepository typerepo;

        private readonly IParametersRepository pararepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="Blogic"/> class.
        /// </summary>
        /// <param name="brand">injected Brandrepository collection.</param>
        /// <param name="types">injected Typesrepository collection.</param>
        /// <param name="para">injected Parametersrepository collection.</param>
        public Blogic(IBrandsRepository brand, ITypesRepository types, IParametersRepository para)
        {
            this.brandrepo = brand;
            this.pararepo = para;
            this.typerepo = types;
        }

        /// <inheritdoc/>
        public string BrandsContents
        {
            get
            {
                return this.brandrepo.GetAllContentsFromTable();
            }
        }

        /// <inheritdoc/>
        public string ParameterssContents
        {
            get
            {
                return this.pararepo.GetAllContentsFromTable();
            }
        }

        /// <inheritdoc/>
        public string TypesContents
        {
            get
            {
                return this.typerepo.GetAllContentsFromTable();
            }
        }

        /// <inheritdoc/>
        public virtual bool AddBrands(string brandname, string counry, int popularity, int totalincome)
        {
            return this.brandrepo.AddaBrand(brandname, counry, popularity, totalincome);
        }

        /// <inheritdoc/>
        public virtual bool AddParameters(string name, int halfprice, int ram, int rom, int tipid)
        {
            return this.pararepo.Addaparameter(name, halfprice, ram, rom, tipid);
        }

        /// <inheritdoc/>
        public virtual bool AddTypes(int brandid, string modelname, int rating, int starterprice)
        {
            return this.typerepo.AddType(brandid, modelname, rating, starterprice);
        }

        /// <inheritdoc/>
        public bool BrandsIsExits(int id)
        {
            return this.brandrepo.IsExists(id);
        }

        /// <inheritdoc/>
        public object Getbrandsbyid(int id)
        {
            return this.brandrepo.GetBrandsTostringbyId(id);
        }

        /// <inheritdoc/>
        public object Getparametersbyid(int id)
        {
            return this.pararepo.GetParametersTostringbyId(id);
        }

        /// <inheritdoc/>
        public object Gettypesbyid(int id)
        {
            return this.typerepo.GetTypesTostringbyId(id);
        }

        /// <inheritdoc/>
        public bool ParametersIsExits(int id)
        {
            return this.pararepo.IsExists(id);
        }

        /// <inheritdoc/>
        public void RemoveBrands(int id)
        {
            this.brandrepo.Remove(id);
        }

        /// <inheritdoc/>
        public void RemoveParameters(int id)
        {
            this.pararepo.Remove(id);
        }

        /// <inheritdoc/>
        public void RemoveTypes(int id)
        {
            this.typerepo.Remove(id);
        }

        /// <summary>
        /// Return all Brand objects.
        /// </summary>
        /// <returns>List with objects.</returns>
        public IQueryable<object> GetAllBrands()
        {
            return this.brandrepo.Getall();
        }

        /// <summary>
        /// Return all Types objects.
        /// </summary>
        /// <returns>List with objects.</returns>
        public IQueryable<object> GetAllTypes()
        {
            return this.typerepo.Getall();
        }

        /// <summary>
        /// Return all Parameters objects.
        /// </summary>
        /// <returns>List with objects.</returns>
        public IQueryable<object> GetAllParameters()
        {
            return this.pararepo.Getall();
        }

        /// <inheritdoc/>
        public bool TypesIsExits(int id)
        {
            return this.typerepo.IsExists(id);
        }

        /// <inheritdoc/>
        public virtual bool UpdateBrands(int id, string brandname, string counry, int popularity, int totalincome)
        {
            return this.brandrepo.UpdateBrands(id, brandname, counry, popularity, totalincome);
        }

        /// <inheritdoc/>
        public virtual bool UpdateParameters(int id, string name, int halfprice, int ram, int rom, int tipid)
        {
            return this.pararepo.UpdateParameters(id, name, halfprice, ram, rom, tipid);
        }

        /// <inheritdoc/>
        public virtual bool UpdateTypes(int id, int brandid, string modelname, int rating, int starterprice)
        {
            return this.typerepo.UpdateTypes(id, brandid, modelname, rating, starterprice);
        }

        /// <summary>
        /// Return types and using Brandname.
        /// </summary>
        /// <param name="brandname">name of Brands object.</param>
        /// <returns>Icollection with objects.</returns>
        public ICollection<NonCrudType> FindTypeByBrandName(string brandname)
        {
            var data = from x in this.brandrepo.Getall()
                       join y in this.typerepo.Getall() on x.Id equals y.BrandId
                       orderby y.Rating descending
                       where x.BrandName == brandname
                       select new NonCrudType(y.Id, y.BrandId, y.ModelName, y.Rating, y.StarterPrice);
            return data.ToArray();
        }

        /// <summary>
        /// Return parameters where halfprice is 0 and using typename.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns>IList with objects.</returns>
        public IList<NonCrudParameter> NoHalfPriceByTypename(string input)
        {
            var data = from x in this.pararepo.Getall()
                       join y in this.typerepo.Getall() on x.TypeId equals y.Id
                       orderby x.Rom descending
                       where x.HalfPrice == 0
                       && y.ModelName.ToUpper() == input.ToUpper()
                       select new NonCrudParameter(x.Id, x.Name, x.HalfPrice, x.Ram, x.Rom, x.TypeId);
            return data.ToArray();
        }

        /// <summary>
        /// Return average rating of brands.
        /// </summary>
        /// <returns>IList with objects.</returns>
        public IList<BrandRating> BrandAverageRating()
        {
            var data = from x in this.brandrepo.Getall()
                       join y in this.typerepo.Getall() on x.Id equals y.BrandId
                       orderby x.BrandName descending
                       let obj = new { Brandname=x.BrandName, rating=y.Rating }
                       group obj by obj.Brandname into g
                       select new BrandRating(g.Key, g.Average(y => y.rating));
            return data.ToArray();
        }

        /// <summary>
        /// Return all halfprice of models.
        /// </summary>
        /// <returns>IList with objects.</returns>
        public IList<AllhalfPrice> AllHalfPriceByType()
        {
            var data = from x in this.typerepo.Getall()
                       join y in this.pararepo.Getall() on x.Id equals y.TypeId
                       orderby x.ModelName descending
                       let obj = new { Modelname = x.ModelName, halfprice = y.HalfPrice }
                       group obj by obj.Modelname into g
                       select new AllhalfPrice(g.Key, g.Sum(y => y.halfprice));
            return data.ToArray();
        }

        /// <summary>
        /// Return all halfprice of models.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns>IList with objects.</returns>
        public IList<SumRamAndRom> SumRamAndRomByType(string input)
        {
            var data = from x in this.typerepo.Getall()
                       join y in this.pararepo.Getall() on x.Id equals y.TypeId
                       orderby x.ModelName descending
                       where x.ModelName.ToUpper().Contains(input.ToUpper())
                       let obj = new { Modelname = x.ModelName, ram = y.Ram, rom=y.Rom }
                       group obj by obj.Modelname into g
                       select new SumRamAndRom(g.Key, g.Sum(y => y.ram), g.Sum(y => y.rom));
            return data.ToArray();
        }

        /// <summary>
        /// return parameters objects and using brandname.
        /// </summary>
        /// <param name="typename">Input string.</param>
        /// <returns>IList with objects.</returns>
        public IList<NonCrudParameter> FindParameterByTypeName2(string typename)
        {
            var data = from x in this.pararepo.Getall()
                       join y in this.typerepo.Getall() on x.TypeId equals y.Id
                       orderby y.Rating descending
                       where y.ModelName.ToUpper()
                       == typename.ToUpper()
                       select new NonCrudParameter(x.Id, x.Name, x.HalfPrice, x.Ram, x.Rom, x.TypeId);
            return data.ToArray();
        }

        /// <summary>
        /// Find brandname, country and total income from brands and this method using input string.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns>IList with objects.</returns>
        public IList<DoSomethhingObject> DoSomething(string input)
        {
            var data = from x in this.brandrepo.Getall()
                       where x.BrandName.ToUpper()
                       .Contains(input.ToUpper())
                       select new DoSomethhingObject(x.BrandName, x.Country, x.TotalIncome);
            return data.ToArray();
        }

        /// <summary>
        /// Find brandname, country and total income from brands and this method using input string and using Task.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns>IList with objects.</returns>
        public Task<IList<DoSomethhingObject>> DoSomethingAsync(string input)
        {
            return Task.Run(() => this.DoSomething(input));
        }

        /// <summary>
        /// Return a parameters object and using typename with Task.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns>IList with objects.</returns>
        public Task<IList<NonCrudParameter>> FindParameterByTypeName2Async(string input)
        {
            return Task.Run(() => this.FindParameterByTypeName2(input));
        }

        /// <summary>
        /// Return parameters with task where halfprice is 0 and using typename.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns>IList with objects.</returns>
        public Task<IList<NonCrudParameter>> NoHalfPriceByTypenameAsync(string input)
        {
            return Task.Run(() => this.NoHalfPriceByTypename(input));
        }

        /// <summary>
        /// Return all halfprice of models.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns>IList with objects.</returns>
        public Task<IList<NonCrudParameter>> SumRamAndRomByTypeAsync(string input)
        {
            return Task.Run(() => this.NoHalfPriceByTypename(input));
        }
    }
}

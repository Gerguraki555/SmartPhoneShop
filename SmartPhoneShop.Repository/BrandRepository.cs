// <copyright file="BrandRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SmartPhoneShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SmartPhoneShop.Data;
    using SmartPhoneShop.Data.Models;
    using SmartPhoneShop.Repository.Interfaces;

    /// <summary>
    /// BrandRepository. Implements Irepository interface.
    /// </summary>
    public class BrandRepository : IBrandsRepository, IRepository<Brands>
    {
        private DatabaseContext ctx;

        /// <summary>
        /// Gets get all contents from Brands table.
        /// </summary>
        /// <returns>object tostring.</returns>
        public virtual string GetAllContentsFromTable()
        {
            string allcontents = string.Empty;
            foreach (var item in DbMethods.Brands)
            {
                allcontents = allcontents + "ID: " + item.Id + " Brand: " + item.BrandName + " Country: " + item.Country + " Popularity: " + item.Popularity + " Total Income: " + item.TotalIncome;
            }

            return allcontents;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BrandRepository"/> class.
        /// </summary>
        /// <param name="ctx">injected BrandRepository collection.</param>
        public BrandRepository(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }

        /// <summary>
        /// Gets every Brands.
        /// </summary>
        /// <returns>object.</returns>
        public virtual IQueryable<Brands> Getall()
        {
            return DbMethods.Brands.AsQueryable();
        }

        /// <summary>
        /// Gets every Brands.
        /// </summary>
        public virtual IQueryable<Brands> All => DbMethods.Brands.AsQueryable();

        /// <summary>
        /// Gives back a Brands object from database.
        /// </summary>
        /// <param name="id">Brands id.</param>
        /// <returns>A Brands object.</returns>
        public Brands GetOne(int id)
        {
            Brands brand = DbMethods.GetBrandsbyId(id);
            return brand;
        }

        /// <summary>
        /// Gives back a Brands.Tostring() from database.
        /// </summary>
        /// <param name="id">Brands id.</param>
        /// <returns>A Brands object.</returns>
        public virtual string GetBrandsTostringbyId(int id)
        {
            Brands brand = DbMethods.GetBrandsbyId(id);
            return brand.ToString();
        }

        /// <summary>
        /// Returns true if the brand object is exists.
        /// </summary>
        /// <param name="id">Brands Id.</param>
        /// <returns>True if exists, or false not exists.</returns>
        public bool IsExists(int id)
        {
            return DbMethods.Brands.Any(x => x.Id == id);
        }

        /// <summary>
        /// Delete a Brands object from database.
        /// </summary>
        /// <param name="id">id of Brands object.</param>
        /// <returns>True if removed, or false not removed.</returns>
        public virtual bool Remove(int id)
        {
            List<Brands> brandlist = DbMethods.Brands.Where(x => x.Id == id).Select(x => x).ToList();
            if (brandlist.Count > 0)
            {
                DbMethods.RemoveBrands(brandlist.First());
                DbMethods.SaveAll();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Add a Brands object to database.
        /// </summary>
        /// /// <param name="brandname">name of Brands object.</param>
        /// /// <param name="country">country of Brands object.</param>
        /// /// <param name="popularity">popularity of Brands object.</param>
        /// /// <param name="totalincome">Total Income of Brands object.</param>
        /// <returns>True if added, or false not added.</returns>
        public virtual bool AddaBrand(string brandname, string country, int popularity, int totalincome)
        {
            {
                Brands brand = new Brands()
                {
                    BrandName = brandname,
                    Country = country,
                    Popularity = popularity,
                    TotalIncome = totalincome,
                };
                DbMethods.AddBrands(brand);
                DbMethods.SaveAll();
                return true;
            }
        }

        /// <summary>
        /// Update a Brands object in database.
        /// </summary>
        /// <param name="brandid">id of Brands object.</param>
        /// /// <param name="brandname">name of Brands object.</param>
        /// /// <param name="country">country of Brands object.</param>
        /// /// <param name="popularity">popularity of Brands object.</param>
        /// /// <param name="totalincome">Total Income of Brands object.</param>
        /// <returns>True if added, or false not added.</returns>
        public virtual bool UpdateBrands(int brandid, string brandname, string country, int popularity, int totalincome)
        {
            List<Brands> brandlist = DbMethods.Brands.Where(x => x.Id == brandid).Select(x => x).ToList();
            if (brandlist.Count > 0)
            {
                Brands update = brandlist.First();
                update.BrandName = brandname;
                update.Country = country;
                update.Popularity = popularity;
                update.TotalIncome = totalincome;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

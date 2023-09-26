// <copyright file="IBrandsRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SmartPhoneShop.Repository.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SmartPhoneShop.Data.Models;

    /// <summary>
    /// Interface of BrandsRepository.
    /// </summary>
    public interface IBrandsRepository
    {
        /// <summary>
        /// Gets every Brands.
        /// </summary>
        /// <returns>object.</returns>
        public IQueryable<Brands> Getall();

        /// <summary>
        /// Gets get all contents from Brands table.
        /// </summary>
        /// <returns>object tostring.</returns>
        public string GetAllContentsFromTable();

        /// <summary>
        /// Gives back a Brands object from database.
        /// </summary>
        /// <param name="id">Brands id.</param>
        /// <returns>A Brands object.</returns>
        public Brands GetOne(int id);

        /// <summary>
        /// Gives back a Brands.Tostring() from database.
        /// </summary>
        /// <param name="id">Brands id.</param>
        /// <returns>A Brands object.</returns>
        public string GetBrandsTostringbyId(int id);

        /// <summary>
        /// Returns true if the brand object is exists.
        /// </summary>
        /// <param name="id">Brands Id.</param>
        /// <returns>True if exists, or false not exists.</returns>
        public bool IsExists(int id);

        /// <summary>
        /// Delete a Brands object from database.
        /// </summary>
        /// <param name="id">id of Brands object.</param>
        /// <returns>True if removed, or false not removed.</returns>
        public bool Remove(int id);

        /// <summary>
        /// Add a Brands object to database.
        /// </summary>
        /// /// <param name="brandname">name of Brands object.</param>
        /// /// <param name="country">country of Brands object.</param>
        /// /// <param name="popularity">popularity of Brands object.</param>
        /// /// <param name="totalincome">Total Income of Brands object.</param>
        /// <returns>True if added, or false not added.</returns>
        public bool AddaBrand(string brandname, string country, int popularity, int totalincome);

        /// <summary>
        /// Update a Brands object in database.
        /// </summary>
        /// <param name="brandid">id of Brands object.</param>
        /// /// <param name="brandname">name of Brands object.</param>
        /// /// <param name="country">country of Brands object.</param>
        /// /// <param name="popularity">popularity of Brands object.</param>
        /// /// <param name="totalincome">Total Income of Brands object.</param>
        /// <returns>True if added, or false not added.</returns>
        public bool UpdateBrands(int brandid, string brandname, string country, int popularity, int totalincome);
    }
}

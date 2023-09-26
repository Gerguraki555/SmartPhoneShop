// <copyright file="ITypesRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SmartPhoneShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SmartPhoneShop.Data.Models;

    /// <summary>
    /// Interface of TypesRepository.
    /// </summary>
    public interface ITypesRepository
    {
        /// <summary>
        /// Gets every Types.
        /// </summary>
        /// <returns>object.</returns>
        public IQueryable<Types> Getall();

        /// <summary>
        /// Gets get all contents from Types table.
        /// </summary>
        /// <returns>object tostring.</returns>
        public string GetAllContentsFromTable();

        /// <summary>
        /// Gives back a Type object from database.
        /// </summary>
        /// <param name="id">Type id.</param>
        /// <returns>A Type object.</returns>
        public Types GetOne(int id);

        /// <summary>
        /// Gives back a Types.Tostring() from database.
        /// </summary>
        /// <param name="id">Types id.</param>
        /// <returns>A Type object.</returns>
        public string GetTypesTostringbyId(int id);

        /// <summary>
        /// Returns true if the Types object is exists.
        /// </summary>
        /// <param name="id">Types Id.</param>
        /// <returns>True if exists, or false not exists.</returns>
        public bool IsExists(int id);

        /// <summary>
        /// Delete a Types object from database.
        /// </summary>
        /// <param name="id">id of Types object.</param>
        /// <returns>True if removed, or false not removed.</returns>
        public bool Remove(int id);

        /// <summary>
        /// Add a Types object to database.
        /// </summary>
        /// <param name="brandid">name of Parameters object.</param>
        /// <param name="modelname">HalfPrice of Brands object.</param>
        /// <param name="rating">Ram of Brands object.</param>
        /// <param name="starterprice">Rom of Brands object.</param>
        /// <returns>True if added, or false not added.</returns>
        public bool AddType(int brandid, string modelname, int rating, int starterprice);

        /// <summary>
        /// Add a Types object to database.
        /// </summary>
        /// <param name="tipid">id of Types object.</param>,0
        /// <param name="brandid">Brand id of Types object.</param>
        /// <param name="modelname">Name of Types object.</param>
        /// <param name="rating">Rating of Types object.</param>
        /// <param name="starterprice">Price of Types object.</param>
        /// <returns>True if added, or false not added.</returns>
        public bool UpdateTypes(int tipid, int brandid, string modelname, int rating, int starterprice);
    }
}

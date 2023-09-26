// <copyright file="IParametersRepository.cs" company="PlaceholderCompany">
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
    /// Interface of ParametersRepository.
    /// </summary>
    public interface IParametersRepository
    {
        /// <summary>
        /// Gets every Parameters.
        /// </summary>
        /// <returns>object.</returns>
        public abstract IQueryable<Parameters> Getall();

        /// <summary>
        /// Gets get all contents from Parameters table.
        /// </summary>
        /// <returns>object tostring.</returns>
        public string GetAllContentsFromTable();

        /// <summary>
        /// Gives back a Parameter object from database.
        /// </summary>
        /// <param name="id">Parameter id.</param>
        /// <returns>A Parameter object.</returns>
        public Parameters GetOne(int id);

        /// <summary>
        /// Gives back a Parameters.Tostring() from database.
        /// </summary>
        /// <param name="id">Brands id.</param>
        /// <returns>A Parameter object.</returns>
        public string GetParametersTostringbyId(int id);

        /// <summary>
        /// Returns true if the Parameters object is exists.
        /// </summary>
        /// <param name="id">Parameters Id.</param>
        /// <returns>True if exists, or false not exists.</returns>
        public bool IsExists(int id);

        /// <summary>
        /// Delete a Parameters object from database.
        /// </summary>
        /// <param name="id">id of Parameters object.</param>
        /// <returns>True if removed, or false not removed.</returns>
        public bool Remove(int id);

        /// <summary>
        /// Add a Parameters object to database.
        /// </summary>
        /// <param name="paraname">name of Parameters object.</param>
        /// <param name="halfprice">HalfPrice of Brands object.</param>
        /// <param name="ram">Ram of Brands object.</param>
        /// <param name="rom">Rom of Brands object.</param>
        /// <param name="typeid">TyypeId of Brands object.</param>
        /// <returns>True if added, or false not added.</returns>
        public bool Addaparameter(string paraname, int halfprice, int ram, int rom, int typeid);

        /// <summary>
        /// update a Parameters object to database.
        /// </summary>
        /// <param name="paraid">id of Parameters object.</param>
        /// <param name="paraname">name of Parameters object.</param>
        /// <param name="halfprice">HalfPrice of Brands object.</param>
        /// <param name="ram">Ram of Brands object.</param>
        /// <param name="rom">Rom of Brands object.</param>
        /// <param name="typeid">TyypeId of Brands object.</param>
        /// <returns>True if added, or false not added.</returns>
        public bool UpdateParameters(int paraid, string paraname, int halfprice, int ram, int rom, int typeid);
    }
}

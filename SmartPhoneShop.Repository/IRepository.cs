// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SmartPhoneShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Interface which requires the CRUD methods.
    /// </summary>
    /// <typeparam name="T">T type. </typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// return a object by id.
        /// </summary>
        /// <param name="id">ID of the object.</param>
        /// <returns>Type.</returns>
        T GetOne(int id);

        /// <summary>
        /// return all object.
        /// </summary>
        /// <returns>object.</returns>
        IQueryable<T> Getall();

        /// <summary>
        /// Gets the contents of the table.
        /// </summary>
        /// <returns>Object tostring.</returns>
        string GetAllContentsFromTable();

        /// <summary>
        /// Gives back if the element exists or not.
        /// </summary>
        /// <param name="id">ID of the object.</param>
        /// <returns>If it exists, true.</returns>
        bool IsExists(int id);

        /// <summary>
        /// Removes an object from the db.
        /// </summary>
        /// <param name="id">ID of the object.</param>
        /// <returns>Gives back true, if it was succesful.</returns>
        bool Remove(int id);
    }
}

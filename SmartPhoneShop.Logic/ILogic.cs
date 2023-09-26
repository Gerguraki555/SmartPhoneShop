// <copyright file="ILogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SmartPhoneShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using SmartPhoneShop.Repository.NonCrudObjects;

    /// <summary>
    /// Ilogic interface for CRUD and NON-CRUD methods.
    /// </summary>
    public interface ILogic
    {
        /// <summary>
        /// Gets all contents from Brands.
        /// </summary>
        string BrandsContents { get; }

        /// <summary>
        /// Gets all contents from Parameters.
        /// </summary>
        string ParameterssContents { get; }

        /// <summary>
        /// Gets all contents from Types.
        /// </summary>
        string TypesContents { get; }

        /// <summary>
        /// update a Brands object.
        /// </summary>
        /// <param name="id">Id of Brands.</param>
        /// <param name="brandname">name of brands.</param>
        /// <param name="counry">country of brands.</param>
        /// <param name="popularity">popularity of brands.</param>
        /// <param name="totalincome">totalincome of brands.</param>
        /// <returns>True if updated, false or not.</returns>
        bool UpdateBrands(int id, string brandname, string counry, int popularity, int totalincome);

        /// <summary>
        /// update a Parameters object.
        /// </summary>
        /// <param name="id">Id of Parameters.</param>
        /// <param name="name">name of Parameters.</param>
        /// <param name="halfprice">halfprice of Parameters.</param>
        /// <param name="ram">ram of Parameters.</param>
        /// <param name="rom">rom of Parameters.</param>
        /// <param name="tipid">typeid of Parameters.</param>
        /// <returns>True if updated, false or not.</returns>
        bool UpdateParameters(int id, string name, int halfprice, int ram, int rom, int tipid);

        /// <summary>
        /// update a Parameters object.
        /// </summary>
        /// <param name="id">Id of Parameters.</param>
        /// <param name="brandid">name of Parameters.</param>
        /// <param name="modelname">halfprice of Parameters.</param>
        /// <param name="rating">ram of Parameters.</param>
        /// <param name="starterprice">rom of Parameters.</param>
        /// <returns>True if updated, false or not.</returns>
        bool UpdateTypes(int id, int brandid, string modelname, int rating, int starterprice);

        /// <summary>
        /// update a Types object.
        /// </summary>
        /// <param name="brandname">name of Brands.</param>
        /// <param name="counry">Country of Brands.</param>
        /// <param name="popularity">popularity of Brands.</param>
        /// <param name="totalincome">totalincome of Brands.</param>
        /// <returns>True if updated, false or not.</returns>
        bool AddBrands(string brandname, string counry, int popularity, int totalincome);

        /// <summary>
        /// Add a Parameters object.
        /// </summary>
        /// <param name="name">name of Parameters.</param>
        /// <param name="halfprice">halfprice of Parameters.</param>
        /// <param name="ram">ram of Parameters.</param>
        /// <param name="rom">rom of Parameters.</param>
        /// <param name="tipid">typeid of Parameters.</param>
        /// <returns>True if updated, false or not.</returns>
        bool AddParameters(string name, int halfprice, int ram, int rom, int tipid);

        /// <summary>
        /// Add a Types object.
        /// </summary>
        /// <param name="brandid">name of Types.</param>
        /// <param name="modelname">halfprice of Types.</param>
        /// <param name="rating">ram of Types.</param>
        /// <param name="starterprice">rom of Types.</param>
        /// <returns>True if updated, false or not.</returns>
        bool AddTypes(int brandid, string modelname, int rating, int starterprice);

        /// <summary>
        /// delete a Brands object.
        /// </summary>
        /// <param name="id">Id of Brands.</param>
        void RemoveBrands(int id);

        /// <summary>
        /// delete a Types object.
        /// </summary>
        /// <param name="id">Id of Types.</param>
        void RemoveTypes(int id);

        /// <summary>
        /// delete a Parameters object.
        /// </summary>
        /// <param name="id">Id of Parameters.</param>
        void RemoveParameters(int id);

        /// <summary>
        /// Gives a Brands object.
        /// </summary>
        /// <param name="id">Id of Types.</param>
        /// <returns>Brands tostring.</returns>
        object Getbrandsbyid(int id);

        /// <summary>
        /// Gives a Types object.
        /// </summary>
        /// <param name="id">Id of Types.</param>
        /// <returns>Types tostring.</returns>
        object Gettypesbyid(int id);

        /// <summary>
        /// Gives a Parameters object.
        /// </summary>
        /// <param name="id">Id of Parameters.</param>
        /// <returns>Parameters tostring.</returns>
        object Getparametersbyid(int id);

        /// <summary>
        /// Gives back if the Type object is exits with this id exists.
        /// </summary>
        /// <param name="id">Id of Brands.</param>
        /// <returns>True if it exists, false or not.</returns>
        bool BrandsIsExits(int id);

        /// <summary>
        /// Gives back if the Type object is exits with this id exists.
        /// </summary>
        /// <param name="id">Id of Types.</param>
        /// <returns>True if it exists, false or not.</returns>
        bool TypesIsExits(int id);

        /// <summary>
        /// Gives back if the Type object is exits with this id exists.
        /// </summary>
        /// <param name="id">Id of Parameters.</param>
        /// <returns>True if it exists, false or not.</returns>
        bool ParametersIsExits(int id);

        /// <summary>
        /// Return types and using Brandname.
        /// </summary>
        /// <param name="brandname">name of Brands object.</param>
        /// <returns>Icollection with objects.</returns>
        ICollection<NonCrudType> FindTypeByBrandName(string brandname);
    }
}

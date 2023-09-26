// <copyright file="DbMethods.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SmartPhoneShop.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SmartPhoneShop.Data.Models;

    /// <summary>
    /// implements db methods.
    /// </summary>
    public static class DbMethods
    {
        /// <summary>
        /// Add a Brands object in database.
        /// </summary>
        /// <param name="brand">an brand object.</param>
        public static void AddBrands(Brands brand)
        {
            DataContext.Brands.Add(brand);
        }

        /// <summary>
        /// Remove a Brands object in database.
        /// </summary>
        /// <param name="brand">an brand object.</param>
        public static void RemoveBrands(Brands brand)
        {
            DataContext.Brands.Remove(brand);
        }

        /// <summary>
        /// Add a Parameters object in database.
        /// </summary>
        /// <param name="para">an parameters object.</param>
        public static void AddParameters(Parameters para)
        {
            DataContext.Parameters.Add(para);
        }

        /// <summary>
        /// Remove a Parameters object in database.
        /// </summary>
        /// <param name="para">an parameters object.</param>
        public static void RemoveParameters(Parameters para)
        {
            DataContext.Parameters.Remove(para);
        }

        /// <summary>
        /// Add a Types object in database.
        /// </summary>
        /// <param name="typ">an types object.</param>
        public static void AddTypes(Types typ)
        {
            DataContext.Types.Add(typ);
        }

        /// <summary>
        /// Remove a Types object in database.
        /// </summary>
        /// <param name="typ">an types object.</param>
        public static void RemoveTypes(Types typ)
        {
            DataContext.Types.Remove(typ);
        }

        /// <summary>
        /// Gets or sets this is the Database context.
        /// </summary>
        public static DatabaseContext DataContext { get; set; } = new DatabaseContext();

        /// <summary>
        /// Gets the contents of the table Brands.
        /// </summary>
        public static List<Brands> Brands
        {
            get { return DataContext.Brands.Select(x => x).ToList(); }
        }

        /// <summary>
        /// Gets the contents of the table Parameters.
        /// </summary>
        public static List<Parameters> Parameters
        {
            get { return DataContext.Parameters.Select(x => x).ToList(); }
        }

        /// <summary>
        /// Gets the contents of the table Types.
        /// </summary>
        public static List<Types> Types
        {
            get { return DataContext.Types.Select(x => x).ToList(); }
        }

        /// <summary>
        /// Returns a Brands object from database.
        /// </summary>
        /// <param name="id">Brands ID.</param>
        /// <returns>Brands entity.</returns>
        public static Brands GetBrandsbyId(int id)
        {
            return Brands.Where(x => x.Id == id).Select(x => x).First();
        }

        /// <summary>
        /// Returns a Parameters object from database.
        /// </summary>
        /// <param name="id">Parameters ID.</param>
        /// <returns>Parameters entity.</returns>
        public static Parameters GetParametersbyId(int id)
        {
            return Parameters.Where(x => x.Id == id).Select(x => x).First();
        }

        /// <summary>
        /// Returns a Types object from database.
        /// </summary>
        /// <param name="id">Types ID.</param>
        /// <returns>Types entity.</returns>
        public static Types GetTypesbyId(int id)
        {
            return Types.Where(x => x.Id == id).Select(x => x).First();
        }

        /// <summary>
        /// SaveAll.
        /// </summary>
        public static void SaveAll()
        {
            DataContext.SaveChanges();
        }
    }
}

// <copyright file="NonCrudParameter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SmartPhoneShop.Logic.NonCrudObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// NonCrudParameter class.
    /// </summary>
    public class NonCrudParameter
    {
        /// <summary>
        /// Gets or sets iD of Parameters.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Name of Parameters.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets half price of Parameters.
        /// </summary>
        public int HalfPrice { get; set; }

        /// <summary>
        /// Gets or sets ram of Parameters.
        /// </summary>
        public int Ram { get; set; }

        /// <summary>
        /// Gets or sets rom of Parameters.
        /// </summary>
        public int Rom { get; set; }

        /// <summary>
        /// Gets or sets TypeiD of Parameters.
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NonCrudParameter"/> class.
        /// </summary>
        /// <param name="id"> id of NonCrudParameter.</param>
        /// <param name="name">name of NonCrudParameter.</param>
        /// <param name="halfprice">halfprice of NonCrudParameter.</param>
        /// <param name="ram">ram of NonCrudParameter.</param>
        /// <param name="rom">rom of NonCrudParameter.</param>
        /// <param name="typeid">typeid of NonCrudParameter.</param>
        public NonCrudParameter(int id, string name, int halfprice, int ram, int rom, int typeid)
        {
            this.Id = id;
            this.Name = name;
            this.HalfPrice = halfprice;
            this.Ram = ram;
            this.Rom = rom;
            this.TypeId = typeid;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "Id: " + this.Id + " Name: " + this.Name + " HalfPrice: " + this.HalfPrice + " Ram: " + this.Ram + " Rom: " + this.Rom + " Type_ID: " + this.TypeId;
        }
    }
}

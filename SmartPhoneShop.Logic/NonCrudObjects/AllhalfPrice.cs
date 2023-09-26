// <copyright file="AllhalfPrice.cs" company="PlaceholderCompany">
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
    /// AllhalfPrice class.
    /// </summary>
    public class AllhalfPrice
    {
        /// <summary>
        /// Gets or sets Name of Brands.
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// Gets or sets Average rating of Brands.
        /// </summary>
        public double Halfprice { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AllhalfPrice"/> class.
        /// </summary>
        /// <param name="name"> Name of types..</param>
        /// <param name="halfprice"> halfprice of parameters.</param>
        public AllhalfPrice(string name, double halfprice)
        {
            this.BrandName = name;
            this.Halfprice = halfprice;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "Modelname: " + this.BrandName + " Halfprice: " + this.Halfprice;
        }
    }
}

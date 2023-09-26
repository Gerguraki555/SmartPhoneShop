// <copyright file="BrandRating.cs" company="PlaceholderCompany">
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
    /// BrandTypeRating class.
    /// </summary>
    public class BrandRating
    {
        /// <summary>
        /// Gets or sets Name of Brands.
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// Gets or sets Average rating of Brands.
        /// </summary>
        public double Rating { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BrandRating"/> class.
        /// </summary>
        /// <param name="name"> Name of brands.</param>
        /// <param name="rate"> Name of types.</param>
        public BrandRating(string name, double rate)
        {
            this.BrandName = name;
            this.Rating = rate;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "Name: " + this.BrandName + " Average rating: " + this.Rating;
        }
    }
}

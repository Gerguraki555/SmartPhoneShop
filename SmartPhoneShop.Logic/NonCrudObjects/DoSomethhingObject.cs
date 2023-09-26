// <copyright file="DoSomethhingObject.cs" company="PlaceholderCompany">
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
    /// DoSomethhingObject class.
    /// </summary>
    public class DoSomethhingObject
    {
        /// <summary>
        /// Gets or sets Name of Brands.
        /// </summary>
        public string Brandname { get; set; }

        /// <summary>
        /// Gets or sets Country of Brands.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets Total Income of Brands.
        /// </summary>
        public int TotalIncome { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DoSomethhingObject"/> class.
        /// </summary>
        /// <param name="brandname"> Name of brands.</param>
        /// <param name="country"> Country of brands.</param>
        /// <param name="totalincome"> Total income of brands.</param>
        public DoSomethhingObject(string brandname, string country, int totalincome)
        {
            this.Brandname = brandname;
            this.Country = country;
            this.TotalIncome = totalincome;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "Brandname: " + this.Brandname + "Country: " + this.Country + "Total Income: " + this.TotalIncome;
        }
    }
}

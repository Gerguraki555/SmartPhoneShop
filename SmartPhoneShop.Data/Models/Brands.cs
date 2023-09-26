// <copyright file="Brands.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SmartPhoneShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    /// <summary>
    /// Class of Brands.
    /// </summary>
    [Table("Brands")]
    public class Brands
    {
        /// <summary>
        /// Gets or sets iD of Brands.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Name of Brands.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string BrandName { get; set; }

        /// <summary>
        /// Gets or sets Country of Brands.
        /// </summary>
        [Required]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets Popularity of Brands.
        /// </summary>
        [Required]
        public int Popularity { get; set; }

        /// <summary>
        /// Gets or sets Total Income of Brands.
        /// </summary>
        [Required]
        public int TotalIncome { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "ID: " + this.Id + " Brand: " + this.BrandName + " Country: " + this.Country + " Popularity: " + this.Popularity + " Total Income: " + this.TotalIncome;
        }
    }
}

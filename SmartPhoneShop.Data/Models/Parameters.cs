// <copyright file="Parameters.cs" company="PlaceholderCompany">
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
    [Table("Parameters")]
    public class Parameters
    {
        /// <summary>
        /// Gets or sets iD of Parameters.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Name of Parameters.
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets half price of Parameters.
        /// </summary>
        [Required]
        public int HalfPrice { get; set; }

        /// <summary>
        /// Gets or sets ram of Parameters.
        /// </summary>
        [Required]
        public int Ram { get; set; }

        /// <summary>
        /// Gets or sets rom of Parameters.
        /// </summary>
        [Required]
        public int Rom { get; set; }

        /// <summary>
        /// Gets or sets TypeiD of Parameters.
        /// </summary>
        [ForeignKey(nameof(Type))]
        [Required]
        public int TypeId { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "ID: " + this.Id + " Name: " + this.Name + " HalfPrice: " + this.HalfPrice + " Ram: " + this.Ram + " Rom: " + this.Rom + " Type_ID: " + this.TypeId;
        }
    }
}

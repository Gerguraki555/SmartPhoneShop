// <copyright file="Types.cs" company="PlaceholderCompany">
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
    /// Class of Types.
    /// </summary>
    [Table("Types")]
    public class Types
    {
        /// <summary>
        /// Gets or sets iD of Types.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets BrandId of Types.
        /// </summary>
        [ForeignKey(nameof(Brands))]
        [Required]
        public int BrandId { get; set; }

        /// <summary>
        /// Gets or sets Model name of Types.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string ModelName { get; set; }

        /// <summary>
        /// Gets or sets rating of Types.
        /// </summary>
        [Required]
        public int Rating { get; set; }

        /// <summary>
        /// Gets or sets starter price of Types.
        /// </summary>
        [Required]
        public int StarterPrice { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "ID: " + this.Id + " BrandId: " + this.BrandId + " Model Name: " + this.ModelName + " Rating: " + this.Rating + " Starter Price: " + this.StarterPrice;
        }
    }
}

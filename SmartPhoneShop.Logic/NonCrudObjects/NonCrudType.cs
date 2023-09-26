// <copyright file="NonCrudType.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SmartPhoneShop.Repository.NonCrudObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// NonCrudType class for non crud methods.
    /// </summary>
    public class NonCrudType
    {
        /// <summary>
        /// Gets or sets iD of Types.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Brandid of Types.
        /// </summary>
        public int Brandid { get; set; }

        /// <summary>
        /// Gets or sets ModelName of Types.
        /// </summary>
        public string Modelname { get; set; }

        /// <summary>
        /// Gets or sets Rating of Types.
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Gets or sets StarterPrice of Types.
        /// </summary>
        public int StarterPrice { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NonCrudType"/> class.
        /// </summary>
        /// <param name="id"> Id of NoncrudType.</param>
        /// <param name="brandid">brandid of NoncrudType.</param>
        /// <param name="modelname">modelname of NoncrudType.</param>
        /// <param name="rating">rating of NoncrudType.</param>
        /// <param name="starterprice">starterprice of NoncrudType.</param>
        public NonCrudType(int id, int brandid, string modelname, int rating, int starterprice)
        {
            this.Id = id;
            this.Brandid = brandid;
            this.Modelname = modelname;
            this.Rating = rating;
            this.StarterPrice = starterprice;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "ID: " + this.Id + " BrandId: " + this.Brandid + " Model Name: " + this.Modelname + " Rating: " + this.Rating + " Starter Price: " + this.StarterPrice;
        }
    }
}

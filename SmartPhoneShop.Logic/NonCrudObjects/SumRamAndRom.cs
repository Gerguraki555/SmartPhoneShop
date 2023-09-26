// <copyright file="SumRamAndRom.cs" company="PlaceholderCompany">
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
    /// SumRamAndRom class.
    /// </summary>
    public class SumRamAndRom
    {
        /// <summary>
        /// Gets or sets Name of Brands.
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// Gets or sets ram of parameter.
        /// </summary>
        public double Ram { get; set; }

        /// <summary>
        /// Gets or sets rom of parameter.
        /// </summary>
        public double Rom { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SumRamAndRom"/> class.
        /// </summary>
        /// <param name="name"> Name of types..</param>
        /// <param name="ram"> ram of parameters.</param>
        /// <param name="rom"> rom of parameters.</param>
        public SumRamAndRom(string name, double ram, double rom)
        {
            this.BrandName = name;
            this.Ram = ram;
            this.Rom = rom;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "Modelname: " + this.BrandName + " Ram: " + this.Ram + " Rom: " + this.Rom;
        }
    }
}

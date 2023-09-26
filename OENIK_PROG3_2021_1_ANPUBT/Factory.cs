// <copyright file="Factory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SmartPhoneShop.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SmartPhoneShop.Data.Models;
    using SmartPhoneShop.Logic;
    using SmartPhoneShop.Repository;

    /// <summary>
    /// SmartPhoneShop Factory class.
    /// </summary>
    public class Factory
    {
        private readonly DatabaseContext ctx;

        private BrandRepository brands;

        private TypesRepository types;

        private ParametersRepository parameters;

        /// <summary>
        /// Business logic object.
        /// </summary>
        private Blogic log;

        /// <summary>
        /// Initializes a new instance of the <see cref="Factory"/> class.
        /// </summary>
        public Factory()
        {
            this.ctx = new DatabaseContext();
            this.brands = new BrandRepository(this.ctx);
            this.types = new TypesRepository(this.ctx);
            this.parameters = new ParametersRepository(this.ctx);
            this.log = new Blogic(this.brands, this.types, this.parameters);
        }

        /// <summary>
        /// Return the BLogic object.
        /// </summary>
        /// <returns>Blogic object.</returns>
        public Blogic GetLog()
        {
            return this.log;
        }
    }
}

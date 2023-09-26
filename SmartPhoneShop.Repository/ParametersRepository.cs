// <copyright file="ParametersRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SmartPhoneShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SmartPhoneShop.Data;
    using SmartPhoneShop.Data.Models;
    using SmartPhoneShop.Repository.Interfaces;

    /// <summary>
    /// ParametersRepository. Implements Irepository interface.
    /// </summary>
    public class ParametersRepository : IParametersRepository, IRepository<Parameters>
    {
        private DatabaseContext ctx;

        /// <summary>
        /// Gets get all contents from Parameters table.
        /// </summary>
        /// <returns>object tostring.</returns>
        public virtual string GetAllContentsFromTable()
        {
            string allcontents = string.Empty;
            foreach (var item in DbMethods.Parameters)
            {
                allcontents = allcontents + "ID: " + item.Id + " Name: " + item.Name + " Halfprice: " + item.HalfPrice + " Ram: " + item.Ram + " Rom: " + item.Rom + " TypeId: " + item.TypeId;
            }

            return allcontents;
        }

        /// <summary>
        /// Gets every Parameters.
        /// </summary>
        /// <returns>object.</returns>
        public virtual IQueryable<Parameters> Getall()
        {
            return DbMethods.Parameters.AsQueryable();
        }

        /// <summary>
        /// Gets every data from Types.
        /// </summary>
        public virtual IQueryable<Parameters> All
        {
            get
            {
                return DbMethods.Parameters.AsQueryable();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParametersRepository"/> class.
        /// </summary>
        /// <param name="ctx">injected ParametersRepository collection.</param>
        public ParametersRepository(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }

        /// <summary>
        /// Gives back a Parameter object from database.
        /// </summary>
        /// <param name="id">Parameter id.</param>
        /// <returns>A Parameter object.</returns>
        public Parameters GetOne(int id)
        {
            Parameters para = DbMethods.GetParametersbyId(id);
            return para;
        }

        /// <summary>
        /// Gives back a Parameters.Tostring() from database.
        /// </summary>
        /// <param name="id">Brands id.</param>
        /// <returns>A Parameter object.</returns>
        public virtual string GetParametersTostringbyId(int id)
        {
            Parameters para = DbMethods.GetParametersbyId(id);
            return para.ToString();
        }

        /// <summary>
        /// Returns true if the Parameters object is exists.
        /// </summary>
        /// <param name="id">Parameters Id.</param>
        /// <returns>True if exists, or false not exists.</returns>
        public virtual bool IsExists(int id)
        {
            return DbMethods.Parameters.Any(x => x.Id == id);
        }

        /// <summary>
        /// Delete a Parameters object from database.
        /// </summary>
        /// <param name="id">id of Parameters object.</param>
        /// <returns>True if removed, or false not removed.</returns>
        public virtual bool Remove(int id)
        {
            List<Parameters> parameterslist = DbMethods.Parameters.Where(x => x.Id == id).Select(x => x).ToList();
            if (parameterslist.Count > 0)
            {
                DbMethods.RemoveParameters(parameterslist.First());
                DbMethods.SaveAll();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Add a Parameters object to database.
        /// </summary>
        /// <param name="paraname">name of Parameters object.</param>
        /// <param name="halfprice">HalfPrice of Brands object.</param>
        /// <param name="ram">Ram of Brands object.</param>
        /// <param name="rom">Rom of Brands object.</param>
        /// <param name="typeid">TyypeId of Brands object.</param>
        /// <returns>True if added, or false not added.</returns>
        public virtual bool Addaparameter(string paraname, int halfprice, int ram, int rom, int typeid)
        {
            {
                Parameters para = new Parameters()
                {
                    Name = paraname,
                    HalfPrice = halfprice,
                    Ram = ram,
                    Rom = rom,
                    TypeId = typeid,
                };
                DbMethods.AddParameters(para);
                DbMethods.SaveAll();
                return true;
            }
        }

        /// <summary>
        /// update a Parameters object to database.
        /// </summary>
        /// <param name="paraid">id of Parameters object.</param>
        /// <param name="paraname">name of Parameters object.</param>
        /// <param name="halfprice">HalfPrice of Brands object.</param>
        /// <param name="ram">Ram of Brands object.</param>
        /// <param name="rom">Rom of Brands object.</param>
        /// <param name="typeid">TyypeId of Brands object.</param>
        /// <returns>True if added, or false not added.</returns>
        public virtual bool UpdateParameters(int paraid, string paraname, int halfprice, int ram, int rom, int typeid)
        {
            List<Parameters> paralist = DbMethods.Parameters.Where(x => x.Id == paraid).Select(x => x).ToList();
            if (paralist.Count > 0)
            {
                Parameters update = paralist.First();
                update.Name = paraname;
                update.HalfPrice = halfprice;
                update.Ram = ram;
                update.Rom = rom;
                update.TypeId = typeid;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

// <copyright file="TypesRepository.cs" company="PlaceholderCompany">
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

    /// <summary>
    /// Repository of Types.
    /// </summary>
    public class TypesRepository : ITypesRepository, IRepository<Types>
    {
        private DatabaseContext ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="TypesRepository"/> class.
        /// </summary>
        /// <param name="ctx">injected TypesRepository collection.</param>
        public TypesRepository(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }

        /// <summary>
        /// Gets get all contents from Types table.
        /// </summary>
        /// <returns>object tostring.</returns>
        public virtual string GetAllContentsFromTable()
        {
            string allcontents = string.Empty;
            foreach (var item in DbMethods.Types)
            {
                allcontents = allcontents + "ID: " + item.Id + " BrandId: " + item.BrandId + " Model Name: " + item.ModelName + " Rating: " + item.Rating + " Starter Price: " + item.StarterPrice;
            }

            return allcontents;
        }

        /// <summary>
        /// Gets every Types.
        /// </summary>
        /// <returns>object.</returns>
        public virtual IQueryable<Types> Getall()
        {
            return DbMethods.Types.AsQueryable();
        }

        /// <summary>
        /// Gives back a Type object from database.
        /// </summary>
        /// <param name="id">Type id.</param>
        /// <returns>A Type object.</returns>
        public Types GetOne(int id)
        {
            Types tip = DbMethods.GetTypesbyId(id);
            return tip;
        }

        /// <summary>
        /// Gives back a Types.Tostring() from database.
        /// </summary>
        /// <param name="id">Types id.</param>
        /// <returns>A Type object.</returns>
        public virtual string GetTypesTostringbyId(int id)
        {
            Types tip = DbMethods.GetTypesbyId(id);
            return tip.ToString();
        }

        /// <summary>
        /// Returns true if the Types object is exists.
        /// </summary>
        /// <param name="id">Types Id.</param>
        /// <returns>True if exists, or false not exists.</returns>
        public virtual bool IsExists(int id)
        {
            return DbMethods.Types.Any(x => x.Id == id);
        }

        /// <summary>
        /// Delete a Types object from database.
        /// </summary>
        /// <param name="id">id of Types object.</param>
        /// <returns>True if removed, or false not removed.</returns>
        public virtual bool Remove(int id)
        {
            List<Types> tiplist = DbMethods.Types.Where(x => x.Id == id).Select(x => x).ToList();
            if (tiplist.Count > 0)
            {
                DbMethods.RemoveTypes(tiplist.First());
                DbMethods.SaveAll();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Add a Types object to database.
        /// </summary>
        /// <param name="brandid">name of Parameters object.</param>
        /// <param name="modelname">HalfPrice of Brands object.</param>
        /// <param name="rating">Ram of Brands object.</param>
        /// <param name="starterprice">Rom of Brands object.</param>
        /// <returns>True if added, or false not added.</returns>
        public virtual bool AddType(int brandid, string modelname, int rating, int starterprice)
        {
            {
                Types tip = new Types()
                {
                    BrandId = brandid,
                    ModelName = modelname,
                    Rating = rating,
                    StarterPrice = starterprice,
                };
                DbMethods.AddTypes(tip);
                DbMethods.SaveAll();
                return true;
            }
        }

        /// <summary>
        /// Gets every data from Types.
        /// </summary>
        public virtual IQueryable<Types> All
        {
            get
            {
                return DbMethods.Types.AsQueryable();
            }
        }

        /// <summary>
        /// Add a Types object to database.
        /// </summary>
        /// <param name="tipid">id of Types object.</param>,0
        /// <param name="brandid">Brand id of Types object.</param>
        /// <param name="modelname">Name of Types object.</param>
        /// <param name="rating">Rating of Types object.</param>
        /// <param name="starterprice">Price of Types object.</param>
        /// <returns>True if added, or false not added.</returns>
        public virtual bool UpdateTypes(int tipid, int brandid, string modelname, int rating, int starterprice)
        {
            List<Types> tiplist = DbMethods.Types.Where(x => x.Id == tipid).Select(x => x).ToList();
            if (tiplist.Count > 0)
            {
                Types update = tiplist.First();
                update.BrandId = brandid;
                update.ModelName = modelname;
                update.Rating = rating;
                update.StarterPrice = starterprice;
                DbMethods.SaveAll();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

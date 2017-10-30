using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hogia.SkeletonWeb.Web.App.src.services.homes
{
    public class RegionModel
    {
        public virtual Guid Id { get; set; }
        public virtual string RegionName { get; set; }
        public virtual ICollection<CityModel> Cities { get; set; }
    }
}
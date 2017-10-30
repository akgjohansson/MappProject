using System;
using System.Collections.Generic;

namespace Hogia.SkeletonWeb.Web.App.src.services.homes
{
    public class CityModel
    {
        public virtual Guid Id { get; set; }
        public virtual string CityName { get; set; }
        public virtual ICollection<AddressModel> Address { get; set; }
        public virtual RegionModel Region { get; set; }
    }
}
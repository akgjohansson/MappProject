using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hogia.SkeletonWeb.Web.App.src.services.homes
{
  public class AddressModel
  {
    public virtual Guid Id { get; set; }
    public virtual string StreetAddress { get; set; }
    public virtual string StreetNumber { get; set; }
    public virtual string ZipCode { get; set; }
    public virtual CityModel City { get; set; }
    public virtual ICollection<HomesModel> Homes{ get; set; }
  }
}
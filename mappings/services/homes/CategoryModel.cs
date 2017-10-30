using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hogia.SkeletonWeb.Web.App.src.services.homes
{
  public class CategoryModel
  {
    public virtual Guid Id { get; set; }
    public virtual string CategoryName { get; set; }
    public virtual ICollection<HomesModel> Homes { get; set; }
  }
}
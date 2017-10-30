using System;

namespace Hogia.SkeletonWeb.Web.App.src.services.homes
{
  public class HomesModel
  {
    public virtual Guid Id { get; set; }
    public virtual DateTime AvailableFrom { get; set; }
    public virtual string Description { get; set; }
    public virtual CategoryModel Category { get; set; }
    public virtual AddressModel Address { get; set; }
    public virtual float Rating { get; set; }
    public virtual string ImgUrl { get; set; }
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;

namespace Hogia.SkeletonWeb.Web.App.src.services.homes
{
    public class Mapper
    {
        private readonly ModelMapper _modelMapper;

        public Mapper()
        {
            _modelMapper = new ModelMapper();
        }
        public HbmMapping Map()
        {
            MapHome();
            MapAddress();
            MapCategory();
            MapCity();
            MapRegion();
            return _modelMapper.CompileMappingForAllExplicitlyAddedEntities();
        }

        private void MapRegion()
        {
            _modelMapper.Class<RegionModel>(e =>
            {
                e.Id(p => p.Id, p => p.Generator(Generators.GuidComb));
                e.Property(p => p.RegionName);
                e.Set(p => p.Cities, p =>
                {
                    p.Cascade(Cascade.All);
                    p.Inverse(true);
                    p.Key(k => k.Column(col => col.Name("CityId")));
                }, p => p.OneToMany());
            });
        }

        private void MapCity()
        {
            _modelMapper.Class<CityModel>(e =>
            {
                e.Id(p => p.Id, p => p.Generator(Generators.GuidComb));
                e.Property(p => p.CityName);
                e.Set(p => p.Address, p =>
                {
                    p.Cascade(Cascade.All);
                    p.Inverse(true);
                    p.Key(k => k.Column(col => col.Name("CityId")));
                }, p => p.OneToMany());
                e.ManyToOne(p => p.Region, mapper =>
                {
                    mapper.Column("Id");
                    mapper.NotNullable(true);
                    mapper.Cascade(Cascade.None);
                });
            });
        }

        private void MapCategory()
        {
            _modelMapper.Class<CategoryModel>(e =>
            {
                e.Id(p => p.Id, p => p.Generator(Generators.GuidComb));
                e.Property(p => p.CategoryName);
                e.Set(p => p.Homes, p =>
                {
                    p.Cascade(Cascade.All);
                    p.Inverse(true);
                    p.Key(k => k.Column(col => col.Name("CategoryId")));
                }, p => p.OneToMany());
            });
        }

        private void MapAddress()
        {
            _modelMapper.Class<AddressModel>(e =>
            {
                e.Id(p => p.Id, p => p.Generator(Generators.GuidComb));
                e.Property(p => p.StreetAddress);
                e.Property(p => p.StreetNumber);
                e.Property(p => p.ZipCode);
                e.Set(p => p.Homes, p =>
                {
                    p.Cascade(Cascade.All);
                    p.Inverse(true);
                    p.Key(k => k.Column(col => col.Name("AddressId")));
                }, p => p.OneToMany());
                e.ManyToOne(p => p.City, mapper =>
                {
                    mapper.Column("Id");
                    mapper.NotNullable(true);
                    mapper.Cascade(Cascade.None);
                });
            });
        }

        private void MapHome()
        {
            _modelMapper.Class<HomesModel>(e =>
            {
                e.Id(p => p.Id, p => p.Generator(Generators.GuidComb));
                e.Property(p => p.Description);
                e.Property(p => p.AvailableFrom);
                e.Property(p => p.ImgUrl);
                e.Property(p => p.Rating);
                e.ManyToOne(p => p.Address, mapper =>
                {
                    mapper.Column("Id");
                    mapper.NotNullable(true);
                    mapper.Cascade(Cascade.None);
                });
                e.ManyToOne(p => p.Category, mapper =>
                {
                    mapper.Column("Id");
                    mapper.NotNullable(true);
                    mapper.Cascade(Cascade.None);
                });
            });
        }
    }
}
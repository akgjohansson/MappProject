using Hogia.Infrastructure.OpenIdConnect.Cache;
using Hogia.SkeletonWeb.Web.Infrastructure;
using Hogia.SkeletonWeb.Web.Infrastructure.CustomActionResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Hogia.SkeletonWeb.Web.App.src.services.homes
{
    public class HomesController : Controller
    {
        private readonly IProviderInformationCache _providerInformationCache;
        private readonly Settings _settings;

        // Mock regions
        static List<RegionModel> regions = new List<RegionModel>{
            new RegionModel
            {
                Id = Guid.NewGuid(),
                RegionName = "Dalarna"
            },
            new RegionModel
            {
                Id = Guid.NewGuid(),
                RegionName = "Bohuslän"
            },
            new RegionModel
            {
                Id = Guid.NewGuid(),
                RegionName = "Västra Götaland"
            },
            new RegionModel
            {
                Id = Guid.NewGuid(),
                RegionName = "Halland"
            }
        };

        // Mock categories
        static List<CategoryModel> categories = new List<CategoryModel>{
            new CategoryModel
            {
                Id = Guid.NewGuid(),
                CategoryName = "Radhus"
            },
            new CategoryModel
            {
                Id = Guid.NewGuid(),
                CategoryName = "Villa"
            },
            new CategoryModel
            {
                Id = Guid.NewGuid(),
                CategoryName = "Lägenhet"
            },
            new CategoryModel
            {
                Id = Guid.NewGuid(),
                CategoryName = "Koja"
            }
        };

        // Mock cities
        static List<CityModel> cities = new List<CityModel>{
            new CityModel
            {
                Id = Guid.NewGuid(),
                CityName = "Grönköping",
                Region = regions[0]
            },
            new CityModel
            {
                Id = Guid.NewGuid(),
                CityName = "Dingle",
                Region = regions[1]
            },
            new CityModel
            {
                Id = Guid.NewGuid(),
                CityName = "Lysekil",
                Region = regions[1]
            },
            new CityModel
            {
                Id = Guid.NewGuid(),
                CityName = "Smögen",
                Region = regions[1]
            },
            new CityModel
            {
                Id = Guid.NewGuid(),
                CityName = "Stenungsund",
                Region = regions[1]
            },
            new CityModel
            {
                Id = Guid.NewGuid(),
                CityName = "Göteborg",
                Region = regions[2]
            },
            new CityModel
            {
                Id = Guid.NewGuid(),
                CityName = "Alingsås",
                Region = regions[2]
            },
            new CityModel
            {
                Id = Guid.NewGuid(),
                CityName = "Borås",
                Region = regions[2]
            },
            new CityModel
            {
                Id = Guid.NewGuid(),
                CityName = "Varberg",
                Region = regions[3]
            },
            new CityModel
            {
                Id = Guid.NewGuid(),
                CityName = "Falkenberg",
                Region = regions[3]
            }
        };

        //Mock homes
        static List<HomesModel> homes = new List<HomesModel> {
            new HomesModel
            {
                Id = Guid.NewGuid(),
                Address = new AddressModel
                {
                    Id = Guid.NewGuid(),
                    ZipCode = "436 90",
                    StreetAddress = "Lyckliga gatan",
                    StreetNumber = "45 F",
                    City = cities[0]
                },
                AvailableFrom = DateTime.Now,
                Category = categories[0],
                Description = "Det bästa huset som finns!",
                ImgUrl = "https://falurodfarg.com/app/uploads/2017/04/alx_2704-1024x684.jpg",
                Rating = 4.3f
            },
            new HomesModel
            {
                Id = Guid.NewGuid(),
                Address = new AddressModel
                {
                    Id = Guid.NewGuid(),
                    ZipCode = "459 02",
                    StreetAddress = "Bovallsgatan",
                    StreetNumber = "32",
                    City = cities[1]
                },
                AvailableFrom = Convert.ToDateTime("2017-12-12"),
                Category = categories[1],
                Description = "Bo på landet men ändå nära havet!",
                ImgUrl = "https://shopcdn.textalk.se/shop/578/art78/h2690/21752690-origpic-b19e20.jpg?max-width=353&max-height=353&quality=85",
                Rating = 4.9f
            },
            new HomesModel
            {
                Id = Guid.NewGuid(),
                Address = new AddressModel
                {
                    Id = Guid.NewGuid(),
                    ZipCode = "499 99",
                    StreetAddress = "Bäveån",
                    StreetNumber = "1",
                    City = cities[1]
                },
                AvailableFrom = Convert.ToDateTime("2017-10-20"),
                Category = categories[3],
                Description = "Bo på landet och ha när till systembolaget på samma gång",
                ImgUrl = "https://slm-assets2.secondlife.com/assets/1800441/lightbox/cf63179ba35a03a2dfcb273b096b4bc7.jpg?1278653837",
                Rating = 4.8f
            },
            new HomesModel
            {
                Id = Guid.NewGuid(),
                Address = new AddressModel
                {
                    Id = Guid.NewGuid(),
                    ZipCode = "983 98",
                    StreetAddress = "Paradisäppelvägen",
                    StreetNumber = "313",
                    City = cities[2]
                },
                AvailableFrom = Convert.ToDateTime("2017-10-10"),
                Category = categories[2],
                Description = "Bo i en lägenhet som känns som ett slott",
                ImgUrl = "https://roomly.se/gamla-content/uploads/2014/05/14001708504gn8k.jpg",
                Rating = 3.3f
            },
            new HomesModel
            {
                Id = Guid.NewGuid(),
                Address = new AddressModel
                {
                    Id = Guid.NewGuid(),
                    ZipCode = "237 36",
                    StreetAddress = "Bollgatan",
                    StreetNumber = "23 C",
                    City = cities[3]
                },
                AvailableFrom = Convert.ToDateTime("2018-01-02"),
                Category = categories[3],
                Description = "Har du ingen annan stans att bo och är samtidigt inte så kräsen av dig? Då är detta kojan för dig!",
                ImgUrl = "https://upload.wikimedia.org/wikipedia/commons/5/56/Hamra_national_park_Koja.jpg",
                Rating = 0.3f
            },
            new HomesModel
            {
                Id = Guid.NewGuid(),
                Address = new AddressModel
                {
                    Id = Guid.NewGuid(),
                    ZipCode = "738 11",
                    StreetAddress = "Kungsgatan",
                    StreetNumber = "22 B",
                    City = cities[3]
                },
                AvailableFrom = Convert.ToDateTime("2017-11-18"),
                Category = categories[2],
                Description = "En fin lägenhet med utsikt över kultiverade fält",
                ImgUrl = "https://odis.homeaway.com/odis/listing/5edcb5ad-fe84-4fad-b3c2-7fd3ebf19bd3.c10.jpg",
                Rating = 3.3f
            },
            new HomesModel
            {
                Id = Guid.NewGuid(),
                Address = new AddressModel
                {
                    Id = Guid.NewGuid(),
                    ZipCode = "345 12",
                    StreetAddress = "Drottninggatan",
                    StreetNumber = "9",
                    City = cities[4]
                },
                AvailableFrom = Convert.ToDateTime("2017-10-18"),
                Category = categories[0],
                Description = "Härligt radhus med trevliga grannar som gärna umgås med dig. Det finns gott om utrymme för barn att leka här",
                ImgUrl = "http://www.jarntorget.se/wp-content/uploads/sites/2/2014/11/flyghallen-bilder3.jpg",
                Rating = 4.1f
            },
            new HomesModel
            {
                Id = Guid.NewGuid(),
                Address = new AddressModel
                {
                    Id = Guid.NewGuid(),
                    ZipCode = "231 90",
                    StreetAddress = "Motgången",
                    StreetNumber = "337",
                    City = cities[4]
                },
                AvailableFrom = Convert.ToDateTime("2017-10-22"),
                Category = categories[2],
                Description = "Perfekt etta för den okräsne studenten",
                ImgUrl = "http://www.viivilla.se/globalassets/sweden/gor-det-sjalv/2014/lusthus-och-friggebodar/11-friggebodar-budget-lyx/friggebod-15-2-rum-sorseles.jpg",
                Rating = 2.4f
            },
            new HomesModel
            {
                Id = Guid.NewGuid(),
                Address = new AddressModel
                {
                    Id = Guid.NewGuid(),
                    ZipCode = "879 22",
                    StreetAddress = "Äppelknyckarvägen",
                    StreetNumber = "3",
                    City = cities[5]
                },
                AvailableFrom = Convert.ToDateTime("2017-10-21"),
                Category = categories[1],
                Description = "En villa med fin trädgård för den som gillar att vara nära naturen",
                ImgUrl = "http://static.messynessychic.com/wp-content/uploads/2013/02/mickeystrailer.jpg",
                Rating = 0.1f
            },
            new HomesModel
            {
                Id = Guid.NewGuid(),
                Address = new AddressModel
                {
                    Id = Guid.NewGuid(),
                    ZipCode = "355 44",
                    StreetAddress = "Kaprifolsgatan",
                    StreetNumber = "44",
                    City = cities[5]
                },
                AvailableFrom = Convert.ToDateTime("2017-10-10"),
                Category = categories[0],
                Description = "En perfekt inkvartering för den som vill ha nära till centrum med ändå slippa stöket",
                ImgUrl = "https://upload.wikimedia.org/wikipedia/commons/e/ed/Nydalaviken%2C_Ume%C3%A5_%28radhus%29.JPG",
                Rating = 3.9f
            }
        };

        public HomesController(IProviderInformationCache providerInformationCache, Settings settings)
        {
            _providerInformationCache = providerInformationCache;
            _settings = settings;
        }

        [Route("homes/homes"), HttpGet]
        public ActionResult GetHomes(string match = null)
        {
            return new JsonCamelCaseResult(GetListOfHomes(match));
        }

        [Route("homes/categories"), HttpGet]
        public ActionResult GetCategories(string match = null)
        {
            return new JsonCamelCaseResult(GetListOfCategories(match));
        }

        [Route("homes/regions"), HttpGet]
        public ActionResult GetRegions(string match = null)
        {
            return new JsonCamelCaseResult(GetListOfRegions(match));
        }

        [Route("homes/image"), HttpGet]
        public ActionResult GetImage()
        {
            var output = "hej";
            return new JsonCamelCaseResult(output);
        }

        private List<object> GetListOfHomes(string match)
        {
            List<object> returnList = new List<object>();
            foreach (var home in homes)
            {
                if (IsHomeMatch(home, match))
                {
                    returnList.Add(new
                    {
                        Address = new
                        {
                            home.Address.StreetAddress,
                            home.Address.StreetNumber,
                            home.Address.Id,
                            home.Address.ZipCode,
                            City = new
                            {
                                home.Address.City.CityName,
                                home.Address.City.Id,
                                Region = new
                                {
                                    home.Address.City.Region.RegionName,
                                    home.Address.City.Region.Id
                                }
                            }
                        },
                        home.Id,
                        home.Description,
                        Category = new
                        {
                            home.Category.Id,
                            home.Category.CategoryName
                        },
                        home.ImgUrl,
                        home.Rating,
                        home.AvailableFrom
                    });
                }
            }
            return returnList;
        }

        private List<object> GetListOfRegions(string match)
        {
            List<object> returnList = new List<object>();
            foreach (var region in regions)
            {
                List<object> theseCities = new List<object>();
                foreach (var city in cities)
                {
                    List<object> theseHomes = AddHomesToCityInRegion(match, city);
                    if (region.Id == city.Region.Id)
                    {
                        theseCities.Add(new
                        {
                            city.Id,
                            city.CityName,
                            homes = theseHomes
                        });
                    }
                }

                {
                    returnList.Add(new
                    {
                        region.Id,
                        region.RegionName,
                        Cities = theseCities
                    });
                }
            }
            return returnList;
        }

        private List<object> AddHomesToCityInRegion(string match, CityModel city)
        {
            List<object> theseHomes = new List<object>();
            foreach (var home in homes)
            {
                if (home.Address.City.Id == city.Id)
                {
                    if (IsHomeMatch(home, match))
                        theseHomes.Add(new
                        {
                            home.Id,
                            home.ImgUrl,
                            home.Rating,
                            home.AvailableFrom,
                            home.Description,
                            Address = new
                            {
                                home.Address.Id,
                                home.Address.StreetAddress,
                                home.Address.StreetNumber,
                                home.Address.ZipCode
                            }
                        });
                }
            }

            return theseHomes;
        }

        private object GetListOfCategories(string match)
        {
            var allCategories = new List<object>();
            
            foreach (var category in categories)
            {
                var theseHomes = new List<object>();
                foreach (var home in homes)
                {
                    if (home.Category.Id == category.Id)
                    {
                        if (IsHomeMatch(home, match))
                            theseHomes.Add(new
                            {
                                Address = new
                                {
                                    home.Address.Id,
                                    home.Address.StreetAddress,
                                    home.Address.StreetNumber,
                                    home.Address.ZipCode,
                                    City = new
                                    {
                                        home.Address.City.CityName,
                                        home.Address.City.Id,
                                        Region = new
                                        {
                                            home.Address.City.Region.Id,
                                            home.Address.City.Region.RegionName
                                        }
                                    }
                                },
                                home.AvailableFrom,
                                home.Description,
                                home.Id,
                                home.Rating,
                                home.ImgUrl
                            });
                    }
                }
                allCategories.Add(new
                {
                    category.CategoryName,
                    category.Id,
                    Homes = theseHomes
                });
            }
            return allCategories;
        }

        private bool IsHomeMatch(HomesModel home, string match)
        {
            if (match != null)
            {
                Regex rx = new Regex(match);
                if (rx.IsMatch(home.Address.StreetAddress) || rx.IsMatch(home.Address.City.CityName) || rx.IsMatch(home.Address.City.Region.RegionName) || rx.IsMatch(home.Category.CategoryName))
                {
                    return true;
                }
                return false;
            }
            return true;
        }
    }
}
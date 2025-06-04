using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Core
{
    public class Mapping :Profile
    {
        public Mapping()
        {
            CreateMap<CategoryDTO, Category>().ReverseMap();
            CreateMap<OrderDTO, Order>().ReverseMap();
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<UserDTO, User>().ReverseMap();

        }
    }
}

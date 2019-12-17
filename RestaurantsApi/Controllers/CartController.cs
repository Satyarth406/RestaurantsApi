using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantsDataAccessLayer.Interfaces;

namespace RestaurantsApi.Controllers
{
    [Route("api/restaurants/{restaurantId}/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        public CartController()
        {

        }
    }
}
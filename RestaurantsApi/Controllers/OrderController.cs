using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantsApi.Controllers
{
    [Route("api/restaurants/{restaurantId}/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {

    }
}
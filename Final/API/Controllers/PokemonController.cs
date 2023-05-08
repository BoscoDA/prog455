﻿using Microsoft.AspNetCore.Mvc;
using APIService.Models;
using API.Models.RequestModels;
using APIService.DALs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private PokemonDAL _dal = new PokemonDAL();

        [HttpGet]
        [Route("get-by-id{id}")]
        public PokemonRecordModel GetById(int id)
        {

            var pokemon = _dal.GetById(id);

            return pokemon;

        }
    }
}

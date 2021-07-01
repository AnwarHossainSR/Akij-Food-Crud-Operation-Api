using Akij_Food_Crud_Operation_Api.data;
using Akij_Food_Crud_Operation_Api.IRepository;
using Akij_Food_Crud_Operation_Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akij_Food_Crud_Operation_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColdDrinkController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ColdDrinkController> _logger;
        private readonly IMapper _mapper;

        public ColdDrinkController(IUnitOfWork unitOfWork, ILogger<ColdDrinkController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetColdDrinks()
        {
            try
            {
                var coldDrinks = await _unitOfWork.ColdDrinks.GetAll();
                var results = _mapper.Map<IList<ColdDrinkDTO>>(coldDrinks);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetColdDrinks)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetColdDrink(int id)
        {
            try
            {
                var coldDrink = await _unitOfWork.ColdDrinks.Get(q => q.ColdDrinksId == id);
                var result = _mapper.Map<ColdDrinkDTO>(coldDrink);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetColdDrink)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateColdDrink([FromBody] CreateColdDrinkDTO coldDrinkDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateColdDrink)}");
                return BadRequest(ModelState);
            }

            try
            {
                var coldDrink = _mapper.Map<ColdDrink>(coldDrinkDTO);
                await _unitOfWork.ColdDrinks.Insert(coldDrink);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetColdDrink", new { id = coldDrink.ColdDrinksId }, coldDrink);
            }     
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(CreateColdDrink)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }


        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateColdDrink(int id, [FromBody] UpdateColdDrinkDTO coldDrinkDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateColdDrink)}");
                return BadRequest(ModelState);
            }

            try
            {
                var coldDrink = await _unitOfWork.ColdDrinks.Get(q => q.ColdDrinksId == id);
                if (coldDrink == null)
                {
                    _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateColdDrink)}");
                    return BadRequest("Submitted data is invalid");
                }

                _mapper.Map(coldDrinkDTO, coldDrink);
                _unitOfWork.ColdDrinks.Update(coldDrink);
                await _unitOfWork.Save();

                return StatusCode(204, "Resource Updated Successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(UpdateColdDrink)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }
    }
}

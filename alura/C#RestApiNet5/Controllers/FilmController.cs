using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using C_RestApiNet5.Models;
using C_RestApiNet5.Repositories;
using C_RestApiNet5.Dtos;
using AutoMapper;

namespace C_RestApiNet5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmRepository _repository;
        private readonly IMapper _mapper;

        public FilmsController(IFilmRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        {
            var film = _mapper.Map<ReadFilmDto>(_repository.GetById(id));
            Func<IActionResult> result =  film is not null ? () => Ok(film) : () => NotFound(new { Id = id });

            return result();
        }

        [HttpGet]
        public IActionResult Get() 
        {
           return Ok(_mapper.Map<IEnumerable<ReadFilmDto>>(_repository.GetAll()));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateFilmDto filmDto)
        {
            var film = _mapper.Map<Film>(filmDto);

            Func<IActionResult> result =  _repository.Create(film) 
                ? () => CreatedAtAction(nameof(Get), new { Id = film.Id }, film)
                : () => Problem() ;

            return result();
        }

        //O retorno mais condizente com o padrão Rest para uma atualização é o status code 204 (No Content)
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateFilmDto filmDto)
        {
            var updated = _mapper.Map<Film>(filmDto);
            updated.Id = id;

            if(_repository.Update(updated))
                return NoContent();
            
            return NotFound(new { id });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           if(_repository.Delete(id))
                return NoContent();

            return NotFound(new { Id = id });
        }
    }
}
using Azure;
using Azure.Core;
using DiplomskiRad.DapperRepository;
using DiplomskiRad.Exceptions;
using DiplomskiRad.MediatR.Commands.EmisijeDapper;
using DiplomskiRad.MediatR.Commands.EmisijeDapper.DodajEmisiju;
using DiplomskiRad.MediatR.Commands.EmisijeDapper.UkloniEmisiju;
using DiplomskiRad.MediatR.Commands.EmisijeDapper.UkloniListuEmisija;
using DiplomskiRad.MediatR.Queries.EmisijeDapper.DohvatiEmisije;
using DiplomskiRad.MediatR.Queries.EmisijeDapper.DohvatiEmisijuPoId;
using DiplomskiRad.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DiplomskiRad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmisijeDapperController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmisijeDapperController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        public async Task<IActionResult> DohvatiEmisije(string? naziv, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new DohvatiEmisijeRequestDapper(naziv), cancellationToken);
                return Ok(result);
            }
            catch (TaskCanceledException ex) { return StatusCode(499, ex.Message); }
            catch (ArgumentNullException ex) { return StatusCode(500, ex.Message); }
            catch (EntityNotFoundException ex) { return NotFound(ex.Message); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        //[HttpGet("detalji")]
        //public async Task<IActionResult> DohvatiEmisijuPoId(int id, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        var result = await _mediator.Send(new DohvatiEmisijuPoIdRequestDapper(id), cancellationToken);
        //        return Ok(result);
        //    }
        //    catch (TaskCanceledException ex) { return StatusCode(499, ex.Message); }
        //    catch (ArgumentNullException ex) { return StatusCode(500, ex.Message); }
        //    catch (EntityNotFoundException ex) { return NotFound(ex.Message); }
        //    catch (Exception ex) { return BadRequest(ex.Message); }
        //}

        //[HttpPost("dodaj")]
        //public async Task<IActionResult> DodajEmisiju([FromBody] DodajEmisijuRequestDapper emisija)
        //{
        //    try
        //    {
        //        await _mediator.Send(emisija);
        //        return Ok();
        //    }
        //    catch (TaskCanceledException ex) { return StatusCode(499, ex.Message); }
        //    catch (ArgumentNullException ex) { return StatusCode(500, ex.Message); }
        //    catch (EntityNotFoundException ex) { return NotFound(ex.Message); }
        //    catch (Exception ex) { return BadRequest(ex.Message); }
        //}

        //[HttpPut("uredi")]
        //public async Task<IActionResult> UrediEmisiju([FromBody] UrediEmisijuRequestDapper emisija)
        //{
        //    try
        //    {
        //        await _mediator.Send(emisija);
        //        return Ok();
        //    }
        //    catch (ArgumentNullException ex) { return StatusCode(500, ex.Message); }
        //    catch (EntityNotFoundException ex) { return NotFound(ex.Message); }
        //    catch (Exception ex) { return BadRequest(ex.Message); }
        //}

        //[HttpDelete("ukloni")]
        //public async Task<IActionResult> UkloniEmisiju(int id)
        //{
        //    try
        //    {
        //        await _mediator.Send(new UkloniEmisijuRequestDapper(id));
        //        return Ok();
        //    }
        //    catch (ArgumentNullException ex) { return StatusCode(500, ex.Message); }
        //    catch (EntityNotFoundException ex) { return NotFound(ex.Message); }
        //    catch (Exception ex) { return BadRequest(ex.Message); }
        //}

        //[HttpDelete("ukloni-listu")]
        //public async Task<IActionResult> UkloniListuEmisija([FromBody] UkloniListuEmisijaRequestDapper emisije)
        //{
        //    try
        //    {
        //        await _mediator.Send(emisije);
        //        return Ok();
        //    }
        //    catch (ArgumentNullException ex) { return StatusCode(500, ex.Message); }
        //    catch (EntityNotFoundException ex) { return NotFound(ex.Message); }
        //    catch (Exception ex) { return BadRequest(ex.Message); }
        //}
    }
}

using Azure;
using DiplomskiRad.Exceptions;
using DiplomskiRad.MediatR.Commands.EmisijeEFC.DodajEmisiju;
using DiplomskiRad.MediatR.Commands.EmisijeEFC.UkloniEmisiju;
using DiplomskiRad.MediatR.Commands.EmisijeEFC.UkloniListuEmisija;
using DiplomskiRad.MediatR.Commands.EmisijeEFC.UrediEmisiju;
using DiplomskiRad.MediatR.Queries.EmisijeEFC.DohvatiEmisije;
using DiplomskiRad.MediatR.Queries.EmisijeEFC.DohvatiEmisijuPoId;
using MediatR;
using DiplomskiRad.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Net;

namespace DiplomskiRad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmisijeEFCController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmisijeEFCController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("")]
        public async Task<IActionResult> DohvatiEmisije(string? naziv, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new DohvatiEmisijeRequestEFC(naziv), cancellationToken);
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
        //        var result = await _mediator.Send(new DohvatiEmisijuPoIdRequestEFC(id), cancellationToken);
        //        return Ok(result);
        //    }
        //    catch (TaskCanceledException ex) { return StatusCode(499, ex.Message); }
        //    catch (ArgumentNullException ex) { return StatusCode(500, ex.Message); }
        //    catch (EntityNotFoundException ex) { return NotFound(ex.Message); }
        //    catch (Exception ex) { return BadRequest(ex.Message); }
        //}

        //[HttpPost("dodaj")]
        //public async Task<IActionResult> DodajEmisiju([FromBody] DodajEmisijuRequestEFC emisija)
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
        //public async Task<IActionResult> UrediEmisiju([FromBody] UrediEmisijuRequestEFC emisija)
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
        //        await _mediator.Send(new UkloniEmisijuRequestEFC(id));
        //        return Ok();
        //    }
        //    catch (ArgumentNullException ex) { return StatusCode(500, ex.Message); }
        //    catch (EntityNotFoundException ex) { return NotFound(ex.Message); }
        //    catch (Exception ex) { return BadRequest(ex.Message); }
        //}

        //[HttpDelete("ukloni-listu")]
        //public async Task<IActionResult> UkloniListuEmisija([FromBody] UkloniListuEmisijaRequestEFC emisije)
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

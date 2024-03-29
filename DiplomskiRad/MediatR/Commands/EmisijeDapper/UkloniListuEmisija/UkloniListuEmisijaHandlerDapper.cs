﻿using DiplomskiRad.DapperRepository;
using DiplomskiRad.Models;
using MediatR;

namespace DiplomskiRad.MediatR.Commands.EmisijeDapper.UkloniListuEmisija
{
    public class UkloniListuEmisijaHandlerDapper : IRequestHandler<UkloniListuEmisijaRequestDapper>
    {
        private readonly IDapperRepository<Emisija> _emisijeRepository;

        public UkloniListuEmisijaHandlerDapper(IDapperRepository<Emisija> emisijeRepository)
        {
            _emisijeRepository = emisijeRepository;
        }

        public async Task Handle(UkloniListuEmisijaRequestDapper request, CancellationToken cancellationToken)
        {
            await _emisijeRepository.DeleteListByIdsAsync(request.Ids);
            
        }
    }
}

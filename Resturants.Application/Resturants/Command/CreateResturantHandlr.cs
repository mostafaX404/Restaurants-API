using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resturants.Application.User;
using Resturants.Domain.Entities;
using Resturants.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Resturants.Command
{
    public class CreateResturantHandlr(ILogger<CreateResturantHandlr> ilogger , 
        IMapper mapper , IResturantRepository resturantRepository,
        IUserContext userContext) : IRequestHandler<CreateResturantCommand, int>
    {
        public async Task<int> Handle(CreateResturantCommand request, CancellationToken cancellationToken)
        {
            var currentUser = userContext.GetCurrentUser();
            ilogger.LogInformation($"Craeting new resturant = {request} for user : {currentUser?.Email} and his id = {currentUser?.Id}");
            var resturant = mapper.Map<Resturant>(request);
            resturant.OwnerId = currentUser?.Id;
            return await resturantRepository.Create(resturant);

        }
    }
}

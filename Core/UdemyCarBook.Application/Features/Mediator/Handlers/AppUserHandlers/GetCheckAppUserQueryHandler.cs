using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.AppUserQueries;
using UdemyCarBook.Application.Features.Mediator.Results.AppUserResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.AppUserInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
    {
        private readonly IRepository<AppUser> _appUserrepository;
        private readonly IRepository<AppRole> _appRolerepository;

        public GetCheckAppUserQueryHandler(IRepository<AppUser> appUserrepository, IRepository<AppRole> appRolerepository)
        {
            _appUserrepository = appUserrepository;
            _appRolerepository = appRolerepository;
        }

        public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
        {
            var values = new GetCheckAppUserQueryResult();
            var user = await _appUserrepository.GetByFilterAsync(x => x.UserName == request.Username && x.Password == request.Password);
            if(user==null)
            {
                values.IsExist = false;

            }
            else
            {
                values.IsExist = true;
                values.Username = user.UserName;
                values.Role = (await _appRolerepository.GetByFilterAsync(x => x.AppRoleId == user.AppRoleId)).AppRoleName;
                values.Id=user.AppUserId;


            }
            return values;
        }
    }
}

﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using MineralWaterMonitoring.Data;
using MineralWaterMonitoring.Features.Exceptions;

namespace MineralWaterMonitoring.Features.Users;

public abstract class AddNewUser
{
    public class AddNewUserCommand : IRequest<Unit>
    {
        public string FullName
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public Guid GroupId
        {
            get;
            set;
        }


        public class Handler : IRequestHandler<AddNewUserCommand, Unit>
        {
            private readonly DataContext _dataContext;
            public Handler( DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Unit> Handle(AddNewUserCommand command, CancellationToken cancellationToken)
            {
                var userExist = await _dataContext.Users.FirstOrDefaultAsync(x => x.UserName == command.UserName, cancellationToken: cancellationToken);
                if (userExist != null)
                {
                    throw new UserAlreadyExistExceptions(command.UserName);
                }

                var users = new Domain.Users
                {
                    FullName = command.FullName,
                    UserName = command.UserName,
                    Password = command.Password,
                    GroupId = command.GroupId
                };
                await _dataContext.Users.AddAsync(users, cancellationToken);
                await _dataContext.SaveChangesAsync(cancellationToken);
                
                return Unit.Value;
                
            }
        }
    }
}
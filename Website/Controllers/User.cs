using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using Core.DatabaseModel;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Website.Controllers
{
    [Authorize]
    public class UserController: Controller, IUserService
    {
        private IUserService _userServiceImplementation;

        public UserController(DataContext dataContext)
        {
            _userServiceImplementation = new UserService(dataContext);
        }

        public async Task<List<ApplicationUser>> Get()
        {
            return await _userServiceImplementation.Get();
        }

        public async Task<ApplicationUser> Get(string id)
        {
            return await _userServiceImplementation.Get(id);
        }

        public async Task<ApplicationUser> MakePayment(string id, decimal amount, PaymentReason reason)
        {
            return await _userServiceImplementation.MakePayment(id, amount, reason);
        }

        public async Task<ApplicationUser> Update(string id, decimal amount, PaymentReason reason)
        {
            return await _userServiceImplementation.Update(id, amount, reason);
        }

        public async Task Update(ApplicationUser user)
        {
            if (!Request.HttpContext.User.IsInRole(Roles.Administrator))
            {
                user.Barcodes = null;
            }
            await _userServiceImplementation.Update(user);
        }
    }
}
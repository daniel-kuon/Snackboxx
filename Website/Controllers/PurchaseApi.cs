using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.DatabaseModel;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Website.Controllers
{
    [Authorize(Roles = Roles.Administrator)]
    public class PurchaseApi: Controller, IPurchaseService
    {
        private readonly IPurchaseService _purchaseServiceImplementation;

        public PurchaseApi(DataContext dataContext)
        {
            _purchaseServiceImplementation = new PurchaseService(dataContext);
        }

        public async Task<List<Purchase>> Get()
        {
            return await _purchaseServiceImplementation.Get();
        }

        public async Task<Purchase> Get(int id)
        {
            return await _purchaseServiceImplementation.Get(id);
        }

        public void Post(Purchase purchase)
        {
            _purchaseServiceImplementation.Post(purchase);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class PaymentService
    {
        private readonly DataContext _context;

        public PaymentService(DataContext context)
        {
            _context = context;
        }

        public async Task Add(int userId, decimal amount, PaymentReason reason)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int paymentId)
        {
            var payment = await _context.Payments.FindAsync(paymentId);
            if (payment == null)
                throw new EntityNotFoundException<Payment>();
            _context.Remove(payment);
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<Payment>> Get()
        {
            return Get(false);
        }

        public async Task<IEnumerable<Payment>> Get(bool expand)
        {
            return await _context.Payments.ToListAsync();
        }

        public Task<IEnumerable<Payment>> Get(int userId)
        {
            return Get(userId, false);
        }

        public async Task<IEnumerable<Payment>> Get(int userId, bool expand)
        {
            throw new NotImplementedException();
        }
    }
}
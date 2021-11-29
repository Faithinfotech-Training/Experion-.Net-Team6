using cmsRestApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsRestApi.Repository
{
    public class PaymentRepo : IPaymentRepo
    {
        ClinicManagementSystemDBContext _db;

        public PaymentRepo(ClinicManagementSystemDBContext db)
        {
            _db = db;
        }
        public async Task<List<TblPayment>> GetPayments()
        {
            if (_db != null)
            {
                return await _db.TblPayment.ToListAsync();
            }
            return null;
        }
        public async Task<TblPayment> GetPaymentById(int id)
        {
            var pay = await _db.TblPayment.SingleOrDefaultAsync(u => u.PaymentId == id);
            if (pay == null)
            {
                return null;
            }
            return pay;
        }
        public async Task<TblPayment> AddPayment(TblPayment payment)
        {
            //--- member function to add payment ---//
            if (_db != null)
            {
                await _db.TblPayment.AddAsync(payment);
                await _db.SaveChangesAsync();
                return payment;
            }
            return null;

        }

    }
}

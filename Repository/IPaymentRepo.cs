using cmsRestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsRestApi.Repository
{
    public interface IPaymentRepo
    {
        //--- get payments ---//
        Task<List<TblPayment>> GetPayments();
        //--- get payment by id ---//
        Task<TblPayment> GetPaymentById(int id);
        //--- add payment ---//
        Task<TblPayment> AddPayment(TblPayment payment);
    }
}

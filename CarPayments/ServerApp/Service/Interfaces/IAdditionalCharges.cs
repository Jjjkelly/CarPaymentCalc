using CarPayments.ServerApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPayments.ServerApp.Service.Interfaces
{
    public interface IAdditionalCharges
    {
        ChargesModel Get();
    }
}

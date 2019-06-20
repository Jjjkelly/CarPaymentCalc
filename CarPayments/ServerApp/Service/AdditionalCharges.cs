using CarPayments.ServerApp.Domain.Model;
using CarPayments.ServerApp.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarPayments.ServerApp.Service
{
    public class AdditionalCharges: IAdditionalCharges
    {
        private readonly IConfiguration _config;

        public AdditionalCharges(IConfiguration config)
        {
            _config = config;
        }

        public ChargesModel Get()
        {
            var charges = new ChargesModel();

            _config.GetSection("AdditionalCharges").Bind(charges);

            return charges;
        }
    }
}

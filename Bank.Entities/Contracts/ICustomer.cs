using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Entities.Contracts
{
    /// <summary>
    /// Represents interface of customer entity
    /// </summary>
    public interface ICustomer
    {
        #region Properties
        //Globally Unique identifier : generate unique identity
        Guid CustomerId { get; set; }
        long CustomerCode { get; set; }
        string Address { get; set; }
        string Landmark { get; set; }
        string City { get; set; }
        string Country { get; set; }
        string Mobile { get; set; }
        #endregion

    }
}

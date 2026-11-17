using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Contracts.Common;

namespace CinemaApp.Data.Repository.Contracts
{
    public interface IUserTicketRepository : IRepository<UserTicket>
    {
    }
}

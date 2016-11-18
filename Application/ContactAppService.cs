using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Finance;
using Core.Interfaces.Repositories;
using Data.PDF;

namespace Application
{
    public class ContactAppService
    {
        private readonly IContractRepository repository;
        private readonly IFinanceRepository financerepository;
        private readonly IPartnerRepository partnerrepository;


        public ContactAppService(IContractRepository repository,IFinanceRepository financerepository,IPartnerRepository partnerrepository)
        {
            this.repository = repository;
            this.financerepository = financerepository;
            this.partnerrepository = partnerrepository;
        }


     
    }
}

using DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BankAbstractMapper<Model> : AbstractMapper<Model> where Model : new()
    {
        protected BankAbstractMapper() : base(new SQLHelper(new WebConfigure("connBankCredit"))) { }
    }
}

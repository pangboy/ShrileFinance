using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BankCredit
{
    public interface ICombinaData
    {
        string BuildMessageName(int fileId);

        string BuildMessageTop(int fileId, int messageTypeId, int i);

        string BuildMessageBody(int fileId, int messageTypeId,out int i);

    }
}

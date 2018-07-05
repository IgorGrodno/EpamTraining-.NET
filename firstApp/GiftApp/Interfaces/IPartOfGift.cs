using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftApp.Interfaces
{
    public interface IPartOfGift
    {
        Guid GetId();

        string GetName();

        int GetWeight();

        int GetSugarCount();

        bool GetInChocolate();

        
    }
}

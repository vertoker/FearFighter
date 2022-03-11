using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Controllers
{
    interface IController
    {
        public void SetKeyDown(byte keyType, byte key);
        public void SetKeyUp(byte keyType, byte key);
    }
}

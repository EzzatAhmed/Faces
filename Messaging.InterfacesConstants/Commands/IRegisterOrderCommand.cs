using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.InterfacesConstants.Commands
{
     public interface IRegisterOrderCommand
    {
         string PictureUrl { get; set; }
         string UserEmail { get; set; }
         byte[] ImageData { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCloud.Models
{
    public interface IModel
    {
        void validar();
        string toString();
    }
}

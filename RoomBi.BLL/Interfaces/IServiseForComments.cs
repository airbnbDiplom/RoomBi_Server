using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.BLL.Interfaces
{
    public interface IServiseForComments<T>
    {
        Task<IEnumerable<T>> GetAllForRentalItem(int? apartmentId);
    }
}

using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;
using RoomBi.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.BLL.Services
{
    public class DataSearchForSortingServise(IUnitOfWork uow) : IServiceDataSearchForSorting<DataSearchForSorting>
    {
        IUnitOfWork Database { get; set; } = uow;

        public Task<IEnumerable<DataSearchForSorting>> TempGetAll(string temp)
        {
            throw new NotImplementedException();
        }
    }
}

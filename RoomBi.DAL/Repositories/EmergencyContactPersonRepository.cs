using Microsoft.EntityFrameworkCore;
using RoomBi.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.DAL.Repositories
{
    public class EmergencyContactPersonRepository : IRepositoryOfAll<EmergencyContactPerson>
    {
        private readonly RBContext context;
        public EmergencyContactPersonRepository(RBContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<EmergencyContactPerson>> GetAll()
        {
            return await context.EmergencyContactPersons.ToListAsync();
        }
        public async Task<EmergencyContactPerson> Get(int id)
        {

            return await context.EmergencyContactPersons.FirstOrDefaultAsync(m => m.Id == id);
            //return await context.EmergencyContactPersons.FindAsync(id);
        }
        public async Task Create(EmergencyContactPerson item)
        {
            await context.EmergencyContactPersons.AddAsync(item);
        }
        public async Task Update(EmergencyContactPerson item)
        {
            context.EmergencyContactPersons.Update(item);
        }
        public async Task Delete(int id)
        {
            EmergencyContactPerson? item = await context.EmergencyContactPersons.FindAsync(id);
            if (item != null)
                context.EmergencyContactPersons.Remove(item);
        }
    }
}

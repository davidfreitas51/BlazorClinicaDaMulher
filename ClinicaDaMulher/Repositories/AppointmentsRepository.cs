using ClinicaDaMulher.Data;
using ClinicaDaMulher.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaDaMulher.Repositories
{
    public interface IAppointmentRepository
    {
        Task<Appointment> GetByIdAsync(int id);
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<List<Appointment>> GetByUserIdAsync(int userId);
        Task<Appointment> Add(Appointment appointment);
        Task UpdateAsync(Appointment appointment);
        Task<bool> DeleteAsync(int id);
    }

    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Appointment> GetByIdAsync(int id)
        {
            return await _context.Appointments.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task<List<Appointment>> GetByUserIdAsync(int userId)
        {
            return await _context.Appointments
                                 .Where(a => a.UserId == userId)
                                 .ToListAsync();
        }

        public async Task<Appointment> Add(Appointment appointment)
        {
            var result = _context.Appointments.Add(appointment);
            _context.SaveChanges();

            return result.Entity;
        }


        public async Task UpdateAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

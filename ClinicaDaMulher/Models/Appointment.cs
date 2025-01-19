namespace ClinicaDaMulher.Models;

public class Appointment
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateOnly AppointmentDate { get; set; }
    public DateTime AppointmentTime { get; set; }
    public string Reason { get; set; }
}
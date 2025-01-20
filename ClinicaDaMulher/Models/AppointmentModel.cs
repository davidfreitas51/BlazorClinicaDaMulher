using System.ComponentModel.DataAnnotations;

namespace ClinicaDaMulher.Models;

public class AppointmentModel
{
    [Required]
    public DateTime? AppointmentDate { get; set; }

    [Required]
    public TimeSpan? AppointmentTime { get; set; }

    [Required]
    public string Reason { get; set; }
}
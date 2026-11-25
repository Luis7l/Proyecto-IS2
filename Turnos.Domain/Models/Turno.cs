namespace Turnos.Domain.Models;

public class Turno
{
    public Guid Id { get; set; }
    public DateTime Fecha { get; set; }
    public string Paciente { get; set; }
    public string Profesional { get; set; }
    public int DuracionMinutos { get; set; }
    public string Estado { get; set; }

    public Turno(DateTime fecha, string paciente, string profesional, int duracionMinutos)
    {
        Id = Guid.NewGuid();
        Fecha = fecha;
        Paciente = paciente;
        Profesional = profesional;
        DuracionMinutos = duracionMinutos;
        Estado = "Pendiente";
    }
}

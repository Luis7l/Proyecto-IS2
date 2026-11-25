namespace Turnos.Domain.Models;

/// <summary>
/// Representa un turno agendado en el sistema.
/// </summary>
public class Turno
{
    public Guid Id { get; private set; }
    public DateTime Fecha { get; private set; }
    public string Paciente { get; private set; }
    public string Profesional { get; private set; }
    public int DuracionMinutos { get; private set; }
    public string Estado { get; private set; }

    public Turno(DateTime fecha, string paciente, string profesional, int duracionMinutos)
    {
        ValidarParametros(paciente, profesional, duracionMinutos);

        Id = Guid.NewGuid();
        Fecha = fecha;
        Paciente = paciente;
        Profesional = profesional;
        DuracionMinutos = duracionMinutos;
        Estado = "Pendiente";
    }

    public DateTime FechaFin => Fecha.AddMinutes(DuracionMinutos);

    private static void ValidarParametros(string paciente, string profesional, int duracionMinutos)
    {
        if (string.IsNullOrWhiteSpace(paciente))
            throw new ArgumentException("El nombre del paciente no puede estar vacío.", nameof(paciente));

        if (string.IsNullOrWhiteSpace(profesional))
            throw new ArgumentException("El nombre del profesional no puede estar vacío.", nameof(profesional));

        if (duracionMinutos <= 0)
            throw new ArgumentException("La duración debe ser mayor a cero.", nameof(duracionMinutos));
    }
}

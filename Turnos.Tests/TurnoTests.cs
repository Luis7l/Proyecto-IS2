using Xunit;
using Turnos.Domain.Models;

namespace Turnos.Tests;

public class TurnoTests
{
    [Fact]
    public void CrearTurno_ConDatosValidos_AsignaCorrectamenteLasPropiedades()
    {
        // Arrange
        var fecha = new DateTime(2026, 12, 1, 10, 0, 0);
        var paciente = "Juan Pérez";
        var profesional = "Dr. García";
        var duracionMinutos = 30;

        // Act
        var turno = new Turno(fecha, paciente, profesional, duracionMinutos);

        // Assert
        Assert.Equal(fecha, turno.Fecha);
        Assert.Equal(paciente, turno.Paciente);
        Assert.Equal(profesional, turno.Profesional);
        Assert.Equal(duracionMinutos, turno.DuracionMinutos);
    }

    [Fact]
    public void CrearTurno_EstadoInicial_EsPendiente()
    {
        // Arrange & Act
        var turno = new Turno(
            new DateTime(2026, 12, 1, 10, 0, 0),
            "Juan Pérez",
            "Dr. García",
            30
        );

        // Assert
        Assert.Equal("Pendiente", turno.Estado);
    }

    [Fact]
    public void CrearTurno_DebeGenerarUnId()
    {
        // Arrange & Act
        var turno = new Turno(
            new DateTime(2026, 12, 1, 10, 0, 0),
            "Juan Pérez",
            "Dr. García",
            30
        );

        // Assert
        Assert.NotEqual(Guid.Empty, turno.Id);
    }
}

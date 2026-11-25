# Iteración 1: Creación de la Entidad Turno

## Objetivo de la Iteración

En esta primera iteración aplicamos el ciclo fundamental **Red-Green-Refactor** para construir la entidad central del dominio: el **Turno**. El objetivo es demostrar de forma práctica cómo TDD guía el diseño de una clase desde su concepción, haciendo que los tests definan su interfaz pública, responsabilidades y encapsulamiento antes de completar la implementación definitiva.

---

## 🔴 Fase RED — Escribir el test que falla

### Especificación del Comportamiento Esperado

Antes de escribir código de producción, planteamos mediante pruebas unitarias qué requisitos debe cumplir la creación de un turno:
1. Al instanciarse con fecha, paciente, profesional y duración, debe almacenar correctamente dichos valores en sus propiedades.
2. Todo turno nuevo debe iniciar con un estado por defecto ("Pendiente").
3. Todo turno debe contar con un identificador único generado automáticamente (`Guid`).


### Ejecución y Resultado (Fallo / Error de compilación)

Al compilar y ejecutar mediante `dotnet test` o `dotnet build`:

```text
C:\...\Turnos.Tests\TurnoTests.cs(2,14): error CS0234: El tipo o el nombre del espacio de nombres 'Domain' no existe en el espacio de nombres 'Turnos' (¿falta alguna referencia de ensamblado?)
```

El proyecto ni siquiera compila porque la clase `Turno` aún no existe. **Este fallo inicial es el pilar de la fase RED**: asegura que el test está verificando algo que realmente falta por implementar y evita falsos positivos.

### Análisis de Diseño en Fase RED

Antes de programar la entidad, el test ya nos indica a definir:
- El nombre y ubicación del modelo (`Turnos.Domain.Models.Turno`).
- Que los datos esenciales deben pasarse mediante el constructor, evitando estados incompletos.
- La semántica de sus propiedades (`Fecha`, `Paciente`, `Profesional`, `DuracionMinutos`, `Estado`, `Id`).
- Que el consumidor no debe preocuparse por inicializar el `Id` ni el `Estado` inicial; la entidad asume esa responsabilidad.

---

## 🟢 Fase GREEN — Escribir el código mínimo para pasar

### Implementación Mínima (`Turnos.Domain/Models/Turno.cs`)

### Ejecución y Resultado (Éxito)

```text
Serie de pruebas para Turnos.Tests.dll (.NETCoreApp,Version=v10.0)
Correctas! - Con error: 0, Superado: 3, Omitido: 0, Total: 3, Duración: 151 ms
```

Las 3 pruebas pasan correctamente.


## 🔵 Fase REFACTOR — Mejorar el diseño manteniendo los tests verdes

Con una suite de pruebas automatizadas funcionando como red de seguridad, procedemos a mejorar la calidad estructural del código.

### Decisiones de Refactorización

1. **Encapsulamiento estricto:** Modificamos las propiedades a `private set`, garantizando que la entidad controle sus propias transiciones de estado.
2. **Invariantes del Dominio / Validaciones:** Agregamos reglas en el constructor para impedir la creación de turnos con datos inconsistentes (lanzando `ArgumentException`).
3. **Propiedad calculada (`FechaFin`):** Centralizamos el cálculo del fin del turno en función de su fecha de inicio y duración.

### Código Refactorizado (`Turnos.Domain/Models/Turno.cs`)

```csharp
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
```

### Extensión de la Suite de Tests (`Turnos.Tests/TurnoTests.cs`)

Para asegurar y documentar las nuevas reglas de negocio agregadas, sumamos pruebas parametrizadas con `[Theory]` y `[InlineData]`:


### Ejecución y Resultado Final

```text
Serie de pruebas para Turnos.Tests.dll (.NETCoreApp,Version=v10.0)
Correctas! - Con error: 0, Superado: 12, Omitido: 0, Total: 12, Duración: 66 ms
```

Las 12 pruebas (las 3 originales más los 9 casos de validación y cálculo) se ejecutan con éxito.

---

## Conclusiones del Caso Analizado

| Aspecto Analizado | Estado Inicial (GREEN) | Estado Refactorizado (REFACTOR) | Beneficio Observado |
|---|---|---|---|
| **Encapsulamiento** | `set` público | `private set` | Protección contra mutaciones inválidas de estado |
| **Integridad del Modelo** | Sin validaciones | Control de nulos, vacíos y rangos | El objeto siempre se instancia en estado válido |
| **Lógica Derivada** | Cálculo externo | Propiedad calculada `FechaFin` | Cohesión: la clase responde sobre sus propios datos |
| **Cobertura de Pruebas** | 3 pruebas unitarias | 12 pruebas unitarias | Documentación viva de los casos borde del dominio |

Este caso describe cómo el flujo TDD ayuda al desarrollador a tomar decisiones de diseño estructuradas a nivel de clases y métodos, permitiendo refactorizar con confianza respaldado por una suite de verificación automatizada.

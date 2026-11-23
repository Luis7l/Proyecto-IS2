# Guía de Configuración del Entorno

## Requisitos Previos

- [.NET SDK 10.0](https://dotnet.microsoft.com/download) o superior
- Un editor de código o IDE compatible:
  - [Visual Studio 2022](https://visualstudio.microsoft.com/) (recomendado para C#)
  - [Visual Studio Code](https://code.visualstudio.com/) con la extensión [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)
- [Git](https://git-scm.com/downloads)

## Clonar el Repositorio

```bash
git clone <URL_DEL_REPOSITORIO>
cd Proyecto-IS2
```

## Estructura del Proyecto

```
Proyecto-IS2/
├── docs/                  ← Documentación del trabajo (Markdown)
├── Turnos.Domain/         ← Librería de clases con la lógica de dominio
├── Turnos.Tests/          ← Proyecto de pruebas unitarias (xUnit)
├── Turnos.slnx            ← Archivo de solución .NET
└── .gitignore
```

- **Turnos.Domain**: contiene las entidades, servicios e interfaces del dominio del sistema de turnos.
- **Turnos.Tests**: contiene las pruebas unitarias escritas con [xUnit](https://xunit.net/), que verifican el comportamiento del dominio.

## Restaurar Dependencias

```bash
dotnet restore
```

## Compilar la Solución

```bash
dotnet build
```

Si la compilación es exitosa, se mostrará un mensaje similar a:

```
Compilación realizado correctamente en X,Xs
```

## Ejecutar las Pruebas

```bash
dotnet test
```

Resultado esperado:

```
Resumen de pruebas: total: N; con errores: 0; correcto: N; omitido: 0
```

## Ejecutar las Pruebas con Detalle

Para ver el nombre de cada prueba individual:

```bash
dotnet test --verbosity normal
```

## Verificación Rápida

Para confirmar que el entorno está correctamente configurado, ejecutá los siguientes comandos en orden:

```bash
dotnet --version        # Debe mostrar 10.0.x o superior
dotnet restore          # Restaurar paquetes NuGet
dotnet build            # Compilar sin errores
dotnet test             # Todas las pruebas deben pasar
```

Si los cuatro comandos se ejecutan sin errores, el entorno está listo para trabajar.

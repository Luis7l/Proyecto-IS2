# Introducción

## 1.1 Contexto 

En el desarrollo de software, la calidad del código no es algo que se pueda dejar para el final del proyecto, sino que debe construirse de manera incremental desde el inicio. Una de las prácticas que promueve esta filosofía es el **Desarrollo Guiado por Pruebas** (*Test-Driven Development* o **TDD**), una técnica de diseño y desarrollo de software que invierte el flujo tradicional de programación al exigir que las pruebas automatizadas se escriban *antes* que el código de producción.

TDD fue popularizado por **Kent Beck** a principios de los años 2000 en su libro *Test-Driven Development: By Example* (Beck, 2003), donde lo describe no como una metodología de testing, sino como una forma de diseñar software de manera emergente, dejando que las pruebas guíen las decisiones de diseño a nivel de clases, funciones y componentes.

## 1.2 TDD como Práctica de Diseño y Desarrollo

Es importante comprender que TDD es reconocida dentro del cuerpo de conocimiento de la ingeniería de software como una **práctica de diseño y desarrollo**, realizada principalmente por los programadores durante la fase de construcción del software. No se trata de una práctica de Aseguramiento de la Calidad (QA) ni pretende reemplazar las pruebas formales que realiza un equipo de QA.

El **SWEBOK v4** (*Software Engineering Body of Knowledge*) ubica a TDD dentro del área de conocimiento de **Construcción de Software** (*Software Construction*), junto con prácticas como la programación en pares, la integración continua y el refactoring. Aunque las pruebas generadas por TDD resultan útiles como red de seguridad para prevenir regresiones y complementan las actividades de verificación del software, su propósito principal es otro: **guiar el diseño del código** que se está escribiendo.

Robert C. Martin, en *Agile Software Development: Principles, Patterns, and Practices* (Martin, 2002), refuerza esta idea al señalar que las pruebas escritas antes del código obligan al desarrollador a pensar en las interfaces y responsabilidades de cada componente antes de implementarlo, fomentando naturalmente la aplicación de principios de diseño como:

- **Principio de Responsabilidad Única (SRP):** Al escribir un test para un comportamiento específico, el desarrollador tiende a crear clases con una sola responsabilidad bien definida.
- **Principio de Inversión de Dependencias (DIP):** Para poder testear una clase de forma aislada, se hace necesario depender de abstracciones (interfaces) en lugar de implementaciones concretas.
- **Bajo acoplamiento:** La necesidad de instanciar una clase en un entorno de pruebas incentiva a minimizar sus dependencias.

## 1.3 Verificación vs. Validación

En la ingeniería de software se distinguen dos conceptos fundamentales:

- **Verificación:** ¿Estamos construyendo el producto *correctamente*? Se asegura de que el software cumple con sus especificaciones técnicas.
- **Validación:** ¿Estamos construyendo el producto *correcto*? Se asegura de que el software satisface las necesidades reales del usuario final.

Las pruebas creadas mediante TDD son escritas por el mismo desarrollador que implementa el código. Por esta razón, TDD se enmarca dentro de la **verificación**: el programador define, a través de los tests, el comportamiento esperado de una unidad de código y luego verifica que la implementación lo cumpla. La validación, en cambio, requiere la intervención de otros actores (equipo de QA, usuarios, *product owners*) mediante pruebas de aceptación, pruebas de usabilidad y otros mecanismos que están fuera del alcance de TDD.

## 1.4 Alcance del Diseño que Fomenta TDD

TDD fomenta la modularidad y un buen diseño a nivel de **clases, funciones y componentes individuales**. Al escribir un test antes del código, el desarrollador se ve obligado a reflexionar sobre:

- Cómo se va a usar la clase (su interfaz pública).
- Qué responsabilidades tiene (y cuáles no).
- Qué dependencias necesita (y cómo inyectarlas).

Sin embargo, es importante reconocer que **TDD por sí solo no garantiza una buena arquitectura general** del sistema. Las decisiones arquitectónicas —como la elección de patrones arquitectónicos (capas, microservicios, hexagonal), la organización de módulos a gran escala y la comunicación entre subsistemas— requieren un trabajo de diseño deliberado que excede el alcance de TDD. Como señala Martin Fowler en su artículo *Is Design Dead?* (Fowler, 2004), TDD produce un diseño emergente a nivel micro, pero las decisiones de arquitectura a nivel macro siguen necesitando experiencia y planificación consciente.

## 1.5 El Ciclo Red-Green-Refactor

El flujo de trabajo de TDD se organiza en un ciclo iterativo de tres fases conocido como **Red-Green-Refactor**:

```
    ┌────────────────────────────────────────────┐
    │                                            │
    ▼                                            │
 ┌──────┐      ┌──────────┐      ┌────────────┐  │
 │ RED  │ ───► │  GREEN   │ ───► │  REFACTOR  │──┘
 └──────┘      └──────────┘      └────────────┘
 Escribir       Escribir el       Mejorar el
 un test        código mínimo     diseño sin
 que falle      para que pase     romper tests
```


### 🔴 RED — Escribir un test que falle

Se escribe una prueba automatizada que describe el comportamiento deseado. En este punto, el test **debe fallar** (o no compilar), ya que el código de producción aún no existe. Esta fase obliga al desarrollador a pensar primero en *qué* debe hacer el código antes de pensar en *cómo* lo hará.

### 🟢 GREEN — Escribir el código mínimo para pasar el test

Se implementa la cantidad mínima de código necesaria para que el test pase. No se busca la solución perfecta ni elegante; solo que el test pase. Kent Beck describe esto como *"fake it till you make it"*: incluso devolver un valor fijo es válido si hace pasar el test.

### 🔵 REFACTOR — Mejorar el diseño sin cambiar el comportamiento

Una vez que el test pasa, se mejora la estructura interna del código (eliminar duplicación, renombrar, extraer métodos o clases) **sin alterar su comportamiento observable**. Los tests existentes actúan como red de seguridad, asegurando que las mejoras no introducen defectos. Martin Fowler define el refactoring como *"a change made to the internal structure of software to make it easier to understand and cheaper to modify without changing its observable behavior"* (Fowler, 2018).

Este ciclo se repite de forma continua, agregando incrementalmente nuevos comportamientos al sistema.

## 1.6 Principales Proponentes

| Autor | Contribución Principal | Obra de Referencia |
|-------|----------------------|-------------------|
| **Kent Beck** | Creador y principal promotor de TDD | *Test-Driven Development: By Example* (2003) |
| **Robert C. Martin** | Integración de TDD con principios SOLID y desarrollo ágil | *Clean Code* (2008), *Agile Software Development* (2002) |
| **Martin Fowler** | Refactoring como complemento esencial del ciclo TDD | *Refactoring: Improving the Design of Existing Code* (2018) |
| **Gerard Meszaros** | Patrones de prueba y Test Doubles (Mocks, Stubs, Fakes) | *xUnit Test Patterns* (2007) |
| **Michael Feathers** | Estrategias para aplicar TDD en código legado | *Working Effectively with Legacy Code* (2004) |

## 1.7 Objetivos del Presente Trabajo

El presente trabajo tiene como objetivos:

1. **Demostrar de forma práctica el ciclo fundamental del TDD:** Construir un cuerpo de conocimiento que ilustre paso a paso el ciclo Red-Green-Refactor a través de al menos tres iteraciones completas.

2. **Analizar la influencia de TDD en el diseño del software:** Describir cómo la obligación de que una clase sea testeable desde su concepción influye en la definición de sus interfaces y responsabilidades a nivel de clases y funciones.

3. **Generar una guía reproducible:** Proporcionar las indicaciones exactas, repositorios y comandos para que cualquier lector pueda reproducir la experiencia y adoptar TDD en sus propios proyectos.

### Preguntas centrales que el trabajo desarrollará

- ¿Cómo influye la escritura anticipada de pruebas en el diseño a nivel de clases y componentes?
- ¿De qué manera el código resultante queda documentado por su suite de pruebas?


## 1.8 Tecnologías Utilizadas

Para el desarrollo práctico se utilizarán las siguientes tecnologías:

- **Lenguaje:** C# (.NET 10)
- **Framework de pruebas:** [xUnit](https://xunit.net/) — framework de pruebas unitarias ampliamente utilizado en el ecosistema .NET, "creado por Jim Newkirk (coautor de NUnit) y Brad Wilson.
- **Librería de Mocking:** [Moq](https://github.com/devlooped/moq) o [NSubstitute](https://nsubstitute.github.io/) — para la creación de Test Doubles en iteraciones avanzadas.
- **Control de versiones:** Git — cada fase del ciclo Red-Green-Refactor quedará reflejada en commits individuales, permitiendo auditar el proceso de desarrollo guiado por pruebas.
- **Dominio de aplicación:** Sistema de gestión de turnos/reservas (lógica de negocio sin interfaz gráfica ni persistencia real).

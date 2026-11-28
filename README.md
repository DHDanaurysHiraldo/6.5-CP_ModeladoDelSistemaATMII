# Caso práctico 6.5 — Modelado del Sistema ATM II

Modelo simplificado del cajero automático de Deitel que demuestra **herencia** y **composición** en C#, como parte del **Programa FullStack .NET Cloud Developer** (Semana 6 — Programación Orientada a Objetos II).

> 🚧 **En desarrollo.** Las secciones marcadas como pendientes se completarán al finalizar la implementación.

## Objetivo

Analizar y representar relaciones de herencia y composición utilizando un modelo simplificado del sistema ATM, implementarlas en C# y simular un retiro de efectivo en consola.

## Clases del modelo

| Clase | Responsabilidad | Relación |
|---|---|---|
| `ATM` | Coordinar el flujo de interacción y las operaciones del cajero. | Compone un `DispensadorEfectivo`; crea y usa un `Retiro` |
| `Transaccion` | Representar los datos comunes a toda operación bancaria. Es abstracta. | Clase base de `Retiro` |
| `Retiro` | Ejecutar la entrega de efectivo usando el dispensador del cajero. | Hereda de `Transaccion`; usa el `DispensadorEfectivo` que recibe |
| `DispensadorEfectivo` | Representar la disponibilidad y entrega de efectivo. | Parte de `ATM` (composición, 1 a 1) |

El análisis completo —constructores, propiedades, métodos y cambios respecto al caso 5.5— está en [`docs/analisis.md`](docs/analisis.md).

## Relaciones implementadas

### Herencia: `Retiro` → `Transaccion`
Un retiro **es una** transacción: tiene los mismos datos que cualquier transacción (monto y fecha) y agrega su propio comportamiento, entregar efectivo. `Retiro` hereda `Monto` y `Fecha` sin volver a declararlos, y su constructor delega su inicialización en `Transaccion` mediante `base(monto)`. `Transaccion` es abstracta, porque no existe una transacción "genérica" en el dominio bancario.

### Composición: `ATM` ◆ `DispensadorEfectivo`
Un cajero **tiene un** dispensador que forma parte de él: se crea junto con el ATM, no se comparte con otros cajeros y no existe fuera de él. El `ATM` crea su dispensador dentro de su constructor y lo guarda en un campo `private readonly`; hacia afuera solo expone el efectivo disponible, no el objeto, de modo que toda entrega de efectivo pasa por las reglas del cajero.

### Uso: `Retiro` → `DispensadorEfectivo`
El retiro no es dueño del dispensador: lo recibe del `ATM` solo durante la ejecución de la operación.

La justificación detallada de cada relación está en [`docs/analisis.md`](docs/analisis.md#2-justificación-de-las-relaciones).

## Diagrama de clases

🚧 *Pendiente.*

## Requerimientos técnicos

| Requerimiento | Cómo se cumple |
|---|---|
| Clases y objetos | Cuatro clases en `Modelos/`, instanciadas desde `Program.cs` |
| Herencia | `Retiro : Transaccion`, con `base(monto)` en el constructor |
| Composición | `ATM` crea y contiene su `DispensadorEfectivo` |
| Constructores | Todas las clases reciben sus datos por constructor y los validan |
| Encapsulamiento básico | Propiedades con `private set` o de solo lectura, campo `private readonly` para el dispensador, método `AlcanzaEfectivo` privado y constructor `protected` en la clase abstracta |

## Validaciones

| Clase | Regla | Excepción |
|---|---|---|
| `ATM` | El código del cajero es obligatorio | `ArgumentException` |
| `DispensadorEfectivo` | El efectivo inicial no puede ser negativo | `ArgumentOutOfRangeException` |
| `DispensadorEfectivo` | El monto a dispensar debe ser mayor que cero | `ArgumentOutOfRangeException` |
| `DispensadorEfectivo` | Debe haber efectivo suficiente | `InvalidOperationException` |
| `Transaccion` | El monto debe ser mayor que cero | `ArgumentOutOfRangeException` |

## Estructura del proyecto

```
├── Modelos/
│   ├── ATM.cs
│   ├── DispensadorEfectivo.cs
│   ├── Transaccion.cs
│   └── Retiro.cs                  # 🚧 pendiente
├── docs/
│   └── analisis.md                # Análisis de clases y justificación de relaciones
├── Program.cs                     # Simulación del retiro (🚧 pendiente)
├── CP65_ModeladoDelSistemaATMII.csproj
└── CP65_ModeladoDelSistemaATMII.slnx
```

## Cómo ejecutar

Requisito: [.NET SDK 10](https://dotnet.microsoft.com/download).

```bash
git clone https://github.com/DHDanaurysHiraldo/6.5-CP_ModeladoDelSistemaATMII.git
cd 6.5-CP_ModeladoDelSistemaATMII
dotnet run
```

## Ejecución

🚧 *Pendiente: salida en consola y captura de la simulación del retiro.*

## Alcance

**Incluye:** las clases `ATM`, `Transaccion`, `Retiro` y `DispensadorEfectivo`; una relación de herencia, una de composición y la simulación de un retiro en consola.

**No incluye:** cuentas de cliente ni validación de saldo, autenticación, otras transacciones (depósito, consulta), interfaz de usuario ni persistencia.

## Antecedente

Este proyecto continúa el caso práctico 5.5 ([Modelado del Sistema ATM](https://github.com/DHDanaurysHiraldo/5.5CP_ModeladoDelSistemaATM)). La clase `Transaccion` parte de esa versión y se transforma en clase base abstracta; `ATM` y `DispensadorEfectivo`, que en el 5.5 solo figuraban en el análisis, se implementan aquí.

## Autor

**DHDanaurysHiraldo** — [GitHub](https://github.com/DHDanaurysHiraldo)

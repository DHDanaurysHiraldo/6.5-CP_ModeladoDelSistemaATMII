# Análisis de clases — Caso práctico 6.5: Modelado del Sistema ATM II

## 1. Clases del caso 6.5 ATM

### ATM

| Elemento | Detalle |
|---|---|
| **Responsabilidad** | Coordinar el flujo de interacción y las operaciones del cajero. |
| **Constructor** | `ATM(string codigoCajero, decimal efectivoInicial)` — asigna el código del cajero y crea su propio `DispensadorEfectivo` con el efectivo inicial. |
| **Propiedades (Atributos)** | DispensadorEfectivo(private readonly), CodigoCajero(public get), EfectivoDisponible(public get “Obtenido de DispensadorEfectivo”) |
| **Métodos** | RealizarRetiro(decimal monto) : void |
| **Relación entre clases** | Composición con DispensadorEfectivo (1 a 1), y además crea y usa un Retiro cuando se pide retirar. |

### Transaccion

| Elemento | Detalle |
|---|---|
| **Responsabilidad** | Representar los datos comunes a toda operación bancaria. |
| **Constructor** | `Transaccion(decimal monto)` — valida que el monto sea mayor que cero, lo asigna y registra la fecha y hora actuales. |
| **Propiedades** | Monto(private set), Fecha(private set) |
| **Métodos** | MostrarDetalle() : string |
| **Relación entre clases** | Clase base de Retiro. |

### Retiro

| Elemento | Detalle |
|---|---|
| **Responsabilidad** | Ejecutar la entrega de efectivo usando el dispensador del cajero. |
| **Constructor** | `Retiro(decimal monto) : base(monto)` — delega en el constructor de `Transaccion` la asignación y validación del monto y de la fecha. |
| **Propiedades** | Ninguno adicional (hereda Monto y Fecha) |
| **Métodos** | Ejecutar(DispensadorEfectivo dispensador) : void |
| **Relación entre clases** | Hereda de Transaccion y usa el DispensadorEfectivo que recibe. |

### DispensadorEfectivo

| Elemento | Detalle |
|---|---|
| **Responsabilidad** | Representar la disponibilidad y entrega de efectivo. |
| **Constructor** | `DispensadorEfectivo(decimal efectivoInicial)` — valida que el efectivo inicial no sea negativo y lo asigna. |
| **Propiedades** | EfectivoDisponible(public get, private set) |
| **Métodos** | DispensarEfectivo(decimal monto) : void, “private” AlcanzaEfectivo(decimal monto) : bool |
| **Relación entre clases** | ATM -> DispensadorEfectivo. Parte de ATM (composición, 1 a 1): la crea el ATM y no existe fuera de él |

## 2. Justificación de las relaciones

### Herencia: `Retiro` hereda de `Transaccion`

Un retiro **es una** transacción bancaria, por lo que la relación entre ambas clases es de herencia. La prueba del lenguaje lo confirma: la frase "un retiro es una transacción" es verdadera, mientras que una relación del tipo "tiene un" no describe el vínculo. Además, todo retiro posee exactamente los datos que caracterizan a cualquier transacción —un monto y una fecha—, y en cualquier lugar donde se espere una `Transaccion` puede usarse un `Retiro` sin que nada deje de funcionar (por ejemplo, para mostrar su detalle). Lo que distingue al retiro es su comportamiento propio: entregar efectivo. En el código, esto se refleja en la declaración `class Retiro : Transaccion`: `Retiro` no vuelve a declarar `Monto` ni `Fecha`, sino que los hereda, y su constructor invoca a `base(monto)` para que la parte común del objeto sea inicializada y validada por `Transaccion`. `Retiro` solo agrega lo que le es exclusivo: el método `Ejecutar`.

### Composición: `ATM` contiene un `DispensadorEfectivo`

Un cajero automático **tiene un** dispensador de efectivo, pero no **es un** dispensador, por lo que no se trata de herencia. La relación es de composición porque el dispensador forma parte física del cajero: se instala junto con él, pertenece a un único cajero, no se comparte con otros y no tiene función fuera de él. Sus ciclos de vida están ligados: el dispensador existe desde que se crea el ATM y deja de existir con él. En el código, el `ATM` crea su propio `DispensadorEfectivo` con `new` dentro de su constructor y lo guarda en un campo `private readonly`, de modo que ninguna otra clase puede crearlo, reemplazarlo ni usarlo directamente. Hacia afuera, el ATM solo expone el dato que hace falta consultar, `EfectivoDisponible`, y no el objeto completo; así, toda entrega de efectivo pasa obligatoriamente por las reglas del cajero.

### Uso: `Retiro` utiliza el `DispensadorEfectivo`

La relación entre `Retiro` y `DispensadorEfectivo` **no** es de composición. El retiro no crea el dispensador ni lo conserva: lo recibe como parámetro de `Ejecutar` únicamente durante la operación, porque el dispensador pertenece al `ATM`. Se trata de una relación de **uso** (dependencia): el retiro necesita al dispensador para cumplir su tarea, pero no es su dueño. Esta diferencia permite que el `ATM` mantenga el control exclusivo de su dispensador y que, aun así, cada `Retiro` pueda ejecutarse.

## 3. Cambios respecto al caso 5.5

- **`Transaccion` pasa a ser una clase base.** En el caso 5.5 era una clase independiente; en el 6.5 reúne los datos comunes de las transacciones y `Retiro` hereda de ella.
- **Se elimina la propiedad `Tipo`.** Ahora el tipo de transacción lo indica la propia clase del objeto (`Retiro`). Conservar un `string` con el tipo duplicaría la información y permitiría inconsistencias, como un `Retiro` con `Tipo = "Depósito"`.
- **Se reemplazan los `set` públicos por constructores y `private set`.** En el 5.5 las propiedades se asignaban desde `Program.cs`; en el 6.5 los datos ingresan por el constructor, que además los valida, y solo la propia clase puede modificarlos (encapsulamiento).
- **`ATM` y `DispensadorEfectivo` pasan del análisis a la implementación.** En el 5.5 solo figuraban en el análisis; en el 6.5 se implementan para demostrar la relación de composición.
- **`Cuenta` queda fuera del alcance.** El modelo se limita a las clases indicadas en la actividad. En consecuencia, el retiro valida el monto y el efectivo disponible en el dispensador, pero no el saldo del cliente.

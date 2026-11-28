namespace CP65_ModeladoDelSistemaATMII.Modelos;

/// <summary>
/// Transacción que entrega efectivo a través del dispensador del cajero.
/// Hereda de <see cref="Transaccion"/> el monto y la fecha.
/// </summary>
internal class Retiro : Transaccion
{
    /// <summary>
    /// Crea un retiro por el monto indicado.
    /// </summary>
    /// <param name="monto">Monto a retirar. Debe ser mayor que cero.</param>
    /// <exception cref="ArgumentOutOfRangeException">Si el monto es menor o igual a cero.</exception>
    public Retiro(decimal monto) : base(monto)
    {
    }

    /// <summary>
    /// Ejecuta el retiro solicitando al dispensador la entrega del monto.
    /// </summary>
    /// <param name="dispensador">Dispensador del cajero que entrega el efectivo. El retiro lo usa, pero no es su dueño.</param>
    /// <exception cref="InvalidOperationException">Si el dispensador no tiene efectivo suficiente.</exception>
    public void Ejecutar(DispensadorEfectivo dispensador)
    {
        // Monto se hereda de Transaccion: no se declara en esta clase.
        dispensador.DispensarEfectivo(Monto);
    }
}

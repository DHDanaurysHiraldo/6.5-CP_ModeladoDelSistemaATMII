namespace CP65_ModeladoDelSistemaATMII.Modelos;

/// <summary>
/// Dispensador de efectivo del cajero. Administra el efectivo disponible y lo entrega.
/// Forma parte de un <see cref="ATM"/>, que lo crea y lo contiene.
/// </summary>
internal class DispensadorEfectivo
{
    /// <summary>
    /// Efectivo disponible para entregar. Solo esta clase puede modificarlo.
    /// </summary>
    public decimal EfectivoDisponible { get; private set; }

    /// <summary>
    /// Crea un dispensador cargado con el efectivo inicial.
    /// </summary>
    /// <param name="efectivoInicial">Efectivo con el que inicia el dispensador. No puede ser negativo.</param>
    /// <exception cref="ArgumentOutOfRangeException">Si el efectivo inicial es negativo.</exception>
    public DispensadorEfectivo(decimal efectivoInicial)
    {
        if (efectivoInicial < 0)
            throw new ArgumentOutOfRangeException(nameof(efectivoInicial), "Operación inválida: el efectivo inicial no puede ser negativo.");

        EfectivoDisponible = efectivoInicial;
    }

    private bool AlcanzaEfectivo(decimal monto)
    {
        return EfectivoDisponible >= monto;
    }

    /// <summary>
    /// Entrega el monto indicado y lo descuenta del efectivo disponible.
    /// Si alguna validación falla, el efectivo no se modifica.
    /// </summary>
    /// <param name="monto">Monto a entregar. Debe ser mayor que cero.</param>
    /// <exception cref="ArgumentOutOfRangeException">Si el monto es menor o igual a cero.</exception>
    /// <exception cref="InvalidOperationException">Si no hay efectivo suficiente.</exception>
    public void DispensarEfectivo(decimal monto)
    {
        // Se valida antes que la disponibilidad: con un monto negativo, AlcanzaEfectivo
        // devolvería true y la resta aumentaría el efectivo.
        if (monto <= 0)
            throw new ArgumentOutOfRangeException(nameof(monto), "Operación inválida: el monto a dispensar debe ser mayor que cero.");

        if (!AlcanzaEfectivo(monto))
            throw new InvalidOperationException("Operación inválida: no hay efectivo suficiente.");

        EfectivoDisponible -= monto;
    }
}

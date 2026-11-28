namespace CP65_ModeladoDelSistemaATMII.Modelos;

/// <summary>
/// Cajero automático. Coordina las operaciones del cajero y contiene su propio
/// <see cref="DispensadorEfectivo"/> (relación de composición).
/// </summary>
internal class ATM
{
    // Composición: el dispensador pertenece a este ATM. Se crea en el constructor,
    // es privado y readonly, por lo que ninguna otra clase puede usarlo ni reemplazarlo.
    private readonly DispensadorEfectivo _dispensador;

    /// <summary>
    /// Código que identifica al cajero.
    /// </summary>
    public string CodigoCajero { get; }

    // Se expone solo el dato y no el objeto: entregar el dispensador permitiría
    // dispensar efectivo sin pasar por las reglas del cajero.
    /// <summary>
    /// Efectivo disponible actualmente en el dispensador del cajero.
    /// </summary>
    public decimal EfectivoDisponible => _dispensador.EfectivoDisponible;

    /// <summary>
    /// Crea un cajero con su dispensador cargado con el efectivo inicial.
    /// </summary>
    /// <param name="codigoCajero">Código del cajero. No puede estar vacío.</param>
    /// <param name="efectivoInicial">Efectivo con el que se carga el dispensador. No puede ser negativo.</param>
    /// <exception cref="ArgumentException">Si el código del cajero es nulo, vacío o solo contiene espacios.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Si el efectivo inicial es negativo.</exception>
    public ATM(string codigoCajero, decimal efectivoInicial)
    {
        // A diferencia de ArgumentOutOfRangeException, ArgumentException recibe primero el mensaje y después el nombre del parámetro.
        if (string.IsNullOrWhiteSpace(codigoCajero))
            throw new ArgumentException("Operación inválida: El código del cajero es obligatorio.", nameof(codigoCajero));

        CodigoCajero = codigoCajero;
        _dispensador = new DispensadorEfectivo(efectivoInicial);
    }
    /// <summary>
    /// Realiza un retiro de efectivo: crea un <see cref="Retiro"/> y lo ejecuta con el dispensador del cajero.
    /// Si alguna validación falla, el efectivo disponible no se modifica.
    /// </summary>
    /// <param name="monto">Monto a retirar. Debe ser mayor que cero.</param>
    /// <exception cref="ArgumentOutOfRangeException">Si el monto es menor o igual a cero.</exception>
    /// <exception cref="InvalidOperationException">Si el dispensador no tiene efectivo suficiente.</exception>
    public void RealizarRetiro(decimal monto)
    {
        Retiro retiro = new Retiro(monto);
        retiro.Ejecutar(_dispensador);
    }
}

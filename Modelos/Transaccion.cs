namespace CP65_ModeladoDelSistemaATMII.Modelos;

/// <summary>
/// Clase base de todas las transacciones bancarias. Reúne los datos comunes: monto y fecha.
/// Es abstracta porque no existe una transacción genérica: siempre es de un tipo concreto, como <see cref="Retiro"/>.
/// </summary>
internal abstract class Transaccion
{
    /// <summary>
    /// Monto de la transacción. Siempre es mayor que cero.
    /// </summary>
    public decimal Monto { get; private set; }

    /// <summary>
    /// Fecha y hora en que se creó la transacción.
    /// </summary>
    public DateTime Fecha { get; private set; }

    /// <summary>
    /// Inicializa los datos comunes de la transacción. Lo invocan las clases derivadas mediante <c>base(monto)</c>.
    /// </summary>
    /// <param name="monto">Monto de la transacción. Debe ser mayor que cero.</param>
    /// <exception cref="ArgumentOutOfRangeException">Si el monto es menor o igual a cero.</exception>
    protected Transaccion(decimal monto)
    {
        if (monto <= 0)
            throw new ArgumentOutOfRangeException(nameof(monto), "Operación inválida: el monto de la transacción debe ser mayor que cero.");

        Monto = monto;
        // La fecha se asigna aquí y no se recibe por parámetro: una transacción ocurre en el momento en que se crea.
        Fecha = DateTime.Now;
    }

    /// <summary>
    /// Devuelve una línea con la fecha, el tipo y el monto de la transacción.
    /// </summary>
    /// <returns>Texto con el detalle de la transacción.</returns>
    public string MostrarDetalle()
    {
        // GetType().Name devuelve la clase real del objeto (por ejemplo, "Retiro"), por eso no se guarda un Tipo.
        return $"{Fecha:dd/MM/yyyy HH:mm} | {GetType().Name,-10} | RD$ {Monto,10:N2}";
    }
}

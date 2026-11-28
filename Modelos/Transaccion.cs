namespace CP65_ModeladoDelSistemaATMII.Modelos;

internal abstract class Transaccion
{
    public decimal Monto { get; private set; }
    public DateTime Fecha { get; private set; }

    protected Transaccion(decimal monto)
    {
        if (monto <= 0)
            throw new ArgumentOutOfRangeException(nameof(monto), "Operación inválida: el monto de la transacción debe ser mayor que cero.");
        Monto = monto;
        Fecha = DateTime.Now;

    }
    public string MostrarDetalle()
    {
        return $"{Fecha:dd/MM/yyyy HH:mm} | {GetType().Name,-10} | RD$ {Monto,10:N2}";
    }
}

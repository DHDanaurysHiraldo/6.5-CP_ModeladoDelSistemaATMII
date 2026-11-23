namespace CP65_ModeladoDelSistemaATMII.Modelos;

internal class Transaccion
{
    public string Tipo { get; set; } = string.Empty;
    public decimal Monto { get; set; }
    public DateTime Fecha { get; set; }


    public string MostrarDetalle()
    {
        return $"{Fecha:dd/MM/yyyy HH:mm} | {Tipo,-10} | RD$ {Monto,10:N2}";
    }
}

namespace CP65_ModeladoDelSistemaATMII.Modelos;

internal class DispensadorEfectivo
{
    public decimal EfectivoDisponible { get; private set; }

    public DispensadorEfectivo(decimal efectivoInicial)
    {
       if (efectivoInicial < 0)
            throw new ArgumentOutOfRangeException (nameof(efectivoInicial), "Operación inválida: el efectivo inicial no puede ser negativo.");

        EfectivoDisponible = efectivoInicial;
    }

    private bool AlcanzaEfectivo(decimal monto)
    {
        return EfectivoDisponible >= monto;
    }
    public void DispensarEfectivo(decimal monto)
    {
        if (monto <= 0)
            throw new ArgumentOutOfRangeException (nameof(monto), "Operación inválida: el monto a dispensar debe ser mayor que cero.");

        if (!AlcanzaEfectivo(monto))
            throw new InvalidOperationException("Operación inválida: no hay efectivo suficiente.");

        EfectivoDisponible -= monto;

    }
}
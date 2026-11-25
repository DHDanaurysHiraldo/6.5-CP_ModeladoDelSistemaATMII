namespace CP65_ModeladoDelSistemaATMII.Modelos;

internal class DispensadorEfectivo
{
    public decimal EfectivoDisponible { get; private set; }

    public DispensadorEfectivo(decimal efectivoDisponible)
    {
       if (efectivoDisponible < 0)
            throw new ArgumentOutOfRangeException("Operación inválida: no puede ingresar números negativos.");

        efectivoDisponible = EfectivoDisponible;
    }

    private bool AlcanzaEfectivo(decimal monto)
    {
        return EfectivoDisponible >= monto;
    }
    public void DispensarEfectivo(decimal monto)
    {
        if (!AlcanzaEfectivo(monto))
            throw new InvalidOperationException("Operación inválida: no hay efectivo suficiente.");

        EfectivoDisponible -= monto;

    }
}
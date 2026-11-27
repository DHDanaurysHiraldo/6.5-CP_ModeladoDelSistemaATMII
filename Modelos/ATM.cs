namespace CP65_ModeladoDelSistemaATMII.Modelos;

internal class ATM
{
    private readonly DispensadorEfectivo _dispensador;

    public string CodigoCajero { get; }

    public decimal EfectivoDisponible => _dispensador.EfectivoDisponible;


    public ATM(string codigoCajero, decimal efectivoInicial)
    {
        if (string.IsNullOrWhiteSpace(codigoCajero))
            //Con ArgumentException se invierte el orden de los parámetros ("mensaje de texto", nameof(...))
            throw new ArgumentException("Operación inválida: El código del cajero es obligatorio.", nameof(codigoCajero)); 
     
        CodigoCajero = codigoCajero;
        _dispensador = new DispensadorEfectivo(efectivoInicial);
    }
}

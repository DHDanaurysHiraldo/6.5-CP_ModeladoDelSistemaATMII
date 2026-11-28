namespace CP65_ModeladoDelSistemaATMII.Modelos;
internal class Retiro : Transaccion
{
    public Retiro(decimal monto) : base(monto) 
    {
    }

    public void Ejecutar(DispensadorEfectivo dispensador)
    {
        dispensador.DispensarEfectivo(Monto); 
    }
}

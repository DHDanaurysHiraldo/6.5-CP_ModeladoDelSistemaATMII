namespace CP65_ModeladoDelSistemaATMII.Modelos;

internal class Cuenta
{
    public string NumeroCuenta { get; set; } = string.Empty;
    public decimal Saldo { get; set; }
    public bool Activa { get; set; }


    public decimal ConsultarSaldo()
    {
        return Saldo;
    }

    public bool EsMontoValido(decimal monto)
    {
        return monto > 0;
    }

    public bool TieneFondos(decimal monto)
    {
        return Saldo >= monto;
    }

    public bool Depositar(decimal monto)
    {
        if (!Activa || !EsMontoValido(monto))
        {
            return false;
        }
        Saldo += monto; //Suma de Saldo + Monto y asignación a Saldo

        return true;
    }

    public bool Retirar(decimal monto)
    {
        if (!EsMontoValido(monto) || !TieneFondos(monto) || !Activa)
        {
            return false;
        }
        Saldo -= monto; 
        return true;
    }

}

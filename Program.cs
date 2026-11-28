using CP65_ModeladoDelSistemaATMII.Modelos;
namespace CP65_ModeladoDelSistemaATMII;

internal class Program
{
    static void Main(string[] args)
    {
        ATM atm = new ATM("ATM-001", 10000);

        Console.WriteLine("=== Caso práctico 6.5 — Simulación de retiros ===");
        Console.WriteLine();
        Console.WriteLine($"Cajero: {atm.CodigoCajero}");
        Console.WriteLine($"Efectivo inicial: {atm.EfectivoDisponible:N2}");
        Console.WriteLine();

        IntentarRetiro(atm, 2000);
        IntentarRetiro(atm, 9000);
        IntentarRetiro(atm, -500);
        IntentarRetiro(atm, 0);
        IntentarRetiro(atm, 8000);
    }

    static void IntentarRetiro(ATM atm, decimal monto)
    {
        Console.WriteLine($"--- Retiro de RD$ {monto:N2} ---");
        try
        {
            atm.RealizarRetiro(monto);
            Console.WriteLine("Resultado: Retiro exitoso.");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Resultado: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Resultado: {ex.Message}");
        }
        finally
        {
            Console.WriteLine($"Efectivo disponible: RD$ {atm.EfectivoDisponible:N2}");
            Console.WriteLine();
        }
    }


}

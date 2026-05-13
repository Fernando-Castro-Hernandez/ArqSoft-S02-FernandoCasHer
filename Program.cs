using Ahorcado;

Console.WriteLine("¿Qué juego quieres jugar?");
Console.WriteLine("  1 — Ahorcado");
Console.WriteLine("  2 — Viborita");
Console.Write("Opción: ");
var opcion = Console.ReadLine();

if (opcion == "2")
{
    // === VIBORITA ===
    var motor = new MotorViborita();
    var ui = new ConsolaUIViborita(motor);

    Console.CursorVisible = false;
    Console.Clear();

    while (!motor.Ganado() && !motor.Perdido())
    {
        ui.MostrarTablero();
        var tecla = ui.LeerTecla();

        if (tecla == ConsoleKey.Q) break;
        if (tecla != ConsoleKey.NoName)
            motor.CambiarDireccion(tecla);

        motor.Avanzar();
        Thread.Sleep(150); // velocidad del juego
    }

    ui.MostrarTablero();
    ui.MostrarMensaje(motor.Ganado()
        ? "\n¡Ganaste! Llegaste a 10 puntos."
        : "\nGame over.");

    Console.CursorVisible = true;
}
else
{
    // === AHORCADO ===
    var categoria = ConsolaUI.PedirCategoria();
    var repositorio = new PalabrasEnMemoria(categoria);
    var motor = new MotorAhorcado(repositorio);
    var ui = new ConsolaUI(motor);

    while (!motor.Ganado() && !motor.Perdido())
    {
        ui.MostrarTablero();

        char letra = ui.PedirLetra();

        if (motor.LetraYaUsada(letra))
        {
            ui.MostrarMensaje("Ya usaste esa letra.");
            Thread.Sleep(800);
            continue;
        }

        motor.RegistrarLetra(letra);
    }

    ui.MostrarTablero();

    if (motor.Ganado())
        ui.MostrarMensaje($"\n¡Ganaste! La palabra era: {motor.PalabraSecreta}");
    else
        ui.MostrarMensaje($"\nPerdiste. La palabra era: {motor.PalabraSecreta}");
}
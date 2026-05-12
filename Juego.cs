namespace Ahorcado
{
    public class Juego
    {
        private List<string> _palabras = new()
        {
            "arquitectura",
            "interfaz",
            "polimorfismo",
            "encapsulamiento",
            "herencia"
        };

        private string _palabraSecreta;
        private List<char> _letrasUsadas;
        private int _intentosRestantes;

        public Juego()
        {
            var random = new Random();
            _palabraSecreta = _palabras[random.Next(_palabras.Count)];
            _letrasUsadas = new List<char>();
            _intentosRestantes = 6;
        }

        public void Jugar()
        {
            Console.Clear();
            Console.WriteLine("=== AHORCADO ===");

            while (_intentosRestantes > 0)
            {
                MostrarTablero();
                if (VerificarVictoria())
                {
                    Console.WriteLine("\n¡Ganaste! La palabra era: " + _palabraSecreta);
                    Console.Write("\n¿Jugar otra vez? (s/n): ");
                    if (Console.ReadLine()?.ToLower() == "s")
                        new Juego().Jugar();
                    return;
                }

                Console.Write("\nIngresa una letra: ");
                char letra = Console.ReadLine()[0];

                if (_letrasUsadas.Contains(letra))
                {
                    Console.WriteLine("Ya usaste esa letra.");
                    continue;
                }
                _letrasUsadas.Add(letra);
                if (!_palabraSecreta.Contains(letra))
                    _intentosRestantes--;
            }

            MostrarTablero();
            Console.WriteLine("\nPerdiste. La palabra era: " + _palabraSecreta);
            Console.Write("\n¿Jugar otra vez? (s/n): ");
            if (Console.ReadLine()?.ToLower() == "s")
                new Juego().Jugar();
        }

        private bool VerificarVictoria()
        {
            foreach (char c in _palabraSecreta)
                if (!_letrasUsadas.Contains(c))
                    return false;
            return true;
        }

        private void MostrarTablero()
        {
            Console.Clear();
            MostrarAhorcado();
            Console.WriteLine($"Intentos restantes: {_intentosRestantes}");
            Console.WriteLine($"Letras usadas: {string.Join(",", _letrasUsadas)}");
            Console.Write("Palabra: ");
            foreach (char c in _palabraSecreta)
                Console.Write(_letrasUsadas.Contains(c) ? c : '_');
            Console.WriteLine();
        }

        private void MostrarAhorcado()
        {
            string[] etapas = new string[]
            {
        // Etapa 0: solo la horca
        "  ┌─────┐\n" +
        "  │     │\n" +
        "  │      \n" +
        "  │      \n" +
        "  │      \n" +
        "  │      \n" +
        "──┴──────",

        // Etapa 1: cabeza
        "  ┌─────┐\n" +
        "  │     │\n" +
        "  │     O\n" +
        "  │      \n" +
        "  │      \n" +
        "  │      \n" +
        "──┴──────",

        // Etapa 2: torso
        "  ┌─────┐\n" +
        "  │     │\n" +
        "  │     O\n" +
        "  │     │\n" +
        "  │     │\n" +
        "  │      \n" +
        "──┴──────",

        // Etapa 3: brazo izquierdo
        "  ┌─────┐\n" +
        "  │     │\n" +
        "  │     O\n" +
        "  │    ╱│\n" +
        "  │     │\n" +
        "  │      \n" +
        "──┴──────",

        // Etapa 4: ambos brazos
        "  ┌─────┐\n" +
        "  │     │\n" +
        "  │     O\n" +
        "  │    ╱│╲\n" +
        "  │     │\n" +
        "  │      \n" +
        "──┴──────",

        // Etapa 5: pierna izquierda
        "  ┌─────┐\n" +
        "  │     │\n" +
        "  │     O\n" +
        "  │    ╱│╲\n" +
        "  │     │\n" +
        "  │    ╱ \n" +
        "──┴──────",

        // Etapa 6: ahorcado completo
        "  ┌─────┐\n" +
        "  │     │\n" +
        "  │     X\n" +
        "  │    ╱│╲\n" +
        "  │     │\n" +
        "  │    ╱ ╲\n" +
        "──┴──────"
            };

            // Color dinámico según los intentos restantes
            ConsoleColor colorOriginal = Console.ForegroundColor;
            Console.ForegroundColor = _intentosRestantes switch
            {
                >= 5 => ConsoleColor.Green,
                >= 3 => ConsoleColor.Yellow,
                _ => ConsoleColor.Red
            };

            Console.WriteLine();
            Console.WriteLine(etapas[6 - _intentosRestantes]);
            Console.WriteLine();

            Console.ForegroundColor = colorOriginal;
        }
    }
}
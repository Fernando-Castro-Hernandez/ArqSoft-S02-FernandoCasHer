using System;
using System.Collections.Generic;
using System.Text;

namespace Ahorcado
{
    public class ConsolaUI
    {
        private readonly MotorAhorcado _motor;
        public ConsolaUI(MotorAhorcado motor)
        {
            _motor = motor;
        }
        public void MostrarTablero()
        {
            Console.Clear();
            MostrarAhorcado();
            Console.WriteLine($"Intentos restantes: {_motor.IntentosRestantes}");
            Console.WriteLine($"Letras usadas: {string.Join(", ", _motor.LetrasUsadas)}");
            Console.Write("Palabra: ");
            foreach (char c in _motor.PalabraSecreta)
                Console.Write(_motor.LetrasUsadas.Contains(c) ? c : '_');
            Console.WriteLine();
            if (_motor.MostrarPista)
                Console.WriteLine($"Pista: la palabra empieza con '{_motor.PalabraSecreta[0]}'");

        }
        public char PedirLetra()
        {
            Console.Write("\nIngresa una letra: ");
            return Console.ReadLine()[0];
        }
        public void MostrarMensaje(string mensaje) => Console.WriteLine(mensaje);
        public bool PreguntarOtraVez()
        {
            Console.Write("\n¿Jugar otra vez? (s/n): ");
            return Console.ReadLine()?.ToLower() == "s";
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
            Console.ForegroundColor = _motor.IntentosRestantes switch
            {
                >= 5 => ConsoleColor.Green,
                >= 3 => ConsoleColor.Yellow,
                _ => ConsoleColor.Red
            };

            Console.WriteLine();
            Console.WriteLine(etapas[6 - _motor.IntentosRestantes]);
            Console.WriteLine();

            Console.ForegroundColor = colorOriginal;
        }
    }
}


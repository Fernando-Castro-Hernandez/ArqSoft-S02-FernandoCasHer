using System;
using System.Collections.Generic;
using System.Text;

using System;
using System.Collections.Generic;

namespace Ahorcado
{
    public enum Categoria
    {
        Arquitectura,
        POO,
        NET
    }

    public class PalabrasEnMemoria : IRepositorioPalabras
    {
        private readonly Dictionary<Categoria, List<string>> _palabrasPorCategoria = new()
        {
            [Categoria.Arquitectura] = new List<string>
            {
                "arquitectura", "componente", "descomposicion", "dependencia", "acoplamiento"
            },
            [Categoria.POO] = new List<string>
            {
                "polimorfismo", "encapsulamiento", "herencia", "abstraccion", "clase"
            },
            [Categoria.NET] = new List<string>
            {
                "ensamblado", "namespace", "interfaz", "delegado", "middleware"
            }
        };

        private readonly List<string> _palabrasActivas;
        private readonly Random _random = new();

        public PalabrasEnMemoria(Categoria categoria)
        {
            _palabrasActivas = _palabrasPorCategoria[categoria];
        }

        public string ObtenerPalabraAleatoria()
        {
            return _palabrasActivas[_random.Next(_palabrasActivas.Count)];
        }
    }
}

using System;

namespace ConsoleApp1
{
    class Nodo
    {
        public int Valor;
        public Nodo Izquierdo;
        public Nodo Derecho;

        public Nodo(int valor)
        {
            Valor = valor;
            Izquierdo = null;
            Derecho = null;
        }
    }

    class ArbolBinarioBusqueda
    {
        public Nodo Raiz;

        // Agregar un valor al árbol
        public void Agregar(int valor)
        {
            Raiz = AgregarRecursivo(Raiz, valor);
        }

        private Nodo AgregarRecursivo(Nodo nodo, int valor)
        {
            if (nodo == null)
                return new Nodo(valor);

            if (valor < nodo.Valor)
                nodo.Izquierdo = AgregarRecursivo(nodo.Izquierdo, valor);
            else if (valor > nodo.Valor)
                nodo.Derecho = AgregarRecursivo(nodo.Derecho, valor);

            return nodo;
        }

        // 1. Obtener el mínimo
        public int ObtenerMinimo()
        {
            if (Raiz == null)
                throw new InvalidOperationException("El árbol está vacío.");

            Nodo actual = Raiz;

            while (actual.Izquierdo != null)
            {
                actual = actual.Izquierdo;
            }

            return actual.Valor;
        }

        // 1. Obtener el máximo
        public int ObtenerMaximo()
        {
            if (Raiz == null)
                throw new InvalidOperationException("El árbol está vacío.");

            Nodo actual = Raiz;

            while (actual.Derecho != null)
            {
                actual = actual.Derecho;
            }

            return actual.Valor;
        }

        // 2. Cantidad de nodos
        public int ObtenerCantidadNodos()
        {
            return ContarNodos(Raiz);
        }

        private int ContarNodos(Nodo nodo)
        {
            if (nodo == null)
                return 0;

            return 1 + ContarNodos(nodo.Izquierdo)
                     + ContarNodos(nodo.Derecho);
        }

        // 3. Altura del árbol
        public int ObtenerAltura()
        {
            return CalcularAltura(Raiz);
        }

        private int CalcularAltura(Nodo nodo)
        {
            if (nodo == null)
                return 0;

            int alturaIzquierda = CalcularAltura(nodo.Izquierdo);
            int alturaDerecha = CalcularAltura(nodo.Derecho);

            return 1 + Math.Max(alturaIzquierda, alturaDerecha);
        }

        // 4. Contar hojas
        public int ContarHojas()
        {
            return ContarHojasRecursivo(Raiz);
        }

        private int ContarHojasRecursivo(Nodo nodo)
        {
            if (nodo == null)
                return 0;

            if (nodo.Izquierdo == null && nodo.Derecho == null)
                return 1;

            return ContarHojasRecursivo(nodo.Izquierdo)
                 + ContarHojasRecursivo(nodo.Derecho);
        }

        // 5. Eliminar un valor
        public void Eliminar(int valor)
        {
            Raiz = EliminarRecursivo(Raiz, valor);
        }

        private Nodo EliminarRecursivo(Nodo nodo, int valor)
        {
            if (nodo == null)
                return null;

            if (valor < nodo.Valor)
            {
                nodo.Izquierdo = EliminarRecursivo(nodo.Izquierdo, valor);
            }
            else if (valor > nodo.Valor)
            {
                nodo.Derecho = EliminarRecursivo(nodo.Derecho, valor);
            }
            else
            {
                // No tiene hijos
                if (nodo.Izquierdo == null && nodo.Derecho == null)
                    return null;

                // Solo tiene hijo derecho
                if (nodo.Izquierdo == null)
                    return nodo.Derecho;

                // Solo tiene hijo izquierdo
                if (nodo.Derecho == null)
                    return nodo.Izquierdo;

                // Tiene dos hijos
                Nodo sucesor = ObtenerNodoMinimo(nodo.Derecho);

                nodo.Valor = sucesor.Valor;

                nodo.Derecho =
                    EliminarRecursivo(nodo.Derecho, sucesor.Valor);
            }

            return nodo;
        }

        private Nodo ObtenerNodoMinimo(Nodo nodo)
        {
            Nodo actual = nodo;

            while (actual.Izquierdo != null)
            {
                actual = actual.Izquierdo;
            }

            return actual;
        }

        // 6. Verificar si el árbol es válido
        public bool EsValido()
        {
            return EsValidoRecursivo(Raiz, null, null);
        }

        private bool EsValidoRecursivo(
            Nodo nodo,
            int? minimo,
            int? maximo)
        {
            if (nodo == null)
                return true;

            if (minimo.HasValue && nodo.Valor <= minimo.Value)
                return false;

            if (maximo.HasValue && nodo.Valor >= maximo.Value)
                return false;

            return EsValidoRecursivo(
                       nodo.Izquierdo,
                       minimo,
                       nodo.Valor)
                   &&
                   EsValidoRecursivo(
                       nodo.Derecho,
                       nodo.Valor,
                       maximo);
        }

        // Mostrar el árbol en orden
        public void MostrarEnOrden()
        {
            MostrarEnOrdenRecursivo(Raiz);
            Console.WriteLine();
        }

        private void MostrarEnOrdenRecursivo(Nodo nodo)
        {
            if (nodo == null)
                return;

            MostrarEnOrdenRecursivo(nodo.Izquierdo);
            Console.Write(nodo.Valor + " ");
            MostrarEnOrdenRecursivo(nodo.Derecho);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda();

            // Agregar valores al árbol
            arbol.Agregar(50);
            arbol.Agregar(30);
            arbol.Agregar(70);
            arbol.Agregar(20);
            arbol.Agregar(40);
            arbol.Agregar(60);
            arbol.Agregar(80);

            Console.WriteLine("Árbol en orden:");
            arbol.MostrarEnOrden();

            // 1. Mínimo y máximo
            Console.WriteLine("Mínimo: " + arbol.ObtenerMinimo());
            Console.WriteLine("Máximo: " + arbol.ObtenerMaximo());

            // 2. Cantidad de nodos
            Console.WriteLine(
                "Cantidad de nodos: " +
                arbol.ObtenerCantidadNodos());

            // 3. Altura
            Console.WriteLine(
                "Altura: " +
                arbol.ObtenerAltura());

            // 4. Cantidad de hojas
            Console.WriteLine(
                "Cantidad de hojas: " +
                arbol.ContarHojas());

            // 5. Eliminar un nodo
            Console.WriteLine("\nEliminando el nodo 30...");
            arbol.Eliminar(30);

            Console.WriteLine("Árbol después de eliminar:");
            arbol.MostrarEnOrden();

            // 6. Verificar si es válido
            Console.WriteLine(
                "¿El árbol es válido? " +
                arbol.EsValido());

            Console.WriteLine("\nPresione una tecla para finalizar...");
            Console.ReadKey();
        }
    }
}

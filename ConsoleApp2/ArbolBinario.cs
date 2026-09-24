namespace ConsoleApp2
{
    public class ArbolBinario
    {
        private Nodo raiz;

        public void Insertar(Pokemon pokemon)
        {
            raiz = InsertarRecursivo(raiz, pokemon);
        }

        private Nodo InsertarRecursivo(Nodo nodo, Pokemon pokemon)
        {
            if (nodo == null)
            {
                return new Nodo(pokemon);
            }

            if (pokemon.Id < nodo.Pokemon.Id)
            {
                nodo.Izquierda = InsertarRecursivo(nodo.Izquierda, pokemon);
            }
            else if (pokemon.Id > nodo.Pokemon.Id)
            {
                nodo.Derecha = InsertarRecursivo(nodo.Derecha, pokemon);
            }

            return nodo;
        }

        public Pokemon Buscar(int id)
        {
            Nodo actual = raiz;

            while (actual != null)
            {
                if (id == actual.Pokemon.Id)
                {
                    return actual.Pokemon;
                }

                if (id < actual.Pokemon.Id)
                {
                    actual = actual.Izquierda;
                }
                else
                {
                    actual = actual.Derecha;
                }
            }

            return null;
        }

        public void Mostrar()
        {
            MostrarRecursivo(raiz);
        }

        private void MostrarRecursivo(Nodo nodo)
        {
            if (nodo != null)
            {
                MostrarRecursivo(nodo.Izquierda);
                Console.WriteLine(nodo.Pokemon.Id + " - " + nodo.Pokemon.Nombre);
                MostrarRecursivo(nodo.Derecha);
            }
        }

        public void Vaciar()
        {
            raiz = null;
        }
    }
}

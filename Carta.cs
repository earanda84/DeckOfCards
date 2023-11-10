// Clase Carta
class Carta
{
    // Propiedades de la Carta
    public string Nombre { get; set; }

    public string Pinta { get; set; }
    public int Val { get; set; }

    // Constructor
    public Carta(string nombre, string pinta, int val)
    {
        Nombre = nombre;
        Pinta = pinta;
        Val = val;
    }

    // Método
    public void Print()
    {
        Console.WriteLine($"Nombre: {Nombre}\nValor: {Val}\nPinta: {Pinta}");
    }
}

// Clase Mazo
class Mazo
{
    // Propiedades de Mazo
    public List<Carta> Cartas { get; set; } = new List<Carta>();
    // Constructor de Mazo, inicializa metodo InicializarMazo()
    public Mazo()
    {
        InicializarMazo();
    }
    private void InicializarMazo()
    {
        // Inicializar Cartas
        Cartas = new List<Carta>();

        // Arreglo de nombres
        string[] nombres = { "As", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Reina", "Rey" };

        // Arreglo de pintas
        string[] pintas = { "Treboles", "Picas", "Corazones", "Diamantes" };

        // Ciclo para inyectar 52 cartas, según largo de arreglo de nombres
        for (int idx = 0; idx < nombres.Length; idx++)
        {
            for (int j = 0; j < pintas.Length; j++)
            {
                // Crea una carta por cada iteración
                Carta nuevaCarta = new Carta(nombres[idx], pintas[j], idx + 1);
                // Agrega las cartas a la lista Cartas
                Cartas.Add(nuevaCarta);
            }
        }
    }

    // Método Reparto
    public Carta Reparto()
    {
        // Parte en la posición 0 de la lista Cartas, indicando que la carta mayor corresponde a este índice.
        Carta cartaMayor = Cartas[0];

        // Bucle para reocorrer la lista de Cartas.
        foreach (Carta carta in Cartas)
        {
            // Si el valor de carta actual es mayor al valor de la carta mayor, actualiza la carta mayor con el elemento que se encuentra en el índice evaluado
            if (carta.Val > cartaMayor.Val)
            {
                // Actualiza si encuentras una carta con un valor mayor.
                cartaMayor = carta;
            }

        }
        // Elimina de la lista de Cartas la carta mayor
        Cartas.Remove(cartaMayor);
        // Retorna el valor de la carta mayor
        return cartaMayor;
    }
    // Método que reinicia el mazo con las 52 cartas, inicializando el metodo InicializarMazo()
    public void ReinicioMazo()
    {
        InicializarMazo();
    }

    //Método Barajador de cartas, que reordena las carta del mazo de manera aleatoria
    public void Barajado()
    {
        // Instancia Random para generear número aleatorios.
        Random rand = new Random();

        // Ciclo for para recorrer todas las cartas en el Mazo
        for (int i = 0; i < Cartas.Count; i++)
        {
            // Genero un índice aleatorio dentro del rango de cartas del Mazo
            int randomIndex = rand.Next(0, Cartas.Count);
            // Guarda la carta actual en una variable temporal
            Carta cartaTemporal = Cartas[i];
            // Intercambia la carta actual almacenada como carta temporal y la intercambia con la carta escogida de manera aleatoria por el método random
            Cartas[i] = Cartas[randomIndex];
            // Establece la carta temporal en el índice aleatorio como la carta temporal
            Cartas[randomIndex] = cartaTemporal;

        }
    }
}


// Clase Jugador
class Jugador
{
    // Propiedades de la clase Jugador
    public string Nombre { get; set; } = "";
    // Se define una lista de cartas para la Mano del jugador con metodo set y get, y se define como una lista de Carta para que no retorne no null
    public List<Carta> Mano { get; set; } = new List<Carta>();

    // Se define un constructor para el jugador con string Nombre
    public Jugador(string nombre)
    {
        Nombre = nombre;
    }

    // Metodo para poder extraer de la instancia Mazo una carta
    public Carta? Robo(Mazo mazo)
    {
        // Instancio el metodo Random para generara un número aleatorio
        Random rand = new Random();
        // Evalúo si el mazo contiene cartas
        if (mazo.Cartas.Count > 0)
        {
            // Defino un número aleatorio entre 0 y el largo del Mazo, ósea la cantidad de cartas  del mazo.
            int randomIndex = rand.Next(0, mazo.Cartas.Count);
            // Almacena la carta extraída del mazo, mediante el número aleatorio generado por el método random.next();
            Carta cartaRobada = mazo.Cartas[randomIndex];
            // Almaceno en en la lista Mano, que es una lista de cartas, la carta extraída del mazo
            Mano.Add(cartaRobada);
            // Remuevo del mazo la carta mediante el número aleatorio generado por el método Random().
            mazo.Cartas.RemoveAt(randomIndex);

            return cartaRobada;
        }

        // Si el Mazo no tiene cartas, retornara null
        return null;
    }

    // Método Descarte, que descarta la carta según el índice pasado cuando este se instancie.
    public Carta? Descarte(int index)
    {
        // Evalúa si el índice esta en el rango de la cantidad de cartas de la mano del jugador.
        if (index >= 0 && index < Mano.Count)
        {
            // De la mano del jugador descarta la carta pasada según el índice pasado cuándo esta se instancie.
            Carta cartaDescartada = Mano[index];
            // Remueve la carta de la mano del jugador según el índice pasado en la istancia del método Descarte.
            Mano.RemoveAt(index);

            return cartaDescartada;
        }

        return null;
    }
}
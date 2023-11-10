class Carta
{
    public string Nombre { get; set; }

    public string Pinta { get; set; }
    public int Val { get; set; }

    public Carta(string nombre, string pinta, int val)
    {
        Nombre = nombre;
        Pinta = pinta;
        Val = val;
    }

    public void Print()
    {
        Console.WriteLine($"Nombre: {Nombre}\nValor: {Val}\nPinta: {Pinta}");
    }
}


class Mazo
{
    public List<Carta> Cartas { get; set; } = new List<Carta>();
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

                Carta nuevaCarta = new Carta(nombres[idx], pintas[j], idx + 1);

                Cartas.Add(nuevaCarta);
            }
        }
    }

    public Carta Reparto()
    {

        Carta cartaMayor = Cartas[0]; // Inicializa con la primera carta.

        foreach (Carta carta in Cartas)
        {
            if (carta.Val > cartaMayor.Val)
            {
                cartaMayor = carta; // Actualiza si encuentras una carta con un valor mayor.
            }

        }
        // Eliminar de la lista
        Cartas.Remove(cartaMayor);
        return cartaMayor;
    }

    public void ReinicioMazo()
    {
        InicializarMazo();
    }

    public void Barajado()
    {
        Random rand = new Random();

        for (int i = 0; i < Cartas.Count; i++)
        {
            int randomIndex = rand.Next(0, Cartas.Count);

            Carta cartaTemporal = Cartas[i];

            Cartas[i] = Cartas[randomIndex];

            Cartas[randomIndex] = cartaTemporal;

        }
    }
}

class Jugador
{
    public string Nombre { get; set; } = "";
    public List<Carta> Mano { get; set; } = new List<Carta>();

    public Jugador(string nombre)
    {
        Nombre = nombre;
    }
    public Carta? Robo(Mazo mazo)
    {
        Random rand = new Random();
        if (mazo.Cartas.Count > 0)
        {
            int randomIndex = rand.Next(0, mazo.Cartas.Count);
            Carta cartaRobada = mazo.Cartas[randomIndex];

            Mano.Add(cartaRobada);

            mazo.Cartas.RemoveAt(randomIndex);

            return cartaRobada;
        }

        return null;
    }

    public Carta? Descarte(int index)
    {
        if(index >= 0 && index < Mano.Count){
            Carta cartaDescartada = Mano[index];
            Mano.RemoveAt(index);

            return cartaDescartada;
        }

        return null;
    }
}
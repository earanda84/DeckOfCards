// Instancia de carta
Console.WriteLine("***********************");
Carta carta1 = new Carta("Pica", "Trebol", 4);
carta1.Print();
Console.WriteLine("***********************");

// Instancia de Mazo
Mazo newMazo = new Mazo();

Console.WriteLine("**************");
Console.WriteLine($"Total de cartas en el mazo: {newMazo.Cartas.Count} cartas");
Console.WriteLine("**************");

// Bucle foreach para mostrar en la lista de Mazo las cartas existentes
foreach (Carta carta in newMazo.Cartas)
{
    Console.WriteLine($"Para la carta {carta.Nombre}, su pinta es {carta.Pinta}");
}

Carta cartaMayor = newMazo.Reparto();

Console.WriteLine("*********************");

Console.WriteLine($"La carta mayor es: {cartaMayor.Nombre}\nEl valor de la carta es: {cartaMayor.Val}\nLa pinta de la carta es: {cartaMayor.Pinta}");

// Cantidad de cartas después de remover la más alta.
Console.WriteLine("**************");
Console.WriteLine($"Total de cartas en el mazo, después de remover la más alta: {newMazo.Cartas.Count} cartas");
Console.WriteLine("**************");

Mazo newMazo2 = new Mazo();

Console.WriteLine($"Total de cartas en nuevo Mazo: {newMazo2.Cartas.Count} cartas");

Mazo newMazo3 = new Mazo();
newMazo3.Barajado();

foreach (var carta in newMazo3.Cartas)
{
    Console.WriteLine("******************");
    Console.WriteLine($"Nombre: {carta.Nombre}, Valor: {carta.Val}, Pinta: {carta.Pinta}");

}

Jugador jugador = new Jugador("Eric");

Mazo newMazo4 = new Mazo();

for (int i = 0; i < 3; i++)
{
    Carta? roboCarta = jugador.Robo(newMazo4);

    if (roboCarta != null)
    {
        Console.WriteLine("****************");
        Console.WriteLine($"Carta robada {roboCarta.Nombre} de {roboCarta.Pinta}");
    }
}

foreach (Carta carta in jugador.Mano)
{
    Console.WriteLine("****************");
    Console.WriteLine($"{carta.Nombre} de {carta.Pinta}");
}


Carta? cartaDescartada = jugador.Descarte(1);


if (cartaDescartada != null)
{
    Console.WriteLine("****************");
    Console.WriteLine($"Carta descartada {cartaDescartada?.Nombre} de {cartaDescartada?.Pinta}");
}
else
{
    Console.WriteLine($"Indice de descarte no existe");
}






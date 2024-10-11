using System;

class Szyfr_Cezara
{
    static void Main()
    {
        Console.WriteLine("Witaj w programie szyfrującym i deszyfrującym Cezara!"); 
        // Wybór operacji: szyfrowanie lub deszyfrowanie
        string operacja;
        do
        {
            Console.WriteLine("Wybierz operację: (S) Szyfrowanie / (D) Deszyfrowanie");
            operacja = Console.ReadLine();

            if (operacja != null)
            {
                operacja = operacja.Trim().ToUpper();
            }
            if (operacja != "S" && operacja != "D")
            {
                Console.WriteLine("Niewłaściwy wybór. Spróbuj ponownie, wybierając 'S' lub 'D'.");
            }
        }
        while (operacja != "S" && operacja != "D");
    
        // Wprowadzenie tekstu do przetworzenia
        Console.WriteLine("Wprowadź tekst do przetworzenia:");
        string tekst = Console.ReadLine();
        
        // Wprowadzenie wartości przesunięcia z walidacją
        int przesuniecie;
        do
        {
            Console.WriteLine("Podaj wartość przesunięcia (np. 3 dla szyfrowania o 3 miejsca):");
            if (!int.TryParse(Console.ReadLine(), out przesuniecie))
            {
                Console.WriteLine("Nieprawidłowa wartość. Podaj liczbę całkowitą.");
            }
            else
            {
                break; 
            }

        }
        while (true);
        
        // Określenie finalnego przesunięcia w zależności od operacji
        int finalnePrzesuniecie;
        if (operacja == "D")
        {
            finalnePrzesuniecie = -przesuniecie; // Dla deszyfrowania przesunięcie jest ujemne
        }
        else
        {
            finalnePrzesuniecie = przesuniecie; // Dla szyfrowania przesunięcie jest dodatnie
        }
        
        // Przetwarzanie tekstu i wyświetlenie wyniku
        string wynik = PrzetworzTekst(tekst, finalnePrzesuniecie);
        Console.WriteLine($"Wynik przetworzenia: {wynik}");
    }

    // Funkcja przetwarzająca cały tekst według przesunięcia
    static string PrzetworzTekst(string wejscie, int przesuniecie)
    {
        char[] znakiTekstu = new char[wejscie.Length];

        for (int i = 0; i < wejscie.Length; i++)
        {
            char znak = wejscie[i];
            if (char.IsLetter(znak))
            {
                char baza;
                if (char.IsUpper(znak))
                {
                    baza = 'A';
                }
                else
                {
                    baza = 'a';
                }
                znak = (char)((znak - baza + przesuniecie + 26) % 26 + baza);
            }
            znakiTekstu[i] = znak;
        }
        return new string(znakiTekstu);
    }
}
 

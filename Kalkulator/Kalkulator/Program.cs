class Pogram
{
    static double poprzedniWynik = 0;
    static bool czyJestWynik = false;

    static void Main()
    {
        while (true)
        {
            Console.Write("Operacje (+, -, *, /, ^), 'wyczyść' - reset, 'exit' - koniec: ");

            string operacja = Console.ReadLine();

            if (operacja.ToLower() == "exit")
            {
                break;
            }

            if (operacja.ToLower() == "wyczyść")
            {
                poprzedniWynik = 0;
                czyJestWynik = false;
                Console.WriteLine("Wynik został wyczyszczony.");
                continue;
            }

            double liczba1;

            if (czyJestWynik)
            {
                liczba1 = poprzedniWynik;
            }
            else
            {
                Console.Write("Liczba 1: ");
                string wejscie = Console.ReadLine();

                if (wejscie.ToLower() == "exit")
                {
                    break;
                }

                liczba1 = double.Parse(wejscie);
            }

            Console.Write("Liczba 2: ");
            string wejscie2 = Console.ReadLine();

            if (wejscie2.ToLower() == "exit")
            {
                break;
            }

            double liczba2 = double.Parse(wejscie2);

            switch (operacja)
            {
                case "+":
                    Dodaj(liczba1, liczba2);
                    break;
                case "-":
                    Odejmij(liczba1, liczba2);
                    break;
                case "*":
                    Pomnoz(liczba1, liczba2);
                    break;
                case "/":
                    Podziel(liczba1, liczba2);
                    break;
                case "^":
                    Poteguj(liczba1, liczba2);
                    break;
                default:
                    Console.WriteLine("Nieznana operacja.");
                    break;
            }
        }
    }

    static void Dodaj(double liczba1, double liczba2) =>
        ZapiszWynik(liczba1, "+", liczba2, liczba1 + liczba2);

    static void Odejmij(double liczba1, double liczba2) =>
        ZapiszWynik(liczba1, "-", liczba2, liczba1 - liczba2);

    static void Pomnoz(double liczba1, double liczba2) =>
        ZapiszWynik(liczba1, "*", liczba2, liczba1 * liczba2);

    static void Poteguj(double liczba1, double liczba2) =>
        ZapiszWynik(liczba1, "^", liczba2, Math.Pow(liczba1, liczba2));

    static void Podziel(double liczba1, double liczba2)
    {
        try
        {
            if (liczba2 == 0)
            {
                throw new DivideByZeroException();
            }

            ZapiszWynik(liczba1, "/", liczba2, liczba1 / liczba2);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Błąd: Nie można dzielić przez zero.");
        }
    }

    static void ZapiszWynik(double liczba1, string operacja, double liczba2, double wynik)
    {
        poprzedniWynik = wynik;
        czyJestWynik = true;
        Console.WriteLine($"{liczba1} {operacja} {liczba2} = {wynik}");
    }
}
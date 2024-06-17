using System.Text;
internal class Program

{
    private static void Main(string[] args)
    {
      
        static string PuntuacionEspacio(string input)
        {
            string resultado = "";
            foreach (char c in input)
            {
                if (!char.IsPunctuation(c) && !char.IsWhiteSpace(c))
                {
                    resultado += c;
                }
            }
            return resultado;
        }

        Console.WriteLine("ingresa una palabra:");
        bool ver = true;
        string input;
        input = Console.ReadLine();

        string palabra = PuntuacionEspacio(input);
        StringBuilder sb = new StringBuilder();

        sb.Append(palabra);

        int i = 0;
        int j = palabra.Length-1;

        for (int k = 0; k <= palabra.Length-1; k++)
        {
            if (palabra[i] == palabra[j])
            {
                i++;
                j--;
                ver = true;
            }
            else if (palabra[i] != palabra[j])
            {
                ver = false;
            }
        }

        if (ver == true)
        {
            Console.WriteLine("la palabra "+palabra + " si es un palindrome ");
        }

        else if (ver == false)
        {
            Console.WriteLine("la palabra ", palabra , " no es un palindrome");
        } 



        Console.WriteLine("");
    }
}
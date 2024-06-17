internal class Program
{ 

    private static void Main(string[] args)
    {

        int num = 0;
        
        while (num<1 || num >10)
        {
            Console.WriteLine("Ingrese un numero entre el 1 y el 10");
            num = int.Parse(Console.ReadLine());
        }
       
        static void multiplicar(int num)
        {
            int rr;
            for (int i = 0; i <= 10; i++)
            {
                rr = i * num;
                Console.WriteLine(num + " x " + i + " = " + rr);
            }

        }

        multiplicar(num);





    }
}
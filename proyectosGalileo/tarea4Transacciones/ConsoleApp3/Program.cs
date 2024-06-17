using System;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            //decimal balance = 0.0m;
            int op;

            string name, lastName;
            decimal balance;
            

            Console.WriteLine("Ingrese su nombre: ");
            name=Console.ReadLine();
            Console.WriteLine("Ingrese su apellido: ");
            lastName=Console.ReadLine();

            balance = 0.0m;

            Class1 usuario1=new Class1 (name, lastName, balance);


            do {


                Console.WriteLine("ingrese el numero de la accion que quiere realizar");
                Console.WriteLine("1) Depositar ");
                Console.WriteLine("2) Retirar ");
                Console.WriteLine("3) Salir");
                op = int.Parse(Console.ReadLine());


                switch (op)
                {
                    case 1:
                        Console.WriteLine("---DEPOSITO---");

                        Console.WriteLine("Ingrese la cantidad de dinero que quiere depositar: ");
                        int deposito = int.Parse(Console.ReadLine());
                        depositar(deposito);
                        mostrarBalance(usuario1);
                        

                        break;

                    case 2:
                        Console.WriteLine("---RETIRO---");
                        if (usuario1.Balance > 0)
                        {
                            Console.WriteLine("Ingrese la cantidad de dinero que quiere retirar: ");
                            int retiro = int.Parse(Console.ReadLine());
                            retirar(retiro);
                            mostrarBalance(usuario1);
                        }
                        else if (usuario1.Balance <= 0)
                        {
                            Console.WriteLine("No puede retirar dinero, no hay fondos");
                            mostrarBalance(usuario1);
                        }


                        break;
                }


            }while (op!=3);
            Console.WriteLine("bye");




            void depositar(int deposito){
                //int deposito;
                //Console.WriteLine("Ingrese la cantidad de dinero que quiere depositar: ");
                //deposito = int.Parse(Console.ReadLine());
                usuario1.Balance = usuario1.Balance + deposito;
                //Console.WriteLine($"Su saldo actual es de {Balance}");


            }

            void retirar(int retiro)
            {

                //int retiro;
                //Console.WriteLine("Ingrese la cantidad de dinero que quiere retirar: ");
                //retiro = int.Parse(Console.ReadLine());
                usuario1.Balance = usuario1.Balance - retiro;
                //Console.WriteLine($"Su saldo actual es de {balance}");

            }

            void mostrarBalance(Class1 usuario1)
            {
                Console.WriteLine($"nombre: {usuario1.Name} apellido: {usuario1.LastName} saldo: {usuario1.Balance}");
            }







        }
    }
}
using System;
using System.Collections;
using System.IO;

namespace TiendaOnline
{
    class Program
    {
        class Producto
        {
            public String referencia;
            public String nombre;
            public decimal precio;

            public Producto()
            {
            }

            public Producto(string referencia, string nombre, decimal precio)
            {
                this.referencia = referencia;
                this.nombre = nombre;
                this.precio = precio;
            }

            public String mostrar()
            {
                return "ref: " + referencia + "\n" + "nombre: " + nombre + "\n" + "precio: " + precio + " $";
            }
        }

        const int MAX = 20;
        class CLista
        {
            public int numero;
            public Producto[] empresa = new Producto[MAX];

        }

        static int cargar(CLista l)
        {
            int i = 0;
            StreamReader F = new StreamReader("productos.txt");
            string linea = F.ReadLine();
            string[] palabra = new string[3];
            while (linea != null)
            {
                Producto e = new Producto();
                palabra = linea.Split('-');
                e.referencia = palabra[0];
                e.nombre = palabra[1];
                e.precio = Convert.ToDecimal(palabra[2]);
                l.empresa[i] = e;
                i++;
                linea = F.ReadLine();
            }
            l.numero = i;
            F.Close();

            return (0);
        }


        class Carrito
        {
            public ArrayList Producto;

            public Carrito()
            {
                Producto = new ArrayList();
            }

            public void añadirProducto(Producto producto)
            {
                Producto.Add(producto);
            }

            public void limpiarCarrito()
            {

            }

            public void mostrarCarrito()
            {
                foreach (Producto a in Producto)
                {
                    Console.WriteLine(a.mostrar());
                }
            }

            public void totalFactura()
            {

            }

            public void buscarProducto()
            {

            }
        }
        static void Main(string[] args)
        {
            CLista mi_lista = new CLista();
            int i = 0, res, opcion;
            res = cargar(mi_lista);

            int op;

            Carrito c = new Carrito();

            do
            {

                op = menu();

                switch (op)
                {
                    case 1:
                        while (i < mi_lista.numero)
                        {
                            Console.WriteLine("ref: " + mi_lista.empresa[i].referencia);
                            Console.WriteLine("nombre: " + mi_lista.empresa[i].nombre);
                            Console.WriteLine("precio: " + mi_lista.empresa[i].precio + "$" + "\n");
                            i++;

                        }

                        break;

                    case 2:
                        String referencia;
                        String nombre;
                        decimal precio;

                        Console.WriteLine("ref?");
                        referencia = Console.ReadLine();
                        Console.WriteLine("nombre?");
                        nombre = Console.ReadLine();
                        Console.WriteLine("precio?");
                        precio = Convert.ToDecimal(Console.ReadLine());

                        Producto a = new Producto(referencia, nombre, precio);

                        c.añadirProducto(a);
                        break;

                    case 3:
                        c.mostrarCarrito();
                        break;
                }

            } while (op != 0);

        }

        public static int menu()
        {
            Console.WriteLine("0. salir");
            Console.WriteLine("1. mostrar catalogo");
            Console.WriteLine("2. añadir producto al carrito");
            Console.WriteLine("3. mostrar los productosen el carrito");
            Console.WriteLine("opción?");

            int op = Convert.ToInt32(Console.ReadLine());

            return op;
        }
    }
}

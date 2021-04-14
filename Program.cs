using retoP2.list;
using System;

namespace retoP2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lista1 = new ArrayList<int>();
            List<String> lista2 = new ArrayList<String>();
            List<double> lista3 = new LinkedList<double>();

            lista1.add(1);
            lista1.add(7);
            lista1.add(3);
            lista1.add(13);

            lista2.add("hola");
            lista2.add(" soy");
            lista2.add(" un  ");
            lista2.add(" main");

            lista3.add(3.1416);
            lista3.add(54.3858);
            lista3.add(4.851);
            lista3.add(85.675);
            lista3.add(6.278);


            lista1.delete(2);

            System.Console.WriteLine("---------------------");

            System.Console.WriteLine("El tamaño es:" + lista1.getSize());
            Iterator<int> it = lista1.getIterator();

            while (it.hasNext())
            {
                int element = it.next();

                System.Console.WriteLine("Dato: " + element);
            }
            System.Console.WriteLine("---------------------");
            it = lista1.getReverseIterator();

            while (it.hasNext())
            {
                int element = it.next();

                System.Console.WriteLine("Dato: " + element);
            }

            System.Console.WriteLine("---------------------");

            Iterator<String> itStrings = lista2.getIterator();

            while (itStrings.hasNext())
            {
                System.Console.WriteLine(itStrings.next());
            }

            System.Console.WriteLine("---------------------");

            Iterator<double> it3 = lista3.getIterator();

            it3 = lista3.getIterator();

            while (it3.hasNext())
            {
                double element = it3.next();

                System.Console.WriteLine("Dato: " + element);
            }

        }
    }
}

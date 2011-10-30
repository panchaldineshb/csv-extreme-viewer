using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {

            TextWriter tsw = new StreamWriter(@"C:\File.csv");
            string[][] Datos = new string [4][]; 
            Datos[0]  = new string[]{ "Jorge", "Elva", "Alejandra", "Patrica", "Paulina", "Vianney", "Pedro", "Luis", "Ruth", "Juan", "Lidia", "Veronica", "Cecilia", "Karina", "Afonso", "Edgardo", "Edith", "Edmundo", "Eduardo", "Efren", "Elena", "Ivan", "Ida", "Iris", "Irma", "Isaias", "Israel", "Ulises", "Uriel", "Aron", "Aida", "Agustin", "Adan", "Alan", "Jesus", "Juda", "Jacob", "Julio", "Maria", "Karolina", "Miriam", "Mina", "Miguel", "Moises", "Monica", "Martha", "Martin", "Nayeli, ","Nevay","Noe", "Norma", "Napoleon", "Pilar", "Carlos", "Ricardo", };
            Datos[1] = new string[] { "Mendez", "Cervantes", "Muñoz", "Angel", "Hernandez", "Garcia", "Martinez", "Gonzalez", "Lopez", "Rodriguez", "Perez", "Sanchez", "Ramirez", "Flores", "Reyes", "Vargas", "Ruiz", "Salazar", "Morales", "Romero", "Ruiz", "Castro", "Gutierrez", "Lopez", "Ramos", "Mendoza", "Torres", "Garcia", "Rodriguez", "Diaz", "Quispe", "Magon", "Rojas", "Acosta", "Cardozo", "Ortiz", "Fernadez", "Ferrerira", "Caceres", "Nuñez", "Ayala", "Baez", "Vera", "Duarte", "Esquivel", "Salas", "Alonso", "Pedraza" };
            Datos[2] = new string[] { "Acapulco", "Cancun","Paquime", "Chetumal", "Chiapas", "Chihuahua", "Ciudad Juarez", "Ciudad Vicotria", "Culiacan", "Durango", "Guadalajara", "Guanajuato", "Hermosillo", "Matamoros", "La paz", "Matamoros", "Coahuila", "Mazatlan", "Mexico", "Monterrey", "Morelia", "Oaxaca", "Palenque", "Playa del carmen", "Puebla", "San cristobal", "San luis potosi", "Queretaro", "Tampico", "Tequila", "Torreon", "Veracruz", "Villahermosa", "Xcaret", "Zacatecas" };
            Datos[3] = new string[] { "Activo", "Inactivo" };
          
            tsw.WriteLine("ID, Nombre, Apellido, Lugar de Nacimiento,  Status");

             getData datos = new getData();

            for (int i = 0; i <= 1000000000; i++)
            {
                tsw.WriteLine((i + 1) + "," + datos.Get_Data(Datos[0]) + "," + datos.Get_Data(Datos[1]) + "," + datos.Get_Data(Datos[2]) + ","+ datos.Get_Data(Datos[3]));
            }
            Console.WriteLine("Listo...");
            Console.ReadKey();
            tsw.Close();

                 }
     

    }
}

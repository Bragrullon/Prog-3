bool continuar = true;

while(continuar){

Console.Clear();
Console.WriteLine(@"

Personas vacunadas contra el COVID 19

Introduzca una opcion:

1- Registrar Vacunado.
2- Exportar Tarjeta de vacunacion a HTML
3- Configuracion de Provincias y vacunas
4- Salir

");

Console.WriteLine("Ingresa una opcion:");
var opcion = Console.ReadLine();

switch(opcion){

case "1":

Console.WriteLine("Registrar Vacunado");
Modulos.Conf_Registrar();

break;

case "2":

Console.WriteLine("Exportar tarjeta de vacunacion");

Modulos.Exportar();

break;

case "3":

Console.WriteLine("Configuracion");
Modulos.Conf_Provincias();

break;

case "4":

continuar = false;

break;

default:
Console.WriteLine("Opcion no valida");
Console.ReadLine();
break;


}


}

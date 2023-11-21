
class Modulos{


    public static void Configuracion(){

        bool continuar = true;
        while(continuar){

Console.Clear();
Console.WriteLine(@"

Configuracion:
 P - Provincias
 V - Vacunas
 R- Regresar 


");

Console.WriteLine("Ingrese una opcion");
string opcion = Console.ReadLine();

switch(opcion){

case "P":

Console.WriteLine("Provincias");

break;

case "V":

Console.WriteLine("Vacunas");

break;

case "R":

continuar = false;

break;

default:
Console.WriteLine("opcion no valida");
Console.ReadLine();
break;






}





    }
  
  }

  public static void Conf_Provincias(){

var db = new CovidContext();
  
  bool continuar = true;
  while(continuar){
    Console.Clear();
    Console.WriteLine(@"
    
    Gestion de provincias

    1- Agregar Provincias
    2- Editar Provincias
    3- Regresar 
    ");

    Console.Write("Ingresa una opcion");

    string opcion = Console.ReadLine()??""; 

    switch(opcion){

  case "1":
  Console.Clear();
  Console.WriteLine("Agregar Pronvicias");
  
//Agregar provincias

Console.WriteLine("Vamos agregar una provincias");
 
var p = new Provincias();

p.Nombre = Utils.input("Ingrese el nombre de la provincia:");
db.Provincias.Add(p);
db.SaveChanges();


Console.WriteLine("Provincias agregada");
Console.ReadKey();

  break;

  case "2":
  Console.WriteLine("Editar Provincias");
  Console.Clear();

  Console.WriteLine("Vamos a editar una provincia");
  
  List<Provincias> provincias = db.Provincias.ToList();
  foreach(var prov in provincias){

    Console.WriteLine($"{prov.id} - {prov.Nombre}");
  }

  Console.WriteLine("Ingrese el ID de la provincia");
  var editar = db.Provincias.Find(int.Parse(Console.ReadLine()));
  
  if(editar == null){
  
  Console.WriteLine("No se encontro la provincia");
  Console.ReadKey();
  }
  else{

    Console.WriteLine("Ingrese el nuevo nombre de la provincial");
    editar.Nombre = Console.ReadLine();
    db.SaveChanges();
    Console.WriteLine("Provincias editada");
  }
  break;



  case "3":
  continuar = false;
  break;

  default:
  Console.WriteLine("Opcion no valida");
  Console.ReadKey();
  break;

    }

  }

  }

  public static void Conf_Vacunas(){

    var db = new CovidContext();

bool continuar = true;
while(continuar){
  Console.Clear();
  Console.WriteLine(@"
  
  
  Gestion de vacuna 

1- Registrar Vacuna
2- Editar Vacuna
3- Salir
  
  ");

Console.WriteLine("Ingresa una opcion");
string opcion = Console.ReadLine();

switch(opcion){

  case "1":

  Console.Clear();
  Console.WriteLine("Agregar Vacuna");

  var v = new Vacunas();
  v.Nombre = Utils.input("Ingrese el nombre de la vacuna");
  db.Vacunas.Add(v);
  db.SaveChanges();
  Console.WriteLine("Vacuna agregada");
  Console.ReadKey();
 
  break;

  case "2":

  Console.WriteLine("Editar Vacuna");
  Console.Clear();
  Console.WriteLine("Vamos a editar una vacuna");
  List<Vacunas> vacunas = db.Vacunas.ToList();
  foreach(var vac in vacunas){
    Console.WriteLine($"{vac.id} - {vac.Nombre}");
  }

  Console.WriteLine("Ingrese el ID de la vacuna:");
  var editar = db.Vacunas.Find(int.Parse(Console.ReadLine()));
  
  if(editar == null){
  
  Console.WriteLine("No se encontro la Vacuna");
  Console.ReadKey();
  }
  else{

    Console.WriteLine("Ingrese el nuevo nombre de la Vacuna:");
    editar.Nombre = Console.ReadLine();
    db.SaveChanges();
    Console.WriteLine("Vacuna editada");
    Console.ReadKey();
  }



  break;

  case "3":
 
 continuar = false;

  break;
}


}



  }
public static void Conf_Registrar(){

  var db = new CovidContext();
  Console.Clear();
  Console.WriteLine("Registrar Vacuna");
  var p = new Persona();
  var proceso = new Proceso();
  
  var Cedula = Utils.input("Ingrese la cedula");

  p = db.Personas.Where(x => x.Cedula == p.Cedula).FirstOrDefault();


if(p ==null){

  var persona1 = new Persona();
  persona1.ok = false;

  try{
  var url = "https://api.adamix.net/apec/cedula/" + p.Cedula;
  var client = new HttpClient();
  var response = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
  
  var persona = Newtonsoft.Json.JsonConvert.DeserializeObject<Persona>(response);
  }
  catch(Exception){}

if(persona1.ok){


  p.Nombre = persona1.Nombre;
  p.Apellido = persona1.Apellido;
}else{
  p.Nombre = Utils.input("Ingrese el nombre:");
  p.Apellido = Utils.input("Ingrese el apellido:");
}

p.Telefono = Utils.input("Ingrese el telefono:");
db.Personas.Add(persona1);

proceso.Persona = persona1;
proceso.Fecha = DateTime.Now;

while(proceso.Vacunas == null){

Console.WriteLine("Ingrese el id de la vacuna:");
var vacuna = db.Vacunas.Find(int.Parse(Console.ReadLine()));
if(vacuna == null){
  Console.WriteLine("No se encontro la vacuna");

}
else{
  proceso.Vacunas = vacuna;
}

}

var ListadoProvincias = db.Provincias.ToList();
foreach(var prov in ListadoProvincias){
Console.WriteLine($"{prov.id} {prov.Nombre}");
}
while(proceso.Provincia == null){
  Console.WriteLine("Ingrese el id de la provincia:");
  var provincia = db.Provincias.Find(int.Parse(Console.ReadLine()));
  if(provincia == null){
    Console.WriteLine("No se encontro la provincia");

  }
  else{
    proceso.Provincia = provincia;
}


  
  }

  db.PacienteVacunas.Add(proceso);
  db.SaveChanges();
  Console.WriteLine("Vacunado registrado");
  Console.ReadKey();

}
}

public static void Exportar(){

var db = new CovidContext();
Console.Clear();
Console.WriteLine("Vamos a expotar un HTML");
Persona persona = null;
while(persona == null){

var cedula = Utils.input("Ingrese una cedula");
if(cedula.ToLower().Trim() == "x"){
var listadoPersonas = db.Personas.ToList();
foreach(var p in listadoPersonas){

  
  Console.WriteLine($"{p.Cedula} {p.Nombre} {p.Apellido}");
}
cedula = Utils.input("Digite el id de la persona");
persona = db.Personas.Find(int.Parse(cedula));
}else{
  persona = db.Personas.Where(x => x.Cedula == cedula).FirstOrDefault();
.incluide(x => x.Vacunas).Incluide(x => x Provincia).ToList();

Console.WriteLine($"{persona.Nombre} {persona.Apellido}");
var detalle = "";
foreach (var proceso in listadoProcesos){

  Console.WriteLine($"{proceso.id}{proceso.Vacuna.Nombre} {proceso.Provincia.Nombre} {proceso.Fecha}");

  detalle = @$"
  
  <tr>
  
  <td>{proceso.Vacuna.Nombre}</td>
  <td>{proceso.Provincia.Nombre}</td>
  <td>{proceso.Fecha.ToshortDateString}</td>
  
  </tr>
  ";
}


 }

} 

var html = @$"
<html>
<head>

<title>Registro de vacunacion</title>

<body>

<h1>Tarjeta de {persona.Nombre} {persona.Apellido}</h1>
<h3>Cedula {persona.Cedula}</h3>
<h4>Telefono {persona.Telefono}</h4>
</div>
</body>
</head>




</html>


";

System.IO.File.WriteAllText("Tarjeta.html".html);
Console.WriteLine("Tarjeta generada");
var uri = "tarjeta.html";
var psi = new System.Diagnostics.ProcessStartInfo();
psi.UseShellExecute = true;
psi.FileName = uri;
System.Diagnostics.Process.Start(psi);

Console.ReadKey();







}

}






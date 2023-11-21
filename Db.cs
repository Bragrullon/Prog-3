using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class CovidContext : DbContext
{

public DbSet <Provincias> Provincias { get; set; }
public DbSet <Vacunas> Vacunas { get; set; }
public DbSet <Persona> Personas { get; set; }
public DbSet <Proceso> PacienteVacunas { get; set; }
 protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
 {
    optionsBuilder.UseSqlite("Data Source=covid.db");
 }



}

public class Persona{

    public int id { get; set; } 

    public string Cedula { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Telefono { get; set;}
    public bool ok { get; set;}



}

public class Provincias{

public int id { get; set; }
public string Nombre { get; set; }


}

public class Vacunas{

    public int id { get; set; }
    public string Nombre { get; set; }
}

public class Proceso{

    public int id { get; set; }
    public DateTime Fecha { get; set; }

    public Persona Persona { get; set; }
    public Provincias Provincia { set; get;}
    public Vacunas Vacunas {  set; get;}
}
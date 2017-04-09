using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

public class DB
{
    private LiteDatabase db;

    public DB()
    {
        db = new LiteDatabase(@"C:\Peluqueria\a.y2k");
    }

    public LiteDatabase getDB()
    {
        return db;
    }
}
public class Cliente
{
    public ObjectId Id { get; set; }
    public String[] Nombres { get; set; }
    public String[] Apellidos { get; set; }
    public DateTime FechaDeNacimiento { get; set; }
    public int[] Telefonos { get; set; }
    public String Zona { get; set; }
    public String Calle { get; set; }
    public String NumPuerta { get; set; }
    public String Esquina { get; set; }
    public String Apartamento { get; set; }
    public String Foto { get; set; }
    public Cita[] Citas { get; set; }
}
public class Clientes
{
    private LiteCollection<Cliente> clientes;

    public Clientes(DB db)
	{
        clientes = db.getDB().GetCollection<Cliente>("Cliente");
    }

    public void BuscarCliente(String nombre, String apellido, int telefono)
    {
        //This NullException
        var busqueda = clientes.Find(Query.StartsWith("Nombres", nombre)).ToList<Cliente>();
        foreach (Cliente cl in busqueda)
        {
            Debug.WriteLine(cl.Nombres);
        }


        //return busqueda.ToList<Cliente>();



    }
}

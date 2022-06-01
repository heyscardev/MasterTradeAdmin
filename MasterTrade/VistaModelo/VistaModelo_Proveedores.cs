using MasterTrade.Modelo.Contexto;
using MasterTrade.Modelo.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace MasterTrade.VistaModelo
{
    public class VistaModelo_Proveedores
    {
        public BaseDatos db = Datos.GetBaseDatos();
        //crea
        public Proveedor crear(Proveedor p)
        {
            if(p == null)return null;
            db.Proveedores.Add(p);
            MessageBox.Show();
           // db.SaveChanges();
            return p;
        }
        //modifica 
        public Proveedor modificar(Proveedor p)
        {
            if (p == null) return null;
            db.SaveChanges();
            return p;
        }
        //lista todos 
        public List<Proveedor> listar()
        {
            return db.Proveedores.ToList();
        }
        //lista todos 
        public List<Proveedor> listarFiltro(string filtro, string consulta)
        {
            return db.Proveedores.FromSqlRaw("select * from Proveedores where " + filtro + "= '" + consulta + "'").ToList();
        }
        public Proveedor getById(int id)
        {
            return db.Proveedores.Find(id);
        }
        public Proveedor getByFiltro(string filtro, string consulta) =>
            db.Proveedores.FromSqlRaw("select * from Proveedores where " + filtro + "= '" + consulta + "'").FirstOrDefault();
    }
}

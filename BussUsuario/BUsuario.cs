using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics; //Modificacion 24 Noviembre 2024
using System.Linq;
using System.Net.Http;
using System.Security.Policy; //Modificacion 24 Noviembre 2024 
using System.Text;
using System.Threading.Tasks; //Modificacion 24 Noviembre 2024
using DataUsuario;
using EntityUsuario;

namespace BussUsuario
{
    public class BUsuario
    {
        DUsuario data = new DUsuario();

        public List<EUsuario> Obtener()
        {
            DataTable dt = data.Obtener();
            List<EUsuario> ls = new List<EUsuario>();
            foreach (DataRow dr in dt.Rows)
            {
                EUsuario us = new EUsuario();
                us.id = Convert.ToInt32(dr["Id"]);
                us.nombre = Convert.ToString(dr["Nombre"]);
                us.apellidop = Convert.ToString(dr["ApellidoP"]);
                us.apellidom = Convert.ToString(dr["ApellidoM"]);
                us.fecha = Convert.ToDateTime(dr["FechaNaci"]).ToString("dd-MM-yyyy");
                us.edad = Convert.ToInt32(dr["Edad"]);
                ls.Add(us);
            }
            return ls;
        }

        public List<EUsuario> Buscar(string valor)
        {
            DataTable dt = data.Buscar(valor);
            List<EUsuario> ls = new List<EUsuario>();
            foreach(DataRow dr in dt.Rows)
            {
                EUsuario us = new EUsuario();

                us.id = Convert.ToInt32(dr["Id"]);
                us.nombre = Convert.ToString(dr["Nombre"]);
                us.apellidop = Convert.ToString(dr["ApellidoP"]);
                us.apellidom = Convert.ToString(dr["ApellidoM"]);
                us.fecha = Convert.ToDateTime(dr["FechaNaci"]).ToString("dd-MM-yyyy");
                us.edad = Convert.ToInt32(dr["Edad"]);
                ls.Add(us);
            }
            return ls;
        }


        public EUsuario ObtenerId(int id)
        {
            DataRow dr = data.ObtenerId(id);
            EUsuario us = new EUsuario();

            us.id = Convert.ToInt32(dr["Id"]);
            us.nombre = Convert.ToString(dr["Nombre"]);
            us.apellidop = Convert.ToString(dr["ApellidoP"]);
            us.apellidom = Convert.ToString(dr["ApellidoM"]);
            us.fecha = Convert.ToDateTime(dr["FechaNaci"]).ToString("yyyy-MM-dd");
            us.edad = Convert.ToInt32(dr["Edad"]);
            return us;
        }

        public void Agregar(EUsuario us)
        {
            int res = data.Agregar(us.nombre, us.apellidop, us.apellidom, us.fecha);
            if (res != 1)
                throw new ApplicationException("Error al agregar");
        }

        public void Editar(EUsuario us)
        {
            int res = data.Editar(us.nombre, us.apellidop, us.apellidom, us.fecha, us.id);
            if (res != 1)
                throw new ApplicationException("Error al editar");
        }

        public void Eliminar(EUsuario us)
        {
            int res = data.Eliminar(us.id);
            if (res != 1)
                throw new ApplicationException("Error al eliminar");
        }
    }
}

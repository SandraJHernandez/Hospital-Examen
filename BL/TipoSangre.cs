using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TipoSangre
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL.SHernandezHospitalEntities context = new DL.SHernandezHospitalEntities())
                {
                    var query = context.TipoSangreGetAll().ToList();

                    result.Objects = new List<object>();

                    if(query != null)
                    {
                        foreach(var obj in query)
                        {
                            ML.TipoSangre tipoSangre = new ML.TipoSangre();

                            tipoSangre.IdTipoSangre = obj.IdTipoSangre;
                            tipoSangre.Nombre = obj.Nombre;

                            result.Objects.Add(obj);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "ERROR, no se pudo mostrar los datos " + ex.Message;
            }

            return result;
        }
    }
}

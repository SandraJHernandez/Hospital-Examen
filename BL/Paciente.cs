using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Paciente
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL.SHernandezHospitalEntities context = new DL.SHernandezHospitalEntities())
                {
                    var query = context.PacienteGetAll().ToList();
                    result.Objects = new List<object>();

                    if(query != null)
                    {
                        foreach(var obj in query)
                        {
                            ML.Paciente paciente = new ML.Paciente();

                            paciente.IdPaciente = obj.IdPaciente;
                            paciente.Nombre = obj.Nombre;
                            paciente.AP = obj.AP;
                            paciente.AM = obj.AM;
                            paciente.FechaNacimiento = obj.FechaNacimiento.Value;
                            paciente.FechaIngreso = obj.FechaIngreso.Value;
                            paciente.Sexo = obj.Sexo;
                            paciente.Sintomas = obj.Sintomas;

                            paciente.TipoSangre = new ML.TipoSangre();
                            paciente.TipoSangre.IdTipoSangre = obj.IdTipoSangre.Value;
                            paciente.TipoSangre.Nombre = obj.NombreSangre;

                            result.Objects.Add(paciente);
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

        public static ML.Result GetById(int idPaciente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL.SHernandezHospitalEntities context = new DL.SHernandezHospitalEntities())
                {
                    var query = context.PacienteGetById(idPaciente).FirstOrDefault();

                    result.Objects = new List<object>();

                    if(query != null)
                    {
                        ML.Paciente paciente = new ML.Paciente();

                        paciente.IdPaciente = query.IdPaciente;
                        paciente.Nombre = query.Nombre;
                        paciente.AP = query.AP;
                        paciente.AM = query.AM;
                        paciente.FechaNacimiento = query.FechaNacimiento.Value;
                        paciente.FechaIngreso = query.FechaIngreso.Value;
                        paciente.Sexo = query.Sexo;
                        paciente.Sintomas = query.Sintomas;

                        paciente.TipoSangre = new ML.TipoSangre();
                        paciente.TipoSangre.IdTipoSangre = query.IdTipoSangre.Value;
                        paciente.TipoSangre.Nombre = query.NombreSangre;

                        result.Object = paciente;
                    }
                   result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "ERROR, no se pudo mostrar los datos " + ex;
            }
            return result;
        }

        public static ML.Result Delete(int idPaciente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL.SHernandezHospitalEntities context = new DL.SHernandezHospitalEntities())
                {
                    int query = context.PacienteDelete(idPaciente);

                    if(query >= 1)
                    {
                        result.Correct=true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "ERROR, no se pudo eliminar al paciente correctamente";
            }

            return result;
        }

        public static ML.Result Add(ML.Paciente paciente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL.SHernandezHospitalEntities context = new DL.SHernandezHospitalEntities())
                {
                    int query = context.PacienteAdd(paciente.Nombre, paciente.AP, paciente.AM, paciente.FechaNacimiento, paciente.FechaIngreso, paciente.Sexo, paciente.Sintomas, paciente.TipoSangre.IdTipoSangre);

                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "ERROR, no se pudo agregar al usuario " + ex.Message;
            }
            return result;
        }

        public static ML.Result Update(ML.Paciente paciente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL.SHernandezHospitalEntities context = new DL.SHernandezHospitalEntities())
                {
                    int query = context.PacienteUpdate(paciente.IdPaciente, paciente.Nombre, paciente.AP, paciente.AM, paciente.FechaNacimiento, paciente.FechaIngreso, paciente.Sexo, paciente.Sintomas, paciente.TipoSangre.IdTipoSangre);

                    if(query >= 1)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "ERROR no se pudo actualizar los datos del paciente";
            }

            return result;
        }

    }
}

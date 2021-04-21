using LavaCar.Entidades.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace LavaCar.LogicaNegocio.Helpers
{
    public static class HelperMensaje
    {
        /// <summary>
        /// Genera mensajes estandar.
        /// </summary>
        /// <param name="tipoMensaje">Identificador de tipo de mensaje.</param>
        /// <param name="sujeto">Sujeto al que se refiere el mensaje.</param>
        /// <returns>Retorna el mensaje estandarizado.</returns>
        public static string GenerarMensaje(TipoMensaje tipoMensaje, string sujeto)
        {
            string mensaje = "";
            switch (tipoMensaje)
            {
                case TipoMensaje.Agregado:
                    mensaje = "¡" + sujeto + " se agregó exitosamente!";
                    break;
                case TipoMensaje.Editado:
                    mensaje = "¡" + sujeto + " se editó exitosamente!";
                    break;
                case TipoMensaje.Eliminado:
                    mensaje = "¡" + sujeto + " se eliminó exitosamente!";
                    break;
                case TipoMensaje.ErrorSolicitud:
                    mensaje = "¡Ocurrió un problema, no se realizó la solicitud!";
                    break;
                case TipoMensaje.Incorrecto:
                    mensaje = "¡Datos incorrectos!";
                    break;
                case TipoMensaje.ErrorEditar:
                    mensaje = "¡No hay datos que editar!";
                    break;
                case TipoMensaje.ErrorYaExiste:
                    mensaje = "¡" + sujeto + " ya existe!";
                    break;
                default:
                    break;
            }
            return mensaje;
        }
    }
}

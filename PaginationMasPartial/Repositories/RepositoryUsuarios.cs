using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PaginationMasPartial.Data;
using PaginationMasPartial.Models;

#region PROCEDURES

/*CREATE PROCEDURE SP_HACER_LOGIN (@NOMBRE NVARCHAR(50), @CONTRASENIA NVARCHAR(50))
AS
	SELECT * FROM USUARIOS WHERE Nombre = @NOMBRE AND Contrasenia = @CONTRASENIA
GO*/

#endregion
namespace PaginationMasPartial.Repositories
{
    public class RepositoryUsuarios
    {
        //REGISTER USUARIO
        //LOGIN USUARIO -> Cuando loguee se va a guardar en sesion
        private AppDBContext context;

        public RepositoryUsuarios(AppDBContext context)
        {
            this.context = context;
        }

        public Usuario HacerLogin(string nombre, string contrasenia)
        {
            string sql = "SP_HACER_LOGIN @NOMBRE, @CONTRASENIA";

            SqlParameter pamNom = new SqlParameter("@NOMBRE", nombre);
            SqlParameter pamCon = new SqlParameter("@CONTRASENIA", contrasenia);

            var consulta = this.context.Usuarios.FromSqlRaw(sql, pamNom, pamCon);

            Usuario user = consulta.AsEnumerable().FirstOrDefault();

            return user;
        }
    }
}

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PaginationMasPartial.Data;
using PaginationMasPartial.Models;

#region PROCEDURES

/*CREATE OR ALTER PROCEDURE SP_ORDEN_ARTICULOS(@REGISTROSPAGINA INT, @POSICION INT)
AS
	SELECT * FROM (SELECT CAST(ROW_NUMBER() OVER(ORDER BY Id) AS INT) AS POSICION, Id, Imagen, Nombre, Precio FROM ARTICULOS) AS QUERY
	WHERE QUERY.POSICION >= @POSICION AND QUERY.POSICION < (@POSICION + @REGISTROSPAGINA)
GO*/

#endregion
namespace PaginationMasPartial.Repositories
{
    public class RepositoryArticulos
    {
        private AppDBContext context;

        public RepositoryArticulos(AppDBContext context)
        {
            this.context = context;
        }

        public int TotalArticulos()
        {
            return this.context.Articulos.Count();
        }

        public List<Articulo> ListaArticulos(int registrospagina, int posicion)
        {
            string sql = "SP_ORDEN_ARTICULOS @REGISTROSPAGINA, @POSICION";

            SqlParameter pamReg = new SqlParameter("@REGISTROSPAGINA", registrospagina);
            SqlParameter pamPos = new SqlParameter("@POSICION", posicion);

            var consulta = this.context.Articulos.FromSqlRaw(sql, pamReg, pamPos);

            List<Articulo> articulos = consulta.AsEnumerable().ToList();

            return articulos;
        } 
    }
}

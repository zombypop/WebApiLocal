using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Artista
    {
        private string con = ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString;

        public List<DTO.Artista> RetornaArtistas()
        {
            List<DTO.Artista> listaARetornar = new List<DTO.Artista>();
            using (IDbConnection conexion = new SqlConnection(this.con)  )
            {
                string sqlComando = "select ArtistId, Name from dbo.Artist";
                listaARetornar = conexion.Query<DTO.Artista>(sqlComando).ToList();
            }
            return listaARetornar;
        }

        public DTO.Artista RetornaArtista(int id)
        {
            DTO.Artista artista = new DTO.Artista();
            using (IDbConnection conexion = new SqlConnection(this.con))
            {
                var param = new { Id = id };
                string sqlComando = "select ArtistId, Name from dbo.Artist where ArtistId = @id";
                artista = conexion.Query<DTO.Artista>(sqlComando, param).FirstOrDefault();
            }
            return artista;
        }

        public int IngresaArtista(DTO.Artista artista)
        {
            DTO.Artista artistaIngres = new DTO.Artista() {
                ArtistId = artista.ArtistId,
                Name = artista.Name,
            };
            string sql = "insert into dbo.Artist (ArtistId, Name) Values ( @ArtistId, @Name ) ";
            using (IDbConnection conexion = new SqlConnection(this.con))
            {
                return  conexion.Execute(sql, artistaIngres);
            }
        }



    }
}

using Microsoft.EntityFrameworkCore;
using TiendaData.Models;

namespace ProductsData
{
    public class TiendaContext : DbContext
    {
        public TiendaContext(DbContextOptions options) : base(options)
        {
        }

        #region "DbSet"
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Estados> Estados { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<RegistroPedidos> RegistroPedidos { get; set; }
        public DbSet<EstadosPedidos> EstadosPedidos { get; set; }
        public DbSet<RegistroPedidosDetalle> RegistroPedidosDetalle { get; set; }
        #endregion

        #region "DbQuery"
        public DbQuery<VistaClienteDetalle> VistaClienteDetalle { get; set; }
        #endregion



    }
}

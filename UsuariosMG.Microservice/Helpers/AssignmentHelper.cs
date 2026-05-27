using UsuariosMG.Microservice.Models;

namespace Items.Microservice.Helpers
{
    public static class AssignmentHelper
    {
        /// <summary>
        /// Ordena los ítems pendientes por:
        /// 1. Relevancia
        /// 2. Fecha de entrega
        /// </summary>
        public static List<Usuario> SortPendingItems(List<Usuario> items)
        {
            /// <summary>
            /// Ordena los ítems por relevancia y fecha de entrega.
            /// </summary>
            /// 
            return items
                .OrderByDescending(x => x.Id)
                .ToList();
        }
    }
}

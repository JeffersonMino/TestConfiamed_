using static Items.Microservice.Models.Items;

namespace Items.Microservice.Helpers
{
    public static class AssignmentHelper
    {
        /// <summary>
        /// Ordena los ítems pendientes por:
        /// 1. Relevancia
        /// 2. Fecha de entrega
        /// </summary>
        public static List<Item> SortPendingItems(List<Item> items)
        {
            /// <summary>
            /// Ordena los ítems por relevancia y fecha de entrega.
            /// </summary>
            /// 
            return items
                .OrderByDescending(x => x.Relevance)
                .ThenBy(x => x.DueDate)
                .ToList();
        }
    }
}

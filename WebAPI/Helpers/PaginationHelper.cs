using WebAPI.Filters;
using WebAPI.Wrappers;

namespace WebAPI.Helpers
{
    public class PaginationHelper
    {
        public static PagedResponse<IEnumerable<T>> CreatePagedResponse<T>(IEnumerable<T> pagedData, PaginationFilter validpaginationFilter, int totalRecords)
        {
            var response = new PagedResponse<IEnumerable<T>>(pagedData, validpaginationFilter.PageNumber, validpaginationFilter.PageSize);
            var totalPages = ((double)totalRecords / (double)validpaginationFilter.PageSize);
            var roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            int currentPage = validpaginationFilter.PageNumber;

            response.TotalPages = roundedTotalPages;
            response.TotalRecords = totalRecords;
            response.PreviousPage = currentPage > 1 ? true : false;
            response.NextPage = currentPage < roundedTotalPages ? true : false;
            return response;
        }
    }
}

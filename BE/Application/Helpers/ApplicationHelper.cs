using Domain.Entities.System;

namespace Application.Helpers
{
    public static class ApplicationHelper
    {
        public static List<SortCreterias> ParseSortCriteria(string sortBy)
        {
            if (string.IsNullOrWhiteSpace(sortBy))
                return new List<SortCreterias>();

            return sortBy
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(field => field.Split(':', StringSplitOptions.RemoveEmptyEntries))
                .Where(parts => parts.Length == 2)
                .Select(parts => new SortCreterias
                {
                    Field = parts[0].Trim(),
                    IsDescending = parts[1].Equals("desc", StringComparison.OrdinalIgnoreCase),
                })
                .ToList();
        }
    }
}

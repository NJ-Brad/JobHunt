namespace JobHunt
{
    public interface IJobBoardDataService
    {
        Task<IEnumerable<JobListingItem>> Select(string orderBy="", bool descending = false);
        Task<JobListingItem> GetJobListingItem(string id);
        Task<int> DeleteJobListingItem(string id);
        Task<JobListingItem> UpdateJobListingItem(JobListingItem document);
        Task<JobListingItem> CreateJobListingItem(JobListingItem document);
    }
}

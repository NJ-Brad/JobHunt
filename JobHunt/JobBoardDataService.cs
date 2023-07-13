using LiteDB;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;

namespace JobHunt
{
    public class JobBoardDataService : IJobBoardDataService
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly IFeatureManagerSnapshot _featureManagerSnapshot;

        private string? connString = string.Empty;

        public JobBoardDataService(/*ILoggerFactory loggerFactory,*/
            //ILogger<DocumentService> logger,
            IConfiguration configuration,
            IFeatureManagerSnapshot featureManagerSnapshot//,
                                                          //IConfigurationRefresherProvider refresherProvider
            )
        {
            //_logger = loggerFactory.CreateLogger<DocumentService>();
            //_logger = logger;
            _configuration = configuration;
            _featureManagerSnapshot = featureManagerSnapshot;
            //_configurationRefresher = refresherProvider.Refreshers.First();

            // Read configuration data
            connString = _configuration["LiteDB:ConnectionString"];
        }

        LiteDatabase dbClient = null;

        private ILiteCollection<JobListingItem> GetCollection()
        {
            dbClient = new LiteDatabase(connString);

            return dbClient.GetCollection<JobListingItem>("jobs");
        }

        public async Task<IEnumerable<JobListingItem>> GetAllJobs()
        {
            List<JobListingItem> rtnVal = new();
            return rtnVal;
        }

        public async Task<IEnumerable<JobListingItem>> Select(string orderBy = "", bool descending = false)
        {
            List<JobListingItem> rtnVal = new();

            ILiteCollection<JobListingItem> col = GetCollection();

            if(descending)
            {
                foreach (JobListingItem item in col.Query()
                    .OrderByDescending(orderBy ?? "Company")
                    .ToEnumerable())
                {
                    rtnVal.Add(item);
                }
            }
            else
            {
                foreach (JobListingItem item in col.Query()
                    .OrderBy(orderBy ?? "Company")
                    .ToEnumerable())
                {
                    rtnVal.Add(item);
                }
            }

            dbClient.Dispose();

            return rtnVal;
        }

        public async Task<JobListingItem> GetJobListingItem(string JobId)
        {
            JobListingItem rtnVal = new();

            ILiteCollection<JobListingItem> col = GetCollection();
            foreach (JobListingItem item in col.Query()
                .Where(x => x.JobId == JobId)
                .ToEnumerable())
            {
                rtnVal = item;
                break;
            }

            dbClient.Dispose();
            return rtnVal;
        }


        public async Task<JobListingItem> CreateJobListingItem(JobListingItem document)
        {
            JobListingItem? newOne = document;
            string newId = string.Empty;

            try
            {
                var coll = GetCollection();

                try
                {
                    if (string.IsNullOrEmpty(newOne.JobId))
                    {
                        newOne.JobId = Guid.NewGuid().ToString().Replace("-", "");
                    }
                    //string jsonValue = JsonSerializer.Serialize(newOne);
                }
                catch (Exception ex)
                {
                    //response.StatusCode = HttpStatusCode.BadRequest;
                    ////response.Body = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(ex.ToString()));
                    //response.Body = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(ex.Message));
                    //return response;
                }

                newId = newOne.JobId == null ? "" : newOne.JobId.ToString();

                coll.Insert(newOne);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //response.StatusCode = HttpStatusCode.InternalServerError;
                //response.Body = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(ex.Message));
                //return response;
            }

            dbClient.Dispose();

            return newOne;
        }

        public async Task<JobListingItem> UpdateJobListingItem(JobListingItem document)
        {
            JobListingItem? newOne = document;

            ILiteCollection<JobListingItem> col = GetCollection();

            col.Update(newOne);

            dbClient.Dispose();

            return newOne;
        }

        public async Task<int> DeleteJobListingItem(string id)
        {
            int numDeleted = 0;

            ILiteCollection<JobListingItem> col = GetCollection();

            col.Delete(id);

            dbClient.Dispose();

            return numDeleted;
        }
    }
}

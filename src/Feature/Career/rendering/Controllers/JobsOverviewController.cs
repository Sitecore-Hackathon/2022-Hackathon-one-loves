using System;
using System.Linq;
using Hackathon.Feature.Career.Helpers;
using Hackathon.Feature.Career.Models.ViewModels;
using Hackathon.Foundation.BaseData.Controllers;
using Hackathon.Foundation.BaseData.Models;
using Hackathon.Foundation.Dictionary;
using Hackathon.Foundation.Search;
using Hackathon.Foundation.Search.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hackathon.Feature.Career.Controllers
{
    [ApiController]
    [Route("api/getjobdetails")]
    public class JobsOverviewController : ApiController
    {
        private readonly IJobDetailSolrRepository _jobDetailSolrRepository;

        public JobsOverviewController(IJobDetailSolrRepository jobDetailSolrRepository, ISitecoreLocalizer localizer) : base(localizer)
        {
            _jobDetailSolrRepository = jobDetailSolrRepository;
        }

        [HttpGet]
        public ActionResult<string> Get([FromQuery] string location, [FromQuery] string position, [FromQuery] string text, [FromQuery] string language, [FromQuery] int pageNumber, [FromQuery] int count)
        {
            var parameters = new SearchParameters()
            {
                Fields = new Fields()
                {
                    Language = language,
                    JobDetailText = text
                },
                Paging = new Paging()
                {
                    PageNumber = pageNumber,
                    Count = count
                }
            };
            if (Guid.TryParse(location, out var fieldsJobLocationId))
            {
                parameters.Fields.JobLocationId = fieldsJobLocationId;
            }
            if (Guid.TryParse(position, out var fieldsPositionId))
            {
                parameters.Fields.PositionIds = fieldsPositionId;
            }
            var result = _jobDetailSolrRepository.GetJobDetails(parameters);

            var apiModel = new BaseApiModel<JobDetailViewModel>()
            {
                ShowLoadMore = result.NumFound > ((pageNumber + 1) * count),
                Items = JobDetailHelper.Map(result)
                    .Select(m =>
                    {
                        var model = JobDetailHelper.Map(m);
                        model.LearnMoreText = GetDictionaryValue(language, "Learn More");
                        return model;
                    })
            };

            return JsonConvert.SerializeObject(apiModel);
        }
    }
}

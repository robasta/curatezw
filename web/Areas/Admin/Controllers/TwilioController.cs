using System;
using System.Threading.Tasks;
using Curate.Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Twilio.AspNet.Common;
using Twilio.AspNet.Core;

namespace Curate.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TwilioController : Twilio.AspNet.Core.TwilioController
    {
        private readonly INyamboService _nyamboService;
        private readonly IYoutubeApiService _youtubeApiService;
        public TwilioController(INyamboService nyamboService, IYoutubeApiService youtubeApiService)
        {
            _nyamboService = nyamboService;
            _youtubeApiService = youtubeApiService;
        }

        [HttpPost]
        public async Task<TwiMLResult> Add([FromBody] SmsRequest smsRequest)
        {
            if (IsUrl(smsRequest.Body))
            {
               await _youtubeApiService.AddVideoOrPlaylist(smsRequest.Body);
            }
            else
            {
                _nyamboService.AddNyambo(smsRequest.Body);
            }
            return new TwiMLResult();
        }

        private bool IsUrl(string body)
        {
            return Uri.IsWellFormedUriString(body,UriKind.Absolute);
        }
    }
}

using Microsoft.AspNet.Identity;
using Sangha.Models.TalkModels;
using Sangha.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sangha.WebAPI.Controllers.WebAPI
{
    [Authorize]
    [RoutePrefix("api/Talk")]
    public class TalkController : ApiController
    {
        private bool SetStarState(int talkId, bool newState)
        {
            // Create the service
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TalkService(userId);

            // Get the note
            var detail = service.GetTalkById(talkId);

            // Create the TalkEdit model instance with the new star state
            var updatedTalk =
                new TalkEdit
                {
                    Name = detail.Name,
                    TeacherId = detail.TeacherId,
                    //entity.Teachers = model.Teacher;
                    Topic = detail.Topic,
                    TalkLength = detail.TalkLength,
                    TalkDate = detail.TalkDate,
                    IsGuided = detail.IsGuided,
                    IsStarred = newState
                };

            // Return a value indicating whether the update succeeded
            return service.UpdateTalk(updatedTalk);
        }

        [Route("{id}/Star")]
        [HttpPut]
        public bool ToggleStarOn(int id) => SetStarState(id, true);

        [Route("{id}/Star")]
        [HttpDelete]
        public bool ToggleStarOff(int id) => SetStarState(id, false);
    }
}


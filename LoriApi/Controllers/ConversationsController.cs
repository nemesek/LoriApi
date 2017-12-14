using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoriApi.Domain;
using LoriApi.Domain.Events;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoriApi.Controllers
{
    [Route("api/[controller]")]
    public class ConversationsController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ConversationDto> Post([FromBody] CreateConversationDto createConversationDto)
        {
            await Task.Delay(1);
            var processor = new StatementProcessor();
            var sentence = processor.ProcessEvent((Events)createConversationDto.BusinessEventId);
            var conversation = new Conversation(createConversationDto.Name, createConversationDto.Language);
            return conversation.GetConversationDto(sentence);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ConversationDto> Put(int id, [FromBody]ConversationDto conversationDto)
        {
            await Task.Delay(1);
            var conversation = new Conversation(conversationDto.Name, conversationDto.Language);
            var sentence = SentenceBuilder.BuildSentence(conversationDto.SentenceId, conversationDto.DisplayText);
            var nextSentence = sentence.GetNextSentence(conversationDto.UserResponse);
            return conversation.GetConversationDto(nextSentence);
        }

        //[Route("api/conversations/{id}/businessEvents")]
        //[HttpPost]
        //public async Task<ConversationDto> Post(int id,[FromBody] CreateConversationDto createConversationDto)
        //{
        //    await Task.Delay(1);
        //    var processor = new StatementProcessor();
        //    var sentence = processor.ProcessEvent(createConversationDto.EventId);
        //    var conversation = new Conversation(createConversationDto.Name, createConversationDto.Language);
        //    return conversation.GetConversationDto(sentence);
        //}
        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

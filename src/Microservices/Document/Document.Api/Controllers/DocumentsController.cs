using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Document.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Document.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {

        private readonly IMediator mediator;

        public DocumentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }



        // GET api/documents
        [HttpGet]
        public ActionResult<IEnumerable<CustomerDocument>> Get()
        {
            return new List<CustomerDocument>();
        }

        // GET api/documents/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/documents
        [HttpPost]
        public async Task Post([FromBody] CustomerDocument customerDocument)
        {
            bool result = await mediator.Send(new CreateDocumentCommand(customerDocument));

            await mediator.Publish(new CreateDocumentEvent(customerDocument));

        }

        // PUT api/documents/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

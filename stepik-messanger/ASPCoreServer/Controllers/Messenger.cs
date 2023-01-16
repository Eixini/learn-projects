using Microsoft.AspNetCore.Mvc;
using mymessenger_stepik;
using Newtonsoft.Json;

namespace ASPCoreServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Messenger : ControllerBase
    {
        static List<Message> ListOfMessages = new List<Message>();
        // GET api/<Messenger>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            string OutputString = "Not found";
            if ((id < ListOfMessages.Count) && (id >= 0))
            {
                OutputString = JsonConvert.SerializeObject(ListOfMessages[id]);
            }
            //Console.WriteLine(String.Format($"Запрошено сообщение # {id}: {OutputString}"));
            return OutputString;
        }

        // POST api/<Messenger>
        [HttpPost]
        public IActionResult SendMessage([FromBody] Message msg)
        {
            if (msg == null)
            {
                return BadRequest();
            }
            ListOfMessages.Add(msg);
            Console.WriteLine(String.Format($"Всего сообщений: {ListOfMessages.Count} , Посланное сообщение: {msg}"));
            return new OkResult();
        }

    }
}

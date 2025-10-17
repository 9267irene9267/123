using Microsoft.AspNetCore.Mvc;

namespace MyFirstNetApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HWController : ControllerBase
    {
        // GET: api/MyfirstApi/Greet?name=Tom
        [HttpGet]
        public string Greet(string name = "Guest") => $"Hello, {name}!";

        // GET: api/MyfirstApi/TimeNow
        [HttpGet]
        public string TimeNow() => $"Current server time is: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}";

        // POST: api/MyfirstApi/PostMessage
        // Body: raw JSON: { "message": "Hi there!" }
        [HttpPost]
        public string PostMessage([FromBody] MessageModel model) => $"You posted: {model.Message}";

        // PUT: api/MyfirstApi/UpdateName
        // Body: raw JSON: { "oldName": "Tom", "newName": "Jerry" }
        [HttpPut]
        public string UpdateName([FromBody] NameUpdateModel model) => $"Updated name from {model.OldName} to {model.NewName}";

        // DELETE: api/MyfirstApi/DeleteItem/123
        [HttpDelete("{id}")]
        public string DeleteItem(int id) => $"Item with ID {id} has been deleted (not really, just a simulation).";
    }

    // 模型類別放在同一檔案也可以（實務上建議放 Models 資料夾）
    public class MessageModel
    {
        public string Message { get; set; }
    }

    public class NameUpdateModel
    {
        public string OldName { get; set; }
        public string NewName { get; set; }
    }
}

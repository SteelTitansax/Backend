using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        [HttpGet("sync")]
        public ActionResult GetSync() 
        
        {
            Stopwatch sw = Stopwatch.StartNew();

            sw.Start();
            Thread.Sleep(1000);
            Console.WriteLine("conextion a base de datos");

            Thread.Sleep(1000);
            Console.WriteLine("Envio de mail terminado");
            return Ok(sw.Elapsed);
        
        }

        [HttpGet("async")]
        public async Task<IActionResult> GetAsync()
        {
            Stopwatch sw = Stopwatch.StartNew();

            sw.Start();
            var task1 = new Task<int>(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Conexion a la base de datos");

                return 1;

            });
            var task2 = new Task<int>(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Envio de corro terminado");

                return 2;

            });
            task1.Start();
            task2.Start();

            Console.WriteLine("Hago otra cosa");

            var result = await task1;

            
            Console.WriteLine("Hago otra cosa");

            var result2 = await task2;
            sw.Stop();
            Console.WriteLine("Todo a terminado");

            return Ok(result + " " +result2 + " " + sw.Elapsed);
        }

    }
}

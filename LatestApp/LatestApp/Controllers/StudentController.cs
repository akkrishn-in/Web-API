using LatestApp.Models;
using LatestApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LatestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        [Route("all", Name = "GetAllStudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<IEnumerable<Student>>  GetStudentName()
        {
            //OK - 200 -Success
            return Ok(CollegeRepository.Students);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetStudentsById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Student> GetStudentById(int id)
        {
            //BadRequest - 400 - ClientError
            if (id <= 0)
            {
                return BadRequest();
            }
            //OK - 200 -Success
            var result = CollegeRepository.Students.FirstOrDefault(n => n.Id == id);

            //NotFound - 404
            if(result == null)
            {
                return NotFound($"The Student id :  {id} is not found");
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("{name:alpha}", Name = "GetStudentsByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Student> GetStudentByName(string name)
        {
            //BadRequest - 400
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest();
            }
            //OK - 200 -Success
            var result =  CollegeRepository.Students.FirstOrDefault(n => n.StudentName == name);
            // NotFound - 404
            if(result == null)
            {
                return NotFound($"The Student {name} is not found");
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}", Name = "DeleteStudentsById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Student> DeleteStudentById(int id)
        {
            //BadRequest - 400
            if(id <= 0)
            {
                return BadRequest();
            }
            var res = CollegeRepository.Students.FirstOrDefault(n => n.Id == id);
            //NotFound - 404
            if(res == null)
            {
                return NotFound($"The Student id :  {id} is not found");
            }
            return Ok(res);
        }
    }
}

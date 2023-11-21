using LatestApp.Models;

namespace LatestApp.Repository
{
    public class CollegeRepository
    {
        public static List<Student> Students { get; set; } = new List<Student>()
        {
            new Student
            {
                Id = 1,
                StudentName = "Akhil Krishnan",
                Email = "akhilkrishnan295@gmail.com",
                Address = "Archana Bhavan, Kunnamthanam"
            },
            new Student
            {
                Id = 2,
                StudentName = "Arun",
                Email = "arun@gmail.com",
                Address = "Arun Bhavan, Kunnamthanam"
            },
        };
    }
}

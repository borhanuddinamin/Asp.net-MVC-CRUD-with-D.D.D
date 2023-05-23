using CRUD.Domain.Entities;

namespace Asp.net_MVC_CRUD_with_D.D.D.Models
{
    public class Course: IEntity<int>
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Fees { get; set; }
    }
}

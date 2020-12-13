
namespace BackendCore.Entity
{
    public class Usuario : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Profile { get; set; }

        public Usuario()
        {

        }
    }
}

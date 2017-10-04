using System.ComponentModel.DataAnnotations;

namespace Commons.Repository.Persisted
{
    public class PersistentObject
    {
        [Key]
        public int Id { get; set; }
    }
}

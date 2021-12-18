using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Photos")]//represent that we attitude to this like a table in db
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }

        /*ADDING PROPERTIES TO FULLY DEFINE RELATIONSHIPS BETWEEN USER AND PHOTO*/

        public AppUser AppUser   { get; set; }
        public int AppUserId { get; set; }
    }
}
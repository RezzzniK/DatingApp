namespace API.DTOs
{
    //CREATING PHOT9DTO TO AVOID CIRCLE EXCEPTION
    public class PhotoDto
    {
        public int Id { get; set; }//id of user instead of AppUser entity
        public string Url { get; set; }
        public bool IsMain { get; set; }

    }
}
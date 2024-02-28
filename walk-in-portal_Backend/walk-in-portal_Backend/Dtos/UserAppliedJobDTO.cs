using System.ComponentModel.DataAnnotations;

namespace walk_in_portal_Backend.Dtos;

public class UserAppliedJobDTO
{
    [Required]
    public int JobId { get; set; }
    
    [Required]
    public string[] JobRoles{ get; set; }
    
    [Required]
    public string TimeSlot { get; set; }
    
    [Required]
    public int UserId  { get; set; }
    
    [Required]
    public string UserResume { get; set; }
}
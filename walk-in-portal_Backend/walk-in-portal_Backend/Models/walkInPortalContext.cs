using Microsoft.EntityFrameworkCore;

namespace walk_in_portal_Backend.Models;

public class walkInPortalContext : DbContext
{
    public walkInPortalContext()
    {
        
    }
    
    public walkInPortalContext(DbContextOptions<walkInPortalContext> options) : base(options)
    {
        
    }
}
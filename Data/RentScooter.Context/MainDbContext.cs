using RentScooter.Context.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RentScooter.Context
{
    public class MainDbContext : IdentityDbContext<User, UserRole, Guid>
    {

    }
}

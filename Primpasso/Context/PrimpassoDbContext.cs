using Microsoft.EntityFrameworkCore;
using Primpasso.Models;
using Primpasso.Models.Entities;
using Primpasso.Models.Entities.Base;

namespace Primpasso.Context
{
    public class PrimpassoDbContext : DbContext
    {
        public PrimpassoDbContext(DbContextOptions<PrimpassoDbContext> options) : base(options) 
        { }

        public DbSet<Candidate> Candidate { get; set; } 
        public DbSet<Company> Company { get; set; }
        public DbSet<JobOpportunity> JobOpportunity { get; set; }
        public DbSet<JobType> JobType { get; set; }
    }
}

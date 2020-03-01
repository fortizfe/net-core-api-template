using ApiTemplate.Core.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiTemplate.Core.Domain.Models
{
    public class Worker : IDomainEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Tagid { get; set; }
        public bool Enabled { get; set; }
    }

    public class WorkerEntityConfig : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Username).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Tagid).HasMaxLength(20);

            SeedWorkers(builder);

            builder.ToTable("Workers");
        }

        private void SeedWorkers(EntityTypeBuilder<Worker> builder)
        {
            builder.HasData(
                new Worker
                {
                    Id = 1,
                    Name = "Jhon doe",
                    Username = "jdoe",
                    Enabled = true,
                    Tagid = "AH24FG7D"
                });
        }
    }
}
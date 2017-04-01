
namespace TeamBuilder.Data.Configurations
{
    using System.Data.Entity.ModelConfiguration;
    using Models;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.ComponentModel.DataAnnotations.Schema;

    class TeamConfiguration: EntityTypeConfiguration<Team>
    {
        public TeamConfiguration()
        {
            this.Property(t => t.Name).IsRequired().HasMaxLength(25)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("IX_Teams_Name", 1) { IsUnique = true }));

            this.Property(t => t.Acronim).IsFixedLength().HasMaxLength(3).IsRequired();
        }
    }
}

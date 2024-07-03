using ClinicManageWebApp.Core.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClinicManageWebApp.Data
{
    public class DbInitializer
    {
        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }
        private readonly ModelBuilder _modelBuilder;

        internal void Seed()
        {
            _modelBuilder.Entity<IdentityRole>().HasData(
                    new IdentityRole
                    {
                        Id = "a6cd982e-80f6-4bc0-8329-84d3aeefb688",
                        Name = "Atendente",
                        NormalizedName = "ATENDENTE"
                    },
                    new IdentityRole
                    {
                        Id = "9116c38b-9fe4-4ef8-8e54-7095d700693a",
                        Name = "Medico",
                        NormalizedName = "MEDICO"
                    }
                );

            var hasher = new PasswordHasher<IdentityUser>();

            _modelBuilder.Entity<Atendente>().HasData(

                    new Atendente
                    {
                        Id = "77f15cbb-889e-48da-abdb-00c25683859c",
                        Nome = "Consultas",
                        Email = "joao.marcos@aedbr.br",
                        EmailConfirmed = true,
                        UserName = "consultas@gmail.com",
                        NormalizedEmail = "CONSULTAS@GMAIL.COM",
                        NormalizedUserName = "CONSULTAS@GMAIL.COM",
                        PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
                    }
                );
            _modelBuilder.Entity<IdentityUserRole<string>>().HasData
                (
                    new IdentityUserRole<string>
                    {
                        RoleId = "a6cd982e-80f6-4bc0-8329-84d3aeefb688",
                        UserId = "77f15cbb-889e-48da-abdb-00c25683859c"
                    }
                );
            _modelBuilder.Entity<Especialidade>().HasData(
                    new Especialidade { IdEspecialidade = 1, Nome = "Cardiologista", Descricao = "Especialidade médica que trata de doenças do coração e do sistema cardiovascular" },
                    new Especialidade { IdEspecialidade = 2, Nome = "Urologista", Descricao = "Trata de orgãos genitais" },
                    new Especialidade { IdEspecialidade = 3, Nome = "Dentista", Descricao = "Especialidade que trata dos dentes" },
                    new Especialidade { IdEspecialidade = 4, Nome = "Oftalmologista", Descricao = "Especialidade médica que trata da visão" },
                    new Especialidade { IdEspecialidade = 5, Nome = "fisioterapeuta", Descricao = "Especialidade médica que trata da parte física" },
                    new Especialidade { IdEspecialidade = 6, Nome = "Pediatra", Descricao = "Especialidade médica que trata crianças" }
                );
        }
    }
}

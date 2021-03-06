﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentEnrollmentAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollmentAPI.Models
{
    public class RoleInitializer
    {
        // craete a list of identity roles

        private static readonly List<IdentityRole> Roles = new List<IdentityRole>()
        {
            new IdentityRole{Name = ApplicationRoles.Principal, NormalizedName = ApplicationRoles.Principal.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },
            new IdentityRole{Name = ApplicationRoles.Advisor, NormalizedName = ApplicationRoles.Advisor.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },
            new IdentityRole{Name = ApplicationRoles.Teacher, NormalizedName = ApplicationRoles.Teacher.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },
            new IdentityRole{Name = ApplicationRoles.Student, NormalizedName = ApplicationRoles.Student.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },

        };

        public static void SeedData(IServiceProvider serviceProvider)
        {
            using (var dbContext = new SchoolEnrollmentDbContext(serviceProvider.GetRequiredService<DbContextOptions<SchoolEnrollmentDbContext>>()))
            {
                dbContext.Database.EnsureCreated();
                AddRoles(dbContext);
            }
        }

        private static void AddRoles(SchoolEnrollmentDbContext context)
        {
            if (context.Roles.Any()) return;

            foreach (var role in Roles)
            {
                context.Roles.Add(role);
                context.SaveChanges();
            }
        }


        // method that craetes/checks the

        // add the roles to the db direclty
    }
}

using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagement_WebAPI.Data.Models;

namespace SchoolManagement_WebAPI.Data
{
    public class DBInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDBContext>();
                if(!context.Students.Any())
                {
                    context.Students.AddRange(new Student()
                    {
                        FirstMidName = "Haseeb",
                        LastName = "Ahmed",
                        EnrollmentDate = DateTime.Now,                        
                    },
                    new Student()
                    {
                        FirstMidName = "Umair",
                        LastName = "Ahmed",
                        EnrollmentDate = DateTime.Now,
                    },
                    new Student()
                    {
                        FirstMidName = "Sana",
                        LastName = "Ahmed",
                        EnrollmentDate = DateTime.Now,
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}

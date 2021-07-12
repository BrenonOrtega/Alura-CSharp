using System.Diagnostics.CodeAnalysis;
using C_RestApiNet5.Models;
using Microsoft.EntityFrameworkCore;

namespace C_RestApiNet5.Data
{
    public class FilmsContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public FilmsContext([NotNullAttribute] DbContextOptions<FilmsContext> options) : base(options)
        {

        }
    }
}
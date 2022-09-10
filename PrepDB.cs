using Docker.Les.Admin.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Docker.Les.Admin.API;

public static class PrepDB
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();

    }

    public static void SeedData(ApplicationDbContext context)
    {
        Console.WriteLine("Applying Migration");

        context.Database.Migrate();

        if (!context.Colours.Any())
        {
            context.Colours.AddRange(
                new Colour { ColourName = "Red" },
                new Colour { ColourName = "Green" },
                new Colour { ColourName = "Blue" },
                new Colour { ColourName = "Yellow" }
                );
        }
        else
        {
            Console.WriteLine("Already have data - not seeding");
        }
    }
}


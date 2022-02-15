using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app){
            using(var serviceScop = app.ApplicationServices.CreateScope()){
                SeedData(serviceScop.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context){
            if(!context.Platforms.Any()){
                Console.WriteLine("--> Seeding data");
                context.Platforms.AddRange(
                    new Platform(){Name = "Dot Net", Publisher = "Microsoft", Cost = "Free"},
                    new Platform(){Name = "Docker", Publisher = "Docker", Cost = "Free"},
                    new Platform(){Name = "Kubernetes", Publisher = "Cloud Native Foundation", Cost = "Free"}
                );

                context.SaveChanges();
            }
            else{
                Console.WriteLine("--> We already have data");
            }
        }
    }
}
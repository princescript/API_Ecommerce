using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DbInitializer
    {
        public void InitDB(WebApplication app) 
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<StoreContext>()
                ?? throw new InvalidOperationException("Failed to retrieve store context");
            SeedData(context);
        }
        private void SeedData(StoreContext context)
        {
            context.Database.Migrate();
            if (context.Products.Any()) return;
        }
    }
}

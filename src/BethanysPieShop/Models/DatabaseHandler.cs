using Microsoft.AspNetCore.Builder;

namespace BethanysPieShop.Models
{
    public class DatabaseHandler : IDatabaseHandler
    {
        private readonly AppDbContext _context;
        private readonly IApplicationBuilder _app;

        public DatabaseHandler(AppDbContext context ,IApplicationBuilder app)
        {
            _context = context;
            _app = app;
        }

        public void ResetDataBase()
        {
            _context.Pies.RemoveRange(_context.Pies);
            _context.Categories.RemoveRange(_context.Categories);
            _context.OrderDetails.RemoveRange(_context.OrderDetails);
            _context.Orders.RemoveRange(_context.Orders);
            _context.ShoppingCartItems.RemoveRange(_context.ShoppingCartItems);
            _context.RoleClaims.RemoveRange(_context.RoleClaims);
            _context.UserLogins.RemoveRange(_context.UserLogins);
            _context.Roles.RemoveRange(_context.Roles);
            _context.UserTokens.RemoveRange(_context.UserTokens);
            _context.Users.RemoveRange(_context.Users);
            _context.SaveChanges();
            DbInitializer.Seed(_app);
        }
    }

    
}

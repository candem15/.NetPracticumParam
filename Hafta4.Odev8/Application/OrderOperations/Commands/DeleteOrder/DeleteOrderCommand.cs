using Hafta4.Odev8.DbOperations;

namespace Hafta4.Odev8.Application.OrderOperations.Commands.DeleteOrder
{
    public class DeleteOrderCommand
    {
        public int OrderId;


        private readonly IMovieStoreDbContext _dbContext;

        public DeleteOrderCommand(IMovieStoreDbContext context)
        {
            _dbContext = context;
        }
        public void Handle()
        {
            var order = _dbContext.Orders.SingleOrDefault(s => s.Id == OrderId);

            if (order is null)
                throw new InvalidOperationException("Order with given id is not exists! ");

            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
        }
    }
}

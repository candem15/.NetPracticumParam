using AutoMapper;
using Hafta4.Odev8.DbOperations;
using Hafta4.Odev8.Entities;

namespace Hafta4.Odev8.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommand
    {
        public CreateOrderModel Model;

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateOrderCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var customer = _dbContext.Customers.SingleOrDefault(s => s.Id == Model.CustomerId);
            var movies = _dbContext.Movies.SingleOrDefault(s => s.Id == Model.MovieId);

            if (customer is null)
                throw new InvalidOperationException("Customer could not found!");
            if (movies is null)
                throw new InvalidOperationException("Movie could not found!");


            var result = _mapper.Map<Order>(Model);
            result.TransactionTime = DateTime.Now;

            _dbContext.Orders.Add(result);
            _dbContext.SaveChanges();
        }

        public class CreateOrderModel
        {
            public int MovieId { get; set; }
            public int CustomerId { get; set; }
            public DateTime TransactionTime { get; set; }
        }
    }
}

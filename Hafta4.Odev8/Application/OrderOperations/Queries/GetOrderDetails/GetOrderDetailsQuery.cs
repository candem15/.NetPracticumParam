using AutoMapper;
using Hafta4.Odev8.DbOperations;
using Hafta4.Odev8.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hafta4.Odev8.Application.OrderOperations.Queries.GetOrderDetails
{
    public class GetOrderDetailsQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int OrderId;

        public GetOrderDetailsQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public OrderViewModel Handle()
        {
            Customer customer = _dbContext.Customers.Include(i => i.Orders).ThenInclude(t => t.Movie).SingleOrDefault(s => s.Id == OrderId);
            OrderViewModel vm = _mapper.Map<OrderViewModel>(customer);

            return vm;
        }

        public class OrderViewModel
        {
            public string NameSurname { get; set; }
            public IReadOnlyCollection<string> Movies { get; set; }
            public IReadOnlyCollection<string> Price { get; set; }
            public IReadOnlyCollection<string> PurchasedDate { get; set; }
        }
    }
}

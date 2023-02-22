using AutoMapper;
using Hafta4.Odev8.DbOperations;
using Hafta4.Odev8.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hafta4.Odev8.Application.OrderOperations.Queries.GetOrders
{
    public class GetOrdersQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetOrdersQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public List<OrderViewModel> Handle()
        {
            List<Customer> list = _dbContext.Customers.Include(i => i.Orders).ThenInclude(t => t.Movie).OrderBy(x => x.Id).ToList();
            List<OrderViewModel> vm = _mapper.Map<List<OrderViewModel>>(list);

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

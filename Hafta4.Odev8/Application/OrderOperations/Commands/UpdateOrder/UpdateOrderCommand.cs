﻿using AutoMapper;
using Hafta4.Odev8.DbOperations;
using Hafta4.Odev8.Entities;

namespace Hafta4.Odev8.Application.OrderOperations.Commands.UpdateOrder
{
    public class UpdateOrderCommand
    {
        public UpdateOrderModel Model { get; set; }
        public int OrderId;


        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;


        public UpdateOrderCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            Customer customer = _dbContext.Customers.SingleOrDefault(s => s.Id == Model.CustomerId);
            Movie movies = _dbContext.Movies.SingleOrDefault(s => s.Id == Model.MovieId);

            Order order = _dbContext.Orders.SingleOrDefault(s => s.Id == OrderId);

            if (customer is null)
                throw new InvalidOperationException("Customer with given id is not exists!");
            else if (movies is null)
                throw new InvalidOperationException("Movie with given id is not exists!");
            else if (order is null)
                throw new InvalidOperationException("Order with given id is not exists!");

            _mapper.Map<UpdateOrderModel, Order>(Model, order);

            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
        }

        public class UpdateOrderModel
        {
            public int MovieId { get; set; }
            public int CustomerId { get; set; }

        }
    }
}

using Google.Protobuf.WellKnownTypes;
using gRPC;
using Grpc.Core;
using Order;

namespace gRPC.Services
{
    public class OrdersApiService : OrderService.OrderServiceBase
    {
        static int id = 0;
        static List<Order> orders = new() { new Order(++id, DateTime.Now, new Product(++id, "", 0.00)), new Order(++id, DateTime.Now, new Product(++id, "", 0.00)) };

        public override Task<ListReply> ListUsers(Empty request, ServerCallContext context)
        {
            var listReply = new ListReply();
            var orderList = orders.Select(item => new OrderReply { Id = item.Id, DateTime = item.DateTime, ProductList = item.ProductList }).ToList();
            listReply.Orders.AddRange(orderList);
            return Task.FromResult(listReply);
        }

        public override Task<OrderReply> GetUser(GetOrderRequest request, ServerCallContext context)
        {
            var order = orders.Find(o => o.Id == request.Id);
            if (order == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "User not found"));
            }
            OrderReply orderReply = new OrderReply() { Id = order.Id, Name = order.Name, Age = order.Age };
            return Task.FromResult(orderReply);
        }

        public override Task<OrderReply> CreateUser(CreateOrderRequest request, ServerCallContext context)
        {
            var order = new Order(++id, request.Name, request.Age);
            orders.Add(order);
            var reply = new OrderReply() { Id = order.Id, Name = order.Name, Age = order.Age };
            return Task.FromResult(reply);
        }

        public override Task<OrderReply> UpdateUser(UpdateOrderRequest request, ServerCallContext context)
        {
            var order = orders.Find(o => o.Id == request.Id);

            if (order == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "User not found"));
            }
            order.Name = request.Name;
            order.Age = request.Age;

            var reply = new OrderReply() { Id = order.Id, Name = order.Name, Age = order.Age };
            return Task.FromResult(reply);
        }

        public override Task<OrderReply> DeleteUser(DeleteOrderRequest request, ServerCallContext context)
        {
            var order = orders.Find(o => o.Id == request.Id);

            if (order == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "User not found"));
            }

            orders.Remove(order);
            var reply = new UserReply() { Id = order.Id, Name = order.Name, Age = order.Age };
            return Task.FromResult(reply);
        }
    }

    public class Order
    {
        int Id { get; set; }
        DateTime DateTime { get; set; }
        List<Product> Products { get; set; }

        public Order(int id, DateTime dateTime, Product product)
        {
            Id = id;
            DateTime = dateTime;
            Products.Add(product);
        }
    }

    public class Product
    {
        int Id { get; set; }
        string Name { get; set; }
        double Price { get; set; }

        public Product(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}

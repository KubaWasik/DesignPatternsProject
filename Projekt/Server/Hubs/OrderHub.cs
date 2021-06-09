using System.Threading.Tasks;

using Microsoft.AspNetCore.SignalR;

using Projekt.Shared.Enums;

namespace Projekt.Server.Hubs
{
    public class OrderHub : Hub
    {
        public OrderHub()
        {
        }

        public async Task TrackOrder(int orderId)
        {
            await Task.Delay(2000);

            await Clients.Caller.SendAsync("ChangeStatus", OrderStatus.Accepted);

            await Task.Delay(2000);

            await Clients.Caller.SendAsync("ChangeStatus", OrderStatus.InPreparation);

            await Task.Delay(2000);

            await Clients.Caller.SendAsync("ChangeStatus", OrderStatus.InDelivery);

            await Task.Delay(2000);

            await Clients.Caller.SendAsync("ChangeStatus", OrderStatus.Delivered);
        }
    }
}
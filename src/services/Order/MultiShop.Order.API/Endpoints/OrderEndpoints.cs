using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MultiShop.Order.Application.Features.OrderFeatures.Commands.CreateOrder;
using MultiShop.Order.Application.Features.OrderFeatures.Queries.GetOrderById;
using MultiShop.Order.Application.Features.OrderFeatures.Queries.GetOrdersByUserId;
using MultiShop.Order.Application.Features.OrderFeatures.Commands.UpdateShippingAddress;
using MultiShop.Order.Application.Features.OrderFeatures.Commands.UpdateOrderStatus;
using MultiShop.Order.Application.Dtos;
using System;
using System.Threading.Tasks;

namespace MultiShop.Order.API.Endpoints
{
    public static class OrderEndpoints
    {
        public static void MapOrderEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/orders")
                           .WithTags("Orders")
                           .WithOpenApi();

            // Create Order
            group.MapPost("/", async (CreateOrderCommand command, IMediator mediator) =>
            {
                // Assuming the handler for CreateOrderCommand returns the Guid of the created order
                var orderId = await mediator.Send(command);
                return Results.Created($"/api/orders/{orderId}", new { OrderId = orderId });
            })
            .WithName("CreateOrder")
            .Produces(StatusCodes.Status201Created, typeof(object)) // Produces an object like { OrderId = "guid" }
            .ProducesValidationProblem(); // Handles 400 Bad Request with validation details

            // Get Order By ID
            group.MapGet("/{id:guid}", async (Guid id, IMediator mediator) =>
            {
                var query = new GetOrderByIdQuery(id);
                var result = await mediator.Send(query);
                return result != null ? Results.Ok(result) : Results.NotFound();
            })
            .WithName("GetOrderById")
            .Produces<GetOrderByIdQueryResult>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            // Get Orders By User ID
            group.MapGet("/user/{userId:guid}", async (Guid userId, IMediator mediator) =>
            {
                var query = new GetOrdersByUserIdQuery { UserId = userId };
                var result = await mediator.Send(query);
                // Assuming GetOrdersByUserIdQueryResult contains a list or is a list itself
                return Results.Ok(result);
            })
            .WithName("GetOrdersByUserId")
            .Produces<GetOrdersByUserIdQueryResult>(StatusCodes.Status200OK);

            // Update Shipping Address
            // Assumes UpdateShippingAddressCommand has properties: Guid OrderId, AddressDto ShippingAddress
            // Assumes the handler returns MediatR.Unit (void)
            group.MapPut("/{id:guid}/shipping-address", async (Guid id, [FromBody] AddressDto addressDto, IMediator mediator) =>
            {
                var command = new UpdateShippingAddressCommand { OrderId = id, NewShippingAddress = addressDto };
                await mediator.Send(command);
                return Results.NoContent();
            })
            .WithName("UpdateShippingAddress")
            .Produces(StatusCodes.Status204NoContent)
            .ProducesValidationProblem()
            .Produces(StatusCodes.Status404NotFound);

            // Update Order Status
            // Assumes UpdateOrderStatusCommand has properties: Guid OrderId, string NewStatus
            // Assumes the handler returns MediatR.Unit (void)
            group.MapPatch("/{id:guid}/status", async (Guid id, [FromBody] UpdateOrderStatusRequestDto request, IMediator mediator) =>
            {
                var command = new UpdateOrderStatusCommand { OrderId = id, NewStatus = request.NewStatus };
                await mediator.Send(command);
                return Results.NoContent();
            })
            .WithName("UpdateOrderStatus")
            .Produces(StatusCodes.Status204NoContent)
            .ProducesValidationProblem()
            .Produces(StatusCodes.Status404NotFound);
        }
    }

    // Helper DTO for the Update Order Status endpoint
    public class UpdateOrderStatusRequestDto
    {
        public required string NewStatus { get; set; }
    }
} 
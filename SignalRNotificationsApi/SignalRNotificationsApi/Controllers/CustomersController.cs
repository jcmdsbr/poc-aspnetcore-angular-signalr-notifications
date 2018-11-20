﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRNotificationsApi.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRNotificationsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IHubContext<NotifyHub, ITypedHubClient> _notifyHub;
        private readonly ICustomerRepository _repository;

        public CustomersController(ICustomerRepository repository, IHubContext<NotifyHub, ITypedHubClient> notifyHub)
        {
            _repository = repository;
            _notifyHub = notifyHub;
        }

        [HttpGet]
        public async Task<IReadOnlyCollection<Customer>> GetCustomers()
        {
            return await _repository.Get();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            var customer = await _repository.Get(id);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer customer)
        {
            customer.Id = Guid.NewGuid();

            await _repository.Add(customer);

            await _notifyHub.Clients.All.BroadcastMessage(
                $"Customer: {customer.Name} created at {DateTime.Now.ToShortDateString()}");

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }
    }
}
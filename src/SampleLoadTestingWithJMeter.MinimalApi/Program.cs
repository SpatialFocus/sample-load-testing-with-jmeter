// <copyright file="Program.cs" company="Spatial Focus GmbH">
// Copyright (c) Spatial Focus GmbH. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.AspNetCore.Builder;
using SampleLoadTestingWithJMeter.MinimalApi;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

Randomizer.Seed = new Random(123456789);

Faker<Customer> customerData = new Faker<Customer>().RuleFor(u => u.Id, f => f.Random.Guid())
	.RuleFor(u => u.Gender, f => f.PickRandom<Gender>())
	.RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName(u.Gender.Map()))
	.RuleFor(u => u.LastName, (f, u) => f.Name.LastName(u.Gender.Map()));

List<Customer> customers = customerData.Generate(1000);

app.MapGet("/customers", async (int? pageIndex, int? pageSize) =>
{
	await Task.Delay(300);
	return customers.Skip((pageIndex ?? 0) * (pageSize ?? 50)).Take(pageSize ?? 50);
});

app.MapGet("/customers/{id}", async (Guid id) =>
{
	await Task.Delay(100);
	return customers.SingleOrDefault(x => x.Id == id);
});

app.MapPut("/customers/{id}", async (Guid id, Customer customer) =>
{
	await Task.Delay(500);
});

app.Run();
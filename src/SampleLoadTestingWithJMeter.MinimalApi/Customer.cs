// <copyright file="Customer.cs" company="Spatial Focus GmbH">
// Copyright (c) Spatial Focus GmbH. All rights reserved.
// </copyright>

namespace SampleLoadTestingWithJMeter.MinimalApi;

using System;

public class Customer
{
	public string FirstName { get; init; } = null!;

	public Gender Gender { get; set; }

	public Guid Id { get; init; }

	public string LastName { get; init; } = null!;
}
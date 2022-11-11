// <copyright file="GenderExtensions.cs" company="Spatial Focus GmbH">
// Copyright (c) Spatial Focus GmbH. All rights reserved.
// </copyright>

namespace SampleLoadTestingWithJMeter.MinimalApi;

using Bogus.DataSets;

public static class GenderExtensions
{
	public static Name.Gender? Map(this Gender gender) =>
		gender switch
		{
			Gender.Female => Name.Gender.Female,
			Gender.Male => Name.Gender.Male,
			_ => null,
		};
}
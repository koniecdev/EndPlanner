using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Entities.NBP;
using Microsoft.EntityFrameworkCore;
using Moq;
using Newtonsoft.Json;
using Persistance;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
namespace UnitTests;

public static class EndPlannerDbContextFactory
{
	public static Mock<EndPlannerDbContext> Create()
	{
		var dateTime = new DateTime(2000, 1, 1);
		var dateTimeMock = new Mock<IDateTime>();
		dateTimeMock.Setup(m => m.Now).Returns(dateTime);

		var currentUserMock = new Mock<ICurrentUserService>();
		currentUserMock.Setup(m => m.Email).Returns("mocked@user.pl");
		currentUserMock.Setup(m => m.Id).Returns("mockedUserId");
		currentUserMock.Setup(m => m.IsAuthenticated).Returns(true);

		var options = new DbContextOptionsBuilder<EndPlannerDbContext>()
			.UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

		var mock = new Mock<EndPlannerDbContext>(options, dateTimeMock.Object, currentUserMock.Object) { CallBase = true };

		var context = mock.Object;

		context.Database.EnsureCreated();

		var country1 = new Country() { Id = 1, StatusId = 1, Name = "France", CountryCode = "FRA", CurrencyCode = "EUR" };
		context.Countries.Add(country1);
		var country2 = new Country() { Id = 2, StatusId = 1, Name = "Germany", CountryCode = "DEU", CurrencyCode = "EUR" };
		context.Countries.Add(country2);

		var member1 = new Member() { Id = 1, StatusId = 1, UserEmail = "lmao@lmao.pl", UserId = "UserIdOfMember" };
		context.Members.Add(member1);
		var member2 = new Member() { Id = 2, StatusId = 1, UserEmail = "mocked@user.pl", UserId = "mockedUserId" };
		context.Members.Add(member2);

		var car1 = new Car() { Id = 1, StatusId = 1, Name = "Prelude", DriversAvailable = 2, FuelConsumption = 10.5, FuelType = 1, MemberId = 1, Seats = 4, TankLiters = 60 };
		context.Cars.Add(car1);

		var trip1 = new Trip()
		{
			Id = 1,
			StatusId = 1,
			Name = "baltic trip",
			CarId = 1,
			Address = new Domain.ValueObjects.Address()
			{
				City = "CItyyy",
				House = "20",
				PostalCode = "11-111",
				Street = "Streett"
			},
			Members = new List<Member>() { member1, member2 },
			Routes = new List<Route>(),
			Rules = new List<Rule>()
		};
		context.Trips.Add(trip1);

		var route1 = new Route()
		{
			Id = 1,
			StatusId = 1,
			Address = new Domain.ValueObjects.Address()
			{
				City = "CItyyy1",
				House = "201",
				PostalCode = "11-1111",
				Street = "Streett1"
			},
			CountryId = 1,
			BorderDistance = 400,
			Order = 1,
			SleepoverCost = 200,
			TripId = 1
		};
		context.Routes.Add(route1);

		context.SaveChanges();

		return mock;
	}

	public static void Destroy(EndPlannerDbContext context)
	{
		context.Database.EnsureDeleted();
		context.Dispose();
	}
}

using System;
using Pitstop.WorkshopManagementAPI.Domain.Entities;
using TestUtils;
using Pitstop.WorkshopManagementAPI.Domain.ValueObjects;

namespace WorkshopManagement.UnitTests.TestdataBuilders
{
    public class VehicleBuilder
    {
        private Random _rnd;

        public Name Name { get; private set; }
        public string Brand { get; private set; }
        public string Type { get; private set; }
        public string OwnerId { get; private set; }

        public VehicleBuilder()
        {
            _rnd = new Random();
            SetDefaults();
        }

        public VehicleBuilder WithName(string Name)
        {
            Name = Name.Create(Name);
            return this;
        }

        public VehicleBuilder WithRandomName()
        {
            Name = Name.Create(TestDataGenerators.GenerateRandomName());
            return this;
        }        

        public VehicleBuilder WithBrand(string brand)
        {
            Brand = brand;
            return this;
        }

        public VehicleBuilder WithType(string type)
        {
            Type = type;
            return this;
        }

        public VehicleBuilder WithOwnerId(string ownerId)
        {
            OwnerId = ownerId;
            return this;
        }

        public Vehicle Build()
        {
            if (string.IsNullOrEmpty(OwnerId))
            {
                throw new InvalidOperationException("You must specify an owner id using the 'WithOwnerId' method.");
            }
            return new Vehicle(Name, Brand, Type, OwnerId);
        }

        private void SetDefaults()
        {
            Name = Name.Create(TestDataGenerators.GenerateRandomName());
            Brand = "Volkswagen";
            Type = "Tiguan";
        }
    }
}
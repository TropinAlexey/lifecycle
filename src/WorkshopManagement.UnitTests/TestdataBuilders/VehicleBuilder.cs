using System;
using BWMS.WorkshopManagementAPI.Domain.Entities;
using TestUtils;
using BWMS.WorkshopManagementAPI.Domain.ValueObjects;

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

        public VehicleBuilder WithName(string name)
        {
            Name = Name.Create(name);
            return this;
        }

        public VehicleBuilder WithRandomName()
        {
            Name = Name.Create("Bike name");
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
            Name = Name.Create("Мой ненаглядный велик");
            Brand = "Comanche";
            Type = "Street";
        }
    }
}
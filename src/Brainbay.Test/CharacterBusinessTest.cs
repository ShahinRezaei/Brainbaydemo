using Brainbay.Business;
using Brainbay.Common.Entities;
using Brainbay.Repository;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace Brainbay.Test
{
    public class CharacterBusinessTest
    {

        private ICharacterBusiness characterBusiness;
        private IStatusBusiness  statusBusiness;
        private CharacterDbContext context; 

        [SetUp]
        public void Setup()
        {

            var options = new DbContextOptionsBuilder<CharacterDbContext>().UseInMemoryDatabase(databaseName: "InMemoryDatabase").Options;
            context = new CharacterDbContext(options); 

            characterBusiness = new CharacterBusiness(new CharacterRepository(context));
            statusBusiness = new StatusBusiness(new StatusRepository(context)); 
        }


        [Test]
        public void CharacterCountTest()
        {
            Gender gender = new Gender() { ID = Guid.NewGuid(), Name = "TestGender" };
            Status status = new Status() { ID = Guid.NewGuid(), Name = "TestStatus" };
            CharacterType characterType = new CharacterType() { ID = Guid.NewGuid(), Name = "TestCharacterType" };
            Location location = new Location() { ID = Guid.NewGuid(), Name = "TestLocation", Url = "TestUrl"  };
            Origin origin = new Origin() { ID = Guid.NewGuid(), Name = "TestOrigin", Url = "TestUrl" };
            Species species = new Species() {  ID = Guid.NewGuid(), Name = "TestSpecies" };

            var character = new Character()
            {
                ID = Guid.NewGuid(),
                Name = "Test1",
                Image = "Url",
                Status = status,
                Gender = gender, 
                Location = location, 
                Origin = origin, 
                Species = species
            };

            var character1 = new Character()
            {
                ID = Guid.NewGuid(),
                Name = "Test1",
                Image = "Url",
                Status = status,
                Gender = gender,
                Location = location,
                Origin = origin,
                Species = species
            };

            characterBusiness.SaveCharacter(character);
            characterBusiness.SaveCharacter(character1);

            var result = characterBusiness.GetAllCharacters(); 

            Assert.AreEqual(result.Result.Count(), 2);
        }
    }
}
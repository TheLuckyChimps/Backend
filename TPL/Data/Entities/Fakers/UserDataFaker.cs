using Bogus;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Enums;

namespace TPL.Data.Entities.Fakers
{
    [DebuggerStepThrough]
    public class UserDataFaker
    {
        private const string LOCALE_CODE = "en";

        public Faker<User> FakeUserProfile =>
            new Faker<User>(locale: LOCALE_CODE)
                .RuleFor(
                    key => key.Id,
                    func => func.Random.Uuid())
                .RuleFor(
                    property => property.Name,
                    func => func.Random.String2(minLength: 3, maxLength: 50))
                .RuleFor(
                    property => property.Surname,
                    func => func.Random.String2(minLength: 3, maxLength: 50))
                .RuleFor(
                    property => property.Password,
                    func => func.Random.String2(minLength: 3, maxLength: 50))
                .RuleFor(
                    property => property.Email,
                    func => func.Internet.Email())
                .RuleFor(
                    property => property.Address,
                    func => func.Random.String2(minLength: 0, maxLength: 100))
                .RuleFor(
                    property => property.Role,
                    func => func.PickRandom<UserRole>())
                .RuleFor(
                    @base => @base.CreatedAt,
                    func => func.Date.Past(yearsToGoBack: 10))
                .RuleFor(
                    @base => @base.CreatedBy,
                    func => func.Random.Uuid())
                .RuleFor(
                    @base => @base.UpdatedAt,
                    func => func.Date.Recent(days: 5))
                .RuleFor(
                    @base => @base.UpdatedBy,
                    func => func.Random.Uuid())
                .RuleFor(
                    @base => @base.IsDeleted,
                    func => func.Random.Bool(weight: 0.25F))
                .StrictMode(ensureRulesForAllProperties: true);

    }
}

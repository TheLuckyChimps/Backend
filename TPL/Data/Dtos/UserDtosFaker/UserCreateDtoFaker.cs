using Bogus;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TPL.Data.Dtos.UserDtosFaker
{
    [DebuggerStepThrough]
    public class UserCreateDtoFaker
    {
        private const string LOCALE_CODE = "en";

        public Faker<UserCreateDto> FakeUserProfileAdd =>
            new Faker<UserCreateDto>(locale: LOCALE_CODE)
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
                .StrictMode(ensureRulesForAllProperties: true);

    }
}

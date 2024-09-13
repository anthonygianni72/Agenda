using AgendaDesafioAPI.Models;
using Bogus;


namespace AgendaDesafio2.Tests
{
    public class AgendaTestes
    {
        public static Agenda Generate()
        {
            var faker = new Faker<Agenda>()
                .RuleFor(a => a.Id, f => f.IndexFaker + 1)
                .RuleFor(a => a.Nome, f => f.Name.FullName())
                .RuleFor(a => a.Email, f => f.Internet.Email())
                .RuleFor(a => a.Telefone, f => f.Phone.PhoneNumber("99-99999-9999"));

            return faker.Generate();
        }

    }
}

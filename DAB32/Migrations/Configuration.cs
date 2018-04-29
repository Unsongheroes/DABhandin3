using System.Collections.Generic;
using DAB32.Models;

namespace DAB32.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAB32.Models.DAB32Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAB32.Models.DAB32Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.ByPostNummers.AddOrUpdate(b => b.Postnummer,
                new ByPostNummer
                {
                    Postnummer = 8000,
                    ByNavn = "Aarhus",
                    Land = "Denmark"
                });

           context.Adresses.AddOrUpdate(a => a.AdresseId,
               new Adresse
               {
                   Husnummer = 1,
                   AdresseId = 2,
                   VejNavn = "kildemosevej",

               },
               new Adresse
               {
                   AdresseId = 1,
                   Husnummer = 2,
                   VejNavn = "Strandvejen",
               }
               );

            context.People.AddOrUpdate(p => p.Cpr,
                new Person
                {
                    Cpr = 1,
                    Fornavn = "Per",
                    EfterNavn = "Andersen",
                    PersonType = "CEO",
                    MellemNavn = "georh",
                    Email = "Per@Gmail.com",
                    

                },
                new Person
                {
                    Cpr = 2,
                    Fornavn = "Patrick",
                    EfterNavn = "Gobbenobber",
                    PersonType = "HouseWife",
                    MellemNavn = "Not",
                    Email = "Patrick@Gmail.com"

                }
                );

            context.PersonAdresses.AddOrUpdate(pa => pa.Type,
                new PersonAdresse
                {
                    MatchId = 12,
                    Type = "Hjem",
                    AdresseId = 1,
                    PersonCpr = 1,
                    
                },
                new PersonAdresse
                {
                    MatchId = 13,
                    Type = "Sommerhus",
                    AdresseId = 2,
                    PersonCpr = 1,

                },
                new PersonAdresse
                {
                    MatchId = 14,
                    Type = "Arbejde",
                    AdresseId = 1,
                    PersonCpr = 1,


                }
                );
                
            context.TelefonNummers.AddOrUpdate(t => t.Telefonnummer,
                new TelefonNummer
                    {
                        Telefonnummer = 12345678,
                        TelefonnummerType = "Privat",
                        TelefonSelskab = "TDC",
                        PersonCpr = 1,
                    }
            );

        }
    }
}

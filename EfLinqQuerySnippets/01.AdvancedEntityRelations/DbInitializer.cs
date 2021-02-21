using EfLinqQuerySnippets._01.AdvancedEntityRelations.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfLinqQuerySnippets._01.AdvancedEntityRelations
{
    public class DbInitializer
    {
        public static void Seed(BillsPaymentSystemContext context)
        {
            SeedUsers(context);
            SeedCreditCards(context);
            SeedBankAccounts(context);
            SeedPaymentMethods(context);
        }

        private static void SeedPaymentMethods(BillsPaymentSystemContext context)
        {
            List<PaymentMethod> paymentMethods = new List<PaymentMethod>();

            for (int i = 0; i < 7; i++)
            {
                PaymentMethod paymentMethod = new PaymentMethod
                {
                    UserId = new Random().Next(1, 4),
                    Type = (PaymentType)new Random().Next(1, 4),
                    CreditCardId = i + 1,
                    BankAccountId = i + 1
                };

                paymentMethods.Add(paymentMethod);
            }

            context.PaymentMethods.AddRange(paymentMethods);
            context.SaveChanges();
        }

        private static void SeedBankAccounts(BillsPaymentSystemContext context)
        {
            List<BankAccount> bankAccounts = new List<BankAccount>();

            for (int i = 0; i < 8; i++)
            {
                BankAccount bankAccount = new BankAccount
                {
                    Balance = new Random().Next(-200, 200),
                    BankName = "Bank" + i,
                    SwiftCode = "Swift" + i + 1
                };

                if (!IsValid(bankAccount))
                {
                    continue;
                }

                bankAccounts.Add(bankAccount);
            }

            context.BankAccounts.AddRange(bankAccounts);
            context.SaveChanges();
        }

        private static void SeedCreditCards(BillsPaymentSystemContext context)
        {
            List<CreditCard> creditCards = new List<CreditCard>();

            for (int i = 0; i < 8; i++)
            {
                CreditCard creditCard = new CreditCard
                {
                    Limit = new Random().Next(-25000, 25000),
                    MoneyOwed = new Random().Next(-25000, 25000),
                    ExpirationDate = DateTime.Now.AddDays(new Random().Next(-200, 200))
                };

                if (!IsValid(creditCard))
                {
                    continue;
                }

                creditCards.Add(creditCard);
            }

            context.CreditCards.AddRange(creditCards);
            context.SaveChanges();
        }

        private static void SeedUsers(BillsPaymentSystemContext context)
        {
            string[] firstNames = { "Gosho", "Pesho", "Ivan", "Kiro", null, "" };
            string[] lastNames = { "Goshov", "Peshev", "Ivanov", "Kirov", null, "ERROR" };
            string[] emails = { "gosho@abv.bg", "pesho@abv.bg", "ivan@gmail.com", null, "ERROR", "ERROR" };
            string[] passwords = { "232343@abv.bg", "pe5667sho@abv.bg", "11111@gmail.com", null, "ERROR", "ERROR" };

            List<User> users = new List<User>();

            for (int i = 0; i < firstNames.Length; i++)
            {
                User user = new User
                {
                    FirstName = firstNames[i],
                    LastName = lastNames[i],
                    Email = emails[i],
                    Password = passwords[i]
                };

                if (!IsValid(user))
                {
                    continue;
                }

                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResults, true);
            return isValid;
        }
    }
}

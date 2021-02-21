using EfLinqQuerySnippets._01.AdvancedEntityRelations.Core.Commands.Contracts;
using System;
using System.Linq;

namespace EfLinqQuerySnippets._01.AdvancedEntityRelations.Core.Commands
{
    public class UserDetailsCommand : ICommand
    {
        private readonly BillsPaymentSystemContext context;

        public UserDetailsCommand(BillsPaymentSystemContext context)
        {
            this.context = context;
        }

        public string Execute(string[] args)
        {
            int userId = int.Parse(args[0]);

            User user = this.context.Users.FirstOrDefault(u => u.UserId == userId);

            if (user == null)
            {
                throw new ArgumentNullException("User not found.");
            }

            return "";
        }
    }
}

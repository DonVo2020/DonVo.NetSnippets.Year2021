using EfLinqQuerySnippets._01.AdvancedEntityRelations.Core.Commands.Contracts;
using EfLinqQuerySnippets._01.AdvancedEntityRelations.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace EfLinqQuerySnippets._01.AdvancedEntityRelations.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Suffix = "Command";

        public string Read(string[] args, BillsPaymentSystemContext context)
        {
            string command = args[0];
            string[] commandArgs = args.Skip(1).ToArray();

            Type type = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == command + Suffix);

            if (type == null)
            {
                throw new ArgumentNullException("Command not found!");
            }

            object typeInstance = Activator.CreateInstance(type, context);

            string result = ((ICommand)typeInstance).Execute(commandArgs);

            return result;
        }
    }
}

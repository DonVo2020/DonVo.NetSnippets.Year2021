using EfLinqQuerySnippets._01.AdvancedEntityRelations.Core;
using EfLinqQuerySnippets._01.AdvancedEntityRelations.Core.Contracts;

namespace EfLinqQuerySnippets._01.AdvancedEntityRelations
{
    public class StartUp
    {
        public static void RunMain()
        {
            //using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
            //{
            //    DbInitializer.Seed(context);
            //}
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IEngine engine = new Engine();

            engine.Run();
        }
    }
}

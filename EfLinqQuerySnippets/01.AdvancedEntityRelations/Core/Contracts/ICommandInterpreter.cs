namespace EfLinqQuerySnippets._01.AdvancedEntityRelations.Core.Contracts
{
    public interface ICommandInterpreter
    {
        string Read(string[] args, BillsPaymentSystemContext context);
    }
}

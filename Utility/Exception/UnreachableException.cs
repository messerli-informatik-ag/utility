namespace Messerli.Utility.Exception
{
    public class UnreachableException : System.Exception
    {
        public UnreachableException()
        {
        }

        public override string Message => $"This code should be unreachable by design.";
    }
}

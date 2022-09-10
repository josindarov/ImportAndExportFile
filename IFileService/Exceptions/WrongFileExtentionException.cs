namespace Application.Exceptions
{
    public class WrongFileExtentionException : Exception
    {
        public WrongFileExtentionException(string message)
            : base(message)
        {

        }
    }
}

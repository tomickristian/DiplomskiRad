namespace DiplomskiRad.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() { }

        public EntityNotFoundException(string message = "Entitet nije pronađen.") : base(message) { }

        public EntityNotFoundException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}

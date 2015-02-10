namespace PongPoC
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                PongGame.Instance.Run();
            }
            finally
            {
                PongGame.Instance.Dispose();
            }
        }
    }
#endif
}


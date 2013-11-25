using System;

namespace PyramidPanic
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (PyramidePanic game = new PyramidePanic())
            {
                game.Run();
            }
        }
    }
#endif
}


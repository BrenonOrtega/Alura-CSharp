using Reflection.Interfaces;

namespace Reflection.Classes
{
    public class Alien : ITalk
    {
        string Name { get; set; }
        public void Talk()
        {
            System.Console.Out.WriteLine($"{nameof(Alien)}{nameof(Talk)}(): Busquem conhecimento.");
        }

        private Alien()
        {
            System.Console.Out.WriteLine($"Instantiang {nameof(Alien)} with private constructor.");
            
        }
    }
}
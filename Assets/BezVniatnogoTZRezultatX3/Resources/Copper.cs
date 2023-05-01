using Assets.BezVniatnogoTZRezultatX3.Abstract;

namespace Assets.BezVniatnogoTZRezultatX3.Resources
{
    public class Copper : Resource
    {
        private const string NAME = "Медяки";


        public override string Name => NAME;

        public Copper(int amount) : base(amount) { }

        public static implicit operator Copper(int amount) => new(amount);

        public static Copper operator +(Copper one, Copper two)
        {
            return new Copper(one.Amount + two.Amount);
        }
    }
}

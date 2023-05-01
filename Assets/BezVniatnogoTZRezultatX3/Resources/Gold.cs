using Assets.BezVniatnogoTZRezultatX3.Abstract;

namespace Assets.BezVniatnogoTZRezultatX3.Resources
{
    public class Gold : Resource
    {
        private const string NAME = "Золото";
        private const int SILVERS_IN_GOLD_AMOUNT = 10;

        public override string Name => NAME;

        public Gold(int amount) : base(amount) { }

        public static implicit operator Gold(int amount) => new(amount);

        public static implicit operator Silver(Gold gold) => new(gold.Amount * SILVERS_IN_GOLD_AMOUNT);

        public static Gold operator +(Gold one, Gold two)
        {
            return new Gold(one.Amount + two.Amount);
        }
    }
}

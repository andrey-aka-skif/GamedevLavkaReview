using Assets.BezVniatnogoTZRezultatX3.Abstract;

namespace Assets.BezVniatnogoTZRezultatX3.Resources
{
    public class Silver : Resource
    {
        private const string NAME = "Серебро";
        public const int COPPERS_IN_SILVER_AMOUNT = 10;

        public override string Name => NAME;

        public Silver(int amount) : base(amount) { }

        public static implicit operator Silver(int amount) => new(amount);

        public static implicit operator Copper(Silver silver) => new(silver.Amount * COPPERS_IN_SILVER_AMOUNT);

        public static Silver operator +(Silver one, Silver two)
        {
            return new Silver(one.Amount + two.Amount);
        }
    }
}

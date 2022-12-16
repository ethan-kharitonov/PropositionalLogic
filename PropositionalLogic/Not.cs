namespace PropositionalLogic
{
    public class Not : Formula
    {
        private readonly Formula A;
        public Not(Formula A)
        {
            this.A = A;
        }
    }
}

namespace PropositionalLogic
{
    public class Or
    {
        public readonly Formula A;
        public readonly Formula B;
        public Or(Formula A, Formula B)
        {
            this.A = A;
            this.B = B;
        }
    }
}

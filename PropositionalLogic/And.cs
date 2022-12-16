namespace PropositionalLogic
{
    public class And
    {
        public readonly Formula A; 
        public readonly Formula B;
        public And(Formula A, Formula B)
        {
            this.A = A;
            this.B = B;
        }
    }
}

namespace CSharpLearning
{
    public class StringInfo
    {
        private char firstChar;
        private int length;

        public char FirstChar => firstChar;

        public int Length => length;

        public StringInfo(char firstChar, int length)
        {
            this.firstChar = firstChar;
            this.length = length;
        }

        public override string ToString()
        {
            return $"First char: {firstChar}. String length: {length}";
        }
    }
}
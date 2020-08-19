namespace CSharpLearning
{
    public class StringInfo
    {
        public char FirstChar { get; }
        public int Length { get; }

        public StringInfo(char firstChar, int length)
        {
            FirstChar = firstChar;
            Length = length;
        }

        public override string ToString()
        {
            return $"First char: {FirstChar}. String length: {Length}";
        }
    }
}
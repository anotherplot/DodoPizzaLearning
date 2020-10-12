namespace CSharpLearning.DSL
{
    public static class Create
    {
        public static DepartmentBuilder Department => new DepartmentBuilder();
        public static UnitBuilder Unit => new UnitBuilder();
        
    }
}
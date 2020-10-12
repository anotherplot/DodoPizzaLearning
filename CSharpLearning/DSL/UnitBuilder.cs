namespace CSharpLearning.DSL
{
    public class UnitBuilder
    {
        public string _name;
        public int _id;
        public bool _approved;

        public UnitBuilder WithName(string name)
        {
            _name = name;
            return this;
        }   
        
        public UnitBuilder WithId(int id)
        {
            _id = id;
            return this;
        }     
        
        public UnitBuilder IsApproved(bool approved)
        {
            _approved = approved;
            return this;
        }   
        
        public Unit Please()
        {
            return new Unit()
            {
                Approve = _approved,
                Id = _id,
                Name = _name,
                Type = 1
            };
        }
    }
}
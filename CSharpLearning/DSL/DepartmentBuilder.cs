using System;
using System.Collections.Generic;

namespace CSharpLearning.DSL
{
    public class DepartmentBuilder
    {
        public string _name;
        public int _type;
        private int _id;
        private List<Unit> _units;


        public DepartmentBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public DepartmentBuilder WithType(int type)
        {
            _type = type;
            return this;
        }

        public DepartmentBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public DepartmentBuilder WithUnits(params Action<UnitBuilder>[] builderSteps)
        {
            _units = new List<Unit>();

            foreach (var setup in builderSteps)
            {
                var builder = Create.Unit;
                setup(builder);
                var unit = builder.Please();
                _units.Add(unit);
            }

            return this;
        }

        public Department Please()
        {
            return new Department()
            {
                Name = _name,
                Id = _id,
                Type = _type,
                State = 1,
                Units = _units
            };
        }
    }
}
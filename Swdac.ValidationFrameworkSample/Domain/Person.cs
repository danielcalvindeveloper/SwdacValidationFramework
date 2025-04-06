using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swdac.ValidationFrameworkSample.Domain
{
    public class Person
    {
        private Person() { }
        public Person(int id, string name, string surname, DateTime birthDate, GenderEnum gender)
        {
            Id = id;
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            this.gender = gender;
        }
        public int Id { get; private set; }
        public string? Name { get; private set; }
        public string? Surname { get; private set; }
        public DateTime BirthDate { get; private set; }
        public GenderEnum gender { get; private set; }

        public Person? Mother { get; private set; }
        public Person? Father { get; private set; }
        public List<Person> Children { get; private set; } = new List<Person>();
        
        internal void AddChild(Person child)
        {
            if (child == null) throw new ArgumentNullException(nameof(child));
            if (Children.Contains(child)) throw new InvalidOperationException("Child already exists");
            Children.Add(child);
        }

        public void setParents(Person mother, Person father)
        {
            if (mother == null) throw new ArgumentNullException(nameof(mother));
            if (father == null) throw new ArgumentNullException(nameof(father));
            Mother = mother; Father = father;

            Mother.AddChild(this);
            Father.AddChild(this);
        }

        public void setMother(Person mother)
        {
            if (mother == null) throw new ArgumentNullException(nameof(mother));
            Mother = mother;
            Mother.AddChild(this);
        }

        public void setFather(Person father)
        {
            if (father == null) throw new ArgumentNullException(nameof(father));
            Father = father;
            Father.AddChild(this);
        }

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}

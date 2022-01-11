using System;

namespace RepositorySample
{
    public class SimpleClassObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }

        public SimpleClassObject()
        {
            Id = Guid.NewGuid();
        }
    }
}
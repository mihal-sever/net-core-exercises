using System;

namespace Lambda
{
    class Client
    {
        public string Name { get; set; }

        public Client(string name)
        {
            this.Name = name;
        }

        public void HandleOutput(int x)
        {
            Console.WriteLine($"{Name} - {x}");
        }
    }
}

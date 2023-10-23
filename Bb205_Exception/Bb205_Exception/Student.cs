using Bb205_Exception.Exceptions;

namespace Bb205_Exception
{
    internal class Student
    {
        public string Name { get; set; }
        int _age;
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value > 18)
                {
                    _age = value;
                }
                else
                {
                    throw new AgeLimitException("18 yasdan asagi olmaz");
                }
            }
        }
    }
}

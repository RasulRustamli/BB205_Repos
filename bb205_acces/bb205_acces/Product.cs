namespace bb205_acces
{
    internal class Product
    {
        private double _price;
        private int _count;
        public string Name { get; set; }
        public double Price
        {
            get { return _price; }
            set
            {
                if (value > 0)
                {
                    _price = value;
                }
            }
        }
        public int Count
        {
            get { return _count; }
            set
            {
                if(value>0)
                {
                    _count = value;
                }
            }
        }
        public Product(string name,double price,int count)
        {
            Name = name;
            Price = price;
            Count = count;
        }

    }
}

namespace Lab2
{
    class Producer
    {
        public string Name { get; set; }       // ім'я виробника
        public string Country { get; set; }    //країна розташування виробника

        public override string ToString()
        {
            return string.Format(@"{0} {1}",  Name, Country);
        }
    }
}

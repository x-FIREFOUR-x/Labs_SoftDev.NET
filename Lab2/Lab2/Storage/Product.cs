namespace Lab2
{
    class Product
    {
        public string Code { get; set; }         // код товару
        public double Price { get; set; }        // ціна за одиницю
        public int Number { get; set; }          // кількість в пачці
        public string DateArrival { get; set; }  // дата прибуття на склад
        public double Weight { get; set; }        // вага

        public override string ToString()
        {
            return string.Format(@"
                Товар: 
                    Код: {0} 
                    Ціна одиниці: {1} грн
                    Кількість: {2} шт
                    Дата привезення: {3}
                    Вага одиниці: {4} кг", Code, Price, Number, DateArrival, Weight);
        }
    }
}


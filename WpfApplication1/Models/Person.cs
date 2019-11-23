namespace WpfApplication1.Models
{
    public class Person
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public static Person[] GetPersons()
        {
            return new Person[]
            {
                new Person(){ LastName = "Ксенофонтов", FirstName = "Михаил"}, 
                new Person(){ LastName = "Песков", FirstName = "Дмитрий"}, 
                new Person(){ LastName = "Серов", FirstName = "Сергей"}, 
            };
        }
    }
}
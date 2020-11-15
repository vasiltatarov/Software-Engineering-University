namespace ExtendedDatabase
{
    public class Person
    {
        public Person(long id, string userName)
        {
            this.Id = id;
            this.UserName = userName;
        }

        public string UserName { get; private set; }

        public long Id { get; private set; }
    }
}

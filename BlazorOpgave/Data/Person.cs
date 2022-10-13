namespace BlazorOpgave.Data
{
    public class Person
    {
        private string id;
        private string firstName;
        private string lastName;

        public Person()
        {

        }

        public Person(string id, string firstName, string lastName)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string getId()
        {
            return this.id;
        }

        public string getFirstName()
        {
            return this.firstName;
        }

        public void setFirstName(string firstName)
        {
            this.firstName = firstName;
        }

        public string getLastName()
        {
            return this.lastName;
        }

        public void setLastName(string lastName)
        {
            this.lastName = lastName;
        }
    }
}

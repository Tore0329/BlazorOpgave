using System.Data.SqlClient;

namespace BlazorOpgave.Data
{
	public static class PersonService
    {
		private static string connectionString = "Data Source=192.168.2.2;Initial Catalog=Opgave;User ID=sa;Password=Passw0rd;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		public static void createPerson(string firstName, string lastName)
        {
			string queryString = "INSERT INTO dbo.OpgaveTable (FirstName, LastName) VALUES (@FirstName, @LastName)";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = new SqlCommand(queryString, connection))
				{
					command.Parameters.AddWithValue("@FirstName", firstName);
					command.Parameters.AddWithValue("@LastName", lastName);

					connection.Open();
					command.ExecuteNonQuery();
				}
			}
		}

		public static void editPerson(string id, string firstName, string lastName)
        {
			string queryString = "UPDATE dbo.OpgaveTable SET FirstName = @FirstName, LastName = @LastName Where ID = @ID";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = new SqlCommand(queryString, connection))
				{
					command.Parameters.AddWithValue("@ID", id);
					command.Parameters.AddWithValue("@FirstName", firstName);
					command.Parameters.AddWithValue("@LastName", lastName);

					connection.Open();
					command.ExecuteNonQuery();
				}
			}
		}

		public static void deletePerson(string id)
        {
			string queryString = "DELETE FROM dbo.OpgaveTable WHERE ID = @ID";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = new SqlCommand(queryString, connection))
				{
					command.Parameters.AddWithValue("@ID", id);

					connection.Open();
					command.ExecuteNonQuery();
				}
			}
		}

        public static List<Person> getPeopleList()
        {
			List<Person> peopleList = new List<Person>();
			string queryString = "SELECT ID, FirstName, LastName FROM OpgaveTable";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(queryString, connection);
				connection.Open();
				using (SqlDataReader reader = command.ExecuteReader())
				{
					try
					{
						while (reader.Read())
						{
							peopleList.Add(new Person(reader["ID"].ToString(), reader["FirstName"].ToString(), reader["LastName"].ToString()));
						}
					}
					finally
					{
						reader.Close();
					}
				}
			}

			return peopleList;
		}
    }
}

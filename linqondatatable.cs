using System.Data;

namespace linq
{
	internal class Program
	{
		static void Main(string[] args)
		{
			DataTable dataTable = new DataTable();

			// Add columns to the DataTable
			dataTable.Columns.Add("Name", typeof(string));
			dataTable.Columns.Add("Class", typeof(string));
			dataTable.Columns.Add("Roll No", typeof(int));

			// Add 5 random records to the DataTable
			Random random = new Random();
			for (int i = 1; i <= 5; i++)
			{
				DataRow row = dataTable.NewRow();
				row["Name"] = "Student " + i;
				row["Class"] = "Class " + random.Next(1, 6);
				row["Roll No"] =i;
				dataTable.Rows.Add(row);
			}
			// to filder selected records 
			var result=dataTable.AsEnumerable().Where(p=>p.Field<int>("Roll No")>3).Select(p => p.Field<string>("Name"));
			//to select all data
			// var result=dataTable.AsEnumerable().Where(p=>p.Field<int>("Roll No")>3); //condition //return row 
			foreach (string row in result)
			{
				Console.WriteLine(row);
			}
			Console.ReadKey();
		}
	}
}

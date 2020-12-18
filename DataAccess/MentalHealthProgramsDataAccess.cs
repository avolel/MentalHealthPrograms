using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using Models;
using System.Data;
using System.Data.SqlClient;
using Logger;

namespace DataAccess
{
    public class MentalHealthProgramsDataAccess
    {
        private static string connectionString;

        static MentalHealthProgramsDataAccess()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MentalConnection"].ConnectionString;
        }

        public static List<MentalHealthProgram> GetMentalHealthPrograms(string name = null)
        {
            List<MentalHealthProgram> programs = new List<MentalHealthProgram>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    DataSet ds = new DataSet();
                    SqlCommand command = new SqlCommand();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = (name == null) ? "GetMentalHealthPrograms" : "GetMentalHealthProgramsByName";
                    if (name != null)
                        command.Parameters.AddWithValue("@Name", name);
                    connection.Open();
                    adapter.Fill(ds);
                    connection.Close();

                    foreach (var row in ds.Tables[0].AsEnumerable().ToList())
                    {
                        MentalHealthProgram program = new MentalHealthProgram()
                        {
                            Name_1 = Convert.ToString(row[1]),
                            Name_2 = Convert.ToString(row[2]),
                            Street_1 = Convert.ToString(row[3]),
                            Street_2 = Convert.ToString(row[4]),
                            City = Convert.ToString(row[5]),
                            Zip = Convert.ToString(row[6]),
                            Phone = Convert.ToString(row[7]),
                            Website = !Convert.IsDBNull(row[8]) ? "<a class='btn btn-info' href='" + Convert.ToString(row[8]) + "' target='_blank'>View Website</a>" : string.Empty
                        };

                        programs.Add(program);
                    }
                    
                }
            }
            catch(Exception ex)
            {
                ErrorLogger.Error(ex, ex.Message);
            }
            return programs;
        }
    }
}

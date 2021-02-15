using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using Model;
using Logger;
using SODA;

namespace DataAccess
{
    public class MentalHealthProgramsDataAccess
    {
        private static string connectionString;

        static MentalHealthProgramsDataAccess()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MentalConnection"].ConnectionString;
        }

        public static List<MentalHealthProgram> GetMentalHealthPrograms()
        {
            List<MentalHealthProgram> programs = new List<MentalHealthProgram>();

            try
            {
                var client = new SodaClient("https://data.cityofnewyork.us", "WmtS5pyPXAaYrcuZeeghnpRUU");
                var dataset = client.GetResource<Dictionary<string, object>>("8nqg-ia7v");
                var soql = new SoqlQuery().Select("name_1", "name_2", "street_1", "street_2", "city", "zip", "phone", "website");
                programs = dataset.Query<MentalHealthProgram>(soql).ToList();
            }
            catch(Exception ex)
            {
                ErrorLogger.Error(ex, ex.Message);
            }
            return programs;
        }

        public static List<MentalHealthProgram> GetMentalHealthPrograms(string name)
        {
            List<MentalHealthProgram> programs = new List<MentalHealthProgram>();

            try
            {
                var client = new SodaClient("https://data.cityofnewyork.us", "WmtS5pyPXAaYrcuZeeghnpRUU");
                var dataset = client.GetResource<Dictionary<string, object>>("8nqg-ia7v");
                var soql = new SoqlQuery().Select("name_1", "name_2", "street_1", "street_2", "city", "zip", "phone", "website")
                    .Where("name_1 like '%" + name + "%'");
                programs = dataset.Query<MentalHealthProgram>(soql).ToList();
            }
            catch (Exception ex)
            {
                ErrorLogger.Error(ex, ex.Message);
            }
            return programs;
        }
    }
}

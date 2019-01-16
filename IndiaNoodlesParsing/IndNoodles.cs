using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SpssLib.DataReader;
using SpssLib.SpssDataset;
using System.Data.SqlClient;


namespace IndiaNoodlesParsing
{
    class IndNoodles
    {
        static void Main(string[] args)
        {

            int SurveyID = 600603;
            string SURVEY_PERIOD = "2018-06-30";//survey period
            string country = "INDIA";//survey country
            InsertIndNoodles iobj = new InsertIndNoodles();
            string questions = "Respondent_Serial,rq7,rq8,WAVE,q16_2,CENTRE,rq6P,q16_1,Newsec,q1_1,q1_2_1,q1_2_2,q1_2_3,q1_2_4,q1_2_5,q1_2_6,q1_2_7,q1_2_8,q1_2_16,q1_2_19,q3_2_1,q3_2_2,q3_2_3,q3_2_4,q3_2_5,q3_2_6,q3_2_7,q3_2_8,q3_2_16,q3_2_19,q2_1,q2_2_1,q2_2_2,q2_2_3,q2_2_4,q2_2_5,q2_2_6,q2_2_7,q2_2_8,q2_2_16,q2_2_19,q4_01,q4_02,q4_03,q4_04,q4_05,q4_06,q4_07,q4_08,q4_16,q4_19,q4_1_1,q4_1_2,q4_1_3,q4_1_4,q4_1_5,q4_1_6,q4_1_7,q4_1_8,q4_1_16,q4_1_19,q4_2_1,q4_2_2,q4_2_3,q4_2_4,q4_2_5,q4_2_6,q4_2_7,q4_2_8,q4_2_16,q4_2_19,q4_3_1,q4_3_2,q4_3_3,q4_3_4,q4_3_5,q4_3_6,q4_3_7,q4_3_8,q4_3_16,q4_3_19,q4_4_1,q4_4_2,q4_4_3,q4_4_4,q4_4_5,q4_4_6,q4_4_7,q4_4_8,q4_4_16,q4_4_19,q4_4a_1,q4_4a_2,q4_4a_3,q4_4a_4,q4_4a_5,q4_4a_6,q4_4a_7,q4_4a_8,q4_4a_16,q4_4a_19,q4_4b_1,q4_4b_2,q4_4b_3,q4_4b_4,q4_4b_5,q4_4b_6,q4_4b_7,q4_4b_8,q4_4b_16,q4_4b_19,q4_5a,q4_5b,q4_6,q4_7,q10_3,q11_6,q11_8,q12,q12_3,q15_5_2,mq15_7,q5_1_C1,q5_1_C2,q5_1_C3,q5_1_C4,q5_1_C5,q5_1_C6,q5_1_C7,q5_1_C8,q5_1_C9,q5_1_C10,q5_1_C11,q5_2_C1,q5_2_C2,q5_2_C3,q5_2_C4,q5_2_C5,q5_2_C6,q5_2_C7,q5_2_C8,q5_2_C9,q5_2_C10,q5_2_C11,q5_3_C1,q5_3_C2,q5_3_C3,q5_3_C4,q5_3_C5,q5_3_C6,q5_3_C7,q5_3_C8,q5_3_C9,q5_3_C10,q5_3_C11,q5_4_C1,q5_4_C2,q5_4_C3,q5_4_C4,q5_4_C5,q5_4_C6,q5_4_C7,q5_4_C8,q5_4_C9,q5_4_C10,q5_4_C11";// dashboard variable value
            //string questions = "";
            string[] spss_variable_name = questions.Split(',');
            SpssReader spssDataset;
            using (FileStream fileStream = new FileStream(@"E:\Clue-Box Work\2018\JUN-2018\IND_NOODLES-Survey\INDN-JUN-2018.sav", FileMode.Open, FileAccess.Read, FileShare.Read, 2048 * 10, FileOptions.SequentialScan))
            {
                spssDataset = new SpssReader(fileStream); // Create the reader, this will read the file header
                foreach (string spss_v in spss_variable_name)
                {
                    foreach (var variable in spssDataset.Variables)  // Iterate through all the varaibles
                    {
                        if (variable.Name.Equals(spss_v))
                        {
                            foreach (KeyValuePair<double, string> label in variable.ValueLabels)
                            {
                                string VARIABLE_NAME = spss_v;
                                string VARIABLE_NAME_SUB_NAME = variable.Name;
                                string VARIABLE_ID = label.Key.ToString();
                                string VARIABLE_VALUE = label.Value;
                                string VARIABLE_NAME_QUESTION = variable.Label;
                                string BASE_VARIABLE_NAME = variable.Name;
                                // iobj.insert_Dashboard_variable_values(VARIABLE_NAME, VARIABLE_NAME_SUB_NAME, VARIABLE_ID, VARIABLE_VALUE, VARIABLE_NAME_QUESTION, SurveyID, country, BASE_VARIABLE_NAME, SURVEY_PERIOD);
                            }
                        }
                    }
                }


                foreach (var record in spssDataset.Records)
                {
                    string userID = null;
                    string variable_name;
                    decimal Weight = 1;
                    string u_id = "-- Not Available --";
                    string Gender = "-- Not Available --";
                    string MaritalStatus = "-- Not Available --";
                    string AttendedOn = "-- Not Available --";
                    string Occupation = "-- Not Available --";
                    string Location = "-- Not Available --";
                    string AgeGroup = "-- Not Available --";
                    string Education = "-- Not Available --";
                    string SEC = "-- Not Available --";
                    string Period = "-- Not Available --";
                    string BrTom = "-- Not Available --";
                    string BrSpont_Maggi = "-- Not Available --";
                    string BrSpont_Yippee = "-- Not Available --";
                    string BrSpont_Top_Ramen = "-- Not Available --";
                    string BrSpont_Biryanz_BiryaniNoodle = "-- Not Available --";
                    string BrSpont_Wai_Wai = "-- Not Available --";
                    string BrSpont_Chings = "-- Not Available --";
                    string BrSpont_Joymee = "-- Not Available --";
                    string BrSpont_Knorr = "-- Not Available --";
                    string BrSpont_Patanjali = "-- Not Available --";
                    string BrSpont_A_M = "-- Not Available --";
                    string BrAid_Maggi = "-- Not Available --";
                    string BrAid_Yippee = "-- Not Available --";
                    string BrAid_Top_Ramen = "-- Not Available --";
                    string BrAid_Biryanz_BiryaniNoodle = "-- Not Available --";
                    string BrAid_Wai_Wai = "-- Not Available --";
                    string BrAid_Chings = "-- Not Available --";
                    string BrAid_Joymee = "-- Not Available --";
                    string BrAid_Knorr = "-- Not Available --";
                    string BrAid_Patanjali = "-- Not Available --";
                    string BrAid_A_M = "-- Not Available --";
                    string AdTom = "-- Not Available --";
                    string AdSpont_Maggi = "-- Not Available --";
                    string AdSpont_Yippee = "-- Not Available --";
                    string AdSpont_Top_Ramen = "-- Not Available --";
                    string AdSpont_Biryanz_BiryaniNoodle = "-- Not Available --";
                    string AdSpont_Wai_Wai = "-- Not Available --";
                    string AdSpont_Chings = "-- Not Available --";
                    string AdSpont_Joymee = "-- Not Available --";
                    string AdSpont_Knorr = "-- Not Available --";
                    string AdSpont_Patanjali = "-- Not Available --";
                    string AdSpont_A_M = "-- Not Available --";
                    string EverCons_Maggi = "-- Not Available --";
                    string EverCons_Yippee = "-- Not Available --";
                    string EverCons_Top_Ramen = "-- Not Available --";
                    string EverCons_Biryanz_BiryaniNoodle = "-- Not Available --";
                    string EverCons_Wai_Wai = "-- Not Available --";
                    string EverCons_Chings = "-- Not Available --";
                    string EverCons_Joymee = "-- Not Available --";
                    string EverCons_Knorr = "-- Not Available --";
                    string EverCons_Patanjali = "-- Not Available --";
                    string EverCons_A_M = "-- Not Available --";
                    string ConsL6M_Maggi = "-- Not Available --";
                    string ConsL6M_Yippee = "-- Not Available --";
                    string ConsL6M_Top_Ramen = "-- Not Available --";
                    string ConsL6M_Biryanz_BiryaniNoodle = "-- Not Available --";
                    string ConsL6M_Wai_Wai = "-- Not Available --";
                    string ConsL6M_Chings = "-- Not Available --";
                    string ConsL6M_Joymee = "-- Not Available --";
                    string ConsL6M_Knorr = "-- Not Available --";
                    string ConsL6M_Patanjali = "-- Not Available --";
                    string ConsL6M_A_M = "-- Not Available --";
                    string ConsL3M_Maggi = "-- Not Available --";
                    string ConsL3M_Yippee = "-- Not Available --";
                    string ConsL3M_Top_Ramen = "-- Not Available --";
                    string ConsL3M_Biryanz_BiryaniNoodle = "-- Not Available --";
                    string ConsL3M_Wai_Wai = "-- Not Available --";
                    string ConsL3M_Chings = "-- Not Available --";
                    string ConsL3M_Joymee = "-- Not Available --";
                    string ConsL3M_Knorr = "-- Not Available --";
                    string ConsL3M_Patanjali = "-- Not Available --";
                    string ConsL3M_A_M = "-- Not Available --";
                    string ConsL1M_Maggi = "-- Not Available --";
                    string ConsL1M_Yippee = "-- Not Available --";
                    string ConsL1M_Top_Ramen = "-- Not Available --";
                    string ConsL1M_Biryanz_BiryaniNoodle = "-- Not Available --";
                    string ConsL1M_Wai_Wai = "-- Not Available --";
                    string ConsL1M_Chings = "-- Not Available --";
                    string ConsL1M_Joymee = "-- Not Available --";
                    string ConsL1M_Knorr = "-- Not Available --";
                    string ConsL1M_Patanjali = "-- Not Available --";
                    string ConsL1M_A_M = "-- Not Available --";
                    string ConsL1W_Maggi = "-- Not Available --";
                    string ConsL1W_Yippee = "-- Not Available --";
                    string ConsL1W_Top_Ramen = "-- Not Available --";
                    string ConsL1W_Biryanz_BiryaniNoodle = "-- Not Available --";
                    string ConsL1W_Wai_Wai = "-- Not Available --";
                    string ConsL1W_Chings = "-- Not Available --";
                    string ConsL1W_Joymee = "-- Not Available --";
                    string ConsL1W_Knorr = "-- Not Available --";
                    string ConsL1W_Patanjali = "-- Not Available --";
                    string ConsL1W_A_M = "-- Not Available --";
                    string RegCons_Maggi = "-- Not Available --";
                    string RegCons_Yippee = "-- Not Available --";
                    string RegCons_Top_Ramen = "-- Not Available --";
                    string RegCons_Biryanz_BiryaniNoodle = "-- Not Available --";
                    string RegCons_Wai_Wai = "-- Not Available --";
                    string RegCons_Chings = "-- Not Available --";
                    string RegCons_Joymee = "-- Not Available --";
                    string RegCons_Knorr = "-- Not Available --";
                    string RegCons_Patanjali = "-- Not Available --";
                    string RegCons_A_M = "-- Not Available --";
                    string RegConsKids_Maggi = "-- Not Available --";
                    string RegConsKids_Yippee = "-- Not Available --";
                    string RegConsKids_Top_Ramen = "-- Not Available --";
                    string RegConsKids_Biryanz_BiryaniNoodle = "-- Not Available --";
                    string RegConsKids_Wai_Wai = "-- Not Available --";
                    string RegConsKids_Chings = "-- Not Available --";
                    string RegConsKids_Joymee = "-- Not Available --";
                    string RegConsKids_Knorr = "-- Not Available --";
                    string RegConsKids_Patanjali = "-- Not Available --";
                    string RegConsKids_A_M = "-- Not Available --";
                    string Bumo = "-- Not Available --";
                    string Bumo_Kids = "-- Not Available --";
                    string FavBrand = "-- Not Available --";
                    string Likely_Cons = "-- Not Available --";
                    string Likelihood_Pur_Biriyanz = "-- Not Available --";
                    string Noodle_likeably_Biriyanz = "-- Not Available --";
                    string Noodle_kids_likeably_Biriyanz = "-- Not Available --";
                    string Pur_Likeability_Biriyanz = "-- Not Available --";
                    string Cons_P1W_BiriyanzNoodles = "-- Not Available --";
                    string PackSize_Reg_Buy = "-- Not Available --";
                    string Freq_Noodle_Pur = "-- Not Available --";
                    string q5_1_C1 = "-- Not Available --";
                    string q5_1_C2 = "-- Not Available --";
                    string q5_1_C3 = "-- Not Available --";
                    string q5_1_C4 = "-- Not Available --";
                    string q5_1_C5 = "-- Not Available --";
                    string q5_1_C6 = "-- Not Available --";
                    string q5_1_C7 = "-- Not Available --";
                    string q5_1_C8 = "-- Not Available --";
                    string q5_1_C9 = "-- Not Available --";
                    string q5_1_C10 = "-- Not Available --";
                    string q5_1_C11 = "-- Not Available --";
                    string q5_2_C1 = "-- Not Available --";
                    string q5_2_C2 = "-- Not Available --";
                    string q5_2_C3 = "-- Not Available --";
                    string q5_2_C4 = "-- Not Available --";
                    string q5_2_C5 = "-- Not Available --";
                    string q5_2_C6 = "-- Not Available --";
                    string q5_2_C7 = "-- Not Available --";
                    string q5_2_C8 = "-- Not Available --";
                    string q5_2_C9 = "-- Not Available --";
                    string q5_2_C10 = "-- Not Available --";
                    string q5_2_C11 = "-- Not Available --";
                    string q5_3_C1 = "-- Not Available --";
                    string q5_3_C2 = "-- Not Available --";
                    string q5_3_C3 = "-- Not Available --";
                    string q5_3_C4 = "-- Not Available --";
                    string q5_3_C5 = "-- Not Available --";
                    string q5_3_C6 = "-- Not Available --";
                    string q5_3_C7 = "-- Not Available --";
                    string q5_3_C8 = "-- Not Available --";
                    string q5_3_C9 = "-- Not Available --";
                    string q5_3_C10 = "-- Not Available --";
                    string q5_3_C11 = "-- Not Available --";
                    string q5_4_C1 = "-- Not Available --";
                    string q5_4_C2 = "-- Not Available --";
                    string q5_4_C3 = "-- Not Available --";
                    string q5_4_C4 = "-- Not Available --";
                    string q5_4_C5 = "-- Not Available --";
                    string q5_4_C6 = "-- Not Available --";
                    string q5_4_C7 = "-- Not Available --";
                    string q5_4_C8 = "-- Not Available --";
                    string q5_4_C9 = "-- Not Available --";
                    string q5_4_C10 = "-- Not Available --";
                    string q5_4_C11 = "-- Not Available --";

                    foreach (var variable in spssDataset.Variables)
                    {
                        foreach (string spss_v in spss_variable_name)
                        {
                            if (variable.Name.Equals(spss_v))
                            {
                                variable_name = variable.Name;
                                switch (variable_name)
                                {
                                    case "Respondent_Serial":
                                        {
                                            u_id = Convert.ToString(record.GetValue(variable));
                                            userID = find_UserId(SurveyID, SURVEY_PERIOD, u_id);
                                            //userID = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "rq7":
                                        {
                                            Gender = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "rq8":
                                        {
                                            MaritalStatus = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16_2":
                                        {
                                            Occupation = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "CENTRE":
                                        {
                                            Location = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "rq6P":
                                        {
                                            AgeGroup = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16_1":
                                        {
                                            Education = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "Newsec":
                                        {
                                            SEC = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "WAVE":
                                        {
                                            Period = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q1_1":
                                        {
                                            BrTom = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q1_2_1":
                                        {
                                            BrSpont_Maggi = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q1_2_2":
                                        {
                                            BrSpont_Yippee = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q1_2_3":
                                        {
                                            BrSpont_Top_Ramen = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q1_2_4":
                                        {
                                            BrSpont_Biryanz_BiryaniNoodle = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q1_2_5":
                                        {
                                            BrSpont_Wai_Wai = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q1_2_6":
                                        {
                                            BrSpont_Chings = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q1_2_7":
                                        {
                                            BrSpont_Joymee = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q1_2_8":
                                        {
                                            BrSpont_Knorr = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q1_2_16":
                                        {
                                            BrSpont_Patanjali = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q1_2_19":
                                        {
                                            BrSpont_A_M = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q3_2_1":
                                        {
                                            BrAid_Maggi = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q3_2_2":
                                        {
                                            BrAid_Yippee = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q3_2_3":
                                        {
                                            BrAid_Top_Ramen = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q3_2_4":
                                        {
                                            BrAid_Biryanz_BiryaniNoodle = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q3_2_5":
                                        {
                                            BrAid_Wai_Wai = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q3_2_6":
                                        {
                                            BrAid_Chings = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q3_2_7":
                                        {
                                            BrAid_Joymee = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q3_2_8":
                                        {
                                            BrAid_Knorr = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q3_2_16":
                                        {
                                            BrAid_Patanjali = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q3_2_19":
                                        {
                                            BrAid_A_M = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q2_1":
                                        {
                                            AdTom = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q2_2_1":
                                        {
                                            AdSpont_Maggi = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q2_2_2":
                                        {
                                            AdSpont_Yippee = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q2_2_3":
                                        {
                                            AdSpont_Top_Ramen = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q2_2_4":
                                        {
                                            AdSpont_Biryanz_BiryaniNoodle = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q2_2_5":
                                        {
                                            AdSpont_Wai_Wai = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q2_2_6":
                                        {
                                            AdSpont_Chings = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q2_2_7":
                                        {
                                            AdSpont_Joymee = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q2_2_8":
                                        {
                                            AdSpont_Knorr = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q2_2_16":
                                        {
                                            AdSpont_Patanjali = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q2_2_19":
                                        {
                                            AdSpont_A_M = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_01":
                                        {
                                            EverCons_Maggi = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_02":
                                        {
                                            EverCons_Yippee = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_03":
                                        {
                                            EverCons_Top_Ramen = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_04":
                                        {
                                            EverCons_Biryanz_BiryaniNoodle = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_05":
                                        {
                                            EverCons_Wai_Wai = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_06":
                                        {
                                            EverCons_Chings = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_07":
                                        {
                                            EverCons_Joymee = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_08":
                                        {
                                            EverCons_Knorr = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_16":
                                        {
                                            EverCons_Patanjali = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_19":
                                        {
                                            EverCons_A_M = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_1_1":
                                        {
                                            ConsL6M_Maggi = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_1_2":
                                        {
                                            ConsL6M_Yippee = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_1_3":
                                        {
                                            ConsL6M_Top_Ramen = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_1_4":
                                        {
                                            ConsL6M_Biryanz_BiryaniNoodle = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_1_5":
                                        {
                                            ConsL6M_Wai_Wai = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_1_6":
                                        {
                                            ConsL6M_Chings = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_1_7":
                                        {
                                            ConsL6M_Joymee = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_1_8":
                                        {
                                            ConsL6M_Knorr = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_1_16":
                                        {
                                            ConsL6M_Patanjali = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_1_19":
                                        {
                                            ConsL6M_A_M = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_2_1":
                                        {
                                            ConsL3M_Maggi = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_2_2":
                                        {
                                            ConsL3M_Yippee = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_2_3":
                                        {
                                            ConsL3M_Top_Ramen = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_2_4":
                                        {
                                            ConsL3M_Biryanz_BiryaniNoodle = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_2_5":
                                        {
                                            ConsL3M_Wai_Wai = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_2_6":
                                        {
                                            ConsL3M_Chings = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_2_7":
                                        {
                                            ConsL3M_Joymee = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_2_8":
                                        {
                                            ConsL3M_Knorr = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_2_16":
                                        {
                                            ConsL3M_Patanjali = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_2_19":
                                        {
                                            ConsL3M_A_M = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_3_1":
                                        {
                                            ConsL1M_Maggi = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_3_2":
                                        {
                                            ConsL1M_Yippee = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_3_3":
                                        {
                                            ConsL1M_Top_Ramen = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_3_4":
                                        {
                                            ConsL1M_Biryanz_BiryaniNoodle = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_3_5":
                                        {
                                            ConsL1M_Wai_Wai = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_3_6":
                                        {
                                            ConsL1M_Chings = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_3_7":
                                        {
                                            ConsL1M_Joymee = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_3_8":
                                        {
                                            ConsL1M_Knorr = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_3_16":
                                        {
                                            ConsL1M_Patanjali = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_3_19":
                                        {
                                            ConsL1M_A_M = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4_1":
                                        {
                                            ConsL1W_Maggi = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4_2":
                                        {
                                            ConsL1W_Yippee = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4_3":
                                        {
                                            ConsL1W_Top_Ramen = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4_4":
                                        {
                                            ConsL1W_Biryanz_BiryaniNoodle = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4_5":
                                        {
                                            ConsL1W_Wai_Wai = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4_6":
                                        {
                                            ConsL1W_Chings = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4_7":
                                        {
                                            ConsL1W_Joymee = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4_8":
                                        {
                                            ConsL1W_Knorr = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4_16":
                                        {
                                            ConsL1W_Patanjali = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4_19":
                                        {
                                            ConsL1W_A_M = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4a_1":
                                        {
                                            RegCons_Maggi = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4a_2":
                                        {
                                            RegCons_Yippee = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4a_3":
                                        {
                                            RegCons_Top_Ramen = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4a_4":
                                        {
                                            RegCons_Biryanz_BiryaniNoodle = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4a_5":
                                        {
                                            RegCons_Wai_Wai = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4a_6":
                                        {
                                            RegCons_Chings = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4a_7":
                                        {
                                            RegCons_Joymee = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4a_8":
                                        {
                                            RegCons_Knorr = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4a_16":
                                        {
                                            RegCons_Patanjali = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4a_19":
                                        {
                                            RegCons_A_M = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4b_1":
                                        {
                                            RegConsKids_Maggi = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4b_2":
                                        {
                                            RegConsKids_Yippee = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4b_3":
                                        {
                                            RegConsKids_Top_Ramen = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4b_4":
                                        {
                                            RegConsKids_Biryanz_BiryaniNoodle = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4b_5":
                                        {
                                            RegConsKids_Wai_Wai = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4b_6":
                                        {
                                            RegConsKids_Chings = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4b_7":
                                        {
                                            RegConsKids_Joymee = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4b_8":
                                        {
                                            RegConsKids_Knorr = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4b_16":
                                        {
                                            RegConsKids_Patanjali = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_4b_19":
                                        {
                                            RegConsKids_A_M = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_5a":
                                        {
                                            Bumo = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_5b":
                                        {
                                            Bumo_Kids = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_6":
                                        {
                                            FavBrand = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q4_7":
                                        {
                                            Likely_Cons = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q10_3":
                                        {
                                            Likelihood_Pur_Biriyanz = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q11_6":
                                        {
                                            Noodle_likeably_Biriyanz = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q11_8":
                                        {
                                            Noodle_kids_likeably_Biriyanz = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q12":
                                        {
                                            Pur_Likeability_Biriyanz = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q12_3":
                                        {
                                            Cons_P1W_BiriyanzNoodles = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q15_5_2":
                                        {
                                            PackSize_Reg_Buy = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "mq15_7":
                                        {
                                            Freq_Noodle_Pur = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_1_C1":
                                        {
                                            q5_1_C1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_1_C2":
                                        {
                                            q5_1_C2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_1_C3":
                                        {
                                            q5_1_C3 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_1_C4":
                                        {
                                            q5_1_C4 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_1_C5":
                                        {
                                            q5_1_C5 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_1_C6":
                                        {
                                            q5_1_C6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_1_C7":
                                        {
                                            q5_1_C7 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_1_C8":
                                        {
                                            q5_1_C8 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_1_C9":
                                        {
                                            q5_1_C9 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_1_C10":
                                        {
                                            q5_1_C10 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_1_C11":
                                        {
                                            q5_1_C11 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_2_C1":
                                        {
                                            q5_2_C1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_2_C2":
                                        {
                                            q5_2_C2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_2_C3":
                                        {
                                            q5_2_C3 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_2_C4":
                                        {
                                            q5_2_C4 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_2_C5":
                                        {
                                            q5_2_C5 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_2_C6":
                                        {
                                            q5_2_C6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_2_C7":
                                        {
                                            q5_2_C7 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_2_C8":
                                        {
                                            q5_2_C8 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_2_C9":
                                        {
                                            q5_2_C9 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_2_C10":
                                        {
                                            q5_2_C10 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_2_C11":
                                        {
                                            q5_2_C11 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_3_C1":
                                        {
                                            q5_3_C1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_3_C2":
                                        {
                                            q5_3_C2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_3_C3":
                                        {
                                            q5_3_C3 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_3_C4":
                                        {
                                            q5_3_C4 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_3_C5":
                                        {
                                            q5_3_C5 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_3_C6":
                                        {
                                            q5_3_C6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_3_C7":
                                        {
                                            q5_3_C7 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_3_C8":
                                        {
                                            q5_3_C8 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_3_C9":
                                        {
                                            q5_3_C9 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_3_C10":
                                        {
                                            q5_3_C10 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_3_C11":
                                        {
                                            q5_3_C11 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_4_C1":
                                        {
                                            q5_4_C1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_4_C2":
                                        {
                                            q5_4_C2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_4_C3":
                                        {
                                            q5_4_C3 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_4_C4":
                                        {
                                            q5_4_C4 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_4_C5":
                                        {
                                            q5_4_C5 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_4_C6":
                                        {
                                            q5_4_C6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_4_C7":
                                        {
                                            q5_4_C7 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_4_C8":
                                        {
                                            q5_4_C8 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_4_C9":
                                        {
                                            q5_4_C9 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_4_C10":
                                        {
                                            q5_4_C10 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5_4_C11":
                                        {
                                            q5_4_C11 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }

                                }
                            }
                        }
                    }

                    if (u_id != null)
                    {
                          iobj.insert_Dashboard_values(userID, Weight, country, SurveyID, Gender, MaritalStatus, SURVEY_PERIOD, Occupation, Location, AgeGroup, Education, SEC, Period, BrTom, BrSpont_Maggi, BrSpont_Yippee, BrSpont_Top_Ramen, BrSpont_Biryanz_BiryaniNoodle, BrSpont_Wai_Wai, BrSpont_Chings, BrSpont_Joymee, BrSpont_Knorr, BrSpont_Patanjali, BrSpont_A_M, BrAid_Maggi, BrAid_Yippee, BrAid_Top_Ramen, BrAid_Biryanz_BiryaniNoodle, BrAid_Wai_Wai, BrAid_Chings, BrAid_Joymee, BrAid_Knorr, BrAid_Patanjali, BrAid_A_M, AdTom, AdSpont_Maggi, AdSpont_Yippee, AdSpont_Top_Ramen, AdSpont_Biryanz_BiryaniNoodle, AdSpont_Wai_Wai, AdSpont_Chings, AdSpont_Joymee, AdSpont_Knorr, AdSpont_Patanjali, AdSpont_A_M, EverCons_Maggi, EverCons_Yippee, EverCons_Top_Ramen, EverCons_Biryanz_BiryaniNoodle, EverCons_Wai_Wai, EverCons_Chings, EverCons_Joymee, EverCons_Knorr, EverCons_Patanjali, EverCons_A_M, ConsL6M_Maggi, ConsL6M_Yippee, ConsL6M_Top_Ramen, ConsL6M_Biryanz_BiryaniNoodle, ConsL6M_Wai_Wai, ConsL6M_Chings, ConsL6M_Joymee, ConsL6M_Knorr, ConsL6M_Patanjali, ConsL6M_A_M, ConsL3M_Maggi, ConsL3M_Yippee, ConsL3M_Top_Ramen, ConsL3M_Biryanz_BiryaniNoodle, ConsL3M_Wai_Wai, ConsL3M_Chings, ConsL3M_Joymee, ConsL3M_Knorr, ConsL3M_Patanjali, ConsL3M_A_M, ConsL1M_Maggi, ConsL1M_Yippee, ConsL1M_Top_Ramen, ConsL1M_Biryanz_BiryaniNoodle, ConsL1M_Wai_Wai, ConsL1M_Chings, ConsL1M_Joymee, ConsL1M_Knorr, ConsL1M_Patanjali, ConsL1M_A_M, ConsL1W_Maggi, ConsL1W_Yippee, ConsL1W_Top_Ramen, ConsL1W_Biryanz_BiryaniNoodle, ConsL1W_Wai_Wai, ConsL1W_Chings, ConsL1W_Joymee, ConsL1W_Knorr, ConsL1W_Patanjali, ConsL1W_A_M, RegCons_Maggi, RegCons_Yippee, RegCons_Top_Ramen, RegCons_Biryanz_BiryaniNoodle, RegCons_Wai_Wai, RegCons_Chings, RegCons_Joymee, RegCons_Knorr, RegCons_Patanjali, RegCons_A_M, RegConsKids_Maggi, RegConsKids_Yippee, RegConsKids_Top_Ramen, RegConsKids_Biryanz_BiryaniNoodle, RegConsKids_Wai_Wai, RegConsKids_Chings, RegConsKids_Joymee, RegConsKids_Knorr, RegConsKids_Patanjali, RegConsKids_A_M, Bumo, Bumo_Kids, FavBrand, Likely_Cons, Likelihood_Pur_Biriyanz, Noodle_likeably_Biriyanz, Noodle_kids_likeably_Biriyanz, Pur_Likeability_Biriyanz, Cons_P1W_BiriyanzNoodles, PackSize_Reg_Buy, Freq_Noodle_Pur, q5_1_C1, q5_1_C2, q5_1_C3, q5_1_C4, q5_1_C5, q5_1_C6, q5_1_C7, q5_1_C8, q5_1_C9, q5_1_C10, q5_1_C11, q5_2_C1, q5_2_C2, q5_2_C3, q5_2_C4, q5_2_C5, q5_2_C6, q5_2_C7, q5_2_C8, q5_2_C9, q5_2_C10, q5_2_C11, q5_3_C1, q5_3_C2, q5_3_C3, q5_3_C4, q5_3_C5, q5_3_C6, q5_3_C7, q5_3_C8, q5_3_C9, q5_3_C10, q5_3_C11, q5_4_C1, q5_4_C2, q5_4_C3, q5_4_C4, q5_4_C5, q5_4_C6, q5_4_C7, q5_4_C8, q5_4_C9, q5_4_C10, q5_4_C11);


                    }
                }
            }
        }

        private static string find_UserId(int SurveyID, string SURVEY_PERIOD, string u_id)
        {
            string sum = "";
            string[] date = SURVEY_PERIOD.Split('-');
            foreach (string d in date)
            {
                sum = sum + d;

            }
            return u_id + SurveyID + sum;
        }
    
     }

        class InsertIndNoodles

       {
        SqlConnection connection = new SqlConnection("Data Source=52.74.59.117;Initial Catalog=ClueboxMobile;Persist Security Info=True;User ID=sa;Password=ClueBox123*;");
        internal void insert_Dashboard_variable_values(string VARIABLE_NAME, string VARIABLE_NAME_SUB_NAME, string VARIABLE_ID, string VARIABLE_VALUE, string VARIABLE_NAME_QUESTION, int SurveyID, string country, string BASE_VARIABLE_NAME, string SURVEY_PERIOD)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO DashboardSPS_Variable_Values (VARIABLE_NAME,VARIABLE_NAME_SUB_NAME,VARIABLE_ID,VARIABLE_VALUE,VARIABLE_NAME_QUESTION,SURVEY_ID,SURVEY_country,BASE_VARIABLE_NAME,SURVEY_PERIOD) " + "VALUES('" + VARIABLE_NAME + "','" + VARIABLE_NAME_SUB_NAME + "','" + VARIABLE_ID + "','" + VARIABLE_VALUE.Replace("'", "''") + "','" + VARIABLE_NAME_QUESTION + "','" + SurveyID + "','" + country + "','" + BASE_VARIABLE_NAME + "','" + SURVEY_PERIOD + "')", connection);
            try
            {

                connection.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Dashboard variable values inserted successfully");

                connection.Close();



            }
            catch (Exception)
            {

                Console.WriteLine("Exception occured");
                Console.ReadLine();
            }
        }


        internal void insert_Dashboard_values(string userID, decimal Weight, string country, int SurveyID, string Gender, string MaritalStatus, string SURVEY_PERIOD, string Occupation, string Location, string AgeGroup, string Education, string SEC, string Period, string BrTom, string BrSpont_Maggi, string BrSpont_Yippee, string BrSpont_Top_Ramen, string BrSpont_Biryanz_BiryaniNoodle, string BrSpont_Wai_Wai, string BrSpont_Chings, string BrSpont_Joymee, string BrSpont_Knorr, string BrSpont_Patanjali, string BrSpont_A_M, string BrAid_Maggi, string BrAid_Yippee, string BrAid_Top_Ramen, string BrAid_Biryanz_BiryaniNoodle, string BrAid_Wai_Wai, string BrAid_Chings, string BrAid_Joymee, string BrAid_Knorr, string BrAid_Patanjali, string BrAid_A_M, string AdTom, string AdSpont_Maggi, string AdSpont_Yippee, string AdSpont_Top_Ramen, string AdSpont_Biryanz_BiryaniNoodle, string AdSpont_Wai_Wai, string AdSpont_Chings, string AdSpont_Joymee, string AdSpont_Knorr, string AdSpont_Patanjali, string AdSpont_A_M, string EverCons_Maggi, string EverCons_Yippee, string EverCons_Top_Ramen, string EverCons_Biryanz_BiryaniNoodle, string EverCons_Wai_Wai, string EverCons_Chings, string EverCons_Joymee, string EverCons_Knorr, string EverCons_Patanjali, string EverCons_A_M, string ConsL6M_Maggi, string ConsL6M_Yippee, string ConsL6M_Top_Ramen, string ConsL6M_Biryanz_BiryaniNoodle, string ConsL6M_Wai_Wai, string ConsL6M_Chings, string ConsL6M_Joymee, string ConsL6M_Knorr, string ConsL6M_Patanjali, string ConsL6M_A_M, string ConsL3M_Maggi, string ConsL3M_Yippee, string ConsL3M_Top_Ramen, string ConsL3M_Biryanz_BiryaniNoodle, string ConsL3M_Wai_Wai, string ConsL3M_Chings, string ConsL3M_Joymee, string ConsL3M_Knorr, string ConsL3M_Patanjali, string ConsL3M_A_M, string ConsL1M_Maggi, string ConsL1M_Yippee, string ConsL1M_Top_Ramen, string ConsL1M_Biryanz_BiryaniNoodle, string ConsL1M_Wai_Wai, string ConsL1M_Chings, string ConsL1M_Joymee, string ConsL1M_Knorr, string ConsL1M_Patanjali, string ConsL1M_A_M, string ConsL1W_Maggi, string ConsL1W_Yippee, string ConsL1W_Top_Ramen, string ConsL1W_Biryanz_BiryaniNoodle, string ConsL1W_Wai_Wai, string ConsL1W_Chings, string ConsL1W_Joymee, string ConsL1W_Knorr, string ConsL1W_Patanjali, string ConsL1W_A_M, string RegCons_Maggi, string RegCons_Yippee, string RegCons_Top_Ramen, string RegCons_Biryanz_BiryaniNoodle, string RegCons_Wai_Wai, string RegCons_Chings, string RegCons_Joymee, string RegCons_Knorr, string RegCons_Patanjali, string RegCons_A_M, string RegConsKids_Maggi, string RegConsKids_Yippee, string RegConsKids_Top_Ramen, string RegConsKids_Biryanz_BiryaniNoodle, string RegConsKids_Wai_Wai, string RegConsKids_Chings, string RegConsKids_Joymee, string RegConsKids_Knorr, string RegConsKids_Patanjali, string RegConsKids_A_M, string Bumo, string Bumo_Kids, string FavBrand, string Likely_Cons, string Likelihood_Pur_Biriyanz, string Noodle_likeably_Biriyanz, string Noodle_kids_likeably_Biriyanz, string Pur_Likeability_Biriyanz, string Cons_P1W_BiriyanzNoodles, string PackSize_Reg_Buy, string Freq_Noodle_Pur, string q5_1_C1, string q5_1_C2, string q5_1_C3, string q5_1_C4, string q5_1_C5, string q5_1_C6, string q5_1_C7, string q5_1_C8, string q5_1_C9, string q5_1_C10, string q5_1_C11, string q5_2_C1, string q5_2_C2, string q5_2_C3, string q5_2_C4, string q5_2_C5, string q5_2_C6, string q5_2_C7, string q5_2_C8, string q5_2_C9, string q5_2_C10, string q5_2_C11, string q5_3_C1, string q5_3_C2, string q5_3_C3, string q5_3_C4, string q5_3_C5, string q5_3_C6, string q5_3_C7, string q5_3_C8, string q5_3_C9, string q5_3_C10, string q5_3_C11, string q5_4_C1, string q5_4_C2, string q5_4_C3, string q5_4_C4, string q5_4_C5, string q5_4_C6, string q5_4_C7, string q5_4_C8, string q5_4_C9, string q5_4_C10, string q5_4_C11)
        {
            int i;
            connection.Open();
            //SqlConnection connection = new SqlConnection("Data Source=52.74.59.117;Initial Catalog=ClueboxMobile;Persist Security Info=True;User ID=sa;Password=ClueBox123*;");
            SqlCommand cmd = new SqlCommand("INSERT INTO DashboardFlat_IndiaNoodles_temp (UserID,Country,SurveyID,Gender,MaritalStatus,AttendedOn,Weight,Occupation,Location,AgeGroup,Education,SEC,Period,BrTom,BrSpont_Maggi,BrSpont_Yippee,BrSpont_Top_Ramen,BrSpont_Biryanz_BiryaniNoodle,BrSpont_Wai_Wai,BrSpont_Chings,BrSpont_Joymee,BrSpont_Knorr,BrSpont_Patanjali,BrSpont_A_M,BrAid_Maggi,BrAid_Yippee,BrAid_Top_Ramen,BrAid_Biryanz_BiryaniNoodle,BrAid_Wai_Wai,BrAid_Chings,BrAid_Joymee,BrAid_Knorr,BrAid_Patanjali,BrAid_A_M,AdTom,AdSpont_Maggi,AdSpont_Yippee,AdSpont_Top_Ramen,AdSpont_Biryanz_BiryaniNoodle,AdSpont_Wai_Wai,AdSpont_Chings,AdSpont_Joymee,AdSpont_Knorr,AdSpont_Patanjali,AdSpont_A_M,EverCons_Maggi,EverCons_Yippee,EverCons_Top_Ramen,EverCons_Biryanz_BiryaniNoodle,EverCons_Wai_Wai,EverCons_Chings,EverCons_Joymee,EverCons_Knorr,EverCons_Patanjali,EverCons_A_M,ConsL6M_Maggi,ConsL6M_Yippee,ConsL6M_Top_Ramen,ConsL6M_Biryanz_BiryaniNoodle,ConsL6M_Wai_Wai,ConsL6M_Chings,ConsL6M_Joymee,ConsL6M_Knorr,ConsL6M_Patanjali,ConsL6M_A_M,ConsL3M_Maggi,ConsL3M_Yippee,ConsL3M_Top_Ramen,ConsL3M_Biryanz_BiryaniNoodle,ConsL3M_Wai_Wai,ConsL3M_Chings,ConsL3M_Joymee,ConsL3M_Knorr,ConsL3M_Patanjali,ConsL3M_A_M,ConsL1M_Maggi,ConsL1M_Yippee,ConsL1M_Top_Ramen,ConsL1M_Biryanz_BiryaniNoodle,ConsL1M_Wai_Wai,ConsL1M_Chings,ConsL1M_Joymee,ConsL1M_Knorr,ConsL1M_Patanjali,ConsL1M_A_M,ConsL1W_Maggi,ConsL1W_Yippee,ConsL1W_Top_Ramen,ConsL1W_Biryanz_BiryaniNoodle,ConsL1W_Wai_Wai,ConsL1W_Chings,ConsL1W_Joymee,ConsL1W_Knorr,ConsL1W_Patanjali,ConsL1W_A_M,RegCons_Maggi,RegCons_Yippee,RegCons_Top_Ramen,RegCons_Biryanz_BiryaniNoodle,RegCons_Wai_Wai,RegCons_Chings,RegCons_Joymee,RegCons_Knorr,RegCons_Patanjali,RegCons_A_M,RegConsKids_Maggi,RegConsKids_Yippee,RegConsKids_Top_Ramen,RegConsKids_Biryanz_BiryaniNoodle,RegConsKids_Wai_Wai,RegConsKids_Chings,RegConsKids_Joymee,RegConsKids_Knorr,RegConsKids_Patanjali,RegConsKids_A_M,Bumo,Bumo_Kids,FavBrand,Likely_Cons,Likelihood_Pur_Biriyanz,Noodle_likeably_Biriyanz,Noodle_kids_likeably_Biriyanz,Pur_Likeability_Biriyanz,Cons_P1W_BiriyanzNoodles,PackSize_Reg_Buy,Freq_Noodle_Pur,q5_1_C1,q5_1_C2,q5_1_C3,q5_1_C4,q5_1_C5,q5_1_C6,q5_1_C7,q5_1_C8,q5_1_C9,q5_1_C10,q5_1_C11,q5_2_C1,q5_2_C2,q5_2_C3,q5_2_C4,q5_2_C5,q5_2_C6,q5_2_C7,q5_2_C8,q5_2_C9,q5_2_C10,q5_2_C11,q5_3_C1,q5_3_C2,q5_3_C3,q5_3_C4,q5_3_C5,q5_3_C6,q5_3_C7,q5_3_C8,q5_3_C9,q5_3_C10,q5_3_C11,q5_4_C1,q5_4_C2,q5_4_C3,q5_4_C4,q5_4_C5,q5_4_C6,q5_4_C7,q5_4_C8,q5_4_C9,q5_4_C10,q5_4_C11) " + "VALUES('" + userID + "','" + country + "','" + SurveyID + "','" + Gender + "','" + MaritalStatus + "','" + SURVEY_PERIOD + "','" + Weight + "','" + Occupation + "','" + Location + "','" + AgeGroup + "','" + Education + "','" + SEC + "','" + Period + "','" + BrTom + "','" + BrSpont_Maggi + "','" + BrSpont_Yippee + "','" + BrSpont_Top_Ramen + "','" + BrSpont_Biryanz_BiryaniNoodle + "','" + BrSpont_Wai_Wai + "','" + BrSpont_Chings + "','" + BrSpont_Joymee + "','" + BrSpont_Knorr + "','" + BrSpont_Patanjali + "','" + BrSpont_A_M + "','" + BrAid_Maggi + "','" + BrAid_Yippee + "','" + BrAid_Top_Ramen + "','" + BrAid_Biryanz_BiryaniNoodle + "','" + BrAid_Wai_Wai + "','" + BrAid_Chings + "','" + BrAid_Joymee + "','" + BrAid_Knorr + "','" + BrAid_Patanjali + "','" + BrAid_A_M + "','" + AdTom + "','" + AdSpont_Maggi + "','" + AdSpont_Yippee + "','" + AdSpont_Top_Ramen + "','" + AdSpont_Biryanz_BiryaniNoodle + "','" + AdSpont_Wai_Wai + "','" + AdSpont_Chings + "','" + AdSpont_Joymee + "','" + AdSpont_Knorr + "','" + AdSpont_Patanjali + "','" + AdSpont_A_M + "','" + EverCons_Maggi + "','" + EverCons_Yippee + "','" + EverCons_Top_Ramen + "','" + EverCons_Biryanz_BiryaniNoodle + "','" + EverCons_Wai_Wai + "','" + EverCons_Chings + "','" + EverCons_Joymee + "','" + EverCons_Knorr + "','" + EverCons_Patanjali + "','" + EverCons_A_M + "','" + ConsL6M_Maggi + "','" + ConsL6M_Yippee + "','" + ConsL6M_Top_Ramen + "','" + ConsL6M_Biryanz_BiryaniNoodle + "','" + ConsL6M_Wai_Wai + "','" + ConsL6M_Chings + "','" + ConsL6M_Joymee + "','" + ConsL6M_Knorr + "','" + ConsL6M_Patanjali + "','" + ConsL6M_A_M + "','" + ConsL3M_Maggi + "','" + ConsL3M_Yippee + "','" + ConsL3M_Top_Ramen + "','" + ConsL3M_Biryanz_BiryaniNoodle + "','" + ConsL3M_Wai_Wai + "','" + ConsL3M_Chings + "','" + ConsL3M_Joymee + "','" + ConsL3M_Knorr + "','" + ConsL3M_Patanjali + "','" + ConsL3M_A_M + "','" + ConsL1M_Maggi + "','" + ConsL1M_Yippee + "','" + ConsL1M_Top_Ramen + "','" + ConsL1M_Biryanz_BiryaniNoodle + "','" + ConsL1M_Wai_Wai + "','" + ConsL1M_Chings + "','" + ConsL1M_Joymee + "','" + ConsL1M_Knorr + "','" + ConsL1M_Patanjali + "','" + ConsL1M_A_M + "','" + ConsL1W_Maggi + "','" + ConsL1W_Yippee + "','" + ConsL1W_Top_Ramen + "','" + ConsL1W_Biryanz_BiryaniNoodle + "','" + ConsL1W_Wai_Wai + "','" + ConsL1W_Chings + "','" + ConsL1W_Joymee + "','" + ConsL1W_Knorr + "','" + ConsL1W_Patanjali + "','" + ConsL1W_A_M + "','" + RegCons_Maggi + "','" + RegCons_Yippee + "','" + RegCons_Top_Ramen + "','" + RegCons_Biryanz_BiryaniNoodle + "','" + RegCons_Wai_Wai + "','" + RegCons_Chings + "','" + RegCons_Joymee + "','" + RegCons_Knorr + "','" + RegCons_Patanjali + "','" + RegCons_A_M + "','" + RegConsKids_Maggi + "','" + RegConsKids_Yippee + "','" + RegConsKids_Top_Ramen + "','" + RegConsKids_Biryanz_BiryaniNoodle + "','" + RegConsKids_Wai_Wai + "','" + RegConsKids_Chings + "','" + RegConsKids_Joymee + "','" + RegConsKids_Knorr + "','" + RegConsKids_Patanjali + "','" + RegConsKids_A_M + "','" + Bumo + "','" + Bumo_Kids + "','" + FavBrand + "','" + Likely_Cons + "','" + Likelihood_Pur_Biriyanz + "','" + Noodle_likeably_Biriyanz + "','" + Noodle_kids_likeably_Biriyanz + "','" + Pur_Likeability_Biriyanz + "','" + Cons_P1W_BiriyanzNoodles + "','" + PackSize_Reg_Buy + "','" + Freq_Noodle_Pur + "','" + q5_1_C1 + "','" + q5_1_C2 + "','" + q5_1_C3 + "','" + q5_1_C4 + "','" + q5_1_C5 + "','" + q5_1_C6 + "','" + q5_1_C7 + "','" + q5_1_C8 + "','" + q5_1_C9 + "','" + q5_1_C10 + "','" + q5_1_C11 + "','" + q5_2_C1 + "','" + q5_2_C2 + "','" + q5_2_C3 + "','" + q5_2_C4 + "','" + q5_2_C5 + "','" + q5_2_C6 + "','" + q5_2_C7 + "','" + q5_2_C8 + "','" + q5_2_C9 + "','" + q5_2_C10 + "','" + q5_2_C11 + "','" + q5_3_C1 + "','" + q5_3_C2 + "','" + q5_3_C3 + "','" + q5_3_C4 + "','" + q5_3_C5 + "','" + q5_3_C6 + "','" + q5_3_C7 + "','" + q5_3_C8 + "','" + q5_3_C9 + "','" + q5_3_C10 + "','" + q5_3_C11 + "','" + q5_4_C1 + "','" + q5_4_C2 + "','" + q5_4_C3 + "','" + q5_4_C4 + "','" + q5_4_C5 + "','" + q5_4_C6 + "','" + q5_4_C7 + "','" + q5_4_C8 + "','" + q5_4_C9 + "','" + q5_4_C10 + "','" + q5_4_C11 + "')", connection);
            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data inserted successfully");
                i = 1;
            }
            catch (Exception ex)
            {

                connection.Close();
                i = 0;
                Console.WriteLine("Exception occured" + ex.ToString());
                Console.WriteLine("Exception occured");

                Console.ReadLine();
            }
            connection.Close();
        }

        
    }
}

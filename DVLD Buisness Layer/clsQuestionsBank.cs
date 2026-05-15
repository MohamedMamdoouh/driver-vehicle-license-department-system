using System;
using System.Data;
using DVLD_DataAccess_Layer;

namespace DVLD_Buisness_Layer
{
    public class clsQuestionsBank
    {
        public static DataTable GenereateVisionTestQuestions(byte NumberOfEasyQuestions, byte NumberOfMediumQuestions, byte NumberOfHardQuestions)
        {
            try
            {
                return clsQuestionsBankData.GenerateTestQuestions(1, NumberOfEasyQuestions, NumberOfMediumQuestions, NumberOfHardQuestions);
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GenereateWrittenTestQuestions(byte NumberOfEasyQuestions, byte NumberOfMediumQuestions, byte NumberOfHardQuestions)
        {
            try
            {
                return clsQuestionsBankData.GenerateTestQuestions(2, NumberOfEasyQuestions, NumberOfMediumQuestions, NumberOfHardQuestions);
            }
            catch
            {
                return null;
            }
        }
    }
}

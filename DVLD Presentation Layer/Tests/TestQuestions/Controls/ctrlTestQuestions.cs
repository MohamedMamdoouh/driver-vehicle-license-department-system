using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using DVLD_Project.Global;

namespace DVLD_Project.Tests.TestQuestions.Controls
{
    public partial class ctrlTestQuestions : UserControl
    {
        public ctrlTestQuestions()
        {
            InitializeComponent();
        }

        public clsTestType.enTestType TestTypeID { get; set; }
        public int TestAppointmentID { get; set; }

        private DataTable _dtTestQuestions;
        private bool _IsPassed = false;
        private short _CurrentIndex = 0;
        private short _PersonScore = 0;
        private short _TestTotalScore = 0;
        private short _RemainingTimerSeconds = 0;
        private clsTestType _TestTypeInfo;
        private clsTestAppointment _TestAppointmentInfo;
        private clsTests _TestInfo;

        private void _LoadTestInfoData()
        {
            _TestAppointmentInfo = clsTestAppointment.GetTestAppointmentInfoByID(TestAppointmentID);

            if (_TestAppointmentInfo == null)
                return;

            lblLDL_ID.Text = _TestAppointmentInfo.LDLA_ID.ToString();
            lblLicenseClass.Text = clsLocalLicenseClass.FindByLDLA_ID(_TestAppointmentInfo.LDLA_ID).LicenseClassName;
            lblApplicantName.Text = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationByLDLA_ID(_TestAppointmentInfo.LDLA_ID).Person.FullName;
            lblTrials.Text = clsTests.GetTotalTrialsPerTest(_TestAppointmentInfo.LDLA_ID, _TestAppointmentInfo.TestTypeID).ToString();
            lblDate.Text = clsFormat.ToShortDateString(_TestAppointmentInfo.AppointmentDate);
            lblFees.Text = clsFormat.ToShortMoneyString(_TestAppointmentInfo.PaidFees);
            lblNoOfQuestions.Text = _dtTestQuestions.Rows.Count.ToString();
            lblPassingPercentage.Text = _TestTypeInfo.PassingPercentage.ToString() + "%";
        }

        private void ctrlTestQuestions_Load(object sender, EventArgs e)
        {
            _TestTypeInfo = clsTestType.Find(TestTypeID);

            if (_TestTypeInfo == null)
                return;

            _RemainingTimerSeconds = (short)(_TestTypeInfo.DurationMinutes * 60);
            TestTimer.Start();
            _UpdateTimerLablel();

            btnNext.Visible = false;
            btnPrevious.Visible = false;
            btnSubmit.Visible = false;

            _HandleControlsVisibilty();

            _dtTestQuestions = new DataTable();

            switch (TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    _dtTestQuestions = clsQuestionsBank.GenereateVisionTestQuestions(10, 5, 5);
                    break;

                case clsTestType.enTestType.WrittenTest:
                    _dtTestQuestions = clsQuestionsBank.GenereateWrittenTestQuestions(10, 5, 5);
                    break;

                case clsTestType.enTestType.StreetTest:
                    MessageBox.Show("Error: You cannot assign street test to this control. Only vision and written test allowed",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this?.FindForm().Close();
                    return;
            }

            _UpdateQuestion();
            _dtTestQuestions.Columns.Add("PersonSelectedAnswer", typeof(char));
            _LoadTestInfoData();
        }

        private void _UpdateQuestion()
        {
            lblQuestionNoOfTotalNo.Text = $"Question {_CurrentIndex + 1} of {_dtTestQuestions.Rows.Count}";
            lblQuestionNo.Text = (_CurrentIndex + 1).ToString() + "-";
            var Row = _dtTestQuestions.Rows[_CurrentIndex];

            lblQuestionText.Text = Row["QuestionText"].ToString();
            rbChoiceA.Text = Row["ChoiceA"].ToString();
            rbChoiceB.Text = Row["ChoiceB"].ToString();
            rbChoiceC.Text = Row["ChoiceC"].ToString();
            rbChoiceD.Text = Row["ChoiceD"].ToString();

            rbChoiceA.Checked = false;
            rbChoiceB.Checked = false;
            rbChoiceC.Checked = false;
            rbChoiceD.Checked = false;
        }

        private void _RestorePersonSelectedAnswer()
        {
            var Row = _dtTestQuestions.Rows[_CurrentIndex];

            if (Row["PersonSelectedAnswer"] == DBNull.Value)
                return;

            char SelectedAnswer = (char)Row["PersonSelectedAnswer"];

            switch (SelectedAnswer)
            {
                case 'A':
                    rbChoiceA.Checked = true;
                    break;

                case 'B':
                    rbChoiceB.Checked = true;
                    break;

                case 'C':
                    rbChoiceC.Checked = true;
                    break;

                case 'D':
                    rbChoiceD.Checked = true;
                    break;
            }
        }

        private void _SavePersonSelectedAnswer()
        {
            var Row = _dtTestQuestions.Rows[_CurrentIndex];

            if (rbChoiceA.Checked)
                Row["PersonSelectedAnswer"] = 'A';

            else if (rbChoiceB.Checked)
                Row["PersonSelectedAnswer"] = 'B';

            else if (rbChoiceC.Checked)
                Row["PersonSelectedAnswer"] = 'C';

            else if (rbChoiceD.Checked)
                Row["PersonSelectedAnswer"] = 'D';
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!(rbChoiceA.Checked || rbChoiceB.Checked || rbChoiceC.Checked || rbChoiceD.Checked))
            {
                MessageBox.Show("You must choose an answer before moving forward to the next question",
                                "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _SavePersonSelectedAnswer();
            _CurrentIndex++;
            _HandleControlsVisibilty();
            _UpdateQuestion();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            _SavePersonSelectedAnswer();
            _CurrentIndex--;
            _HandleControlsVisibilty();
            _UpdateQuestion();
            _RestorePersonSelectedAnswer();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit the test? Your current score will be saved and if you failed, " +
                                "you cannot re-enter the test again unless you make another retake test application, and pay fees",
                               "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            else
            {
                SaveResults();
            }
        }

        private void _HandleControlsVisibilty()
        {
            if (_CurrentIndex == 0)
            {
                btnSubmit.Visible = false;
                btnPrevious.Visible = false;
                btnNext.Visible = true;
            }

            else if (_CurrentIndex == _dtTestQuestions.Rows.Count - 1)
            {
                btnPrevious.Visible = true;
                btnSubmit.Visible = true;
                btnNext.Visible = false;
            }

            else
            {
                btnPrevious.Visible = true;
                btnSubmit.Visible = false;
                btnNext.Visible = true;
            }
        }

        private void TestTimer_Tick(object sender, EventArgs e)
        {
            _RemainingTimerSeconds--;

            if (_RemainingTimerSeconds == 0)
            {
                TestTimer.Stop();
                lblTimer.Text = "Time Up";
                MessageBox.Show("Your time is up. Your answers will be automatically submitted", "Time up",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                SaveResults();
            }

            else
            {
                _UpdateTimerLablel();
            }
        }

        private void _UpdateTimerLablel()
        {
            int Minutes = _RemainingTimerSeconds / 60;
            int Seconds = _RemainingTimerSeconds % 60;

            lblTimer.Text = $"{Minutes:D2}:{Seconds:D2}";
        }

        public void SaveResults()
        {
            TestTimer.Stop();

            foreach (DataRow Row in _dtTestQuestions.Rows)
            {
                _TestTotalScore += (byte)Row["QuestionGrade"];

                // Just in case person skipped a question
                if (Row["PersonSelectedAnswer"] == DBNull.Value)
                    continue;

                if ((char)Row["PersonSelectedAnswer"] == Row["CorrectAnswer"].ToString()[0])
                {
                    _PersonScore += (byte)Row["QuestionGrade"];
                }
            }

            if (_IsPassedTest())
            {
                _IsPassed = true;
                MessageBox.Show($"Congrats! You have successfully passed the test. Your score is {_PersonScore}/" +
                                $"{_TestTotalScore}, with percentage of {(float)((float)_PersonScore / _TestTotalScore) * 100:F2}%",
                                "Congrats", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                _IsPassed = false;
                MessageBox.Show($"Sorry, you did NOT pass the test. Your score is {_PersonScore}/" +
                               $"{_TestTotalScore}, with percentage of {(float)((float)_PersonScore / _TestTotalScore) * 100:F2}%",
                               "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            _TestInfo = new clsTests();

            _TestInfo.TestAppointmentID = _TestAppointmentInfo.TestAppointmentID;
            _TestInfo.TestResult = _IsPassed;
            _TestInfo.Notes = string.Empty;
            _TestInfo.CreatedByUserID = clsUtil.CurrentUser.UserID;
            _TestInfo.PersonTestScore = _PersonScore;
            _TestInfo.TestTotalScore = _TestTotalScore;

            if (!_TestInfo.AddNewTestResult())
            {
                MessageBox.Show("Cannot save the test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                this?.FindForm().Close();
            }
        }

        private bool _IsPassedTest()
        {
            // Person should score at least 70% of the test to pass
            float Result = (float)((float)_TestTypeInfo.PassingPercentage / 100) * _TestTotalScore;
            return (_PersonScore >= Result);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to submit?", "Confirm",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            SaveResults();
        }

        private void btnGoToQuestions_Click(object sender, EventArgs e)
        {
            tcTestQuestions.SelectedTab = tpTestQuestions;
        }
    }
}

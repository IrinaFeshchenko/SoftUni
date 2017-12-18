using System;
using System.Collections.Generic;
using System.Text;

namespace Teamwork.Common
{
    public class GlobalConstants
    {
        public const int UserNameMinLength = 2;
        public const int UserNameMaxLength = 100;

        public const int ProjectNameMinLength = 2;
        public const int ProjectNameMaxLength = 100;

        public const int AssessmentCommentMinLength = 10;
        public const int AssessmentGradeMinValue = 0;
        public const int AssessmentGradeMaxValue = 5;

        public const int GenericNameMaxLength = 100;

        public const int StudentNumberMaxLength = 12;

        public const string AdministratorRole = "Administrator";
        public const string TeacherRole = "Teacher";

        public const string TempDataSuccessMessageKey = "SuccessMessage";
        public const string TempDataErrorMessageKey = "ErrorMessage";

        public const int AdminUsersPageSize = 5;
        public const int TeacherCoursesPageSize = 5;
    }
}

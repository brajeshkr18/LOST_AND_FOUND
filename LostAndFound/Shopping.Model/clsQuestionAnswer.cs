using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Model
{
    public class clsQuestionAnswer
    {
        public long Id { get; set; }
        public string Question { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string Answer { get; set; }
        public string CorrectOption { get; set; }
        public bool IsActive { get; set; }
        public string CreateDate { get; set; }
        public string ModifiedDate { get; set; }
        public string CreateBy { get; set; }
        public string ModifiedBy { get; set; }
       
    }
}

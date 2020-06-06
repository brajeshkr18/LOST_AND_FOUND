using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.Model;
using Shopping.Data;
using BizBrolly.Util;

//using TelaCall.Models;

namespace Shopping.Business
{
    public class HomeBLL
    {
        
        public bool SendMailOnCallInCreation(string To, string Subject, string Body,string from,string CC, string BCC, bool enableSSl)
        {
            try
            {
                Emailer em = new Emailer();
                var IsSent = em.SendMail(To, Subject, Body, from, CC, BCC, enableSSl);
                return IsSent;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
        public List<clsFoundedPeople> GetFoundedPeople(int Id)
        {
            List<clsFoundedPeople> lstFoundedPeople = new List<clsFoundedPeople>();

             return lstFoundedPeople = (new HomeDAL()).GetFoundedPeople(Id);

        }
        public int SaveFoundPeolpeDetail(clsFoundedPeople objfoundedppl)
        {
            return (new HomeDAL()).SaveFoundPeolpeDetail(objfoundedppl);
        }
        public List<clsQuestionAnswer> GetQuestionAnswer()
        {
            List<clsQuestionAnswer> lstFoundedPeople = new List<clsQuestionAnswer>();

            return lstFoundedPeople = (new HomeDAL()).GetQuestionAnswer();

        }
    }
    
}

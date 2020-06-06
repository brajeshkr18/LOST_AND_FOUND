using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.Model;
using Shopping.Data.Entity;
using System.Data.Objects;
using System.Data.Objects.SqlClient;
//using TelaCall.Models;

namespace Shopping.Data
{
    public class HomeDAL
    {
        public List<clsFoundedPeople> GetFoundedPeople(int Id)
        {
            using (var maincontext = new Entity.LostAndFindEntities())
            {
              
                List<clsFoundedPeople> lstFoundedPeople = new List<clsFoundedPeople>();
                var objgetFindpeopleDetail = maincontext.Web_GetFindpeopleDetail(Id).ToList();
                if (objgetFindpeopleDetail.Count() > 0)
                {
                    
                    foreach (var FindpeopleDetail in objgetFindpeopleDetail)
                    {
                        clsFoundedPeople objpeopleDetail = new clsFoundedPeople();
                        objpeopleDetail.FirstName = FindpeopleDetail.FirstName;
                        objpeopleDetail.LastName = FindpeopleDetail.LastName ;
                        objpeopleDetail.EmailId = FindpeopleDetail.EmailId;
                        objpeopleDetail.FindPeopleImage = FindpeopleDetail.FindPeopleImage;
                        objpeopleDetail.Phone = FindpeopleDetail.Phone;
                        objpeopleDetail.Latitude = FindpeopleDetail.Latitude;
                        objpeopleDetail.Longitude = FindpeopleDetail.Longitude;
                        objpeopleDetail.IsActive = FindpeopleDetail.IsActive;
                        objpeopleDetail.IsApproved = FindpeopleDetail.IsApproved;
                        objpeopleDetail.Address = FindpeopleDetail.Address;
                        objpeopleDetail.Id = FindpeopleDetail.id;
                        objpeopleDetail.FullAddress = FindpeopleDetail.FullAddress;
                        objpeopleDetail.City=FindpeopleDetail.City;
                        objpeopleDetail.State = FindpeopleDetail.State;
                        objpeopleDetail.Country = FindpeopleDetail.Country;
                        objpeopleDetail.Pincode = FindpeopleDetail.PinCode;
                        objpeopleDetail.LostOrFound = FindpeopleDetail.LostOrFound;
                        lstFoundedPeople.Add(objpeopleDetail);
                    }

                    return lstFoundedPeople;
                }

                return lstFoundedPeople;
            }
        }
        public int SaveFoundPeolpeDetail(clsFoundedPeople objfoundedppl)
        {
            using (var maincontext = new Entity.LostAndFindEntities())
            {
                var db_Result = maincontext.Web_SaveFindpeopleDetail(0,objfoundedppl.FirstName,objfoundedppl.LastName,
                    objfoundedppl.FindPeopleImage,objfoundedppl.Latitude,objfoundedppl.Longitude,objfoundedppl.EmailId,objfoundedppl.Phone,objfoundedppl.IsActive,objfoundedppl.IsApproved,objfoundedppl.UserId.ToString(),objfoundedppl.Address,objfoundedppl.FullAddress,objfoundedppl.City,objfoundedppl.State,objfoundedppl.Country,objfoundedppl.Pincode,objfoundedppl.LostOrFound).FirstOrDefault();
                return 1;
                //return db_Result.UserResult;
            }
        }
         public List<clsQuestionAnswer> GetQuestionAnswer()
        {
            using (var maincontext = new Entity.LostAndFindEntities())
            {
              
                List<clsQuestionAnswer> lstQuestionsAns = new List<clsQuestionAnswer>();
                var objgetobjQuestionsAnsDetail = maincontext.Web_GetAllQuestions().ToList();
                if (objgetobjQuestionsAnsDetail.Count() > 0)
                {
                    
                    foreach (var QuestionsAnsDetail in objgetobjQuestionsAnsDetail)
                    {
                        clsQuestionAnswer objQuestionsAns = new clsQuestionAnswer();
                        objQuestionsAns.Question = QuestionsAnsDetail.Question;
                        objQuestionsAns.OptionA = QuestionsAnsDetail.OptionA;
                        objQuestionsAns.OptionB = QuestionsAnsDetail.OptionB;
                        objQuestionsAns.OptionC = QuestionsAnsDetail.OptionC;
                        objQuestionsAns.OptionD = QuestionsAnsDetail.OptionD;
                        objQuestionsAns.Answer = QuestionsAnsDetail.Answer;
                        objQuestionsAns.CorrectOption = QuestionsAnsDetail.CorrectOption;
                        objQuestionsAns.IsActive = QuestionsAnsDetail.IsActive;
                        objQuestionsAns.Id = QuestionsAnsDetail.id;
                      //  objQuestionsAns.
                        lstQuestionsAns.Add(objQuestionsAns);
                    }

                    return lstQuestionsAns;
                }

                return lstQuestionsAns;
            }
        }
    }
}
        
    


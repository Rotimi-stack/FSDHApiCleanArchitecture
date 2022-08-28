using System;
using System.Collections.Generic;
using System.Text;

namespace FSDH.Application.Common.Models.FSDHIDENTITY
{
  public  class Responses
    {
    }

    public class GetDetailedInfoforAListofBVNResponse
    {
        public string responseCode { get; set; }
        public List<GetDetailedInfoforAListofBVN> validationResponses { get; set; }
    }
    public class GetDetailedInfoforAListofBVN
    {
        public string responseCode { get; set; }
        public string bvn { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string dateOfBirth { get; set; }
        public string registrationDate { get; set; }
        public string enrollmentBank { get; set; }
        public string enrollmentBranch { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string levelOfAccount { get; set; }
        public string lgaOfOrigin { get; set; }
        public string lgaOfResidence { get; set; }
        public string maritalStatus { get; set; }
        public string nin { get; set; }
        public string nameOnCard { get; set; }
        public string nationality { get; set; }
        public string phoneNumber1 { get; set; }
        public string phoneNumber2 { get; set; }
        public string residentialAddress { get; set; }
        public string stateOfOrigin { get; set; }
        public string stateOfResidence { get; set; }
        public string title { get; set; }
        public string watchListed { get; set; }
        public string base64Image { get; set; }
    }



    public class GetSingleBVNResponse
    {
        public string responseCode { get; set; }
        public string bvn { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string dateOfBirth { get; set; }
        public string registrationDate { get; set; }
        public string enrollmentBank { get; set; }
        public string enrollmentBranch { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string levelOfAccount { get; set; }
        public string lgaOfOrigin { get; set; }
        public string lgaOfResidence { get; set; }
        public string maritalStatus { get; set; }
        public string nin { get; set; }
        public string nameOnCard { get; set; }
        public string nationality { get; set; }
        public string phoneNumber1 { get; set; }
        public string phoneNumber2 { get; set; }
        public string residentialAddress { get; set; }
        public string stateOfOrigin { get; set; }
        public string stateOfResidence { get; set; }
        public string title { get; set; }
        public string watchListed { get; set; }
        public string base64Image { get; set; }
    }


    public class GetSingleBVNbyDAteResponses
    {
        public string responseCode { get; set; }
        public string bvn { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string dateOfBirth { get; set; }
        public string registrationDate { get; set; }
        public string enrollmentBank { get; set; }
        public string enrollmentBranch { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string levelOfAccount { get; set; }
        public string lgaOfOrigin { get; set; }
        public string lgaOfResidence { get; set; }
        public string maritalStatus { get; set; }
        public string nin { get; set; }
        public string nameOnCard { get; set; }
        public string nationality { get; set; }
        public string phoneNumber1 { get; set; }
        public string phoneNumber2 { get; set; }
        public string residentialAddress { get; set; }
        public string stateOfOrigin { get; set; }
        public string stateOfResidence { get; set; }
        public string title { get; set; }
        public string watchListed { get; set; }
        public string base64Image { get; set; }
    }




    public class GetSingleBVNbyOTPResponses
    {
        public string responseCode { get; set; }
        public string bvn { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string dateOfBirth { get; set; }
        public string registrationDate { get; set; }
        public string enrollmentBank { get; set; }
        public string enrollmentBranch { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string levelOfAccount { get; set; }
        public string lgaOfOrigin { get; set; }
        public string lgaOfResidence { get; set; }
        public string maritalStatus { get; set; }
        public string nin { get; set; }
        public string nameOnCard { get; set; }
        public string nationality { get; set; }
        public string phoneNumber1 { get; set; }
        public string phoneNumber2 { get; set; }
        public string residentialAddress { get; set; }
        public string stateOfOrigin { get; set; }
        public string stateOfResidence { get; set; }
        public string title { get; set; }
        public string watchListed { get; set; }
        public string base64Image { get; set; }
        public bool otpSentSuccessfully { get; set; }
        public string otpRecordReference { get; set; }
    }

    public class ValidateOTPResponses
    {

    }

    public class IsBVNWatchListedResponses
    {
        public string responseCode { get; set; }
        public string bvn { get; set; }
        public string bankCode { get; set; }
        public string category { get; set; }
        public string watchListed { get; set; }
    }





    public class VerifyMultipleBVNResponses
    {
        public string responseCode { get; set; }
        public List<VerifyMultipleBVN> validationResponses { get; set; }
    }
    public class VerifyMultipleBVN
    {
        public string responseCode { get; set; }
        public string bvn { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string dateOfBirth { get; set; }
        public string registrationDate { get; set; }
        public string enrollmentBank { get; set; }
        public string enrollmentBranch { get; set; }
        public string phoneNumber1 { get; set; }
        public string watchListed { get; set; }
    }







    public class VerifySingleBVN
    {
        public string responseCode { get; set; }
        public string bvn { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string dateOfBirth { get; set; }
        public string registrationDate { get; set; }
        public string enrollmentBank { get; set; }
        public string enrollmentBranch { get; set; }
        public string phoneNumber1 { get; set; }
        public string watchListed { get; set; }
    }

    public class VerifySingleBVNbyDate
    {
        public string responseCode { get; set; }
        public string bvn { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string dateOfBirth { get; set; }
        public string registrationDate { get; set; }
        public string enrollmentBank { get; set; }
        public string enrollmentBranch { get; set; }
        public string phoneNumber1 { get; set; }
        public string watchListed { get; set; }
    }
}

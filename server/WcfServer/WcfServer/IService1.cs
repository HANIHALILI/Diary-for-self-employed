using Model;
using System.Collections.Generic;
using System.ServiceModel;

namespace WcfServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //Add fanctions.
        [OperationContract]
        int AddCustomers(Customers c);
        [OperationContract]
        int AddSceduel(Sceduel c);
        [OperationContract]
        int AddPersonalMeeting(PersonalMeeting p);
        [OperationContract]
        int AddCourse(Course c);

        [OperationContract]
        int AddCity(Cities c);

        [OperationContract]
        int AddPersonToCourse(RegistrationForCourse rf);

        [OperationContract]
        int AddCourseMeeting(CourseMeeting cm);

        [OperationContract]
        int AddTypeCourse(TypeCourse tc);
        [OperationContract]
        int AddTypeAdvice(TypeAdvice ta);
        //Update fanctions.

        [OperationContract]
        int UpdateCustomers(Customers c);
        [OperationContract]
        int UpdateSceduel(Sceduel c);
        [OperationContract]
        int UpdatePersonalMeeting(PersonalMeeting p);
        [OperationContract]
        int UpdateCourse(Course c);

        [OperationContract]
        int UpdateCities(Cities c);
        [OperationContract]
        int UpdateCourseMeeting(CourseMeeting cm);
        [OperationContract]
        int UpdateRegistrationToCourse(RegistrationForCourse rc);
        [OperationContract]
        int UpdateTypeCurse(TypeCourse tc);
        [OperationContract]
        int UpdateTypeAdvice(TypeAdvice ta);
       
        //Delete fanctions.
        [OperationContract]
        int DeleteCustomers(Customers c);
        [OperationContract]
        int DeleteSceduel(Sceduel c);
        [OperationContract]
        int DeletePersonalMeeting(PersonalMeeting p);
        [OperationContract]
        int DeleteCourse(Course c);
        [OperationContract]
        int DeleteCity(Cities c);
        [OperationContract]
        int DeleteRegistrationToCourse(RegistrationForCourse rfc);
        [OperationContract]
        int DeleteTypeCourse(TypeCourse tc);
        [OperationContract]
        int DeleteTypeAdvice(TypeAdvice ta);
        [OperationContract]
        int DeleteCourseMeeting(CourseMeeting cm);

        //GetCode fanctions.
        [OperationContract]
        int GetCodeToCustomers();
        [OperationContract]
        int GetCodeToCourseMeeting();
        [OperationContract]
        int GetCodeToSceduel();
        [OperationContract]
        int GetCodeToPersonalMeeting();
        [OperationContract]
        int GetCodeToCourse();

        [OperationContract]
        int GetCodeToCity();

        [OperationContract]
        int GetCodeToTypeCourse();
        [OperationContract]
        int GetCodeToTypeAdvice();


        //Get fanctions.
        [OperationContract]
        List<PersonalMeeting> GetPersonalMeetingList();
        [OperationContract]
        List<Sceduel> GetSceduelList();
        [OperationContract]
        List<Course> GetCourseList();
        [OperationContract]
        List<Customers> GetCustomersList();
        [OperationContract]
        List<Cities> GetCitiesList();
        [OperationContract]
        List<RegistrationForCourse> GetRegistrationToCourseList();

        [OperationContract]
        List<CourseMeeting> GetCourseMeetingList();

        [OperationContract]
        List<TypeAdvice> GetTypeAdviceList();
        [OperationContract]
        List<TypeCourse> GetTypeCourseList();
        //add list function.
        [OperationContract]
        int AddLstCourseMeeting(int list , Course course);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WcfServer.ContractType".

}

he purpose of this .net mvc core application is to apply some design principles and patterns that I learned about from the following course
https://www.udemy.com/course/software-architecture-and-design-essentials/
*functional purpose Registring and giving appointments to receive COVID Vaccination 
*Actors one actor the actor 
use cases are 1.Add vaccination types 
2.Add registrars 
3.Assign appointments to the registrars

*functions implementation , design patterns and design principles used

1.Add vaccination types and registrars 
-Design patterns used 
 A)Repository design pattern 
  #Each entity instance(e.g vaccination type) goes under the CRUD operation through a gateway class The gateway class calls the database context class methods (e.g. SaveChanges) 
 2.Mapping view models to entity model 
  -A service (or business logic class ) found in a class library called ServicesClassLibrary receives viewmodel object from razor views 
  -A data repository class (called [entitytype]modelmapper maps viewmodel object into entity object 
  -The service classes are injected into the mvc project using dependency injection of course 
  3.Validation registrars information 
  -An internal validation of registrar information is implemented 
  -This validation invokes an external API to check wither registrar phone number is valid 
  -Single responsibility principle is applied in API calling pipeline as explained below 
  #A (change) event is fired from client side in the registrar create screent 
  #the event sends an ajax call to a method CallTelephoneVerifyFunction in RegistrarsController
  #this methods calls a method called CallAPI() in a service class called TelephoneCheckAPICaller 
  #it is the responsibility of this class to determine if a token must be sent with the api call for security purposes or not 
  #also ,it is the responsibility of a (token manager) class to check if the token is expired and to ask for a new one if so 
  #in shorter words,the controller action method to call api remains the same always 
  #the token part is not fully implemented.the code for token issue is commented out for now 
  #The API Project is found seperately in a different repo
  (https://github.com/basemsha3bani/TelephoneNumbersWebAPI)

4.Assign appointments to the registrar and notify 
-Two patterns here are apply 
A)The Observer Pattern in order to add the registrars who are assigned appointments 
B) The Adapter Pattern in order to be able to invoke different notifiation approaches(Mail,phone ,etc...) 
-For simplicity ,the application shows a message stating which notification approach is used (there is no real notification happens)

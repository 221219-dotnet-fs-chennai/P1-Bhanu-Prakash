using System;
namespace Hellocsharp
{
    public class user
    {
        //type members - variable (define state/attribute of the object)
        string firstName="Lilly", lastName = "Windsor", id="101";
        // properties is another way to represent encapsulation
        public string FirstName{
            //readable accessor
            get{
                // + is used in strings to do string concatenation but it is inefficient way because strings are immutable, use string Builder instead
                //if(firstName != "" || firstName != null)
                if(String.IsNullOrEmpty(firstName))
                    throw new InvalidDataException("The firstname is empty or null") ; 
                return firstName;
            }
            //writable accessor
            set
            {
                if(value.Length<=0)
                    throw new InvalidDataException("The firstname should not be empty") ;   
                firstName = value;
            }
            //to assign a new value only dueing object construction
            //init;
        }
        public string LastName{
            get{
                 if(String.IsNullOrEmpty(lastName))
                    throw new InvalidDataException("The lastname is empty") ; 
                  return lastName;
                
            }
            set{
                 if(value.Length<=0)
                    throw new InvalidDataException("The firstname should not be empty") ;   
                lastName = value;
            }
        }
        public string Id{
            get{
                 if(String.IsNullOrEmpty(id))
                    throw new InvalidDataException("The id is empty or null") ; 
                return id;
            }
            set{
                 if(value.Length<=0)
                    throw new InvalidDataException("The id should not be empty") ;   
                id = value;
            }
        }
        //int age=25;
        //char code = '1';
        //bool isAlive = true;
    }
}
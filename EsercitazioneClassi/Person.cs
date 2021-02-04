using System;
using System.Collections.Generic;
using System.Text;

namespace EsercitazioneClassi
{
    public class Person
    {
        //Campi         definizione delle variabili

        //Inizializzare un campo con un valore di default 
        private string firstName = "Pippo";
        private string lastName = "Sconosciuto";  //posso non inizializzare la stringa scrivendo
                                                  // private string lastname; se lo richiamo lo inizializza vuoto
        private int age;  //lo setta a 0

        //Proprietà     livello di accesso alle variabili

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }  //value è il valore che passiamo 
        }

        public string LastName
        {
            get { return lastName; }   //se non ci fosse get non posso leggerlo ma solo modificarlo con set
            set { lastName = value; }  //se non ci fosse set non posso modificarlo
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public Contact Contacts {get;set;}



        //Metodi        cosa puoi fare con le variabili

        public string GetFullName()
        {
            return firstName + " " + lastName + " " + age ;
        }

     
    }
}

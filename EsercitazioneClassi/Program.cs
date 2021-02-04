using System;
using System.IO;

namespace EsercitazioneClassi
{
    class Program
    {
        static void Main(string[] args)
        {
            Person persona = new Person();

            persona.FirstName = "Matilde";
            persona.Age = 30;
            //persona.Address.City = "Genova";
            Console.WriteLine(persona.GetFullName());

            // mostrare a schermo 5 elementi del tipo:
            //Pippo1 Cognome2 Age:random
            //Pippo2 Cognome4
            //salvare in un array person

            Random numRandom = new Random();
            Person[] persone = new Person[5];
            for (int i = 0; i < 5; i++)
            {
                Person personadainserire = new Person()
                {
                    FirstName = String.Format("Pippo{0}", i + 1),
                    LastName = "Cognome" + 2 * (i + 1),
                    Age = numRandom.Next(0, 50)
                };

                persone[i] = personadainserire;
            }

            foreach (Person person in persone)
            {
                Console.WriteLine(person.GetFullName());
            }

            persona.Contacts = new Contact
            {
                PhoneNumber = 123,
                Email = "blabla@",
                Address = new Address
                {
                    City = "Genova",
                    State = "Italy",
                    ZipCode = 16147
                }
            };
           // Console.WriteLine(persona.GetFullName() + " " + persona.Contacts.Address.City);


            Employee[] employees= EmployeeManagement.GetAllEmployees();
            //foreach(Employee person in employees)
            //{
            //    Console.WriteLine(person.FirstName + " " + person.LastName +" " + person.Role + " " + person.Department);
            //}

            Employee[] SameName = EmployeeManagement.GetAllName();

            foreach (Employee person in SameName)
            {
                Console.WriteLine(person.FirstName + " " + person.LastName + " " + person.Role + " " + person.Department);
            }


            //foreach (Employee e in employees)    //Modifichiamo l'array di Employees
            //{
            //    if (e.LastName == "Colella")
            //    {
            //        e.LastName = "ALAL";
            //    }
            //}

            Employee[] SameName2 = EmployeeManagement.GetEmployeesByName2("Alice",employees);

            foreach (Employee person in SameName2)
            {
                Console.WriteLine(person.FirstName + " " + person.LastName + " " + person.Role + " " + person.Department);
            }


            Employee[] SameName3 = EmployeeManagement.AddNewEmployee();

            foreach (Employee person in SameName3)
            {
                Console.WriteLine(person.FirstName + " " + person.LastName + " " + person.Role + " " + person.Department);
            }

            //Aggiunta employee su file

            Employee employeeDaAggiungere = new Employee
            {
                FirstName = "Anna",
                LastName = "Ett",
                Role = "Developer",
                Department = "IT"
            };
            EmployeeManagement.WriteEmployee(employeeDaAggiungere);

            Employee[] employee2 = EmployeeManagement.GetAllEmployees();
            foreach (Employee person in employee2)
            {
                Console.WriteLine(person.FirstName + " " + person.LastName + " " + person.Role + " " + person.Department);
            }

            //EmployeeManagement.DeleteEmployee(employeeDaAggiungere);
            //Employee[] employee3 = EmployeeManagement.GetAllEmployees();
            //foreach (Employee person in employee2)
            //{
            //    Console.WriteLine(person.FirstName + " " + person.LastName + " " + person.Role + " " + person.Department);
            //}

        }
    }
}

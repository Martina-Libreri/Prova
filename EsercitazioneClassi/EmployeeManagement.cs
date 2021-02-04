using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EsercitazioneClassi
{
    public class EmployeeManagement
    {
        public static string path { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Employess.txt");


        //Lettura Employee da file
        public static Employee[] GetAllEmployees()
        {
            int totalLine = File.ReadLines(path).Count();
            string line;
            Employee[] employees = new Employee[totalLine - 1];
            using (StreamReader reader = File.OpenText(path))
            {
                string header = reader.ReadLine(); //legge una riga, solo la prima; ma se lo metto all'interno di un for le legge tutte
                while (!reader.EndOfStream)
                {
                    for (int i = 0; i < totalLine - 1; i++)
                    {
                        line = reader.ReadLine();
                        string[] employeeData = line.Split(",");
                        
                        Employee employee = new Employee
                        {
                            FirstName = employeeData[0],
                            LastName = employeeData[1],
                            Role = employeeData[2],
                            Department = employeeData[3]
                        };
                        employees[i] = employee;
                    }
                }
            }

            return employees;
        }


        //Metodo
        //ricercare tutti gli employees con un certo nome

        //Metodo 1 metodo che va sul file
        public static Employee[] GetAllName()
        {
            Employee[] employees = EmployeeManagement.GetAllEmployees();
            ArrayList employeeList = new ArrayList();

            int count = 0;

            Employee employee = new Employee
            {
                FirstName = "Alice",
                LastName = "Colella",
                Role = "Developer",
                Department = "IT"
            };

            foreach (Employee person in employees)
            {
                count++;
            }


            for (int i = 0; i < count; i++)
            {
                if (employees[i].FirstName == employee.FirstName)
                {
                    employeeList.Add(employees[i]);
                }
            }

            return (Employee[])employeeList.ToArray(typeof(Employee));  //mi restituisce un employee trasformando l'arraylist
        }


        //Metodo 2 metodo che va sull'oggetto
        public static Employee[] GetEmployeesByName2(string firstName, Employee[] employee)   //passo anche un'array di employee
        {
            ArrayList filteredEmployees = new ArrayList();
            for (int i = 0; i < employee.Length; i++)
            {
                if (employee[i].FirstName == firstName)
                {
                    filteredEmployees.Add(employee[i]);
                }
            }

            return (Employee[])filteredEmployees.ToArray(typeof(Employee));  //facciamo un casting verso la tipologia di array
        }



        //Aggiunta Employee 

        public static Employee[] AddNewEmployee()
        {
            ArrayList employees = new ArrayList(EmployeeManagement.GetAllEmployees());
            Employee employee = new Employee
            {
                FirstName = "Martina",
                LastName = "Libreri",
                Role = "Developer",
                Department = "IT"
            };

            employees.Add(employee);



            return (Employee[])employees.ToArray(typeof(Employee));
        }


        //Aggiunta Employee su file
        public static bool WriteEmployee(Employee employee)
        {

            try
            {
                using (StreamWriter writer = File.AppendText(path)) //scrive alla fine del file
                {
                    writer.WriteLine(employee.FirstName + "," + employee.LastName + "," + employee.Role + "," + employee.Department);
                }
                Console.WriteLine("Employee registrato correttamente");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static bool DeleteEmployee(Employee employee)
        {
            Employee[] employees = EmployeeManagement.GetAllEmployees();
            ArrayList newEmployee = new ArrayList();
            
            foreach(Employee emp in employees)
            {
                if(emp.FirstName!=employee.FirstName && emp.LastName != employee.LastName)
                {
                    newEmployee.Add(emp);
                }
            }

            try
            {
                using (StreamWriter writer = File.CreateText(path))
                {
                    writer.WriteLine("firstName, lastName, role, department");
                    foreach(Employee e in newEmployee)
                    {
                        writer.WriteLine(e.FirstName + " " + e.LastName + " " + e.Role + " " + e.Department);
                    }
                      
                }
                Console.WriteLine("Employee registrato correttamente");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}

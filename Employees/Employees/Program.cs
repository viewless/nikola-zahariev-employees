using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Employees
{
    internal class Program
    {
        static void Main()
        {
            int[] employeeIdContainter = AddEmployeesWhoWorkedMostOnSameProject();

            Console.WriteLine("Ids of mployees who worked longest time together on common projects are: " + String.Join(" and ", employeeIdContainter));

        }

        private static int[] AddEmployeesWhoWorkedMostOnSameProject()
        {
            int[] employeeIdContainter = new int[2];
            TimeSpan result;
            TimeSpan temp = TimeSpan.Zero;
            DateTime biggestDateFrom;
            DateTime smallestDateTo;

            List<Employee> employees = AddDataToEmployeesList();
            employees = employees.OrderBy(x => x.ProjectId).ToList();

            for (int i = 0; i < employees.Count - 1; i++)
            {
                if (employees[i].ProjectId == employees[i + 1].ProjectId)
                {

                    smallestDateTo = (employees[i].DateFrom > employees[i + 1].DateFrom ? employees[i].DateFrom : employees[i + 1].DateFrom);

                    biggestDateFrom = employees[i].DateTo > employees[i + 1].DateTo ? employees[i].DateTo : employees[i + 1].DateTo;

                    result = biggestDateFrom - smallestDateTo;

                    if (result > temp)
                    {
                        temp = result;
                        employeeIdContainter[0] = employees[i].EmId;
                        employeeIdContainter[1] = employees[i + 1].EmId;
                    }
                }
            }

            return employeeIdContainter;
        }

        private static List<Employee> AddDataToEmployeesList()
        {
            string[] lines = File.ReadAllLines(@".\Data\EmployeesData.txt");

            List<string[]> splitedData = new();
            List<Employee> employees = new List<Employee>();

            foreach (var line in lines)
            {
                splitedData.Add(line.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries));
            }

            Employee employee;

            for (int i = 0; i < splitedData.Count; i++)
            {
                if (splitedData[i][2] == "NULL")
                {
                    splitedData[i][2] = DateTime.UtcNow.ToString();
                }
                else if (splitedData[i][3] == "NULL")
                {
                    splitedData[i][3] = DateTime.UtcNow.ToString();
                }

                employee = new Employee(int.Parse(splitedData[i][0]), int.Parse(splitedData[i][1]), DateTime.Parse(splitedData[i][2]), DateTime.Parse(splitedData[i][3]));
                employees.Add(employee);
            }

            return employees;
        }
    }
}

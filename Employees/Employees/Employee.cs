using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    internal class Employee
    {
        private int empId;
        private int projectId;
        private DateTime dateFrom;
        private DateTime dateTo;

        public Employee(int empId, int projectId, DateTime dateFrom, DateTime dateTo)
        {
            this.empId = empId;
            this.projectId = projectId;
            this.dateFrom = dateFrom;
            this.dateTo = dateTo;
        }
        public int ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
        }

        public DateTime DateFrom
        {
            get { return dateFrom; }
            set { dateFrom = value; }
        }

        public DateTime DateTo
        {
            get { return dateTo; }
            set { dateTo = value; }
        }

        public int EmId
        {
            get { return empId; }
            set { empId = value; }
        }


    }
}

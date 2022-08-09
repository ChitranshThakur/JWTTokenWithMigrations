using Microsoft.EntityFrameworkCore;
using TokenWithMigrations.Interface;
using TokenWithMigrations.Models;

namespace TokenWithMigrations.Repository
{
    public class EmployeeRepository : IEmployees
    {
        private readonly DatabaseContext _db;
        public EmployeeRepository(DatabaseContext db)
        {
                _db = db;
        }

        public List<Employee> GetEmployeeDetails()
        {
            try
            {
                return _db.Employees.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Employee GetEmployeeDetails(int id)
        {
            try
            {
                var GetEmp = _db.Employees.FirstOrDefault(x => x.EmployeeID == id);
                if (GetEmp != null)
                {
                    return GetEmp;
                }
                throw new ArgumentNullException();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddEmployee(Employee employee)
        {
            try
            {
                if (employee != null)
                { 
                 _db.Employees.Add(employee);
                 _db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            try
            {
                if (employee != null)
                {
                    _db.Entry(employee).State = EntityState.Modified;
                    //_db.Employees.Update(employee);
                    _db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Employee DeleteEmployee(int id)
        {
            try
            {
                var DelEmp = _db.Employees.FirstOrDefault(x => x.EmployeeID == id);
                if (DelEmp != null)
                { 
                    _db.Remove(DelEmp);
                    _db.SaveChanges();
                    return DelEmp;
                }
                throw new ArgumentNullException();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CheckEmployee(int id)
        { 
            return _db.Employees.Any(x => x.EmployeeID == id);
        }
    }
}

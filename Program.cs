// See https://aka.ms/new-console-template for more information

using BenefitsWorker;
using System;
using System.Globalization;
Main();
void Main()
{
    Dependent dependent = new Dependent();
    dependent.FirstName = "Sue";
    dependent.LastName = "Jones";
    dependent.Age = 51;
    dependent.Relationship = Relationship.Spouse;
    Employee employee = new Employee();
    employee.FirstName = "Robert";
    employee.LastName = "Jones";
    employee.Salary = 80000;
    if(!employee.AddDependent(dependent))
    {
        throw new Exception("Could not add dependent!");
    }
    Dependent dependent2 = new Dependent();
    dependent2.FirstName = "Ryan";
    dependent2.LastName = "Farmer";
    dependent2.Age = 17;
    dependent2.Relationship = Relationship.Child;
    Employee employee2 = new Employee();
    employee2.FirstName = "Jane";
    employee2.LastName = "Farmer";
    employee2.Salary = 100000;
    employee2.AddDependent(dependent2);
    Calculator calculator = new Calculator();
    for(int i = 1; i < 13; i++)
    {
        employee.Checks.AddRange(calculator.CalculatePaycheck(employee, i));
        employee2.Checks.AddRange(calculator.CalculatePaycheck(employee2, i));
    }
    for(int i = 0; i < 26; i++)
    {
        int checkNum = i + 1;
        Console.WriteLine("Employee Check For " + employee.LastName +  " Check Number " + checkNum + "/26 " + "Amount: " + employee.Checks[i].ToString("C", CultureInfo.CurrentCulture));
        Console.WriteLine("Employee Check For " + employee2.LastName + " Check Number " + checkNum + "/26 " + " Amount: " + employee2.Checks[i].ToString("C", CultureInfo.CurrentCulture));

    }


}

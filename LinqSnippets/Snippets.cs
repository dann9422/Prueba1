using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqSnippets
{
    public class Snippets
    {


        static public void BasicLinq()
        {

            string[] cars =
            {
                "VW Golf",
                "VW California",
                "Audi A3",
                "Audi A5",
                "Fiat Punto",
                "Toyota Rav4",

            };

            //1. select * from cars(SELECT ALL)
            var CarList = from car in cars select car;

            foreach (var car in CarList)
            {
                Console.WriteLine(car);
            }

            // select where car is audi

            var AudiList = from car in cars where car.Contains("Audi") select car;

            foreach (var audi in AudiList)
            {
                Console.WriteLine(audi);
            }

        }

        static public void LinqNumbers()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, };

            var processdNumbersList = numbers
                .Select(num => num * 3)// each number multiplied by 3 
                .Where(num => num != 9)// take all number but 9
                .OrderBy(num => num);// order numbers by ascending value 

        }

        static public void SerachExamples()
        {
            List<String> textList = new List<string>
            {
                "a",
                "b",
                "c",
                "d",
                "e",
                "cj",
                "f",
                "c",

            };
            //1. firs of all elements
            var first = textList.First();
            //2. firts element that is C
            var ctext = textList.First(text => text.Equals("C"));
            //3. first element that contains j
            var jtext = textList.First(text => text.Contains("j"));
            //4.First element that contains Z
            var firstOrDefaultText = textList.FirstOrDefault(text => text.Contains("z"));
            //5.Last element that contains Z
            var LasttOrDefaultText = textList.LastOrDefault(text => text.Contains("z"));

            //6.Single values
            var uniqueText = textList.Single();
            var uiqueDefaultText = textList.SingleOrDefault();


            int[] evenNumber = { 0, 2, 4, 6, 8 };
            int[] MyevenNumber = { 0, 2, 6 };

            var myEvenNumebers = evenNumber.Except(MyevenNumber);



        }

        static public void MultipleSelects()
        {
            string[] myOpinion =
            {
            "Opinion 1 , text 1",
            "Opinion 2 , text 2",
            "Opinion 3 , text 3",
            };

            var MyOpinionSelect = myOpinion.SelectMany(opiniion => opiniion.Split(","));

            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id= 1,
                    Name ="Enterprise 2",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id= 1,
                            Name=  "Daniel",
                            Email ="Daniel@gmail.com",
                            Salary= 1000,
                        },
                        new Employee
                        {
                            Id= 2,
                            Name=  "Juan",
                            Email ="Juan@gmail.com",
                            Salary= 2000,
                        },
                        new Employee
                        {
                            Id= 3,
                            Name=  "Aaron",
                            Email ="Aaron@gmail.com",
                            Salary= 3000,
                        },
                        new Employee
                        {
                            Id= 4,
                            Name=  "Samuel",
                            Email ="samuel@gmail.com",
                            Salary= 5000,
                        }
                    }
                },
                                new Enterprise()
                {
                    Id= 2,
                    Name ="Enterprise 2",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id= 5,
                            Name=  "Zare",
                            Email ="Zare@gmail.com",
                            Salary= 1000,
                        },
                        new Employee
                        {
                            Id= 6,
                            Name=  "Melanie",
                            Email ="Melanie@gmail.com",
                            Salary= 2000,
                        },
                        new Employee
                        {
                            Id= 7,
                            Name=  "Tatiana",
                            Email ="Tatiana@gmail.com",
                            Salary= 3000,
                        },
                        new Employee
                        {
                            Id= 8,
                            Name=  "Victoria",
                            Email ="Victoria@gmail.com",
                            Salary= 5000,
                        }
                    }
                }
            };


            //Obtain ALL emplyee

            var employeeList = enterprises.SelectMany(enterprise => enterprise.Employees);

            //Khow if ana lis is empty
            bool hasEnterprises = enterprises.Any();

            bool hasEmployeees = enterprises.Any(enterprises => enterprises.Employees.Any());

            // all enterprise at laeast has a employee with more that 1000 of salary

            bool HasEmployeeWithSalaryMoroThat1000 = enterprises.Any(enterprises =>
            enterprises.Employees.Any(employee => employee.Salary >= 1000));


        }

        static public void LinqCollecction()
        {

            var firstList = new List<String>() { "a", "b", "c" };
            var SecondList = new List<String>() { "a", "c", "d" };

            //Inner join 

            var CommonResult = from element in firstList
                               join secondElement in SecondList
                               on element equals secondElement
                               select new { element, secondElement };


            var commonResult2 = firstList.Join(
             SecondList,
                   element => element,
                   secondElement => secondElement,
                   (element, secondElement) => new {element,secondElement}
                 );


            //OUTER JOIN -LEFT

            var leftOutherJoin = from element in firstList
                                 join secondElement in SecondList
                                 on element equals secondElement
                                 into temporalList
                                 from temporalElement in temporalList.DefaultIfEmpty()
                                 where temporalElement != temporalElement
                                 select new { element = element };

            var leftOuterJoin2 = from element in firstList
                                 from secondElement in SecondList.Where(s=> s==element).DefaultIfEmpty()
                                 select new { Element = element,SecondElement =secondElement };

            //OUTER JOIN -RIGHT

            var rigthOutherJoin = from SecondElement in SecondList
                                 join element in firstList
                                 on SecondElement equals element
                                 into temporalList
                                 from temporalElement in temporalList.DefaultIfEmpty()
                                 where SecondElement != temporalElement
                                 select new { element = SecondElement };

            //UNION
            var UnionList = leftOutherJoin.Union(rigthOutherJoin);

        }

        static public void SkipTakeLinq()
        {
            var myList = new[] { 
            
            1,2,3,4,5,6,7,8,9,10
                   
            };

            //Skip
            var SkipTwoFirtValues = myList.Skip(2);
            var SkipLastValues = myList.SkipLast(2);
            var SkipWhile = myList.SkipWhile(num => num < 4);


            //Take
            var TakeFirtValues = myList.Take(2);
            var TakeLastValues = myList.TakeLast(2);
            var TakeWhile = myList.TakeWhile(num => num < 4);
        }



    }
}
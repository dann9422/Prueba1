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
                   (element, secondElement) => new { element, secondElement }
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
                                 from secondElement in SecondList.Where(s => s == element).DefaultIfEmpty()
                                 select new { Element = element, SecondElement = secondElement };

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

        // pading
        public IEnumerable<T> GetPage<T>(IEnumerable<T> collection, int pageNumer, int resultPerpage)
        {
            int starIndex = (pageNumer - 1) * resultPerpage;
            return collection.Skip(starIndex).Take(resultPerpage);
        }

        //Variables
        public static void Linqvariables()
        {
            int[] Numbers = { 1, 2, 3, 5, 6, 7, 8, 9, 10 };
            var abodeAverge = from number in Numbers
                              let avarage = Numbers.Average()
                              let nsquared = Math.Pow(number, 2)
                              where nsquared > avarage
                              select number;

            Console.WriteLine("Avarage: {0}", Numbers.Average());

            foreach (var number in abodeAverge)
            {
                Console.WriteLine("Number: {0} square: {1}", number, Math.Pow(number, 2));
            }
        }


        //ZIP
        public static void ZipLinq()
        {
            int[] Number = { 1, 2, 3, 5 };
            string[] stringNumber = { "one", "two", "three", "four", "five" };

            IEnumerable<string> zipNumbers = Number.Zip(stringNumber, (Number, word) => Number + "=" + word);

        }

        //Repeat and range
        static public void ReapeatRangeLinq()
        {
            IEnumerable<int> first1000 = Enumerable.Range(1, 1000);
            IEnumerable<string> fivesX = Enumerable.Repeat("X", 5);
        }

        //Students class    

        static public void StudentLinq()
        {
            var classRoom = new[]
            {
                new Student
                {
                    Id = 1,
                    Name="Daniel",
                    Grade=90,
                    Certified = true

                },
            new Student
                {
                    Id = 2,
                    Name="Juan",
                    Grade=70,
                    Certified = false

                },
                 new Student
                {
                    Id = 3,
                    Name="Pedro",
                    Grade=80,
                    Certified = true

                },
                   new Student
                {
                    Id = 4,
                    Name="Martin",
                    Grade=90,
                    Certified = true

                }
            };

            var CertifiedStudents = from Student in classRoom
                                    where Student.Certified
                                    select Student;

            var NotCertifiedStudents = from Student in classRoom
                                       where Student.Certified == false
                                       select Student;

            var StudentAprovete = from Student in classRoom
                                  where Student.Grade > 70 && Student.Certified == true
                                  select Student;

        }


        //ALL
        static public void ALLlinq()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5 };
            bool allAreNumbersThan10 = numbers.All(x => x < 10);
            bool allAreNumbersequalThan10 = numbers.All(x => x >= 2);

            var emptyList = new List<int>();
            bool EmptyNumbersThan0 = numbers.All(x => x >= 0);

        }

        //Aggreate

        static public void AggreteLinq()
        {

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };


            //sum all numbers
            int sum = numbers.Aggregate((prevSUm, current) => prevSUm + current);

            string[] words = { "hello,", "my", "name", "is", "daniel" };
            string greeting = words.Aggregate((preventGreating, current) => preventGreating + current);



        }
        //distinc

        static public void DistincLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 4, 5, 5, 3, 2, 1 };
            IEnumerable<int> distinctNumeber = numbers.Distinct();



        }

        //Groudby

        static public void GroupByLinq()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 4, 5 };
            var group = numbers.GroupBy(x => x % 2 ==0);

            foreach (var valueGroup in group)
            {
                foreach (var value in valueGroup)
                {
                    Console.WriteLine(value);
                }
            }

            //another Example
            var classRoom = new[]
            {
                new Student
                {
                    Id = 1,
                    Name="Daniel",
                    Grade=90,
                    Certified = true

                },
            new Student
                {
                    Id = 2,
                    Name="Juan",
                    Grade=70,
                    Certified = false

                },
                 new Student
                {
                    Id = 3,
                    Name="Pedro",
                    Grade=80,
                    Certified = true

                },
                   new Student
                {
                    Id = 4,
                    Name="Martin",
                    Grade=90,
                    Certified = true

                }
            };

            var CertifiedQuery = classRoom.GroupBy(Student => Student.Certified && Student.Grade > 70);

            foreach (var valueGroup in CertifiedQuery)
            {
                Console.WriteLine("------{0}-----",valueGroup.Key);
                foreach (var Student in valueGroup)
                {
                    Console.WriteLine(Student.Name);
                }
            }


        }


        static public void RelacionIlnq()
        {
            List<Post> posts = new List<Post>();
            {
                new Post()
                {
                    Id = 1,
                    Title = "My First Post",
                    Content = "My First Content",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id=1,
                            Title ="My First comment",
                            Content = "My First Content",
                            Created =DateTime.Now,

                        },
                        new Comment()
                        {
                            Id=2,
                            Title ="My second comment",
                            Content = "My second Content",
                            Created =DateTime.Now,

                        },
                        new Comment()
                        {
                            Id=3,
                            Title ="My last comment",
                            Content = "My last Content",
                            Created =DateTime.Now,

                        },
                    }
                };
                                new Post()
                                {
                                    Id = 2,
                                    Title = "My Second Post",
                                    Content = "My second Content",
                                    Created = DateTime.Now,
                                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id=4,
                            Title ="My other comment",
                            Content = "My other Content",
                            Created =DateTime.Now,

                        },
                        new Comment()
                        {
                            Id=5,
                            Title ="My lalalal comment",
                            Content = "My lalalla Content",
                            Created =DateTime.Now,

                        },
                        new Comment()
                        {
                            Id=6,
                            Title ="My dududuud comment",
                            Content = "My dududud Content",
                            Created =DateTime.Now,

                        },
                    }
                };
            }

            var commentsWithContent = posts.SelectMany(Post => Post.Comments,
                (Post, comments) => new { PostId = Post.Id, commentContent = comments.Content });
                
  




        }
    }
    }
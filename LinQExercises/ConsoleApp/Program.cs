using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Models;

namespace ConsoleApp
{
    class Program
    {
        static IEnumerable<int> numbers = new[] { -1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 10 };

        static void Main(string[] args)
        {
            // CollectionOperators();
            // DemoStudentCollection();
            FinalOperators();
            // ConversionOperators();
        }

        static void DemoStudentCollection()
        {
            // 1.แปลงเป็น student ที่คำนวณเกรดแล้ว
            // 2.โชว์เฉพาะคนที่ได้ตั้งแต่ B ขึ้นไป
            // 3.โชว์เฉพาะผู้หญิงเท่านั้น (คะแนนคู่คือเพศชาย คะแนนคี่คือเพศหญิง)
            // qry = IEnumerable<Student>

            // var qry = numbers
            //             .Where(it => it >= 0)
            //             .Select(it => new Student
            //             {
            //                 Score = it,
            //                 Grade = calculateGrade(it),
            //                 IsMale = it % 2 == 0 // true: ช, false: ญ
            //             })
            //             .Where(it => it.Score > 7)
            //             .Where(it => it.IsMale == false);

            var qry = numbers
                .Where(it => it > 7)
                .Where(it => it % 2 != 0)
                .Select(it => new Student
                {
                    Score = it,
                    Grade = calculateGrade(it),
                    IsMale = true,
                });


            foreach (var item in qry)
            {
                System.Console.WriteLine(item.Grade);
            }
        }

        static string calculateGrade(int score)
        {
            if (score > 8)
            {
                return "A";
            }
            else if (score > 7)
            {
                return "B";
            }
            else if (score > 6)
            {
                return "C";
            }
            else
            {
                return "F";
            }
        }

        static void CollectionOperators()
        {
            var qry = Enumerable.Empty<int>();

            // แสดงผลตัวเลขเป็น %
            // var x = numbers.Select(it => (double)it / 100);

            // Number > 5
            // qry = numbers.Where(it=> it > 5);

            // Range 3~8
            // qry = numbers.Where(it => it > 2 && it < 9);
            // qry = numbers.Where(it => it >= 3 && it <= 8);

            // Unique numbers
            // qry = numbers.Distinct();

            // แสดงเฉพาะ 3 ตัวแรก
            // qry = numbers.Take(3);
            // qry = numbers
            //         .Where(it => it < 4)
            //         .Distinct();
            // ใช้ได้บางกรณี บางกรณีใช้ไม่ได้ เช่น { 9, 7, 12, 5, 1, 2, 3 }

            // qry = numbers.TakeWhile(it => it < 5); // 1 2 3 4
            // qry = numbers.Where(it => it < 5); // 1 2 3 4 1

            // ไม่เอา 3 ตัวแรก
            // qry = numbers.Skip(3);
            // qry = numbers.SkipWhile(it => it < 5);

            // เรียงลำดับ น้อย-มาก
            // qry = numbers.OrderBy(it => it);

            // เรียงลำดับ มาก-น้อย
            // qry = numbers.OrderByDescending(it => it);

            // กลับด้านลำดับ
            // qry = numbers.Reverse();

            // รวม 2 collection ไว้ด้วยกัน
            var aCollection = new[] { 1, 2, 3 };
            var bCollection = new[] { 3, 4, 5 };
            // qry = aCollection.Union(bCollection);


            // เอาเฉพาะตัวที่ซ้ำกันใน 2 collection
            // qry = aCollection.Intersect(bCollection);

            // ตัดตัวที่ซ้ำกับ collection อื่น
            // qry = aCollection.Except(bCollection);

            foreach (var item in qry)
            {
                System.Console.WriteLine(item);
            }
        }

        static void FinalOperators()
        {
            // นับว่ามีเลข 1 กี่ตัว
            // var result = numbers.Count(it => it == 1);

            // หาผลรวม
            // var result = numbers.Sum();
            // System.Console.WriteLine(result);
            // เลขที่มากกว่า 5 ทั้งหมดรวมกันได้เท่าไหร่
            // var result = numbers.Where(it => it > 5).Sum();

            // หาค่าต่ำสุด
            // var result = numbers.Min();

            // หาค่ามากสุด
            // var result = numbers.Max();

            // หาค่าเฉลี่ย
            // var result = numbers.Average();

            // ขอข้อมูลตัวแรก
            // numbers = new int[0]; // { }
            // var result = numbers.First();
            // var result = numbers.FirstOrDefault();

            // มีเลขที่มากกว่า 8 ใน collection ไหม
            //  var result = numbers.Any(it => it > 8);

            // ข้อมูลใน collection ทุกตัวมากกว่า 0 ใช่ไหม
            // var result = numbers.All(it => it > 0);

            // ข้อมูลใน collection ทุกตัวมากกว่า 5 ใช่ไหม
            // var result = numbers.All(it => it > 5);

            // มีเลข 3 ไหม
            // var result = numbers.Contains(3);

            // มีเลข 99 ไหม
            var result = numbers.Contains(99);
            System.Console.WriteLine(result);
        }

        static void ConversionOperators()
        {
            // numbers > IEnumerable<int>

            // แปลง collection เป็น array
            int[] arrayCollection = numbers.ToArray();

            // แปลง collection เป็น list
            List<int> listCollection = numbers.ToList();

            IEnumerable<int> x = listCollection;
        }
    }
}

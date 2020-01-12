using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Euler
{
    class Euler
    {
        static void Main(string[] args)
        {
            Euler001();
            //Euler002();
            //Euler003();
            //Euler004();
            //Euler005();
            //Euler006();
            //Euler007();
            //Euler008();
            //Fizzbuzz();
        }

        static void Euler001()
        {
            //Prints the sum of all the multiples of 3 or 5 below the UpperLimit.

            var UpperLimit = 1000;
            var total = 0;

            for (int i = 0; i < UpperLimit; i++)
            {
                if (IsDivisibleBy(i, 3) || IsDivisibleBy(i, 5))
                {
                    total += i;
                }
                else { continue; }
            }
            Console.WriteLine(total);
        }

        static void Euler002()
        {
            //Prints the sum of the even-valued Fibonacci terms that do not exceed the UpperLimit.

            var UpperLimit = 4000000;
            long total = 0;
            var i = 0;
            long result;

            while ((result = Fibonacci(i)) <= UpperLimit)
            {
                if (IsEven(result))
                {
                    //Console.WriteLine(Fibonacci(i));
                    total += result;
                }
                else { continue; }
                i++;
            }
            Console.WriteLine(total);
        }

        static void Euler003()
        {
            //Prints the largest prime factor of the candidate number.

            var candidate = 600851475143;
            var UpperLimit = Math.Sqrt(candidate);
            var primes = new List<long>();

            //Console.WriteLine(UpperLimit);

            for (int i = 1; i < UpperLimit; i++)
            {
                if (IsDivisibleBy(candidate, i) && IsPrime(i))
                {
                    primes.Add(i);
                }
                else { continue; }
            }
            //primes.ForEach(prime => { Console.WriteLine(prime); });
            Console.WriteLine(primes.Last());
        }

        static void Euler004()
        {
            //Prints the largest palindrome made from the product of two 3-digit numbers.

            long right = 0;
            long reverse = 0;
            var product = 0;
            var left = 0;
            var palindromes = new List<long>();

            for (int i = 999; i >= 100; i--)
                for (int j = i; j >= 100; j--)
                {
                    product = i * j;
                    right = product % 1000;
                    left = product / 1000;
                    reverse = ReverseNum(right);

                    if (reverse == left)
                    {
                        palindromes.Add(product);
                    }
                    else { continue; }
                }
            palindromes = palindromes.OrderByDescending(x => x).ToList();
            Console.WriteLine(palindromes.FirstOrDefault());
        }

        static void Euler005() //TBD
        {
            //Prints the lowest common multiple of numbers 1 to 20.
            //Console.WriteLine(2*2*5*3*7*2*3*11*13*2*17*19);
            //answer = 232,792,560

            //Console.WriteLine(LCM(1, 20));

            //Console.WriteLine(GCF(50, 25));

            //Console.WriteLine(LCMagg(...));

            Console.WriteLine(LowestCommonMultiple(1, 20));
            Console.ReadLine();
        }

        static void Euler006()
        {
            //Prints the difference betwen the sum of the squares 
            //of the first 100 naural numbers and the square of the sum 
            //of the first 100 natural numbers.
            var a = 100;
            var answer = Difference(SquareOfSum(a), SumOfSquares(a));
            Console.WriteLine(answer);
            Console.ReadLine();
        }

        static void Euler007()
        {
            //Prints the 10,001st prime number.
            var n = 1;
            var primesFound = 0;

            while (primesFound < 10001)
            {
                n++;
                while (!IsPrime(n))
                {
                    n++;
                }
                primesFound++;
            }
            Console.WriteLine(primesFound);
            Console.WriteLine(n);
            Console.ReadLine();
        }

        static void Euler008() //TBD
        {

        }

        static void Fizzbuzz()
        {
            var UpperLimit = 100;
            for (int i=1; i <= UpperLimit; i++)
            {
                if (IsDivisibleBy(i, 3) && IsDivisibleBy(i, 5))
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (IsDivisibleBy(i, 3))
                {
                    Console.WriteLine("Fizz");
                }
                else if (IsDivisibleBy(i, 5))
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
            Console.ReadLine();
        }

        public static long SumOfSquares(long a)
        {
            //Finds the sum of the squares of the first 'a' natural numbers.
            long sum = 0;
            for (var i = 1; i <= a; i++)
            {
                sum += Squared(i);
            }
            return sum;
        }

        public static long SquareOfSum(long a)
        {
            //Finds the square of the sum of the first 'a' natural numbers.
            long sum = 0;
            for (var i = 1; i <= a; i++)
            {
                sum += i;
            }
            sum = Squared(sum);
            return sum;
        }

        public static long Difference(long a, long b) => (a - b);

        public static long Squared(long a) => (a * a);

        public static long Product(long a, long b) => (a * b);

        public static long GreatestCommonFactor(long a, long b)
        {
            //greatest common factor; Euclidean algorithm
            return b == 0 ? a : GreatestCommonFactor(b, a % b);
        }

        public static long LCMabs(long a, long b)
        {
            //reduction by the GCF
            return Math.Abs(a * b) / GreatestCommonFactor(a, b);
        }

        public static long LCMagg(long[] numbers)
        {
            //aggregate gets an accumulating function
            return numbers.Aggregate(LCMabs);
        }

        public static long LowestCommonMultiple(long a, long b)
        {
            //Finds lowest common multiple from a to b.
            var lcm = a;  //lowest common multiple begins at our lower limit
            for (long i = a; i <= b; i++)  //for loop cycles through 1 to 20
            {
                var sum = lcm;  //sum equals latest lcm
                while (!IsDivisibleBy(sum,i))  //while sum is indivisible by one of our numbers...
                {
                    sum += lcm;  //...add latest lcm to sum
                }
                lcm = sum;  //once the sum is divisible by i, lcm equals the sum
            }
            return lcm;
        }

        public static long ReverseNum(long num)
        {
            long result = 0;

            while (num > 0)
            {
                result = result * 10 + num % 10;
                num /= 10;
            }
            return result;
        }

        public static bool IsDivisibleBy(long a, long b) => (a % b == 0);

        public static bool IsEven(long a) => IsDivisibleBy(a,2);

        public static bool IsOdd(long a) => !IsEven(a);

        public static long Fibonacci(long n){
            long a = 0;
            long b = 1;

            for (int i = 0; i < n; i++){
                long temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }

        public static bool IsPrime(long num)
        {
            if (IsEven(num)){
                return num == 2;
            }
            else { continue; }
            for (int i = 3; (i * i) <= num; i += 2){
                if (IsDivisibleBy(num, i)) return false;
            }
            return num != 1;
        }
    }
}

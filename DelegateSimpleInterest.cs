using System;

namespace DelegateSimpleInterest
{
    public delegate void InterestHandler(int principal, int interest, int timeMonths, int cal);
    public delegate void Sender();
    class SimpleInterestCal // publisher
    {
        public event InterestHandler send;
        int principal { get; set; }
        int interest { get; set; }
        int timeMonths { get; set; }
        int cal { get; set; }
        public void GetInput(int principal, int interest, int timeMonths)
        {
            this.principal = principal;
            this.interest = interest;
            this.timeMonths = timeMonths;
            principalMethod();
            interestMethod();
            timeMonthsMethod();
            CalcSimpleInterest();
        }
        public void principalMethod()
        {
            try
            {
                Console.WriteLine("Input interest:");
                principal = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Exception raised: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Input principal success!");
            }
        }
        public void interestMethod()
        {
            try
            {
                Console.WriteLine("Input interest:");
                interest = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Exception raised: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Input interest success!");
            }
        }
        public void timeMonthsMethod()
        {
            try
            {
                Console.WriteLine("Input time in months:");
                timeMonths = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Exception raised: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Input time in months success!");
            }
        }
        public void CalcSimpleInterest()
        {
            try
            {
                SimpleInterestCal simpleInterestCal = new SimpleInterestCal();

                cal = principal * interest * timeMonths;
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Exception raised: " + ex.Message);
            }
            finally
            {
                if (send != null)
                {
                    send(principal, interest, timeMonths, cal);
                }
            }
        }
    }
    class Program
        {
            static void Main(string[] args)
            {

            SimpleInterestCal simpleInterestCal = new SimpleInterestCal();
            simpleInterestCal.send += SimpleInterestCal_send;

            simpleInterestCal.principalMethod();
            simpleInterestCal.interestMethod();
            simpleInterestCal.timeMonthsMethod();
            simpleInterestCal.CalcSimpleInterest();
        }
            private static void SimpleInterestCal_send(int principal, int interest, int timeMonths, int cal)
            {
                Console.WriteLine("Your simple interest is: " + cal);
            }
        }
    }


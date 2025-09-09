using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    internal class Fraction
    {
        public int Integer { get; set; }
        public int Numerator { get; set; }
        int denominator;        //переменная-член класса (поле класса) smallCamel
        public int Denominator  //свойство (property) BigCamel
        {
            get => denominator;
            /*get
			{
				return denominator;
			}*/
            set => denominator = value == 0 ? 1 : value;
            //set=>if(value==0)denominator=1;else denominator=value;	//CS1525: Invalid expression item 'if';
            /*set
			{
				denominator = value == 0 ? 1 : value;
				//if (value != 0) denominator = value; else denominator = 1;
			}*/
        }
        public Fraction()
        {
            Denominator = 1;
            Console.WriteLine($"DefaultConstructor:{this.GetHashCode().ToString("X")}");
        }
        public Fraction(int Integer)
        {
            this.Integer = Integer;
            this.Denominator = 1;
            Console.WriteLine($"SingleArgumentConstructor:{GetHashCode().ToString("X")}");
        }
        public Fraction(int Numerator, int Denominator)
        {
            this.Numerator = Numerator;
            this.Denominator = Denominator;
            Console.WriteLine($"Constrcutor:\t\t{GetHashCode().ToString("X")}");
        }
        public Fraction(int Integer, int Numerator, int Denominator)
        {
            this.Integer = Integer;
            this.Numerator = Numerator;
            this.Denominator = Denominator;
            Console.WriteLine($"Constrcutor:\t\t{GetHashCode().ToString("X")}");
        }
        public Fraction(Fraction other)
        {
            this.Integer = other.Integer;
            this.Numerator = other.Numerator;
            this.Denominator = other.Denominator;
            Console.WriteLine($"CopyConstructor:{this.GetHashCode().ToString("X")}");
        }
        ~Fraction()
        {
            Console.WriteLine($"Destructor:\t\t {this.GetHashCode().ToString("X")}");
        }

        //				Operators:
        public static Fraction operator *(Fraction left, Fraction right) =>
            new Fraction
                (
                    left.ToImproper().Numerator * right.ToImproper().Numerator,
                    left.denominator * right.Denominator
                ).ToProper().Reduced();
        public static Fraction operator /(Fraction left, Fraction right) => left * right.Inverted();

        //{
        //	//Fraction l_buffer = new Fraction(left);
        //	//Fraction r_buffer = new Fraction(right);
        //	//l_buffer.ToImproper();
        //	//r_buffer.ToImproper();
        //	//Console.WriteLine(l_buffer);
        //	//Console.WriteLine(r_buffer);
        //	//return new Fraction
        //	//	(
        //	//		l_buffer.Numerator * r_buffer.Numerator,
        //	//		l_buffer.Denominator * r_buffer.Denominator
        //	//	).ToProper();
        //}


        //Methods:
        public Fraction ToImproper() => new Fraction(Numerator + Integer * Denominator, Denominator);
        //{
        //	return new Fraction(Numerator + Integer * Denominator, Denominator);
        //	//Numerator += Integer * Denominator;
        //	//Integer = 0;
        //	//return improper;
        //}
        public Fraction ToProper() => new Fraction(Numerator / Denominator, Numerator % Denominator, Denominator);
        //{
        //	return new Fraction(Numerator / Denominator, Numerator % Denominator, Denominator);
        //	//Integer += Numerator / Denominator;
        //	//Numerator %= Denominator;
        //	//if (Numerator < 0) Numerator *= -1;
        //	//return this;
        //}
        public Fraction Inverted() => new Fraction(Denominator, ToImproper().Numerator);
        public Fraction Reduced() => new Fraction(Integer, Numerator / GCD(), Denominator / GCD());
        public int GCD() =>
            (int)Convert.ToUInt32(System.Numerics.BigInteger.GreatestCommonDivisor(Numerator, Denominator).ToString());
        //{
        //	Fraction inverted = ToImproper();
        //	return new Fraction
        //		(
        //			inverted.Denominator, inverted.Numerator
        //		);
        //}
        public void Print()
        {
            Console.WriteLine($"{Integer}({Numerator}/{Denominator})");
        }
        //Overrides:

        public override string ToString()
        {
            string @string = "";
            if (Integer != 0) @string += $"{Integer}";
            if (Numerator != 0)
            {
                if (Integer != 0) @string += "(";
                @string += $"{Numerator}/{Denominator}";
                if (Integer != 0) @string += ")";
            }
            else if (Integer == 0) @string = "0";
            return @string;//base.ToString();
        }
    }
}


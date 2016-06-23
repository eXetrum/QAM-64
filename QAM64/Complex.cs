using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAM64
{
    public class Complex : IComparable
    {
        private double real;
        private double imaginary;

        public double Re
        {
            get { return real; }
            set { real = value; }
        }

        public double Im
        {
            get { return imaginary; }
            set { imaginary = value; }
        }

        public Complex()
        {
            real = 0.0;
            imaginary = 0.0;
        }

        public Complex(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        public double Amplitude
        {
            get
            {
                int quadrant = 1;
                if(Phase < 0 || Phase > 180)
                {
                    quadrant *= -1;
                }
                return quadrant * Complex.Magnitude(this);
            }
        }

        public double Phase
        {
            get
            {
                return Complex.Angle(this);
            }
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.real + c2.real, c1.imaginary + c2.imaginary);
        }

        public static Complex operator - (Complex c1, Complex c2)
        {
            return new Complex(c1.real - c2.real, c1.imaginary - c2.imaginary);
        }

        public static Complex operator *(Complex c1, Complex c2)
        {
            return new Complex(c1.real * c2.real - c1.imaginary * c2.imaginary, c1.real * c2.imaginary + c1.imaginary * c2.real);
        }

        public static Complex operator /(Complex c1, Complex c2)
        {
            return new Complex(
                (c1.real * c2.real + c1.imaginary * c2.imaginary) / (c2.real * c2.real + c2.imaginary * c2.imaginary),
                (c2.real * c1.imaginary - c1.real * c2.imaginary) / (c2.real * c2.real + c2.imaginary * c2.imaginary));
        }
        public static double Magnitude(Complex c)
        {
            return Math.Sqrt(c.real * c.real + c.imaginary * c.imaginary);
        }

        public static double Angle(Complex c)
        {
            return Math.Atan2(c.imaginary, c.real);
        }

        public static Dictionary<float, float> Signal(Complex Z)
        {
            Dictionary<float, float> values = new Dictionary<float, float>();
            for (int angle = 0; angle < 360; ++angle)
            {
                values.Add(angle, (float)(Z.Re * Math.Cos(angle * Math.PI / 180) + Z.Im * Math.Sin(angle * Math.PI / 180)));
            }
            return values;
        }

        public int CompareTo(object obj)
        {
            Complex that = obj as Complex;
            // Сортируем сначала по фазе и если фазы совпадают затем учитываем амлитуды
            if (Phase < that.Phase || (Phase == that.Phase && Amplitude < that.Amplitude)) return -1;
            if (Phase > that.Phase || (Phase == that.Phase && Amplitude > that.Amplitude)) return 1;
            return 0;
        }

        public override string ToString()
        {
            return (System.String.Format("{0} + {1}i", real, imaginary));
        }
    }
}

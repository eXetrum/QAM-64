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
                if (Phase < 0 || Phase > 180)
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

        public static Complex operator -(Complex c1, Complex c2)
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
            double angle = Math.Atan2(c.imaginary, c.real) * 180 / Math.PI;
            if (angle < 0) angle = 360 + angle;
            return angle;
        }

        public static float [] GenerateSignal(Complex Z)
        {
            int period = 360;
            //Dictionary<float, float> values = new Dictionary<float, float>();
            float[] values = new float[period];
            for (int angle = 0; angle < period; ++angle)
            {
                float y = (float)(Z.Re * Math.Cos(angle * Math.PI / 180.0f) + Z.Im * Math.Sin(angle * Math.PI / 180.0f));
                values[angle] = y;
                //values.Add(angle, y);
            }
            return values;
        }

        public static float [] GenerateNoiseSignal(float[] original, int noiseScale)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);

            // Находим макс/мин амплитуды сигнала
            double minAmp = Double.MaxValue;
            double maxAmp = -Double.MaxValue;
            foreach (var amp in original)
            {
                if (minAmp > amp) minAmp = amp;
                if (maxAmp < amp) maxAmp = amp;
            }
            // Определяем расстояние между минимальым и максимальным значениями амплитуды
            double ampLength = Math.Abs(minAmp - maxAmp);

            float[] noised = new float[original.Length];
            Array.Copy(original, noised, original.Length);
            for(int x = 0; x < original.Length; ++x)
            {
                double noise = rnd.NextDouble() * (2 * ampLength / (101 - noiseScale)); /// 100.0f + 1);// 4.0f + 1);
                int sign = rnd.Next(-1, 2);

                float y = original[x];
                noised[x] = (float)(y + noise * sign);
            }
            return noised;
        }

        public static double SignalsDiff(float [] signalA, float [] signalB)
        {
            double sum = 0;
            int size = signalA.Length < signalB.Length ? signalA.Length : signalB.Length;
            for(int i = 0; i < size; ++i)
            {
                sum += Math.Pow(signalA[i] - signalB[i], 2.0);
            }
            return sum;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Complex)) return false;
            Complex that = obj as Complex;
            return this.real == that.real && this.imaginary == that.imaginary;
        }

        public override int GetHashCode()
        {
            return real.GetHashCode() ^ imaginary.GetHashCode();
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

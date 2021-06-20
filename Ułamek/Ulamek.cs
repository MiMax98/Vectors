using System;
using System.Reflection;

namespace UlamekBiblioteka
{
    public struct Ulamek : IComparable<Ulamek>, IConvertible
    {
        //private int licznik, mianownik;
        private int mianownik;


        public Ulamek(int licznik, int mianownik = 1)
        {
            if (mianownik == 0)
                throw new ArgumentException("Mianownik musi byc rozny od zera");
            this.Licznik = licznik;
            this.mianownik = mianownik;
        }
        public static readonly Ulamek Zero = new Ulamek(0);
        public static readonly Ulamek Jeden = new Ulamek(1);
        public static readonly Ulamek Polowa = new Ulamek(1, 2);
        public static readonly Ulamek Cwierc = new Ulamek(1, 4);

        public static string Info()
        {
            return "Struktura ulamek";
        }

        public override string ToString()
        {
            return Licznik.ToString() + "/" + mianownik.ToString();
        }

        public readonly double ToDouble()
        {
            return Licznik / (double)mianownik;
        }

        public void Uprosc()
        {
            int a = Licznik;
            int b = mianownik;
            int c;

            while (b != 0)
            {
                c = a % b;
                a = b;
                b = c;
            }
            Licznik /= a;
            mianownik /= a;

            if (Math.Sign(Licznik) * Math.Sign(mianownik) < 0)
            {
                Licznik = -Math.Abs(Licznik);
                mianownik = Math.Abs(mianownik);
            }
            else
            {
                Licznik = Math.Abs(Licznik);
                mianownik = Math.Abs(mianownik);
            }
        }

        #region Properties

        public int Licznik { get; set; }


        public int Mianownik
        {
            get => mianownik;
            set
            {
                if (value == 0)
                    throw new ArgumentException("Mianownik musi byc różny od zera!");
                mianownik = value;
            }

        }


        #endregion

        #region Operatory arytmetyczne
        public static Ulamek operator -(Ulamek u)
        {
            return new Ulamek(-u.Licznik, u.Mianownik);
        }
        public static Ulamek operator +(Ulamek u)
        {
            return u;
        }
        public static Ulamek operator +(Ulamek u1, Ulamek u2)
        {
            Ulamek wynik = new Ulamek(u1.Licznik * u2.Mianownik + u2.Licznik * u1.Mianownik, u1.Mianownik * u2.Mianownik);
            wynik.Uprosc();
            return wynik;
        }
        public static Ulamek operator -(Ulamek u1, Ulamek u2)
        {
            Ulamek wynik = new Ulamek(u1.Licznik * u2.Mianownik - u2.Licznik * u1.Mianownik, u1.Mianownik * u2.Mianownik);
            wynik.Uprosc();
            return wynik;
        }
        public static Ulamek operator *(Ulamek u1, Ulamek u2)
        {
            Ulamek wynik = new Ulamek(u1.Licznik * u2.Licznik, u1.Mianownik * u2.Mianownik);
            wynik.Uprosc();
            return wynik;
        }
        public static Ulamek operator /(Ulamek u1, Ulamek u2)
        {
            Ulamek wynik = new Ulamek(u1.Licznik * u2.Mianownik, u1.Mianownik * u2.Licznik);
            wynik.Uprosc();
            return wynik;
        }
        #endregion

        #region

        public static bool operator ==(Ulamek u1, Ulamek u2)
        {
            return (u1.ToDouble() == u2.ToDouble());
        }

        public static bool operator !=(Ulamek u1, Ulamek u2)
        {
            return !(u1 == u2);
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Ulamek)) return false;
            Ulamek u = (Ulamek)obj;
            return (this == u);
        }

        public override int GetHashCode()
        {
            return Licznik ^ Mianownik;

        }

        public int CompareTo(Ulamek other)
        {
            double roznica = this.ToDouble() - other.ToDouble();
            if (roznica != 0) roznica /= Math.Abs(roznica);
            return (int)roznica;
        }

        public TypeCode GetTypeCode() => TypeCode.Object;

        public bool ToBoolean(IFormatProvider provider) => Licznik != 0;

        public byte ToByte(IFormatProvider provider) => (byte)(Licznik / Mianownik);

        public char ToChar(IFormatProvider provider) => (char)ToByte(provider);

        public DateTime ToDateTime(IFormatProvider provider) => new DateTime(ToInt64(provider));

        public decimal ToDecimal(IFormatProvider provider) => (decimal)Licznik / Mianownik;

        public double ToDouble(IFormatProvider provider) => (double)Licznik / Mianownik;

        public short ToInt16(IFormatProvider provider) => (short)(Licznik / Mianownik);

        public int ToInt32(IFormatProvider provider) => Licznik / Mianownik;

        public long ToInt64(IFormatProvider provider) => Licznik / Mianownik;

        public sbyte ToSByte(IFormatProvider provider) => (sbyte)(Licznik / Mianownik);

        public float ToSingle(IFormatProvider provider) => (float)Licznik / Mianownik;

        public string ToString(IFormatProvider provider) => ToString();

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            MethodInfo castMethod = GetType().GetMethod("Cast").MakeGenericMethod(conversionType);
            return castMethod.Invoke(null, new object[] { Licznik / Mianownik });
        }

        public ushort ToUInt16(IFormatProvider provider) => (ushort)(Licznik / Mianownik);

        public uint ToUInt32(IFormatProvider provider) => (uint)(Licznik / Mianownik);

        public ulong ToUInt64(IFormatProvider provider) => (ulong)(Licznik / Mianownik);

        public static T Cast<T>(object o)
        {
            return (T)o;
        }

        public static bool operator >(Ulamek u1, Ulamek u2)
        {
            return (u1.ToDouble() > u2.ToDouble());
        }
        public static bool operator >=(Ulamek u1, Ulamek u2)
        {
            return (u1.ToDouble() >= u2.ToDouble());
        }
        public static bool operator <(Ulamek u1, Ulamek u2)
        {
            return (u1.ToDouble() < u2.ToDouble());
        }
        public static bool operator <=(Ulamek u1, Ulamek u2)
        {
            return (u1.ToDouble() <= u2.ToDouble());
        }

        #endregion

        #region Operatory konwersji

        public static explicit operator double(Ulamek u)
        {
            return u.ToDouble();
        }
        public static implicit operator Ulamek(int n)
        {
            return new Ulamek(n);
        }
        #endregion
    }
}

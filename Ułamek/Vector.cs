using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlamekBiblioteka
{
    public struct Vector : IComparable<Vector>
    {
        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public double Length => Math.Sqrt(X * X + Y * Y + Z * Z);

        public static Vector operator+(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        public static Vector operator-(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        public static Vector operator+(Vector v1)
        {
            return v1;
        }

        public static Vector operator-(Vector v1)
        {
            return new Vector(-v1.X, -v1.Y, -v1.Z);
        }

        public static bool operator==(Vector v1, Vector v2)
        {
            return v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z;
        }

        public static bool operator!=(Vector v1, Vector v2)
        {
            return !(v1==v2);
        }

        public override bool Equals(object obj)
        {
            if (obj is not Vector v)
            {
                return false;
            }
            return v == this;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }

        public static double Dot(Vector v1, Vector v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }

        public static Vector Cross(Vector v1, Vector v2)
        {
            return new Vector(v1.Y * v2.Z - v1.Z * v2.Y, v1.Z * v2.X - v1.X * v2.Z, v1.X * v2.Y - v1.Y * v2.X);
        }

        public static double operator*(Vector v1, Vector v2)
        {
            return Dot(v1,v2);
        }

        public static Vector operator ^(Vector v1, Vector v2)
        {
            return Cross(v1,v2);
        }

        public static Vector operator *(double s, Vector v)
        {
            return new Vector(v.X * s, v.Y * s, v.Z * s);
        }

        public static Vector operator *(Vector v, double s)
        {
            return s * v;
        }

        public static Vector operator /(Vector v, double s)
        {
            if (s == 0.0)
            {
                throw new ArgumentException("Dzielenie przez 0", nameof(s));
            }
            s = 1 / s;
            return v*s;
        }

        public static bool ArePerpendicular(Vector v1, Vector v2)
        {
            return v1 * v2 == 0.0;
        }

        public int CompareTo(Vector other)
        {
            return (int)(Length - other.Length);
        }

        public static Vector WeightedSum((double weight, Vector vector)[] vectors)
        {
            return vectors.Aggregate(new Vector(0, 0, 0), (acc, next) => acc + next.weight * next.vector);
        }
    }
}

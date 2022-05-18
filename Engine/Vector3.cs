using System;
using System.Collections.Generic;
using System.Text;

namespace Pix.Engine {


    public struct Vector3 {
        public const float degToRad = 57.2958f;

        float x;
        public float X {
            get { return x; }
            set { x = value; }
        }

        float y;
        public float Y {
            get { return y; }
            set { y = value; }
        }

        float z;
        public float Z {
            get { return z; }
            set { z = value; }
        }



        static public Vector3 zero {
            get { return new Vector3(0, 0, 0); }
        }



        public Vector3(float x, float y, float z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }



        public static Vector3 operator +(Vector3 thi, Vector3 toAdd) => new Vector3(thi.x + toAdd.x, thi.y + toAdd.y, thi.z + toAdd.z);
        public static Vector3 operator -(Vector3 thi, Vector3 toAdd) => new Vector3(thi.x - toAdd.x, thi.y - toAdd.y, thi.z - toAdd.z);
        public static Vector3 operator *(Vector3 thi, float toAdd) => new Vector3(thi.x * toAdd, thi.y * toAdd, thi.z * toAdd);
        public static Vector3 operator /(Vector3 thi, float toAdd) => new Vector3(thi.x / toAdd, thi.y / toAdd, thi.z / toAdd);

        public static bool operator ==(Vector3 thi, Vector3 other) => (thi.x == other.x && thi.y == other.y && thi.z == other.z);
        public static bool operator !=(Vector3 thi, Vector3 other) => !(thi.x == other.x && thi.y == other.y && thi.z == other.z);


        public Vector2 GetProjectedPoint() {

            float screenDistance = 500f;

            float _X;
            float _Y;

            if (this.z > 1) {
                _X = screenDistance * this.x / this.z;
                _Y = screenDistance * this.y / this.z;
            }
            else {
                _X = screenDistance * this.x;
                _Y = screenDistance * this.y;
            }
            return new Vector2(Convert.ToInt32(_X), Convert.ToInt32(_Y));
        }

        public Vector3 RotateX(float deg, Vector3 origin) {
            Vector3 ab = this - (origin);

            double cos = Math.Cos(deg * degToRad);
            double sin = Math.Sin(deg * degToRad);

            float resY = Convert.ToSingle((ab.y * cos) - (ab.z * sin));
            float resZ = Convert.ToSingle((ab.y * sin) + (ab.z * cos));

            resY += origin.X;
            resZ += origin.Z;

            return new Vector3(this.x, resY, resZ);
        }

        public Vector3 RotateY(float deg, Vector3 origin) {
            Vector3 ab = this - (origin);

            double cos = Math.Cos(deg * degToRad);
            double sin = Math.Sin(deg * degToRad);

            float resX = Convert.ToSingle((ab.x * cos) + (ab.z * sin));
            float resZ = Convert.ToSingle(-(ab.x * sin) + (ab.z * cos));

            resX += origin.X;
            resZ += origin.Z;

            return new Vector3(resX, this.y, resZ);
        }

        public Vector3 RotateZ(float deg, Vector3 origin) {
            Vector3 ab = this - (origin);

            double cos = Math.Cos(deg * degToRad);
            double sin = Math.Sin(deg * degToRad);

            float resX = Convert.ToSingle((ab.x * cos) - (ab.y * sin));
            float resY = Convert.ToSingle((ab.x * sin) + (ab.y * cos));

            resX += origin.X;
            resY += origin.Y;

            return new Vector3(resX, resY, this.z);
        }
    }
}

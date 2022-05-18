using System;

namespace Pix {

    class PixV {
        public const char block = '\u2580';


        char _char;
        public char _Char {
            get { return _char; }
        }
        ConsoleColor _color;
        public ConsoleColor _Color {
            get { return _color; }
        }

        object parent;
        public object Parent {
            get { return parent; }
        }

        public PixV(char _char, ConsoleColor _color, object parent) {
            this._char = _char;
            this._color = _color;
            this.parent = parent;
            
        }
        
    }
    
    

    public struct Vector2 {
        int x;
        public int X {
            get { return x; }
            set { x = value; }
        }

        int y;
        public int Y {
            get { return y; }
            set { y = value; }
        }



        public Vector2 zero {
            get { return new Vector2(0, 0); }
        }

        public Vector2 up {
            get { return new Vector2(0, 1); }
        }

        public Vector2 down {
            get { return new Vector2(0, -1); }
        }

        public Vector2 left {
            get { return new Vector2(-1, 0); }
        }

        public Vector2 right {
            get { return new Vector2(1, 0); }
        }



        public Vector2(int x, int y) {
            this.x = x;
            this.y = y;
        }



        public static Vector2 operator +(Vector2 thi, Vector2 toAdd) => new Vector2(thi.x + toAdd.x, thi.y + toAdd.y);


        public static Vector2 operator -(Vector2 thi, Vector2 toAdd) => new Vector2(thi.x - toAdd.x, thi.y - toAdd.y);


        public static Vector2 operator*(Vector2 thi, float toAdd) => new Vector2(Convert.ToInt32(thi.x* toAdd), Convert.ToInt32(thi.y* toAdd));

        public Vector2 Rotate(float deg, Vector2 origin) {
            Vector2 ab = this - (origin);

            double cos = Math.Cos(deg * Drawer.degToRad);
            double sin = Math.Sin(deg * Drawer.degToRad);

            double resX = (ab.x * cos) - (ab.y * sin);
            double resY = (ab.x * sin) + (ab.y * cos);

            resX += origin.X;
            resY += origin.Y;

            return new Vector2(Convert.ToInt32(resX), Convert.ToInt32(resY));
        }
    }
}

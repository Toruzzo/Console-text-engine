using System;
using Pix.Engine;

namespace Pix {

    class Drawer {
        public const float degToRad = 0.0174533f;


        PixV[,] res;

        public PixV[,] Res {
            get { return res; }
        }

        public Drawer(int x, int y) {
            res = new PixV[x, y];

        }



        public void Reset() {
            res = new PixV[res.GetLength(0), res.GetLength(1)];

        }


        /// shape///////////////////////////////////////////////////////////////////////////////////////////


        public void AddIm(PixV[,] shape, int x, int y) {
            for (int i = 0; i < res.GetLength(1); i++) {
                for (int j = 0; j < res.GetLength(0); j++) {
                    if (i >= y && i <= y + shape.GetLength(1) - 1) {
                        if (j >= x && j <= x + shape.GetLength(0) - 1) {
                            res[j, i] = shape[j - shape.GetLength(0), i - shape.GetLength(1)];
                        }
                    }
                }
            }
        }


        public void AddIm(PixV[,] shape, Vector2 pos) {
            for (int i = 0; i < res.GetLength(1); i++) {
                for (int j = 0; j < res.GetLength(0); j++) {
                    if (i >= pos.Y && i <= pos.Y + shape.GetLength(1) - 1) {
                        if (j >= pos.X && j <= pos.X + shape.GetLength(0) - 1) {
                            res[j, i] = shape[j - shape.GetLength(0), i - shape.GetLength(1)];
                        }
                    }
                }
            }
        }

        /// rect///////////////////////////////////////////////////////////////////////////////////////////


        public void AddRect(int sx, int sy, int x, int y, ConsoleColor color, object parent) {
            for (int i = 0; i < res.GetLength(1); i++) {
                for (int j = 0; j < res.GetLength(0); j++) {
                    if (i >= y && i <= y + sy - 1 && j >= x && j <= x + sx - 1) {

                        res[j, i] = new PixV(PixV.block, color, parent);

                    }
                }
            }
        }

        public void AddRect(Vector2 size, Vector2 pos, ConsoleColor color, object parent) {
            for (int i = 0; i < res.GetLength(1); i++) {
                for (int j = 0; j < res.GetLength(0); j++) {
                    if (i >= pos.Y && i <= pos.Y + size.Y - 1 && j >= pos.X && j <= pos.X + size.X - 1) {

                        res[j, i] = new PixV(PixV.block, color, parent);

                    }
                }
            }
        }


        /// line///////////////////////////////////////////////////////////////////////////////////////////
        /// //////////////////////////////////////////////////////////////////////////////////////////////
        ///         /// //////////////////////////////////////////////////////////////////////////////////////////////

        /// //////////////////////////////////////////////////////////////////////////////////////////////

        /// //////////////////////////////////////////////////////////////////////////////////////////////

        /// //////////////////////////////////////////////////////////////////////////////////////////////



        public void AddLine(Vector2 p1, Vector2 p2, ConsoleColor color, object parent) {
            float m = (float)(p2.Y - p1.Y) / (float)(p2.X - p1.X);
            float q = (float)p1.Y - m * (float)p1.X;

            // nC///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (p1.X < p2.X && p1.X > 0) {
                for (int i = p1.X; i < p2.X && i < res.GetLength(0); i++) {
                    if (Convert.ToInt32(q + m * (i)) > 1 && Convert.ToInt32(q + m * (i)) < res.GetLength(1)) {


                        res[i, Convert.ToInt32(q + m * (i))] = new PixV(PixV.block, color, parent);


                        if ((Math.Abs(Convert.ToInt32(q + m * (i-1)) - Convert.ToInt32(q + m * (i))) >= 2) && Convert.ToInt32(q + m * (i + 1)) > 1 && Convert.ToInt32(q + m * (i + 1)) < res.GetLength(1) && Convert.ToInt32(q + m * (i - 1)) > 0 && Convert.ToInt32(q + m * (i - 1)) < res.GetLength(1)) {
                            if (m > 0) {
                                for (int h = 0; h < Math.Abs(Convert.ToInt32(q + m * (i)) - Convert.ToInt32(q + m * (i + 1))); h++) {
                                    res[i, Convert.ToInt32(q + m * (i + 1)) - h] = new PixV(PixV.block, color, parent);
                                }
                            }
                            else {
                                for (int h = 0; h < Math.Abs(Convert.ToInt32(q + m * (i)) - Convert.ToInt32(q + m * (i + 1))); h++) {
                                    res[i, Convert.ToInt32(q + m * (i + 1)) + h] = new PixV(PixV.block, color, parent);
                                }
                            }

                        }
                    }

                }
            }
            else if (p1.X > p2.X && p2.X > 0) {
                for (int i = p2.X; i < p1.X && i < res.GetLength(0); i++) {
                    if (Convert.ToInt32(q + m * (i)) > 1 && Convert.ToInt32(q + m * (i)) < res.GetLength(1)) {
                        res[i, Convert.ToInt32(q + m * (i))] = new PixV(PixV.block, color, parent);
                        if ((Math.Abs(Convert.ToInt32(q + m * (i)) - Convert.ToInt32(q + m * (i + 1))) >= 2) && Convert.ToInt32(q + m * (i + 1)) > 1 && Convert.ToInt32(q + m * (i + 1)) < res.GetLength(1) && Convert.ToInt32(q + m * (i - 1)) > 0 && Convert.ToInt32(q + m * (i - 1)) < res.GetLength(1)) {
                            if (m > 0) {
                                for (int h = 0; h < Math.Abs(Convert.ToInt32(q + m * (i)) - Convert.ToInt32(q + m * (i + 1))); h++) {
                                    res[i, Convert.ToInt32(q + m * (i + 1)) - h] = new PixV(PixV.block, color, parent);
                                }
                            }
                            else {
                                for (int h = 0; h < Math.Abs(Convert.ToInt32(q + m * (i)) - Convert.ToInt32(q + m * (i + 1))); h++) {
                                    res[i, Convert.ToInt32(q + m * (i + 1)) + h] = new PixV(PixV.block, color, parent);
                                }
                            }

                        }
                    }
                }

            }
            // ==C//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            else if (p1.X == p2.X && p1.X > 0 && p1.X < res.GetLength(0)) {
                if (p1.Y < p2.Y) {
                    for (int i = p1.Y; i < p2.Y && i < res.GetLength(1) && i > 0; i++) {
                        res[p1.X, i] = new PixV(PixV.block, color, parent);
                    }
                }
                if (p1.Y > p2.Y) {
                    for (int i = p2.Y; i <= p1.Y && i < res.GetLength(1) && i > 0; i++) {
                        res[p1.X, i] = new PixV(PixV.block, color, parent);
                    }
                }
            }
            // /-0C/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            else if (p1.X <= 0) {
                for (int i = 0; i < p2.X && i < res.GetLength(0); i++) {
                    if (Convert.ToInt32(q + m * (i)) > 1 && Convert.ToInt32(q + m * (i)) < res.GetLength(1)) {


                        res[i, Convert.ToInt32(q + m * (i))] = new PixV(PixV.block, color, parent);


                        if ((Math.Abs(Convert.ToInt32(q + m * (i)) - Convert.ToInt32(q + m * (i + 1))) >= 2) && Convert.ToInt32(q + m * (i + 1)) > 1 && Convert.ToInt32(q + m * (i + 1)) < res.GetLength(1) && Convert.ToInt32(q + m * (i - 1)) > 0 && Convert.ToInt32(q + m * (i - 1)) < res.GetLength(1)) {
                            if (m > 0) {
                                for (int h = 0; h < Math.Abs(Convert.ToInt32(q + m * (i)) - Convert.ToInt32(q + m * (i + 1))); h++) {
                                    res[i, Convert.ToInt32(q + m * (i + 1)) - h] = new PixV(PixV.block, color, parent);
                                }
                            }


                            else
                                for (int h = 0; h < Math.Abs(Convert.ToInt32(q + m * (i)) - Convert.ToInt32(q + m * (i + 1))); h++) {
                                    res[i, Convert.ToInt32(q + m * (i + 1)) + h] = new PixV(PixV.block, color, parent);
                                }

                        }
                    }

                }
            }


        }
        /// //////////////////////////////////////////////////////////////////////////////////////////////

        /// //////////////////////////////////////////////////////////////////////////////////////////////

        /// //////////////////////////////////////////////////////////////////////////////////////////////





        //custom shapes///////////////////////////////////////////////////////////////////////////////////////////////////////////


        public void AddShape(Shape shape, ConsoleColor color) {



            for (int i = 0; i < shape.Vertices - 1; i++) {
                AddLine(shape.GlobalVerticesArr[i]+(shape.Position), shape.GlobalVerticesArr[i + 1]+(shape.Position), color, shape);
            }
            AddLine(shape.GlobalVerticesArr[shape.Vertices - 1]+(shape.Position), shape.GlobalVerticesArr[0]+(shape.Position), color, shape);

            if (shape.Fill) {
                for (int i = 0; i < res.GetLength(1); i++) {
                    bool first = false;
                    for (int j = 0; j < res.GetLength(0); j++) {
                        if (res[j, i] != null && res[j, i].Parent == (object)shape) {
                            this.AddText(first.ToString(), new Vector2(10, 10), ConsoleColor.DarkRed, this);
                            first = !first;
                        }
                        if (first) {
                            res[j, i] = new PixV(PixV.block, color, shape);
                        }
                    }
                }
            }
        }


        //text//////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void AddText(string text, Vector2 pos, ConsoleColor color, object parent) {
            for (int tc = 0; tc < text.Length; tc++) {
                for (int i = 0; i < res.GetLength(1); i++) {
                    for (int j = 0; j < res.GetLength(0); j++) {
                        if (i == pos.Y && j == tc + pos.X) {

                            res[j, i] = new PixV(text.ToCharArray()[tc], color, parent);

                        }
                    }
                }
            }
        }


        public void AddTriangle(Triangle triangle) {
            for (int i = 0; i < 2; i++) {
                AddLine(triangle.ProjectedPoints[i], triangle.ProjectedPoints[i+1], triangle.color, triangle);
            }
            AddLine(triangle.ProjectedPoints[2], triangle.ProjectedPoints[0], triangle.color, triangle);
        }

        public void AddCube(Cube cube) {
            for (int i = 0; i < cube.triangles.Length; i++) {
                AddTriangle(cube.triangles[i].Shape.RefreshShape());
            }
        }

    }



    struct Shape {

        int vertices;
        public int Vertices {
            get { return vertices; }
        }

        Vector2 position;
        public Vector2 Position {
            get { return position; }
            set { position = value; }
        }

        Vector2[] localVerticesArr;
        public Vector2[] LocalVerticesArr {
            get { return localVerticesArr; }
        }

        Vector2[] globalVerticesArr;
        public Vector2[] GlobalVerticesArr {
            get { return globalVerticesArr; }
        }

        bool fill;
        public bool Fill {
            get { return fill; }
            set { fill = value; }
        }

        float rotation;
        public float Rotation {
            get {
                for (int i = 1; i < localVerticesArr.Length; i++) {
                    globalVerticesArr[i] = localVerticesArr[i].Rotate(rotation, localVerticesArr[0]);

                }
                return rotation;
            }
            set {
                rotation = value;
                for (int i = 1; i < localVerticesArr.Length; i++) {
                    globalVerticesArr[i] = (localVerticesArr[i]*size).Rotate(rotation, localVerticesArr[0]);

                }
            }
        }

        float size;
        public float Size {
            get {
                for (int i = 1; i < localVerticesArr.Length; i++) {
                    globalVerticesArr[i] = (localVerticesArr[i]*size).Rotate(rotation, localVerticesArr[0]);

                }
                return size;

            }
            set {
                size = value;
                for (int i = 1; i < localVerticesArr.Length; i++) {
                    globalVerticesArr[i] = (localVerticesArr[i]*size).Rotate(rotation, localVerticesArr[0]);

                }
            }
        }








        Vector2 down;
        public Vector2 Down {
            get {
                down.Y = 0;
                for (int i = 0; i < globalVerticesArr.Length; i++) {
                    if (globalVerticesArr[i].Y > down.Y) {
                        down = globalVerticesArr[i];

                    }
                }
                return down;
            }
        }

        Vector2 up;
        public Vector2 Up {
            get {
                up.Y = 50;

                for (int i = 0; i < globalVerticesArr.Length; i++) {
                    if (globalVerticesArr[i].Y < up.Y) {
                        up = globalVerticesArr[i];

                    }
                }
                return up;
            }
        }

        Vector2 left;
        public Vector2 Left {
            get {
                left.X = 450;

                for (int i = 0; i < globalVerticesArr.Length; i++) {
                    if (globalVerticesArr[i].X < left.X) {
                        left = globalVerticesArr[i];

                    }
                }
                return left;
            }
        }

        Vector2 right;
        public Vector2 Right {
            get {
                right.X = 0;
                for (int i = 0; i < globalVerticesArr.Length; i++) {
                    if (globalVerticesArr[i].X > right.X) {
                        right = globalVerticesArr[i];

                    }
                }
                return right;
            }
        }











        public Shape(Vector2[] localVerticesArr, Vector2 position, float rotation, float size, bool fill) {

            vertices = localVerticesArr.Length;
            this.localVerticesArr = localVerticesArr;
            this.position = position;
            this.rotation = rotation;
            globalVerticesArr = new Vector2[vertices];
            down = new Vector2(0, 0);
            up = new Vector2(0, 50);
            left = new Vector2(450, 0);
            right = new Vector2(0, 0);
            this.size = size;
            this.fill = fill;
            for (int i = 1; i < localVerticesArr.Length; i++) {
                globalVerticesArr[i] = localVerticesArr[i].Rotate(rotation, localVerticesArr[0]);

            }

        }




    }
}

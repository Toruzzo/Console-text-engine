using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Pix.Engine {
    class Cube {

        public float size;
        public Vector3 position;
        bool fill;
        public Vector3 rotation;
        public Triangle[] triangles = new Triangle[12];

        Vector3[] up1 = { new Vector3(0, 1, 1), new Vector3(1, 1, 1), new Vector3(1, 0, 1) };
        Vector3[] up2 = { new Vector3(0, 1, 1), new Vector3(0, 0, 1), new Vector3(1, 0, 1) };


        Vector3[] down1 = { new Vector3(0, 1, 0), new Vector3(1, 1, 0), new Vector3(1, 0, 0) };
        Vector3[] down2 = { new Vector3(0, 1, 0), new Vector3(0, 0, 0), new Vector3(1, 0, 0) };

        Vector3[] left1 = { new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(0, 0, 1) };
        Vector3[] left2 = { new Vector3(0, 0, 1), new Vector3(0, 1, 1), new Vector3(0, 1, 0) };

        Vector3[] right1 = { new Vector3(1, 0, 0), new Vector3(1, 1, 0), new Vector3(1, 0, 1) };
        Vector3[] right2 = { new Vector3(1, 0, 1), new Vector3(1, 1, 1), new Vector3(1, 1, 0) };

        Vector3[] back1 = { new Vector3(0, 0, 1), new Vector3(0, 1, 1), new Vector3(1, 1, 1) };
        Vector3[] back2 = { new Vector3(1, 1, 1), new Vector3(1, 0, 1), new Vector3(0, 0, 1) };

        Vector3[] front1 = { new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(1, 1, 0) };
        Vector3[] front2 = { new Vector3(1, 1, 0), new Vector3(1, 0, 0), new Vector3(0, 0, 0) };


        public Cube(Vector3 position, Vector3 rotation, bool fill, float size, ConsoleColor color) {



            this.position = position;
            this.size = size;
            this.rotation = rotation;
            this.fill = fill;


            Vector3[] up1 = { new Vector3(0, 1, 0) * size, new Vector3(1, 1, 0) * size, new Vector3(1, 1, 1) * size };
            Vector3[] up2 = { new Vector3(0, 1, 0) * size, new Vector3(0, 1, 1) * size, new Vector3(1, 1, 1) * size };


            Vector3[] down1 = { new Vector3(0, 0, 0) * size, new Vector3(1, 0, 0) * size, new Vector3(1, 0, 1) * size };
            Vector3[] down2 = { new Vector3(0, 0, 0) * size, new Vector3(0, 0, 1) * size, new Vector3(1, 0, 1) * size };

            Vector3[] left1 = { new Vector3(0, 0, 0) * size, new Vector3(0, 1, 0) * size, new Vector3(0, 0, 1) * size };
            Vector3[] left2 = { new Vector3(0, 0, 1) * size, new Vector3(0, 1, 1) * size, new Vector3(0, 1, 0) * size };

            Vector3[] right1 = { new Vector3(1, 0, 0) * size, new Vector3(1, 1, 0) * size, new Vector3(1, 0, 1) * size };
            Vector3[] right2 = { new Vector3(1, 0, 1) * size, new Vector3(1, 1, 1) * size, new Vector3(1, 1, 0) * size };

            Vector3[] back1 = { new Vector3(0, 0, 1) * size, new Vector3(0, 1, 1) * size, new Vector3(1, 1, 1) * size };
            Vector3[] back2 = { new Vector3(1, 1, 1) * size, new Vector3(1, 0, 1) * size, new Vector3(0, 0, 1) * size };

            Vector3[] front1 = { new Vector3(0, 0, 0) * size, new Vector3(0, 1, 0) * size, new Vector3(1, 1, 0) * size };
            Vector3[] front2 = { new Vector3(1, 1, 0) * size, new Vector3(1, 0, 0) * size, new Vector3(0, 0, 0) * size };


            triangles[0] = new Triangle(down1, position, rotation, position, color, fill).Shape.RefreshShape();
            triangles[1] = new Triangle(down2, position, rotation, position, color, fill).Shape.RefreshShape();
            triangles[2] = new Triangle(up1, position, rotation, position, color, fill).Shape.RefreshShape();
            triangles[3] = new Triangle(up2, position, rotation, position, color, fill).Shape.RefreshShape();
            triangles[4] = new Triangle(left1, position, rotation, position, color, fill).Shape.RefreshShape();
            triangles[5] = new Triangle(left2, position, rotation, position, color, fill).Shape.RefreshShape();
            triangles[6] = new Triangle(right1, position, rotation, position, color, fill).Shape.RefreshShape();
            triangles[7] = new Triangle(right2, position, rotation, position, color, fill).Shape.RefreshShape();
            triangles[8] = new Triangle(back1, position, rotation, position, color, fill).Shape.RefreshShape();
            triangles[9] = new Triangle(back2, position, rotation, position, color, fill).Shape.RefreshShape();
            triangles[10] = new Triangle(front1, position, rotation, position, color, fill).Shape.RefreshShape();
            triangles[11] = new Triangle(front2, position, rotation, position, color, fill).Shape.RefreshShape();



        }

        public void UpdateCube() {

            Vector3[] up1 = { new Vector3(0, 1, 0) * size, new Vector3(1, 1, 0) * size, new Vector3(1, 1, 1) * size };
            Vector3[] up2 = { new Vector3(0, 1, 0) * size, new Vector3(0, 1, 1) * size, new Vector3(1, 1, 1) * size };


            Vector3[] down1 = { new Vector3(0, 0, 0) * size, new Vector3(1, 0, 0) * size, new Vector3(1, 0, 1) * size };
            Vector3[] down2 = { new Vector3(0, 0, 0) * size, new Vector3(0, 0, 1) * size, new Vector3(1, 0, 1) * size };

            Vector3[] left1 = { new Vector3(0, 0, 0) * size, new Vector3(0, 1, 0) * size, new Vector3(0, 0, 1) * size };
            Vector3[] left2 = { new Vector3(0, 0, 1) * size, new Vector3(0, 1, 1) * size, new Vector3(0, 1, 0) * size };

            Vector3[] right1 = { new Vector3(1, 0, 0) * size, new Vector3(1, 1, 0) * size, new Vector3(1, 0, 1) * size };
            Vector3[] right2 = { new Vector3(1, 0, 1) * size, new Vector3(1, 1, 1) * size, new Vector3(1, 1, 0) * size };

            Vector3[] back1 = { new Vector3(0, 0, 1) * size, new Vector3(0, 1, 1) * size, new Vector3(1, 1, 1) * size };
            Vector3[] back2 = { new Vector3(1, 1, 1) * size, new Vector3(1, 0, 1) * size, new Vector3(0, 0, 1) * size };

            Vector3[] front1 = { new Vector3(0, 0, 0) * size, new Vector3(0, 1, 0) * size, new Vector3(1, 1, 0) * size };
            Vector3[] front2 = { new Vector3(1, 1, 0) * size, new Vector3(1, 0, 0) * size, new Vector3(0, 0, 0) * size };

            for (int i = 0; i < 12; i++) {


                triangles[i].rotation = this.rotation;
                triangles[i].Shape.RefreshShape();

            }

        }


    }
}

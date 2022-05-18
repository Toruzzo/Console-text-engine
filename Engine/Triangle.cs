using System;
using System.Collections.Generic;
using System.Text;

namespace Pix.Engine {
    class Triangle {

        public Vector3[] points3D = new Vector3[3];
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 origin;
        public ConsoleColor color;
        public bool fill;
        Vector2[] projectedPoints = new Vector2[3];
        Vector3[] traslatedPoints = new Vector3[3];
        public Vector3[] TranslatedPoints { get => traslatedPoints; }



        public Vector2[] ProjectedPoints { get => projectedPoints; }

        public Triangle(Vector3[] points3D, Vector3 position, Vector3 rotation, Vector3 origin, ConsoleColor color, bool fill) {

            this.points3D = points3D;
            this.position = position;
            this.rotation = rotation;
            this.color = color;
            this.fill = fill;
        }

        public Triangle RefreshShape() {

            for (int i = 0; i < points3D.Length; i++) {

                traslatedPoints[i] = points3D[i];

                traslatedPoints[i] = traslatedPoints[i].RotateX(rotation.X, origin);
                traslatedPoints[i] = traslatedPoints[i].RotateY(rotation.Y, origin);
                traslatedPoints[i] = traslatedPoints[i].RotateZ(rotation.Z, origin);

                traslatedPoints[i] += position -= Engine.camera.position;

                traslatedPoints[i] = traslatedPoints[i].RotateX(Engine.camera.rotation.X, Engine.camera.position).RotateY(Engine.camera.rotation.Y, Engine.camera.position).RotateZ(Engine.camera.rotation.Z, Engine.camera.position);


                projectedPoints[i] = traslatedPoints[i].GetProjectedPoint() + new Vector2(Engine.WindowSize.X, Engine.WindowSize.Y) * .5f;

            }

            return this;
        }

        public Triangle Shape {
            get {
                return new Triangle(points3D, position, rotation, origin, color, fill);
            }

        }
    }
}

using System;
using Pix.Engine;



namespace Pix {

    class Program : Engine.Engine{
        int off = 0;
        int x = 50;
        int y = 50;
        static Vector2[] points = { new Vector2(0, 0), new Vector2(0, 10), new Vector2(10, 10), new Vector2(10, 0) };
        Shape rect = new Shape(points, new Vector2(30, 30), 0f, 1f, false);

        Vector3[] tpoints = { new Vector3(0, 0, 0), new Vector3(50, 50, 0), new Vector3(0, 50, 0)};
        Triangle t;
        Triangle t2;
        Triangle t3;

       

        Cube c;
        public Program() : base(new Vector2(300, 300)) {
           
        }

        public override void Start() {
            t = new Triangle(tpoints, new Vector3(), Vector3.zero, tpoints[0], ConsoleColor.Red, false);
            t2 = new Triangle(tpoints, new Vector3(-50, -50, 10), Vector3.zero, tpoints[0], ConsoleColor.Green, false);
            t3 = new Triangle(tpoints, new Vector3(50, 50, -10), Vector3.zero, tpoints[0], ConsoleColor.Magenta, false);

            camera.position.Z = -100;
            t.RefreshShape();
            t2.RefreshShape();
            t3.RefreshShape();


        }

        public override void Update() {

            t.rotation.X+= .001f;
            t.position.Y += .001f;
            t.rotation.Z += .001f;

            t2.rotation.X += .001f;
            t2.rotation.Y += .001f;
            t2.rotation.Z += .001f;

            t3.rotation.X += .001f;
            t3.rotation.Y += .001f;
            t3.rotation.Z += .001f;

            //drawer.AddTriangle(t.Shape.RefreshShape());
            //drawer.AddTriangle(t2.Shape.RefreshShape());
            if(Input.GetKey(ConsoleKey.Spacebar)) drawer.AddTriangle(t3.Shape.RefreshShape());


        }

        static void Main(string[] args) {

            Program p = new Program(); 
        }
    }
}

using System;
using System.Text;
using System.IO;
using System.Threading;


namespace Pix {
    class Display {
        protected int height;
        protected int width;
        double fps;
        double max;
        double min = 40;
        double avg;
        int framesDis = 0;
        PixV[,] displayedMat;
        DateTime begbeg = DateTime.Now;


        public int Height {
            get { return height; }
            //set { height = value; }           
        }

        public int Width {
            get { return width; }
            //set { width = value; }
        }

        float deltaTime;
        public float DeltaTime {

            get { return deltaTime; }
        }

        public Display(int x, int y) {
            height = y;
            width = x;
            Console.Title = $"T-graphics engine -- (FPS : {fps})";
            Console.BackgroundColor = ConsoleColor.Black;
            displayedMat = new PixV[x, y];

            Console.SetWindowSize(width, (int)(height / 2));

            Console.SetBufferSize(width, (int)(height/2));

        }


        public void Draw(PixV[,] pixMatrix) {

            DateTime beg = DateTime.Now;

            Console.CursorVisible = false;

            Console.Title = $"T-graphics engine -- (FPS : {(int)fps}(Max: {(int)max} Min:{(int)min} Avg: {(int)avg}))";

            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < height-1; i+= 2) {
                for (int j = 0; j < width-1; j++) {
                    if (pixMatrix[j, i] != displayedMat[j, i] || pixMatrix[j, i+1] != displayedMat[j, i+1]) {
                        Console.SetCursorPosition(j, (int)(i/2));

                        if (pixMatrix[j, i] != null) {
                            Console.ForegroundColor = pixMatrix[j, i]._Color;
                        } else Console.ForegroundColor = ConsoleColor.Black;

                        if (pixMatrix[j, i+1] != null) {

                            Console.BackgroundColor = pixMatrix[j, i + 1]._Color;
                        }else Console.BackgroundColor = ConsoleColor.Black;

                       Console.Out.Write('\u2580');


                    }
                }


            }


            displayedMat = pixMatrix;
            deltaTime = Convert.ToSingle((DateTime.Now - beg).TotalSeconds);
            fps = 1 / deltaTime;
            avg = framesDis / (DateTime.Now - begbeg).TotalSeconds;
            if (fps > max) max = fps;
            if (fps < min) min = fps;
            framesDis++;
            Thread.Sleep(1);
        }

    }
}

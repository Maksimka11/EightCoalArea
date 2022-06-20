using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Math;

namespace EightCoalArea
{
    public class Area
    {
        //Переменные, в которых хранятся размеры фигуры и координаты ее вершин
        public double N, M, A_x, A_y, B_x, B_y, C_x, C_y, D_x, D_y, E_x, E_y, F_x, F_y, G_x, G_y, H_x, H_y;
        //Переменные для подсчета коэффицента размеров
        public double DefaultN, DefaultM;
        //Переменных, в которых хранятся коэффиценты координат вершин фигуры
        public double defA_x, defA_y, defB_x, defB_y, defC_x, defC_y, defD_x, defD_y, defE_x, defE_y, defF_x, defF_y, defG_x, defG_y, defH_x, defH_y;


        //Метод загрузки размеров и координат фигуры
        public void LoadFromFile()
        {
            //Указываем путь к файлу
            string path = @"Cords.txt";
            //Создаем экземпляр классу StreamReader
            StreamReader sr = new StreamReader(path, System.Text.Encoding.Default);

            //Считываем координаты вершин и размеры фигуры
            N = Convert.ToInt16(sr.ReadLine());
            M = Convert.ToInt16(sr.ReadLine());
            A_x = Convert.ToInt16(sr.ReadLine()); A_y = Convert.ToInt16(sr.ReadLine());
            B_x = Convert.ToInt16(sr.ReadLine()); B_y = Convert.ToInt16(sr.ReadLine());
            C_x = Convert.ToInt16(sr.ReadLine()); C_y = Convert.ToInt16(sr.ReadLine());
            D_x = Convert.ToInt16(sr.ReadLine()); D_y = Convert.ToInt16(sr.ReadLine());
            E_x = Convert.ToInt16(sr.ReadLine()); E_y = Convert.ToInt16(sr.ReadLine());
            F_x = Convert.ToInt16(sr.ReadLine()); F_y = Convert.ToInt16(sr.ReadLine());
            G_x = Convert.ToInt16(sr.ReadLine()); G_y = Convert.ToInt16(sr.ReadLine());
            H_x = Convert.ToInt16(sr.ReadLine()); H_y = Convert.ToInt16(sr.ReadLine());

            //Записываем коэффицент размеров фигуры
            DefaultN = 1 / N;
            DefaultM = 1 / M;

            //Записываем коэффиценты координат вершин фигуры
            defA_x = A_x * DefaultN; defA_y = A_y * DefaultM;
            defB_x = B_x * DefaultN; defB_y = B_y * DefaultM;
            defC_x = C_x * DefaultN; defC_y = C_y * DefaultM;
            defD_x = D_x * DefaultN; defD_y = D_y * DefaultM;
            defE_x = E_x * DefaultN; defE_y = E_y * DefaultM;
            defF_x = F_x * DefaultN; defF_y = F_y * DefaultM;
            defG_x = G_x * DefaultN; defG_y = G_y * DefaultM;
            defH_x = H_x * DefaultN; defH_y = H_y * DefaultM;
        }

        //Метод проверки принадлежность точки к фигуре
        public bool PointCheck(double x, double y)
        {
            //Проверка на принадлежность
            if (x >= A_x & x <= H_x & y <= B_y & y >= A_y | x >= C_x & x <= G_x & y >= C_y & y <= G_y | x >= D_x & x <= E_x & y <= D_y & y >= G_y) return true;
            else return false;
            
        }

        //Метод изменения размеров фигуры
        public void scaleChange(double newN,double newM)
        {
            //Записываем новые размеры фигуры
            N = newN;
            M = newM;
            //Записываем изменные координаты вершин фигуры
            A_x =N * defA_x ; A_y =N * defA_y ;
            B_x =N * defB_x ; B_y =N * defB_y ;
            C_x =N * defC_x ; C_y =N * defC_y ;
            D_x =N * defD_x ; D_y =N * defD_y ;
            E_x =N * defE_x ; E_y =N * defE_y ;
            F_x =N * defF_x ; F_y =N * defF_y ;
            G_x =N * defG_x ; G_y =N * defG_y ;
            H_x =N * defH_x ; H_y =N * defH_y ;
        }

        //Метод поворота фигру на заданный угол
        public void areaTurn(int Angle)
        {
            //Записываем промежуточные координаты
            double x = A_x;
            double y = A_y;
            //Высчитываем и записываем конечные координаты
            A_x = x* Cos(Angle) - y* Sin(Angle); A_y = Cos(Angle) * y + Sin(Angle) * x;
            x = B_x; y = B_y;
            B_x = x * Cos(Angle) - y * Sin(Angle); B_y = Cos(Angle) * y + Sin(Angle) * x;
            x = C_x; y = C_y;
            C_x = x * Cos(Angle) - y * Sin(Angle); C_y = Cos(Angle) * y + Sin(Angle) * x;
            x = D_x; y = D_y;
            D_x = x * Cos(Angle) - y * Sin(Angle); D_y = Cos(Angle) * y + Sin(Angle) * x;
            x = E_x; y = E_y;
            E_x = x * Cos(Angle) - y * Sin(Angle); E_y = Cos(Angle) * y + Sin(Angle) * x;
            x = F_x; y = F_y;
            F_x = x * Cos(Angle) - y * Sin(Angle); F_y = Cos(Angle) * y + Sin(Angle) * x;
            x = G_x; y = G_y;
            G_x = x * Cos(Angle) - y * Sin(Angle); G_y = Cos(Angle) * y + Sin(Angle) * x;
            x = H_x; y = H_y;
            H_x = x * Cos(Angle) - y * Sin(Angle); H_y = Cos(Angle) * y + Sin(Angle) * x;
        }

        //Метод нарисования фигуры
        public void DrawArea(PictureBox picture)
        {
            //Создаем экземпляр класса Pen черного цвета и размером толщиной 3
            Pen pen = new Pen(Color.Black, 3);

            //записываем координаты центра элемента управления
            int height = picture.Height/2;
            int width = picture.Width/2;
            
            //Создаем массив точек
            Point[] points =
            {
                new Point (Convert.ToInt16(A_x * N) + width,Convert.ToInt16(A_y * M)+height),
                new Point (Convert.ToInt16(B_x* N)+ width,Convert.ToInt16(B_y* M) +height),
                new Point (Convert.ToInt16(C_x* N) + width,Convert.ToInt16(C_y* M) +height),
                new Point (Convert.ToInt16(D_x* N) + width, Convert.ToInt16(D_y* M) +height),
                new Point (Convert.ToInt16(E_x* N) + width,Convert.ToInt16(E_y* M) +height),
                new Point (Convert.ToInt16(F_x* N) + width,Convert.ToInt16(F_y* M) +height),
                new Point (Convert.ToInt16(G_x* N) + width,Convert.ToInt16(G_y* M) +height),
                new Point (Convert.ToInt16(H_x* N) + width,Convert.ToInt16(H_y* M) +height),
                new Point (Convert.ToInt16(A_x * N) + width,Convert.ToInt16(A_y * M)+height)
            };

            //Создаем экземпляр класса BitMap с шириной и высотой элемента управления
            Bitmap bmp = new Bitmap(picture.Width, picture.Height);
            //Создаем экземпляр класса Graphics
            Graphics graph = Graphics.FromImage(bmp);
            //Рисуем фигуру
            graph.DrawLines(pen, points);
            //Загружаем полученную фигуру в элемент управления
            picture.Image = bmp;
        }

    }
}

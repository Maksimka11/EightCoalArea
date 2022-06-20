using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EightCoalArea
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Создаем экземпляр класса Area
        Area area = new Area();
        //Обработка загрузки формы
        private void Form1_Load(object sender, EventArgs e)
        {
            //Загружаем начальные координаты и размеры фигуры
            area.LoadFromFile();
            //Выводим значения на форму 
            LoadValues();
            //Рисуем фигуру
            area.DrawArea(pbArea);
        }

        //Обработка нажатия на кнопку btnCheck
        private void btnCheck_Click(object sender, EventArgs e)
        {
            //Записываем координаты точки
            double x = Convert.ToDouble(tbX.Text);
            double y = Convert.ToDouble(tbY.Text);

            //Вызываем метод проверки и выводим соответсвующее сообщение
            if (area.PointCheck(x, y)) MessageBox.Show("Точка принадлежит области");
            else MessageBox.Show("Точка не принадлежит области");
        }

        //Обработка нажатия на кнопку btnChangeScale
        private void btnChangeScale_Click(object sender, EventArgs e)
        {
            //Записываем новую ширину фигуры
            int newN = Convert.ToInt16(tbNewN.Text);
            //Если ширина меньше или равна 0, то выводим сообщение об ошибки и выходим из метода
            if(newN <= 0)
            {
                MessageBox.Show("Ширина фигуры не может быть меньше или равна нулю!");
                tbNewN.Focus();
                return;
            }
            //Записываем новую высоту фигуры
            int newM = Convert.ToInt16(tbNewM.Text);
            //Если высота меньше или равна 0, то выводим сообщение об ошибки и выходим из метода
            if (newM <= 0)
            {
                MessageBox.Show("Высота фигуры не может быть меньше или равна нулю!");
                tbNewM.Focus();
                return;
            }
            //Вызываем ментод изменения размеров
            area.scaleChange(newN, newM);
            //Загружаем значения на форму
            LoadValues();
            //Рисуем фигуру
            area.DrawArea(pbArea);
        }

        //Метод загрузки значений
        private void LoadValues()
        {
            //Выводим на форму значения размеров и координат вершин фигуры
            tbN.Text = area.N.ToString();
            tbM.Text = area.M.ToString();
            tbA_X.Text = area.A_x.ToString(); tbA_Y.Text = area.A_y.ToString();
            tbB_X.Text = area.B_x.ToString(); tbB_Y.Text = area.B_y.ToString();
            tbC_X.Text = area.C_x.ToString(); tbC_Y.Text = area.C_y.ToString();
            tbD_X.Text = area.D_x.ToString(); tbD_Y.Text = area.D_y.ToString();
            tbE_X.Text = area.E_x.ToString(); tbE_Y.Text = area.E_y.ToString();
            tbF_X.Text = area.F_x.ToString(); tbF_Y.Text = area.F_y.ToString();
            tbG_X.Text = area.G_x.ToString(); tbG_Y.Text = area.G_y.ToString();
            tbH_X.Text = area.H_x.ToString(); tbH_Y.Text = area.H_y.ToString();
        }

        //Обработка нажатия на кнопку btnTurn
        private void btnTurn_Click(object sender, EventArgs e)
        {
            //Записываем угол поворота
            int Angle = Convert.ToInt16(tbAngle.Text);
            //Вызываем метод поворота фигуры
            area.areaTurn(Angle);
            //Загружаем значения на форму
            LoadValues();
            //Рисуем фигуру
            area.DrawArea(pbArea);
        }

        //Обработка нажатия на кнопку btnClear
        private void btnClear_Click(object sender, EventArgs e)
        {
            //Загружаем данные из файла
            area.LoadFromFile();
            //Загружаем значения на форму
            LoadValues();
            //Рисуем фигуру
            area.DrawArea(pbArea);
        }
    }
}

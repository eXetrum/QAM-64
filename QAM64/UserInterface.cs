﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QAM64
{
    public partial class UserInterface : Form
    {
        const int M = 64;
        // Максимальное количество бит переносимое сигналом
        static int MAX_BITS_COUNT = (int)Math.Log(M, 2);
        // Количество точек
        static int DOTS_COUNT = (int)Math.Sqrt(M);
        // Размер сетки по "X"
        static int X_GRID_SIZE = (DOTS_COUNT / 2 + 1) * 2;
        // Размер сетки по "Y"
        static int Y_GRID_SIZE = (DOTS_COUNT / 2 + 1) * 2;
        // Отступы слева/српава
        const int offsetX = 10;
        // Отступы сверху/снизу
        const int offsetY = 10;
        // Радиус точек
        const int dotRadius = 6;
        // Длина засечек на осях
        const int axislinelen = 8;
        static int PERIOD_LENGTH = 360;

        Dictionary<string, Complex> ConstellationMap = new Dictionary<string, Complex>();
        Dictionary<Complex, string> InverseConstellationMap = new Dictionary<Complex, string>();

        Dictionary<Complex, Dictionary<float, float>> SignalMap = new Dictionary<Complex, Dictionary<float, float>>();

        Pen gridPen = new Pen(Color.LightBlue);
        Pen axisPen = new Pen(Color.Black);
        Pen signalPen = new Pen(Color.MediumOrchid);
        Bitmap ConstellationImg;

        char BinaryStrToChar(string binaryString)
        {
            if (binaryString.Length != 8) throw new Exception("Error string format");
            int value = 0;
            for(int i = binaryString.Length - 1; i >= 0; --i)
            {
                value |= (1 << (7 - i)) * (binaryString[i] - '0');
            }
            return (char)value;
        }

        public UserInterface()
        {
            InitializeComponent();
            ConstellationImg = new Bitmap(pbConstellation.Size.Width, pbConstellation.Size.Height);
            pbConstellation.Image = ConstellationImg;
        }

        private void UserInterface_Load(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(ConstellationImg);
            // Шрифт для текста
            System.Drawing.Font drawFontDots = new System.Drawing.Font("Arial", 8);
            System.Drawing.Font drawFontAxisTicks = new System.Drawing.Font("Calibri", 7, FontStyle.Italic);
            // Шрифт заглавных букв
            System.Drawing.Font drawFontAxes = new System.Drawing.Font("Arial", 14);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();

            int width = ConstellationImg.Size.Width;
            int height = ConstellationImg.Size.Height;            
            int X_STEP_SIZE = (width - offsetX * 2) / X_GRID_SIZE;
            int Y_STEP_SIZE = (height - offsetY * 2) / Y_GRID_SIZE;            
            // Сетка
            // Вертикальные линии
            for (int i = 0; i < X_GRID_SIZE + 1; ++i)
                g.DrawLine(gridPen, offsetX + X_STEP_SIZE * i, offsetY, offsetX + X_STEP_SIZE * i, offsetY + Y_STEP_SIZE * Y_GRID_SIZE);
            // Горизонтальные линии
            for (int i = 0; i < Y_GRID_SIZE + 1; ++i)
                g.DrawLine(gridPen, offsetX, offsetY + Y_STEP_SIZE * i, offsetX + X_STEP_SIZE * X_GRID_SIZE, offsetY + Y_STEP_SIZE * i);
            // Оси координат
            g.DrawLine(axisPen, 
                offsetX, offsetY + (Y_GRID_SIZE / 2) * Y_STEP_SIZE, 
                offsetX + X_GRID_SIZE * X_STEP_SIZE, offsetY + (Y_GRID_SIZE / 2) * Y_STEP_SIZE);
            g.DrawLine(axisPen,
                offsetX + (X_GRID_SIZE / 2) * X_STEP_SIZE, offsetY,
                offsetX + (X_GRID_SIZE / 2) * X_STEP_SIZE, offsetY + Y_GRID_SIZE * Y_STEP_SIZE);
            // Засечки на осях по горизонтали
            for (int i = 0; i < X_GRID_SIZE + 1; ++i)
            {
                // Шкала
                g.DrawLine(axisPen, offsetX + X_STEP_SIZE * i, offsetY + Y_GRID_SIZE / 2 * Y_STEP_SIZE - axislinelen, offsetX + X_STEP_SIZE * i, offsetY + Y_GRID_SIZE / 2 * Y_STEP_SIZE + axislinelen);
                float val = (i - X_GRID_SIZE / 2.0f) / 4.0f;                
                // Подпись шкалы
                g.DrawString(string.Format("{0:0.00}", val), drawFontAxisTicks, Brushes.Black, offsetX + X_STEP_SIZE * i - axislinelen, offsetY + Y_GRID_SIZE / 2 * Y_STEP_SIZE + axislinelen, drawFormat);
            }
            // Засечки на осях по вертикали
            for (int i = 0; i < Y_GRID_SIZE + 1; ++i)
            {
                // Засечка
                g.DrawLine(axisPen, offsetX + X_GRID_SIZE / 2 * X_STEP_SIZE - axislinelen, offsetY + Y_STEP_SIZE * i, offsetX + X_GRID_SIZE / 2 * X_STEP_SIZE + axislinelen, offsetY + Y_STEP_SIZE * i);
                float val = (Y_GRID_SIZE / 2.0f - i) / 4.0f;
                if (val != 0)
                {
                    // Подпись шкалы
                    g.DrawString(string.Format("{0:0.00}", val), drawFontAxisTicks, Brushes.Black,
                        offsetX + X_GRID_SIZE / 2 * X_STEP_SIZE + axislinelen,
                        offsetY + Y_STEP_SIZE * i - axislinelen / 2.0f, drawFormat);
                }
            }
            // Подпишем оси
            g.DrawString("Q", drawFontAxes, Brushes.Green, 
                (offsetX + X_GRID_SIZE * X_STEP_SIZE - X_STEP_SIZE / 5.5f),
                (offsetY + Y_GRID_SIZE / 2.0f * Y_STEP_SIZE - Y_STEP_SIZE / 1.5f), drawFormat);
            g.DrawString("I", drawFontAxes, Brushes.Green,
                (offsetX + X_GRID_SIZE / 2.0f * X_STEP_SIZE - X_STEP_SIZE / 2.0f),
                (offsetY ), drawFormat);
            // Отметим центр координат
            g.DrawEllipse(axisPen,
                offsetX + (X_GRID_SIZE / 2) * X_STEP_SIZE - dotRadius / 2,
                offsetY + (Y_GRID_SIZE / 2) * Y_STEP_SIZE - dotRadius / 2, dotRadius, dotRadius);
            g.FillEllipse(Brushes.Black, offsetX + (X_GRID_SIZE / 2) * X_STEP_SIZE - dotRadius / 2,
                offsetY + (Y_GRID_SIZE / 2) * Y_STEP_SIZE - dotRadius / 2, dotRadius, dotRadius);
            // Получаем узлы
            // 4 фазы по 4 амплитуды для каждой, всего 16 значений
            // 8 фаз с одинаковой амплитудой из группы "A" (первая от центральной линии), всего 8 значений
            // 8 фаз с одинаковой амплитудой из группы "B" (вторая от центральной линии), всего 8 значений
            // 8 фаз с по 2 амплитуды для каждой из группы "C" (третья от центральной линии), всего 16 значений
            // 8 фаз с одинаковой амплитудой из группы "D" (четвертая от центральной линии), всего 8 значений
            // 8 фаз с одинаковой амплитудой из группы "E" (самые близкие линии к осям), всего 8 значений
            int binaryInt = 0;
            // Используем значения от -1 до +1
            for (int x = 0; x <= DOTS_COUNT; ++x)
            {
                double I = (x - DOTS_COUNT / 2) / 4.0;
                // Не учитываем нулевые компоненты
                if (I == 0) continue;
                for (int y = 0; y <= DOTS_COUNT; ++y)
                {
                    double Q = (y - DOTS_COUNT / 2) / 4.0;
                    // Не учитываем нулевые компоненты
                    if (Q == 0) continue;
                    // Получаем битовое представление очередного числа
                    string binaryString = Convert.ToString(binaryInt, 2);
                    // Следующее число
                    ++binaryInt;
                    Complex Z = new Complex(I, Q);
                    // Заносим в словарь пары ключ : значение, где ключ - битовая строка, а значение комплексное число
                    ConstellationMap.Add
                    (
                        binaryString.PadLeft(6, '0'),
                        new Complex(I, Q)
                    );
                    InverseConstellationMap.Add
                    (
                        new Complex(I, Q),
                        binaryString.PadLeft(6, '0')
                    );
                    SignalMap.Add
                    (
                        new Complex(I, Q),
                        Complex.GenerateSignal(new Complex(I, Q))
                    );
                }
            }
            // Рисуем сетку точек
            foreach (var binaryValue in ConstellationMap.Keys)
            {
                Complex Z = ConstellationMap[binaryValue];
                // Рисуем круг
                g.DrawEllipse(axisPen, 
                    (int)(offsetX + X_GRID_SIZE / 2 * X_STEP_SIZE + Z.Re * 4 * X_STEP_SIZE) - dotRadius / 2, 
                    (int)(offsetY + Y_GRID_SIZE / 2 * Y_STEP_SIZE - Z.Im * 4 * Y_STEP_SIZE) - dotRadius / 2, 
                    dotRadius, dotRadius);
                // Закрашиваем его чтобы получилась "точка"
                g.FillEllipse(Brushes.Brown, 
                    (int)(offsetX + X_GRID_SIZE / 2 * X_STEP_SIZE + Z.Re * 4 * X_STEP_SIZE) - dotRadius / 2, 
                    (int)(offsetY + Y_GRID_SIZE / 2 * Y_STEP_SIZE - Z.Im * 4 * Y_STEP_SIZE) - dotRadius / 2,
                    dotRadius, dotRadius);
                // Битовая подпись                
                g.DrawString(binaryValue, drawFontDots, drawBrush, 
                    (int)(offsetX + X_GRID_SIZE / 2 * X_STEP_SIZE + Z.Re * 4 * X_STEP_SIZE) - X_STEP_SIZE / 3,
                    (int)(offsetY + Y_GRID_SIZE / 2 * Y_STEP_SIZE - Z.Im * 4 * Y_STEP_SIZE) - Y_STEP_SIZE / 3, 
                    drawFormat);
            }
            // Отладочный вывод
            foreach (var key in ConstellationMap.Keys)
            {
                Complex entry = ConstellationMap[key];
                logBox.AppendText(key + "    " + string.Format("{0:0.0}    {1:0.00}    {2}    {3}", entry.Phase, entry.Amplitude, entry.Re, entry.Im) + Environment.NewLine);
            }
            logBox.AppendText(ConstellationMap.Count.ToString() + Environment.NewLine);
            // Заносим изображение в контейнер
            pbConstellation.Image = ConstellationImg;
            // Освобождаем ресурсы
            drawFontDots.Dispose();
            drawFontAxes.Dispose();
            drawBrush.Dispose();
            g.Dispose(); 
        }
        private void btnSendData_Click(object sender, EventArgs e)
        {
            //////////////////////////////////////////////////////
            ///
            /// Генерируем последовательность для передачи данных
            ///
            //////////////////////////////////////////////////////
            List<KeyValuePair<float, float>> generatedSignal = new List<KeyValuePair<float, float>>();
            string signalString = txtBoxInputBits.Text;
            // Выравниваем длину строки до кратности MAX_BITS_COUNT
            if(signalString.Length % MAX_BITS_COUNT != 0)
            {
                // Добавляем нули вперед строки
                signalString += new string('0', MAX_BITS_COUNT - signalString.Length % MAX_BITS_COUNT);
            }
            // Определяем количество сигналов необходимых для передачи всей битовой последовательности
            int chunksCount = signalString.Length / MAX_BITS_COUNT;
            int noisedOffset = 0;
            if (chBoxNoise.Checked) noisedOffset = 20;

            generatedSignal.Clear();
            for (int chunk = 0; chunk < chunksCount; ++chunk)
            {
                Complex Z = ConstellationMap[signalString.Substring(chunk * MAX_BITS_COUNT, MAX_BITS_COUNT)];
                if (chBoxNoise.Checked)
                    generatedSignal.AddRange(Complex.GenerateNoiseSignal(Complex.GenerateSignal(Z)));
                else
                    generatedSignal.AddRange(Complex.GenerateSignal(Z));
            }

            // Находим макс/мин амплитуды сигнала
            double minAmp = Double.MaxValue;
            double maxAmp = -Double.MaxValue;
            foreach(var pair in generatedSignal)
            {
                float amp = pair.Value;
                if (minAmp > amp) minAmp = amp;
                if (maxAmp < amp) maxAmp = amp;
            }
            //
            double ampLength = Math.Abs(minAmp - maxAmp);

            pbSignal.Image = null;
            Bitmap signalBmp = new Bitmap(pbSignal.Size.Width, pbSignal.Size.Height);
            Graphics gg = Graphics.FromImage(signalBmp);
            float SIGNAL_MAX_WIDTH = pbSignal.Size.Width - offsetX * 2;
            float SIGNAL_MAX_HEIGHT = pbSignal.Size.Height - offsetY * 2;
            float PART_SIZE = (float)(SIGNAL_MAX_WIDTH / chunksCount);
            float X_SCALE_FACTOR = (float)(PART_SIZE / PERIOD_LENGTH);
            float Y_SCALE_FACTOR = (float)Math.Round((SIGNAL_MAX_HEIGHT + offsetY) / ampLength);

            //DrawSignalGrid(ref gg, SIGNAL_MAX_WIDTH, SIGNAL_MAX_HEIGHT + offsetY * 2 + 8, chunksCount);
            ////////////////////////////////////////////////////////////////////////////////////////////
            float X_GRID_SIZE = 24 * chunksCount; // 24 отрезка по 15 градусов
            float Y_GRID_SIZE = DOTS_COUNT;
            float X_STEP_SIZE = (SIGNAL_MAX_WIDTH ) / X_GRID_SIZE;
            float Y_STEP_SIZE = (SIGNAL_MAX_HEIGHT ) / Y_GRID_SIZE;
            // Сетка
            // Вертикальные линии
            for (int i = 0; i < X_GRID_SIZE + 1; ++i)
                gg.DrawLine(gridPen, offsetX + X_STEP_SIZE * i, offsetY, offsetX + X_STEP_SIZE * i, offsetY + Y_STEP_SIZE * Y_GRID_SIZE);
            // Горизонтальные линии
            for (int i = 0; i < Y_GRID_SIZE + 1; ++i)
                gg.DrawLine(gridPen, offsetX, offsetY + Y_STEP_SIZE * i, offsetX + X_STEP_SIZE * X_GRID_SIZE, offsetY + Y_STEP_SIZE * i);

            gg.DrawLine(Pens.Black, offsetX, offsetY + SIGNAL_MAX_HEIGHT / 2, offsetX + X_GRID_SIZE * X_STEP_SIZE, offsetY + SIGNAL_MAX_HEIGHT / 2);
            gg.DrawLine(Pens.Black, offsetX, offsetY, offsetX, offsetY + Y_GRID_SIZE * Y_STEP_SIZE);
            ////////////////////////////////////////////////////////////////////////////////////////////
            float prevX = 0;
            float prevY = 0;
            int quadr = 0;
            int chunkNumber = 0;

            foreach (var v in generatedSignal)
            {
                float x = v.Key;
                float y = v.Value;
                if (quadr != 0 && quadr % PERIOD_LENGTH == 0)
                {
                    chunkNumber++;
                    gg.DrawLine(signalPen,
                        offsetX + ((chunkNumber - 1) * PART_SIZE) + prevX * X_SCALE_FACTOR,
                        SIGNAL_MAX_HEIGHT / 2.0f - ((float)prevY * Y_SCALE_FACTOR) + offsetY + noisedOffset,
                        offsetX + (chunkNumber * PART_SIZE) + x * X_SCALE_FACTOR,
                        SIGNAL_MAX_HEIGHT / 2.0f - ((float)y * Y_SCALE_FACTOR) + offsetY + noisedOffset
                        );
                }
                else { 
                    gg.DrawLine(signalPen,
                        offsetX + (chunkNumber * PART_SIZE) + prevX * X_SCALE_FACTOR,
                        SIGNAL_MAX_HEIGHT / 2.0f - ((float)prevY * Y_SCALE_FACTOR) + offsetY + noisedOffset,
                        offsetX + (chunkNumber * PART_SIZE) + x * X_SCALE_FACTOR,
                        SIGNAL_MAX_HEIGHT / 2.0f - ((float)y * Y_SCALE_FACTOR) + offsetY + noisedOffset
                        );
                }
                prevX = x;
                prevY = y;
                
                ++quadr;                
                /*gg.DrawEllipse(signalPen, 
                    offsetX + (chunk * PART_SIZE) + x * X_SCALE_FACTOR, 
                    offsetY + SIGNAL_MAX_HEIGHT / 2.0f - ((float)y * Y_SCALE_FACTOR), 
                    dotRadius / 4.0f, dotRadius / 4.0f);*/
            }


            pbSignal.Image = signalBmp;
            gg.Dispose();

            //////////////////////////////////////////////////////
            ///
            /// Принимаем данные
            ///
            //////////////////////////////////////////////////////
            txtBoxMessageOut.Clear();
            txtBoxOutputBits.Clear();
            float[] signalValues = generatedSignal.Select(d => d.Value).ToArray();
            
            for(int chunk = 0; chunk < chunksCount; ++chunk)
            {
                double minDif = double.MaxValue;
                float[] curSignalPart = new float[PERIOD_LENGTH];
                Array.Copy(signalValues, chunk * PERIOD_LENGTH, curSignalPart, 0, PERIOD_LENGTH);
                Complex candidate = null;
                foreach(var pair in SignalMap)
                {
                    Complex Z = pair.Key;
                    if (candidate == null)
                    {
                        candidate = Z;
                        continue;
                    }
                    else
                    {
                        float[] candidateSignal = pair.Value.Select(d => d.Value).ToArray();
                        double signalDiff = Complex.SignalsDiff(curSignalPart, candidateSignal);
                        if(minDif > signalDiff)
                        {
                            candidate = Z;
                            minDif = signalDiff;
                        }
                    }
                    
                }
                string binary = InverseConstellationMap[candidate];
                txtBoxOutputBits.AppendText(binary);
            }
            string binSeq = txtBoxOutputBits.Text;
            if (binSeq.Length % 8 != 0)
            {
                binSeq = binSeq.Substring(binSeq.Length % 8);
            }
            int charCount = binSeq.Length / 8;
            StringBuilder msg = new StringBuilder();
            for(int c = 0; c < charCount; ++c)
            {
                string curPart = binSeq.Substring(c * 8, 8);
                char curChar = BinaryStrToChar(curPart);
                msg.Append(curChar);
            }
            txtBoxMessageOut.Text = msg.ToString();
        }

        private void txtBoxInputBits_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x08) return;
            if (e.KeyChar == 0x0d && txtBoxInputBits.TextLength > 0) btnSendData_Click(sender, e);
            if (e.KeyChar != '0' && e.KeyChar != '1')
            {
                e.Handled = true;
                return;
            }
        }

        private void txtBoxInputBits_TextChanged(object sender, EventArgs e)
        {
            btnSendData.Enabled = txtBoxInputBits.TextLength > 0;
        }

        private void txtBoxMessage_TextChanged(object sender, EventArgs e)
        {
            string message = txtBoxMessageInp.Text;
            StringBuilder bitSequence = new StringBuilder();
            txtBoxInputBits.Clear();
            for (int i = 0; i < message.Length; ++i)
            {
                int charCode = (int)message[i];
                bitSequence.Append(Convert.ToString(charCode, 2).PadLeft(8, '0'));
            }
            // Выравниваем длину строки до кратности MAX_BITS_COUNT
            if (bitSequence.Length % MAX_BITS_COUNT != 0)
            {
                // Добавляем нули вперед строки
                bitSequence.Insert(0, new string('0', MAX_BITS_COUNT - bitSequence.Length % MAX_BITS_COUNT));
            }
            txtBoxInputBits.Text = bitSequence.ToString();
        }

        private void txtBoxMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x0d && txtBoxMessageInp.TextLength > 0)
            {
                btnSendData_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}

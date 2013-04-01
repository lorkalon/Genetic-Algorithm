using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    class EntitiesDrawer
    {
        private static Bitmap canvas;

        private static Size illustrationCanvasSize;

        private static SearchArea searchArea;

        private static int dashesCount = 9;

        public static Bitmap DrawEntities(List<IEntity> entities)
        {
            searchArea = GetAreaSize();
            if (canvas == null)
            {
                InitializeCanvas();
            }
            DrawCS();
            PaintEntities(entities);
            return canvas;
        }

        public static void ClearCanvas()
        {
            canvas = null;
        }

        private static void PaintEntities(List<IEntity> entities)
        {
            Graphics drawer = Graphics.FromImage(canvas);
            drawer.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (var entity in entities)
            {
                DrawEntity(drawer, entity);
            }
        }

        private static void DrawEntity(Graphics drawer, IEntity entity)
        {
            int pointRadius = 5;
            Point windowCoordinates = TranslateToWindowCoordinates(entity.RealLocation);
            drawer.FillEllipse(Brushes.Red, windowCoordinates.X - pointRadius, windowCoordinates.Y - pointRadius, 2 * pointRadius, 2 * pointRadius);
        }

        private static Point TranslateToWindowCoordinates(PointF realCoordiantes)
        {
            double xRatio = illustrationCanvasSize.Width / (searchArea.RightBorder - searchArea.LeftBorder);
            double yRatio = illustrationCanvasSize.Height / (searchArea.TopBorder - searchArea.BottomBorder);
            int windowX = (int)(realCoordiantes.X * xRatio);
            int windowY = (int)(illustrationCanvasSize.Height - realCoordiantes.Y * yRatio);

            return new Point(windowX, windowY);
        }

        private static void DrawCS()
        {
            Graphics drawer = Graphics.FromImage(canvas);
            drawer.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            drawer.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            drawer.FillRectangle(Brushes.WhiteSmoke, new Rectangle(0, 0, illustrationCanvasSize.Width, illustrationCanvasSize.Height));

            double windowX = 0;
            double windowY = 0;
            double windowStepX = illustrationCanvasSize.Width / (dashesCount - 1);
            double windowStepY = illustrationCanvasSize.Height / (dashesCount - 1);
            double realX = searchArea.LeftBorder;
            double realY = searchArea.TopBorder;
            double realStepX = (searchArea.RightBorder - searchArea.LeftBorder) / (dashesCount - 1);
            double realStepY = (searchArea.TopBorder - searchArea.BottomBorder) / (dashesCount - 1);
            
            for (int i = 0; i < dashesCount; i++)
            {
                drawer.DrawString(Convert.ToString(realX), new Font("Arial", 7), Brushes.Black, (int)windowX + 4, illustrationCanvasSize.Height - 15);
                drawer.DrawLine(new Pen(Brushes.Black, 1), new Point((int)windowX, 0), new Point((int)windowX, illustrationCanvasSize.Height));
                windowX += windowStepX;
                realX += realStepX;
            }
            drawer.DrawLine(new Pen(Brushes.Black, 1), new Point(illustrationCanvasSize.Width-1, 0), new Point(illustrationCanvasSize.Width-1, illustrationCanvasSize.Height));
            for (int i = 0; i < dashesCount; i++)
            {
                drawer.DrawString(Convert.ToString(realY), new Font("Arial", 7), Brushes.Black, 4, (int)windowY - 15);
                drawer.DrawLine(new Pen(Brushes.Black, 1), new Point(0, (int)windowY), new Point(illustrationCanvasSize.Width, (int)windowY));
                windowY += windowStepY;
                realY -= realStepY;
            }
            drawer.DrawLine(new Pen(Brushes.Black, 1), new Point(0, illustrationCanvasSize.Height - 1), new Point(illustrationCanvasSize.Width, illustrationCanvasSize.Height - 1));

            drawer.DrawString("X", new Font("Arial", 8), Brushes.Black, illustrationCanvasSize.Width - 14, illustrationCanvasSize.Height - 15);
            drawer.DrawString("Y", new Font("Arial", 8), Brushes.Black, 4, 6);
        }

        private static void InitializeCanvas()
        {
            int illustrationCanvasWidth = Convert.ToInt32(ConfigurationSettings.AppSettings.GetValues("illustrationCanvasWidth")[0]);
            int illustrationCanvasHeigth = Convert.ToInt32(ConfigurationSettings.AppSettings.GetValues("illustrationCanvasHeigth")[0]);
            canvas = new Bitmap(illustrationCanvasWidth, illustrationCanvasHeigth);
            illustrationCanvasSize = new Size(illustrationCanvasWidth, illustrationCanvasHeigth);
        }

        private static SearchArea GetAreaSize()
        {
            int serchAreaLeftBorder = Convert.ToInt32(ConfigurationSettings.AppSettings.GetValues("serchAreaLeftBorder")[0]);
            int serchAreaRightBorder = Convert.ToInt32(ConfigurationSettings.AppSettings.GetValues("serchAreaRightBorder")[0]);
            int serchAreaBottomBorder = Convert.ToInt32(ConfigurationSettings.AppSettings.GetValues("serchAreaBottomBorder")[0]);
            int serchAreaTopBorder = Convert.ToInt32(ConfigurationSettings.AppSettings.GetValues("serchAreaTopBorder")[0]);
            SearchArea searchAreaSize = new SearchArea(serchAreaLeftBorder, serchAreaRightBorder, serchAreaBottomBorder, serchAreaTopBorder);
            return searchAreaSize;
        }
    }
}

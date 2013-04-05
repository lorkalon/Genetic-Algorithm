using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;

namespace GeneticAlgoritm
{
    class EntitiesDrawer
    {
        private static Graphics drawer;

        private static Bitmap canvas;

        private static Size illustrationCanvasSize;

        private static SearchArea searchArea;

        private static int dashesCount = 9;

        private static int transparensy = 150;

        public static Bitmap DrawEntities(List<IEntity> entities, EntityTypes type)
        {
            searchArea = GetAreaSize();
            if (canvas == null)
            {
                InitializeCanvas();
                InitializeDrawer();
                DrawCS();
            }
            PaintEntities(entities, type);
            return canvas;
        }

        public static void ClearCanvas()
        {
            canvas = null;
        }

        private static void PaintEntities(List<IEntity> entities, EntityTypes type)
        {
            foreach (var entity in entities)
            {
                DrawEntity(entity, type);
            }
        }

        public static Bitmap DrawLegend()
        {
            const int legendWidth = 200;
            const int legendHeight = 200;
            Bitmap legendCanvas = new Bitmap(legendWidth, legendHeight);
            Graphics drawer = Graphics.FromImage(legendCanvas);
            drawer.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            drawer.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            drawer.Clear(SystemColors.Control);

            var entityColorConformity = EntityCustomizer.GetEntityColorConformity();
            Point location = new Point(40, 30);
            foreach (var entityColor in entityColorConformity)
            {
                DrawLegendItem(entityColor, location, drawer);
                location.Y += 22;
            }
            return legendCanvas;
        }

        private static void DrawLegendItem(KeyValuePair<EntityTypes, Color> entityColor,Point position, Graphics drawer)
        {
            Color color = entityColor.Value;

            int outerRadius = entityColor.Key == EntityTypes.BestEntity ? 9 : 7;
            SolidBrush outerBrush = MakeSemiTransparentBrush(color);
            drawer.FillEllipse(outerBrush, position.X - outerRadius, position.Y - outerRadius, 2 * outerRadius, 2 * outerRadius);

            int innerRadius = 5;
            SolidBrush innerBrush = MakeSemiTransparentBrush(Color.White);
            drawer.FillEllipse(innerBrush, position.X - innerRadius, position.Y - innerRadius, 2 * innerRadius, 2 * innerRadius);

            drawer.DrawString(FormatedEntityType(entityColor.Key), new Font("Arial", 8), Brushes.Black, position.X + 15, position.Y - 6);
        }

        private static String FormatedEntityType(EntityTypes type)
        {
            String formatedEntityType = type.ToString();
            foreach (char symbol in formatedEntityType)
            {
                StringBuilder sd = new StringBuilder();
            }
            return formatedEntityType;
        }
        public static Bitmap DrawBestResult(List<IEntity> entities)
        {
            if (entities.Count != 0)
            {
                var bestEntity = entities.MaxBy(e => e.F1);
                drawer.DrawString(String.Format("{0:0.00} {1:0.00} {2:0.00}", bestEntity.F1, bestEntity.RealLocation.X, bestEntity.RealLocation.Y), new Font("Arial", 7), Brushes.Black, 4, 15);
            }
            return canvas;
        }

        private static void DrawEntity(IEntity entity, EntityTypes type)
        {
            Point windowCoordinates = TranslateToWindowCoordinates(entity.RealLocation);
            Color color = EntityCustomizer.GetEntityColor(type);

            int outerRadius = type == EntityTypes.BestEntity ? 9 : 7;
            SolidBrush outerBrush = MakeSemiTransparentBrush(color);
            drawer.FillEllipse(outerBrush, windowCoordinates.X - outerRadius, windowCoordinates.Y - outerRadius, 2 * outerRadius, 2 * outerRadius);

            int innerRadius = 5;
            SolidBrush innerBrush = MakeSemiTransparentBrush(Color.White);
            drawer.FillEllipse(innerBrush, windowCoordinates.X - innerRadius, windowCoordinates.Y - innerRadius, 2 * innerRadius, 2 * innerRadius);
        }

        private static SolidBrush MakeSemiTransparentBrush(Color color)
        {
            Color semiTransparentColor = Color.FromArgb(transparensy, color);
            SolidBrush semiTransparentBrush = new SolidBrush(semiTransparentColor);
            return semiTransparentBrush;
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
            drawer.Clear(Color.WhiteSmoke);

            double windowX = 0;
            double windowY = illustrationCanvasSize.Height;
            double windowStepX = illustrationCanvasSize.Width / (dashesCount - 1);
            double windowStepY = illustrationCanvasSize.Height / (dashesCount - 1);
            double realX = searchArea.LeftBorder;
            double realY = 0;
            double realStepX = (searchArea.RightBorder - searchArea.LeftBorder) / (dashesCount - 1);
            double realStepY = (searchArea.TopBorder - searchArea.BottomBorder) / (dashesCount - 1);

            int illustrationCanvasHeight = illustrationCanvasSize.Height;
            int illustrationCanvasWidth = illustrationCanvasSize.Width;
            
            for (int i = 0; i < dashesCount; i++)
            {
                drawer.DrawString(String.Format("{0:0.00}", realX), new Font("Arial", 7), Brushes.Black, (int)windowX + 4, illustrationCanvasHeight - 15);
                drawer.DrawLine(Pens.Black, new Point((int)windowX, 0), new Point((int)windowX, illustrationCanvasHeight));
                windowX += windowStepX;
                realX += realStepX;
            }
            drawer.DrawLine(Pens.Black, new Point(illustrationCanvasWidth - 1, 0), new Point(illustrationCanvasWidth - 1, illustrationCanvasHeight));
            for (int i = 0; i < dashesCount; i++)
            {
                drawer.DrawString(String.Format("{0:0.00}", realY), new Font("Arial", 7), Brushes.Black, 4, (int)windowY - 15);
                drawer.DrawLine(Pens.Black, new Point(0, (int)windowY), new Point(illustrationCanvasWidth, (int)windowY));
                windowY -= windowStepY;
                realY += realStepY;
            }
            drawer.DrawLine(Pens.Black, new Point(0, illustrationCanvasHeight - 1), new Point(illustrationCanvasWidth, illustrationCanvasHeight - 1));

            drawer.DrawString("X", new Font("Arial", 8), Brushes.Black, illustrationCanvasWidth - 14, illustrationCanvasHeight - 15);
            drawer.DrawString("Y", new Font("Arial", 8), Brushes.Black, 4, 6);
        }

        private static void InitializeCanvas()
        {
            int illustrationCanvasWidth = Convert.ToInt32(ConfigurationSettings.AppSettings.GetValues("illustrationCanvasWidth")[0]);
            int illustrationCanvasHeigth = Convert.ToInt32(ConfigurationSettings.AppSettings.GetValues("illustrationCanvasHeigth")[0]);
            canvas = new Bitmap(illustrationCanvasWidth, illustrationCanvasHeigth);
            illustrationCanvasSize = new Size(illustrationCanvasWidth, illustrationCanvasHeigth);
        }

        private static void InitializeDrawer()
        {
            if (canvas == null)
            {
                throw new Exception("Canvas do not initialize.");
            }
            drawer = Graphics.FromImage(canvas);
            drawer.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            drawer.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
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

﻿using System;
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

        private static int currentEntityNumber;


        public static void DrawEntities(List<IEntity> entities, EntityTypes type)
        {
            if (canvas == null)
            {
                InitializeStuff();
                InitializeCanvas();
                InitializeDrawer();
                DrawCS();
            }
            PaintEntities(entities, type);
        }

        public static void DrawEntities(Dictionary<EntityTypes, List<IEntity>> statistic)
        {
            if (canvas == null)
            {
                InitializeStuff();
                InitializeCanvas();
                InitializeDrawer();
                DrawCS();
            }
            PaintEntities(statistic);
        }

        public static Bitmap DrawLegend()
        {
            const int legendWidth = 200;
            const int legendHeight = 200;
            Bitmap legendCanvas = new Bitmap(legendWidth, legendHeight);
            drawer = Graphics.FromImage(legendCanvas);
            drawer.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            drawer.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            drawer.Clear(SystemColors.Control);

            var entityColorConformity = EntityCustomizer.GetEntityColorConformity();
            Point location = new Point(40, 20);
            foreach (var entityColorForType in entityColorConformity)
            {
                DrawLegendItem(entityColorForType, location, drawer);
                location.Y += 25;
            }
            return legendCanvas;
        }

        public static void ClearCanvas()
        {
            canvas = null;
        }

        public static Bitmap GetIllustrationCanvas()
        {
            return canvas;
        }

        public static void DrawBestResult(List<IEntity> entities)
        {
            if (entities.Count != 0 && canvas != null)
            {
                var bestEntity = entities.MaxBy(e => e.F1);
                drawer.DrawString(String.Format("{0:0.00} {1:0.00} {2:0.00}", bestEntity.F1, bestEntity.RealLocation.X, bestEntity.RealLocation.Y), new Font("Arial", 7), Brushes.Black, illustrationCanvasSize.Width - 70, 10);
            }
        }

        private delegate void DrawEntityDelegate(Point windowCoordinates, EntityTypes type, int? index = null);
        
        private static void PaintEntities(List<IEntity> entities, EntityTypes type)
        {
            DrawEntityDelegate PaintEntity = DrawEntity;
            if (type == EntityTypes.BestEntity || type == EntityTypes.SelectedEntity)
            {
                PaintEntity = DrawLeadingEntity;
            }
            foreach (var entity in entities)
            {
                Point windowCoordinates = TranslateToWindowCoordinates(entity.RealLocation);
                PaintEntity(windowCoordinates, type, currentEntityNumber);
            }
        }

        private static void PaintEntities(Dictionary<EntityTypes, List<IEntity>> statistic)
        {
            foreach (var types in statistic)
            {
                EntityTypes type = types.Key;
                List<IEntity> entities = types.Value;
                DrawEntityDelegate PaintEntity = DrawEntity;
                if (type == EntityTypes.BestEntity || type == EntityTypes.SelectedEntity)
                {
                    PaintEntity = DrawLeadingEntity;
                }
                foreach (var entity in entities)
                {
                    Point windowCoordinates = TranslateToWindowCoordinates(entity.RealLocation);
                    PaintEntity(windowCoordinates, type, currentEntityNumber);
                }
            }
        }

        private static void DrawLegendItem(KeyValuePair<EntityTypes, Color> entityColorForType, Point position, Graphics drawer)
        {
            if (entityColorForType.Key == EntityTypes.BestEntity || entityColorForType.Key == EntityTypes.SelectedEntity)
            {
                DrawEntity(position, EntityTypes.UsualEntity);
                DrawLeadingEntity(position, entityColorForType.Key);
            }
            else
            {
                DrawEntity(position, entityColorForType.Key);
            }

            drawer.DrawString(AddSpacesToSentence(entityColorForType.Key.ToString()), new Font("Arial", 8), Brushes.Black, position.X + 16, position.Y - 7);
        }

        private static String AddSpacesToSentence(String text)
        {
            if (String.IsNullOrWhiteSpace(text))
            {
                return String.Empty;
            }
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (Char.IsUpper(text[i]) && text[i - 1] != ' ')
                {
                    newText.Append(' ');
                }
                newText.Append(text[i]);
            }
            return newText.ToString();
        }

        private static void DrawEntity(Point windowCoordinates, EntityTypes type, int? index = null)
        {
            Color color = EntityCustomizer.GetEntityColor(type);

            int outerRadius = 10;
            SolidBrush outerBrush = new SolidBrush(color);
            drawer.FillEllipse(outerBrush, windowCoordinates.X - outerRadius, windowCoordinates.Y - outerRadius, 2 * outerRadius, 2 * outerRadius);

            int innerRadius = 8;
            SolidBrush innerBrush = new SolidBrush(Color.White);
            drawer.FillEllipse(innerBrush, windowCoordinates.X - innerRadius, windowCoordinates.Y - innerRadius, 2 * innerRadius, 2 * innerRadius);

            DrawEntityNumber(windowCoordinates, index);
            currentEntityNumber += 1;
        }

        private static void DrawLeadingEntity(Point windowCoordinates, EntityTypes type, int? index = null)
        {
            Color color = EntityCustomizer.GetEntityColor(type);

            int outerRadius = 6;
            SolidBrush outerBrush = new SolidBrush(color);
            drawer.DrawEllipse(new Pen(outerBrush, 2), windowCoordinates.X - outerRadius, windowCoordinates.Y - outerRadius, 2 * outerRadius, 2 * outerRadius);
        }

        private static void DrawEntityNumber(Point windowCoordinates, int? index)
        {
            if (index == null)
            {
                return;
            }

            String entityNumber = index.ToString();
            int deltaX = entityNumber.Count() == 1 ? 3 : 5;
            drawer.DrawString(entityNumber, new Font("Arial", 6), Brushes.Black, windowCoordinates.X - deltaX, windowCoordinates.Y - 4);
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

        private static void InitializeStuff()
        {
            searchArea = ConfigurationManager.GetAreaSize();
            currentEntityNumber = 1;
        }

        private static void InitializeCanvas()
        {
            illustrationCanvasSize = ConfigurationManager.GetIllustrationCanvasSize();
            canvas = new Bitmap(illustrationCanvasSize.Width, illustrationCanvasSize.Height);
        }

        private static void InitializeDrawer()
        {
            if (canvas == null)
            {
                throw new Exception("Canvas do not initialize.");
            }
            drawer = Graphics.FromImage(canvas);
            drawer.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            drawer.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            drawer.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
            drawer.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
            drawer.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
        }
    }
}

using Game.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Game.Renderer
{
    public class TeglaDisplay : FrameworkElement
    {
        ITeglaModel model;
        Size area;
        static Random r;
        public int[] corrects { get; set; } 


        public void SetupSizes(Size area)
        {
            this.area = area;
            this.InvalidateVisual();
        }

        public void SetupModel(ITeglaModel model)
        {
            this.model = model;
            this.model.Changed += (sender, eventargs) => this.InvalidateVisual();

        }

        public Brush EgyesTeglaBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "1.png"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush KettesTeglaBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "2.png"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush HarmasTeglaBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "3.png"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush NegyesTeglaBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "4.png"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush kek
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "bluebrick.png"), UriKind.RelativeOrAbsolute)));
            }
        }


        List<Rect> bricks;

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (area.Width > 0 && area.Height > 0 && model != null)
            {
                drawingContext.DrawRectangle(Brushes.LightCoral, null, new Rect(0, 0, area.Width, area.Height));
                model = new TeglaLogic();
                r = new Random();


                bricks = new List<Rect>();

                Rect also = new Rect(area.Width / 3 - 200, area.Height - 150, 400, 150);
                Rect masodik = new Rect(area.Width / 3 - 200, area.Height - 300, 400, 150);
                Rect harmadik = new Rect(area.Width / 3 - 200, area.Height - 450, 400, 150);
                Rect negyedik = new Rect(area.Width / 3 - 200, area.Height - 600, 400, 150);
                Rect otodik = new Rect(area.Width / 3 - 200, area.Height - 750, 400, 150);
                Rect hatodik = new Rect(area.Width / 3 - 200, area.Height - 900, 400, 150);
                Rect hetedik = new Rect(area.Width / 3 - 200, area.Height - 1050, 400, 150);


                bricks.Add(also);
                bricks.Add(masodik);
                bricks.Add(harmadik);
                bricks.Add(negyedik);
                bricks.Add(otodik);
                bricks.Add(hatodik);
                bricks.Add(hetedik);

                List<Brush> brickBrushes = new List<Brush>();
                brickBrushes.Add(EgyesTeglaBrush);
                brickBrushes.Add(KettesTeglaBrush);
                brickBrushes.Add(HarmasTeglaBrush);
                brickBrushes.Add(EgyesTeglaBrush);
                brickBrushes.Add(KettesTeglaBrush);
                brickBrushes.Add(HarmasTeglaBrush);
                brickBrushes.Add(NegyesTeglaBrush);


                corrects = model.correctAnswer();

                

                for (int i = 0; i < 7; i++)
                {
                    if (corrects[i] == 1)
                    {
                        drawingContext.DrawRectangle(EgyesTeglaBrush, null, bricks[i]);
                    }
                    else if (corrects[i] == 2)
                    {
                        drawingContext.DrawRectangle(KettesTeglaBrush, null, bricks[i]);
                    }
                    else if (corrects[i] == 3)
                    {
                        drawingContext.DrawRectangle(HarmasTeglaBrush, null, bricks[i]);
                    }
                    else if (corrects[i] == 4)
                    {
                        drawingContext.DrawRectangle(NegyesTeglaBrush, null, bricks[i]);
                    }


                }



            }
        }





    }
}

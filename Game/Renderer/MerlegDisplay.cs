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
    public class MerlegDisplay : FrameworkElement
    {
        IMerlegModel model;
        Size area;
        static Random r;
        public int[] corrects { get; set; }


        public void SetupSizes(Size area)
        {
            this.area = area;
            this.InvalidateVisual();
        }

        public void SetupModel(IMerlegModel model)
        {
            this.model = model;
            this.model.Changed += (sender, eventargs) => this.InvalidateVisual();

        }

        public Brush Ant
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "ant.png"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush Cat
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "cat.png"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush Piglet
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "piglet.png"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush Puppy
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "puppy.png"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush Level1_ant
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "Level1_ant.jpg"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush Level2_puppy
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "Level2_puppy.jpg"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush Level3_puppy
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "Level3_puppy.jpg"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush Level4_pig
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "Level4_pig.jpg"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush Level5_puppy
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "Level5_puppy.jpg"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush Level6_pig
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "Level6_pig.jpg"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush Level7_cat
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "Level7_cat.jpg"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush Level8_dog
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "Level8_dog.jpg"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush Level9_pig
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "Level9_pig.jpg"), UriKind.RelativeOrAbsolute)));
            }
        }

        List<Brush> Mapbrushes;

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (area.Width > 0 && area.Height > 0 && model != null)
            {
                //drawingContext.DrawRectangle(Level5_puppy, null, new Rect(0, 0, area.Width, area.Height));
                model = new MerlegLogic();

                Mapbrushes = new List<Brush>();


                Mapbrushes.Add(Level1_ant);
                Mapbrushes.Add(Level2_puppy);
                Mapbrushes.Add(Level3_puppy);
                Mapbrushes.Add(Level4_pig);
                Mapbrushes.Add(Level5_puppy);
                Mapbrushes.Add(Level6_pig);
                Mapbrushes.Add(Level7_cat);
                Mapbrushes.Add(Level8_dog);
                Mapbrushes.Add(Level9_pig);


                corrects = model.correctAnswer();



                for (int i = 0; i < 9; i++)
                {
                    if (corrects[i] == 1)
                    {
                        drawingContext.DrawRectangle(Level1_ant, null, new Rect(0, 0, area.Width, area.Height));
                    }
                    else if (corrects[i] == 2)
                    {
                        drawingContext.DrawRectangle(Level2_puppy, null, new Rect(0, 0, area.Width, area.Height));
                    }
                    else if (corrects[i] == 3)
                    {
                        drawingContext.DrawRectangle(Level3_puppy, null, new Rect(0, 0, area.Width, area.Height));

                    }
                    else if (corrects[i] == 4)
                    {
                        drawingContext.DrawRectangle(Level4_pig, null, new Rect(0, 0, area.Width, area.Height));

                    }
                    else if (corrects[i] == 5)
                    {
                        drawingContext.DrawRectangle(Level5_puppy, null, new Rect(0, 0, area.Width, area.Height));

                    }
                    else if (corrects[i] == 6)
                    {
                        drawingContext.DrawRectangle(Level6_pig, null, new Rect(0, 0, area.Width, area.Height));

                    }
                    else if (corrects[i] == 7)
                    {
                        drawingContext.DrawRectangle(Level7_cat, null, new Rect(0, 0, area.Width, area.Height));

                    }
                    else if (corrects[i] == 8)
                    {
                        drawingContext.DrawRectangle(Level8_dog, null, new Rect(0, 0, area.Width, area.Height));

                    }
                    else if (corrects[i] == 9)
                    {
                        drawingContext.DrawRectangle(Level9_pig, null, new Rect(0, 0, area.Width, area.Height));

                    }
                }

                drawingContext.DrawRectangle(Ant, null, new Rect(area.Width / 5 - 100, area.Height / 8 * 6, 200, 150));
                drawingContext.DrawRectangle(Cat, null, new Rect((area.Width / 5) * 2 - 100, area.Height / 8 * 6, 200, 150));
                drawingContext.DrawRectangle(Piglet, null, new Rect(area.Width / 5 * 3 - 100, area.Height / 8 * 6, 200, 150));
                drawingContext.DrawRectangle(Puppy, null, new Rect(area.Width / 5 * 4 - 100, area.Height / 8 * 6, 200, 150));

            }
        }
    }
}

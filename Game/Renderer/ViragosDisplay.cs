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
    public class ViragosDisplay : FrameworkElement
    {
        IGameModel model;
        static Random r;
        Size area;
        public Rect correctRect { get; set; }
        Brush correctBrush;
        public int rnd { get; set; }

        public void SetupSizes(Size area)
        {
            this.area = area;
            this.InvalidateVisual();
        }

        public void SetupModel(IGameModel model)
        {
            this.model = model;
            this.model.Changed += (sender, eventargs) => this.InvalidateVisual();

        }

        public Brush HatterBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "hatter2.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush KekBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "kek.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush RoseBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "rose.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush KoszoruBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "koszoru.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush LevelBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "level.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush PiriBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "piri_viri.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush PitypangBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "pitypang.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush TuzviragBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "tuzvirag.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush LotuszBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "lotusz.png"), UriKind.RelativeOrAbsolute)));
            }
        }




        List<Rect> flowers;

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (area.Width > 0 && area.Height > 0 && model != null)
            {
                drawingContext.DrawRectangle(HatterBrush, null, new Rect(0, 0, area.Width, area.Height));
                model = new ViragLogic();



                #region also viragok
                r = new Random();
                flowers = new List<Rect>();


                Rect elso = new Rect(area.Width / 5, area.Height - 200, 100, 100);
                Rect masodik = new Rect((area.Width / 5) * 2, area.Height - 200, 100, 100);
                Rect harmadik = new Rect((area.Width / 5) * 3, area.Height - 200, 100, 100);
                Rect negyedik = new Rect((area.Width / 5) * 4, area.Height - 200, 100, 100);

                List<Brush> FlowerBrushes = new List<Brush>();
                FlowerBrushes.Add(TuzviragBrush);
                FlowerBrushes.Add(KekBrush);
                FlowerBrushes.Add(KoszoruBrush);
                FlowerBrushes.Add(LevelBrush);
                FlowerBrushes.Add(LotuszBrush);
                FlowerBrushes.Add(PiriBrush);
                FlowerBrushes.Add(PitypangBrush);
                FlowerBrushes.Add(RoseBrush);

                flowers.Add(elso);
                flowers.Add(masodik);
                flowers.Add(harmadik);
                flowers.Add(negyedik);


                int[] array = new int[8];
                for (int i = 0; i < 8; i++)
                {
                    array[i] = i;
                }

                var shuffled = array.OrderBy(a => r.Next()).ToList();

                List<Brush> usedBrushes = new List<Brush>();
                for (int i = 0; i < 4; i++)
                {
                    drawingContext.DrawRectangle(FlowerBrushes[shuffled[i]], null, flowers[i]);
                    usedBrushes.Add(FlowerBrushes[shuffled[i]]);

                }


                #endregion

                #region felso viragok


                List<Rect> flowers2 = new List<Rect>();
                Rect tuzvirag2 = new Rect(area.Width / 5, area.Height / 8, 100, 100);
                Rect kek2 = new Rect((area.Width / 5) * 2, area.Height / 8, 100, 100);
                Rect koszoru2 = new Rect((area.Width / 5) * 3, area.Height / 8, 100, 100);
                Rect level2 = new Rect((area.Width / 5) * 4, area.Height / 8, 100, 100);


                flowers2.Add(tuzvirag2);
                flowers2.Add(kek2);
                flowers2.Add(koszoru2);
                flowers2.Add(level2);


                rnd = model.CorrectAnswer();

                for (int i = 4; i < 8; i++)
                {
                    if ((i - 4) != rnd)
                    {
                        drawingContext.DrawRectangle(FlowerBrushes[shuffled[i]], null, flowers2[i - 4]);
                    }
                }

                correctRect = flowers2[rnd];
                correctBrush = usedBrushes[r.Next(0, 4)];
                drawingContext.DrawRectangle(correctBrush, null, correctRect);

                #endregion
            }

        }



    }





}

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

        public Brush KekTeglaBrush
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

                bricks = new List<Rect>();

                Rect also = new Rect(area.Width / 3 - 200, area.Height - 200, 400, 200);
                Rect masodik = new Rect(area.Width / 3 - 200, area.Height - 400, 400, 200);
                Rect harmadik = new Rect(area.Width / 3 - 200, area.Height - 600, 400, 200);
                Rect negyedik = new Rect(area.Width / 3 - 200, area.Height - 800, 400, 200);
                Rect otodik = new Rect(area.Width / 3 - 200, area.Height - 1000, 400, 200);

                bricks.Add(also);
                bricks.Add(masodik);
                bricks.Add(harmadik);
                bricks.Add(negyedik);
                bricks.Add(otodik);

                for (int i = 0; i < bricks.Count; i++)
                {
                    drawingContext.DrawRectangle(KekTeglaBrush, null, bricks[i]);
                }


            }
        }





    }
}
